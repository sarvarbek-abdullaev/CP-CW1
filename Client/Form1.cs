using System.Diagnostics;
using ServiceReference1;

namespace Client
{
    public partial class Form1 : Form
    {
        private DTask task = new DTask();
        Service1Client client = new Service1Client();
        private List<DTask> taskList = new List<DTask>();
        private List<DTask> downloadedList = new List<DTask>();
        DTask selectedTask = new DTask();

        public Form1()
        {
            InitializeComponent();
            cbxPriority.DataSource = Enum.GetValues(typeof(DTaskPriority));
            cbxPriority.SelectedIndex = 1;
        }

        private async void addToQueueButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Client: " + task.Url + " " + task.TargetPath);

            if (string.IsNullOrEmpty(task.Url))
            {
                MessageBox.Show("URL cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(task.TargetPath))
            {
                MessageBox.Show("Target path cannot be empty.");
                return;
            }

            await client.EnqueueDownloadAsync(new EnqueueDownloadRequest(task.Url, task.TargetPath, task.Priority));

            task = new DTask
            {
                TargetPath = tbxTargetPath.Text,
                Priority = DTaskPriority.Normal
            };
            tbxUrl.Text = "";
            cbxPriority.SelectedIndex = 1;
        }

        private void downloadUrlInput_TextChanged(object sender, EventArgs e)
        {
            task.Url = ((TextBox)sender).Text;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tbxTargetPath.ForeColor = Color.Black;
                tbxTargetPath.Text = fbd.SelectedPath;
                task.TargetPath = fbd.SelectedPath;
            }
        }

        private void targetPathInput_Leave(object sender, EventArgs e)
        {
            var path = ((TextBox)sender).Text;
            var exists = Directory.Exists(path);
            Debug.WriteLine($"{path} ${exists}");
            if (exists)
            {
                tbxTargetPath.ForeColor = Color.Black;
                tbxTargetPath.Text = path;
            }
            else
            {
                tbxTargetPath.ForeColor = Color.Red;
            }
        }

        private void targetPathInput_TextChanged(object sender, EventArgs e)
        {
            task.TargetPath = ((TextBox)sender).Text;
        }

        private async void UpdateQueueDisplay()
        {
            try
            {
                string selectedTaskId = null;
                if (listViewDownloadQueue.SelectedItems.Count > 0)
                {
                    selectedTaskId = listViewDownloadQueue.SelectedItems[0].Text;
                }

                var queue = await client.GetDownloadQueueAsync(new GetDownloadQueueRequest());
                taskList = queue.GetDownloadQueueResult.ToList();

                if (!taskList.Contains(selectedTask) && taskList.Count <= 0 && downloadedList.Count > 0)
                {
                    pbFile1.Value = 100;
                    lblFileTime1.Text = "Downloaded";
                }

                listViewDownloadQueue.Items.Clear();

                int number = 0;
                foreach (var file in queue.GetDownloadQueueResult)
                {
                    var item = new ListViewItem(
                        [
                           (number+1).ToString(),
                            file.Url,
                            file.TargetPath,
                            file.Progress.ToString("0.00") + "%",
                            file.Priority.ToString(),
                            file.TaskId.ToString(),
                            file.timeLeftText
                        ]
                    );
                    listViewDownloadQueue.Items.Add(item);
                    number++;
                }

                if (!string.IsNullOrEmpty(selectedTaskId))
                {
                    foreach (ListViewItem item in listViewDownloadQueue.Items)
                    {
                        if (item.Text == selectedTaskId)
                        {
                            item.Selected = true;
                            listViewDownloadQueue.EnsureVisible(item.Index); // Ensure the selected item is visible
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving download queue: {ex.Message}");
            }
        }

        private async void UpdateDownloadedFilesDisplay()
        {
            try
            {
                var files = await client.GetDownloadedListAsync(new GetDownloadedListRequest());
                listViewDownloadedFiles.Items.Clear();

                int number = 0;

                downloadedList = files.GetDownloadedListResult.ToList();

                foreach (var file in downloadedList)
                {
                    var item = new ListViewItem(
                        [
                           (number+1).ToString(),
                            file.Url,
                            file.TargetPath,
                            file.Progress.ToString("0.00") + "%",
                            file.Priority.ToString(),
                            file.TaskId.ToString(),
                            file.timeLeftText
                        ]
                    );
                    listViewDownloadedFiles.Items.Add(item);
                    number++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving download queue: {ex.Message}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDownloadedFilesDisplay();
            UpdateQueueDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private async void buttonCancel_Click(object sender, EventArgs e)
        {
            if (listViewDownloadQueue.SelectedItems.Count > 0)
            {
                string taskId = listViewDownloadQueue.SelectedItems[0].SubItems[5].Text;
                var result = await client.CancelDownloadAsync(new CancelDownloadRequest(taskId));
                if (result.CancelDownloadResult)
                {
                    MessageBox.Show("Download cancelled.");
                    UpdateQueueDisplay(); // Refresh the ListView to remove the cancelled task
                }
                else
                {
                    MessageBox.Show("Failed to cancel download.");
                }
            }
        }

        private async void buttonResume_Click(object sender, EventArgs e)
        {
            if (listViewDownloadQueue.SelectedItems.Count > 0)
            {
                string taskId = listViewDownloadQueue.SelectedItems[0].SubItems[5].Text;
                var result = await client.ResumeDownloadAsync(new ResumeDownloadRequest(taskId));

                if (result.ResumeDownloadResult)
                {
                    MessageBox.Show("Download resumed.");
                }
                else
                {
                    MessageBox.Show("Failed to resume download.");
                }
            }
        }

        private async void buttonPause_Click(object sender, EventArgs e)
        {
            if (listViewDownloadQueue.SelectedItems.Count > 0)
            {
                string taskId = listViewDownloadQueue.SelectedItems[0].SubItems[5].Text;
                var result = await client.PauseDownloadAsync(new PauseDownloadRequest(taskId));
                if (result.PauseDownloadResult)
                {
                    MessageBox.Show("Download paused.");
                }
                else
                {
                    MessageBox.Show("Failed to pause download.");
                }
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (listViewDownloadQueue.SelectedItems.Count > 0)
            {
                if (listViewDownloadQueue.SelectedItems.Count > 0)
                {
                    var selectedItem = listViewDownloadQueue.SelectedItems[0];

                    // Check if the selected item has at least 6 sub-items
                    if (selectedItem.SubItems.Count >= 6)
                    {
                        string taskId = selectedItem.SubItems[5].Text;

                        // Find the corresponding task in the global queue
                        var foundTask = taskList.FirstOrDefault(task => task.TaskId.ToString() == taskId);

                        await client.StartDownloadOneAsync(new StartDownloadOneRequest(foundTask));
                    }
                }
            }
        }

        private void listViewDownloadQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDownloadQueue.SelectedItems.Count > 0)
            {
                var selectedItem = listViewDownloadQueue.SelectedItems[0];

                // Check if the selected item has at least 6 sub-items
                if (selectedItem.SubItems.Count >= 6)
                {
                    string taskId = selectedItem.SubItems[5].Text;

                    // Find the corresponding task in the global queue
                    var foundTask = taskList.FirstOrDefault(task => task.TaskId.ToString() == taskId);


                    if (foundTask != null)
                    {
                        selectedTask = foundTask;

                        int value = (int)selectedTask.Progress + 10;
                        if (value > 100)
                        {
                            value = 100;
                        }
                        pbFile1.Value = value;
                        lblFile1.Text = selectedTask.FileName; // Placeholder text, replace with appropriate value
                        lblFileTime1.Text = selectedTask.timeLeftText;
                    }
                }
            }
        }
    }
}
