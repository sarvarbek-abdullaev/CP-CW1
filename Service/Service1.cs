using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class Service1 : IService1
    {
        private static SemaphoreSlim semaphore = new SemaphoreSlim(3, 3);
        private static List<DTask> downloadQueue = new List<DTask>();
        private static List<DTask> downloadedList = new List<DTask>();

        string IService1.EnqueueDownload(string url, string targetPath, DTaskPriority priority)
        {
            var downloadTask = new DTask(url, targetPath, priority);
            downloadQueue.Add(downloadTask);

            //StartDownload(downloadTask);
            return downloadTask.TaskId;
        }

        public void StartDownloadOne(DTask task)
        {
            DTask task1 = downloadQueue.Find(_task => _task.TaskId == task.TaskId);
            StartDownload(task1);
        }

        public List<DTask> GetDownloadQueue()
        {
            return downloadQueue;
        }
        public List<DTask> GetDownloadedList()
        {
            return downloadedList;
        }

        // Pause download functionality
        public bool PauseDownload(string taskId)
        {
            var task = downloadQueue.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null && task.Status == DTaskStatus.Downloading)
            {
                task.Status = DTaskStatus.Paused;
                task.CancellationTokenSource.Cancel();
                return true;
            }
            return false;
        }

        public bool ResumeDownload(string taskId)
        {
            var task = downloadQueue.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null && task.Status == DTaskStatus.Paused)
            {
                task.Status = DTaskStatus.Downloading;
                task.CancellationTokenSource = new CancellationTokenSource();
                StartDownload(task, task.BytesDownloaded);
                return true;
            }
            return false;
        }

        bool IService1.CancelDownload(string taskId)
        {
            var task = downloadQueue.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Status = DTaskStatus.Cancelled;
                task.CancellationTokenSource.Cancel(); // Signal the token to cancel the download
                downloadQueue.Remove(task);
                return true;
            }
            return false;
        }

        static async void StartDownload(DTask task, long offset = 0)
        {
            // Only create a new CancellationTokenSource if one does not exist or has been cancelled
            if (task.CancellationTokenSource == null || task.CancellationTokenSource.IsCancellationRequested)
            {
                task.CancellationTokenSource = new CancellationTokenSource();
            }

            var token = task.CancellationTokenSource.Token;

            Debug.WriteLine("Service: " + task.Url + " " + task.TargetPath);

            int bufferSize = 4096; // Initial buffer size
            int maxBufferSize = 1 * 1024 * 1024; // Maximum buffer size

            if (task.TotalBytes == 0)
            {
                try
                {
                    // Get the total file size
                    long totalFileSize = await GetFileSizeAsync(task.Url);
                    task.TotalBytes = totalFileSize;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Could not determine total file size: {ex.Message}");
                    // If the file size could not be determined, handle accordingly
                    task.TotalBytes = 0; // Consider handling this case appropriately
                }
            }

            // Set the filename once and reuse for subsequent operations
            if (string.IsNullOrEmpty(task.FileName) || !File.Exists(Path.Combine(task.TargetPath, task.FileName)))
            {
                task.FileName = GetUniqueFileName(task.TargetPath, Path.GetFileName(task.Url));
            }

            string filePath = Path.Combine(task.TargetPath, task.FileName);

            await semaphore.WaitAsync();

            task.Status = DTaskStatus.Downloading;

            task.DownloadTask = Task.Run(async () =>
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromMinutes(10); // Set a longer timeout to handle slow connections

                        var request = new HttpRequestMessage(HttpMethod.Get, task.Url);
                        request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(offset, null); // Set the range for partial downloads

                        using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token))
                        {
                            response.EnsureSuccessStatusCode();

                            using (var responseStream = await response.Content.ReadAsStreamAsync())
                            {
                                FileMode fileMode = offset > 0 ? FileMode.Append : FileMode.CreateNew;

                                using (var fileStream = new FileStream(filePath, fileMode))
                                {
                                    byte[] buffer = new byte[bufferSize];
                                    int bytesRead;
                                    // stopwatch to calculate time left
                                    Stopwatch stopwatch = Stopwatch.StartNew();

                                    // variables to store previous time and bytes downloaded
                                    double previousTimeSeconds = 0;
                                    long previousBytesDownloaded = 0;

                                    while ((bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                                    {
                                        await fileStream.WriteAsync(buffer, 0, bytesRead, token);
                                        task.BytesDownloaded += bytesRead;

                                        // Update the download progress
                                        if (task.TotalBytes > 0)
                                        {
                                            task.Progress = (task.BytesDownloaded * 100.0) / task.TotalBytes;
                                        }

                                        // Calculate elapsed time since the last calculation
                                        TimeSpan elapsedTime = stopwatch.Elapsed;
                                        double currentTimeSeconds = elapsedTime.TotalSeconds;

                                        // Calculate time elapsed since the last calculation
                                        double timeElapsedSeconds = currentTimeSeconds - previousTimeSeconds;

                                        // Update previous time and bytes downloaded for the next calculation
                                        previousTimeSeconds = currentTimeSeconds;
                                        long bytesDownloadedThisInterval = task.BytesDownloaded - previousBytesDownloaded;
                                        previousBytesDownloaded = task.BytesDownloaded;

                                        // Calculate download speed for the last interval
                                        double downloadSpeed = bytesDownloadedThisInterval / timeElapsedSeconds;

                                        // Calculate remaining bytes
                                        long remainingBytes = task.TotalBytes - task.BytesDownloaded;

                                        // Calculate time left in seconds, ensuring downloadSpeed is not zero
                                        double timeLeftInSeconds = (downloadSpeed != 0) ? remainingBytes / downloadSpeed : 0;

                                        timeLeftInSeconds = timeLeftInSeconds * 100;

                                        // Convert time left to a more human-readable format
                                        string timeLeftText = "...";
                                        if (timeLeftInSeconds < 60)
                                        {
                                            timeLeftText = $"{timeLeftInSeconds:F1} seconds";
                                        }
                                        else
                                        {
                                            double minutes = Math.Floor(timeLeftInSeconds / 60);
                                            double seconds = timeLeftInSeconds % 60;
                                            timeLeftText = $"{minutes} minutes {seconds:F1} seconds";
                                        }

                                        task.timeLeftText = timeLeftText;

                                        // Dynamically adjust buffer size based on download progress, up to a maximum
                                        bufferSize = Math.Min(bufferSize * 2, maxBufferSize);

                                        if (token.IsCancellationRequested)
                                        {
                                            task.Status = DTaskStatus.Paused;
                                            break; // Handle pause or cancel
                                        }
                                    }

                                    if (!token.IsCancellationRequested && task.Status != DTaskStatus.Cancelled)
                                    {
                                        task.Status = DTaskStatus.Finished;
                                        Debug.WriteLine($"File downloaded and saved: {filePath}");
                                    }

                                    Debug.WriteLine($"Downloaded {task.Status} bytes");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is TaskCanceledException || ex is OperationCanceledException)
                    {
                        task.Status = DTaskStatus.Paused;
                        Debug.WriteLine("Download paused");
                    }
                    else
                    {
                        task.Status = DTaskStatus.Error;
                        Debug.WriteLine($"Error downloading file: {ex.Message}");
                    }
                }
                finally
                {
                    semaphore.Release();

                    if (task.Status == DTaskStatus.Finished || task.Status == DTaskStatus.Error)
                    {
                        downloadQueue.Remove(task);
                        downloadedList.Add(task);
                    }
                }
            }, token);
        }

        // A method to get the file size, which might involve sending an HTTP HEAD request
        private static async Task<long> GetFileSizeAsync(string url)
        {
            using (var client = new HttpClient())
            {
                // Set the HTTP version to 1.1 or 2.0 as required
                client.DefaultRequestHeaders.ConnectionClose = false; // Use persistent connections

                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Head, url);

                    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode(); // This will throw if the status code is not a success code.

                        if (response.Content.Headers.ContentLength.HasValue)
                        {
                            return response.Content.Headers.ContentLength.Value;
                        }
                        else
                        {
                            throw new InvalidOperationException("Could not determine file size.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HttpRequestException occurred: {ex.Message}");

                    // Fallback to a GET request if HEAD is not supported
                    try
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, url);
                        using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                        {
                            response.EnsureSuccessStatusCode();

                            if (response.Content.Headers.ContentLength.HasValue)
                            {
                                return response.Content.Headers.ContentLength.Value;
                            }
                            else
                            {
                                throw new InvalidOperationException("Could not determine file size with GET request.");
                            }
                        }
                    }
                    catch (Exception innerEx)
                    {
                        Console.WriteLine($"Error occurred during GET request: {innerEx.Message}");
                        throw; // Rethrow or handle as needed
                    }
                }
            }
        }



        private static string GetUniqueFileName(string folderPath, string fileName)
        {
            int count = 0;
            string uniqueFileName = fileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);

            while (File.Exists(filePath))
            {
                count++;
                string extension = Path.GetExtension(fileName);
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                uniqueFileName = $"{nameWithoutExtension} ({count}){extension}";
                filePath = Path.Combine(folderPath, uniqueFileName);
            }

            return uniqueFileName;
        }
    }
}
