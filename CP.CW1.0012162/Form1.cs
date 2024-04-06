using Microsoft.VisualBasic;
using ServiceReference1;
namespace CP.CW1._0012162
{
    public partial class Form1 : Form
    {
        private readonly Service1Client serviceClient;
        private bool autoDownload = false;
        DownloadItem[] items;

        public Form1()
        {
            InitializeComponent();
            serviceClient = new Service1Client();
            cbxPriority.DataSource = Enum.GetValues(typeof(DownloadItemPriority));

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Path))
            {
                tbxTargetPath.Text = Properties.Settings.Default.Path;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbxTargetPath.Text = fbd.SelectedPath;

                    Properties.Settings.Default.Path = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxTargetPath.Text))
                {
                    MessageBox.Show("Choose the folder for downloadable file");
                }
                else if (string.IsNullOrEmpty(tbxUrl.Text))
                {
                    MessageBox.Show("Write the file Url to download");
                }
                else
                {
                    DownloadItem item = new DownloadItem();
                    item.Id = items != null ? items.Length : 0;
                    item.Url = tbxUrl.Text;
                    item.TargetPath = tbxTargetPath.Text;
                    item.Progress = 0;

                    if (Enum.TryParse(cbxPriority.Text, out DownloadItemPriority priority))
                    {
                        item.Priority = priority;
                    }
                    else
                    {
                        item.Priority = DownloadItemPriority.Normal;
                    }

                    // Assuming serviceClient.AddNewDownloadItemAsync(item) returns a list of DownloadItem objects
                    items = await serviceClient.AddNewDownloadItemAsync(item);

                    // Clear the existing items in the ListView
                    listView.Items.Clear();

                    // Add each item from the 'items' list to the ListView
                    for (int i = 0; i < items.Length; i++)
                    {
                        // Create a new ListViewItem and add sub-items
                        ListViewItem listViewItem = new ListViewItem(new[] {
                            (i+1).ToString(),
                            items[i].Url,
                            items[i].TargetPath,
                            items[i].Priority.ToString(),
                            items[i].Progress.ToString() + "%",
                        });

                        // Add the ListViewItem to the ListView
                        listView.Items.Add(listViewItem);
                    }

                    if(autoDownload)
                    {
                        await DownloadFile(item);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding file: {ex.Message}");
            }
        }

        private async void btnDownload1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            btnDownload1.Text = "Download";
            btnCancel1.Enabled = true;
            btnGetNext1.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            if (item == null)
            {
                return;
            }

            await DownloadFile(item);

            progressBar1.Value = 100;
            btnCancel1.Enabled = false;
            btnDownload1.Text = "Download again";
            btnGetNext1.Visible = true;
        }

        private async void btnDownload2_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            btnDownload2.Text = "Download";
            btnCancel2.Enabled = true;
            btnGetNext2.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            if (item == null)
            {
                return;
            }

            await DownloadFile(item);

            progressBar2.Value = 100;
            btnCancel2.Enabled = false;
            btnDownload2.Text = "Download again";
            btnGetNext2.Visible = true;
        }

        private async void btnDownload3_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 0;
            btnDownload3.Text = "Download";
            btnCancel3.Enabled = true;
            btnGetNext3.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            if (item == null)
            {
                return;
            }

            await DownloadFile(item);

            progressBar3.Value = 100;
            btnCancel3.Enabled = false;
            btnDownload3.Text = "Download again";
            btnGetNext3.Visible = true;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            // Cancel the webClient;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            // Cancel the webClient;
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            // Cancel the webClient;
        }

        private void btnGetNext1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            btnDownload1.Text = "Download";
            btnGetNext1.Visible = false;
        }

        private void btnGetNext2_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            btnDownload2.Text = "Download";
            btnGetNext2.Visible = false;
        }

        private void btnGetNext3_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 0;
            btnDownload3.Text = "Download";
            btnGetNext3.Visible = false;
        }

        private DownloadItem FindFileGoingToBeDownloaded()
        {
            try
            {
                // Filter out items that have already been downloaded (progress is 100)
                var remainingItems = items.Where(item => item.Progress != 100).ToList();

                // Sort the remaining items based on Priority
                var sortedItems = remainingItems.OrderBy(item =>
                {
                    if (item.Priority == DownloadItemPriority.High)
                        return 0;
                    else if (item.Priority == DownloadItemPriority.Normal)
                        return 1;
                    else // Low
                        return 2;
                }).ToList();


                if (sortedItems.Count > 0)
                {
                    // Return the item at index 0 (which has the highest priority)
                    return sortedItems[0];
                }
                else
                {
                    MessageBox.Show("No files to download.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding file: {ex.Message}");
            }
            return null;
        }

        private async Task DownloadFile(DownloadItem item)
        {
            try
            {
                items = await serviceClient.DownloadFileAsync(item);

                listView.Items.Clear();
                // Add each item from the 'items' list to the ListView
                for (int i = 0; i < items.Length; i++)
                {
                    // Create a new ListViewItem and add sub-items
                    ListViewItem listViewItem = new ListViewItem(new[] {
                            (i+1).ToString(),
                            items[i].Url,
                            items[i].TargetPath,
                            items[i].Priority.ToString(),
                            items[i].Progress.ToString() + "%",
                    });

                    // Add the ListViewItem to the ListView
                    listView.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private async Task DownloadAllFiles()
        {
            if (items.Length < 1)
            {
                MessageBox.Show("No items found to download, add some");
                return;
            }

            foreach (DownloadItem item in items)
            {
                if (item.Progress != 100) // Check if file is not already downloaded
                {
                    await DownloadFile(item);
                }
            }
        }

        private async void chkDownloadAll_CheckedChanged(object sender, EventArgs e)
        {
            autoDownload = chkDownloadAll.Checked;
            if (autoDownload)
            {
                // Hide individual download buttons
                btnDownload1.Visible = false;
                btnDownload2.Visible = false;
                btnDownload3.Visible = false;

                await DownloadAllFiles();
            }
            else
            {
                // Show individual download buttons
                btnDownload1.Visible = true;
                btnDownload2.Visible = true;
                btnDownload3.Visible = true;
            }
        }
    }
}