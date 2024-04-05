using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private static Semaphore semaphore = new Semaphore(2, 2); // Allow 2 concurrent downloads
        private static readonly string logFilePath = "C:\\Users\\User\\Desktop\\logs.txt"; // Path to the log file
        private static List<DownloadItem> downloadItems = new List<DownloadItem>();
        public static int i = 1;

        public List<DownloadItem> GetDownloadQueue()
        {
            return downloadItems;
        }

        public List<DownloadItem> AddNewDownloadItem(DownloadItem item)
        {
            downloadItems.Add(item);
            return downloadItems;
        }

        public List<DownloadItem> DownloadFile(DownloadItem item)
        {
            try
            {
                semaphore.WaitOne(); // Acquire semaphore

                //Log($"Thread {i} acquired semaphore."); // Log semaphore acquisition

                lock (this) // Ensure atomic check and download operation
                {
                    DownloadItem downloadItem = downloadItems.FirstOrDefault(i => i.Id == item.Id);

                    string fileName = Path.GetFileName(item.Url);
                    string filePath = Path.Combine(item.TargetPath, GetUniqueFileName(item.TargetPath, fileName));

                    if (!File.Exists(filePath))
                    {
                        WebClient webClient = new WebClient();
                        byte[] fileBytes = webClient.DownloadData(item.Url);
                        File.WriteAllBytes(filePath, fileBytes);
                        downloadItem.Progress = 100;
                        
                        Console.WriteLine($"File downloaded and saved: {filePath}"); // Log file download
                    };
                    i++;

                    return downloadItems;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                //Log($"Error downloading file: {ex.Message}"); // Log error
                throw new FaultException($"Error downloading file: {ex.Message}");
            }
            finally
            {
                semaphore.Release(); // Release semaphore
                //Log($"Thread {i} released semaphore."); // Log semaphore release
            }
        }

        private string GetUniqueFileName(string folderPath, string fileName)
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

        private static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now.ToString()}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
