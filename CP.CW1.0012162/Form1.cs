using Microsoft.VisualBasic;
using ServiceReference1;
namespace CP.CW1._0012162
{
    public partial class Form1 : Form
    {
        private readonly Service1Client serviceClient;
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
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding file: {ex.Message}");
            }
        }

        private void btnDownload1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            btnDownload1.Text = "Download";
            btnCancel1.Enabled = true;
            btnGetNext1.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

            progressBar1.Value = 100;
            btnCancel1.Enabled = false;
            btnDownload1.Text = "Download again";
            btnGetNext1.Visible = true;
        }

        private void btnDownload2_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            btnDownload2.Text = "Download";
            btnCancel2.Enabled = true;
            btnGetNext2.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

            progressBar2.Value = 100;
            btnCancel2.Enabled = false;
            btnDownload2.Text = "Download again";
            btnGetNext2.Visible = true;
        }

        private void btnDownload3_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 0;
            btnDownload3.Text = "Download";
            btnCancel3.Enabled = true;
            btnGetNext3.Visible = false;

            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

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
        }

        private void btnGetNext2_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            btnDownload2.Text = "Download";
        }

        private void btnGetNext3_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 0;
            btnDownload3.Text = "Download";
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

        private void DownloadFile(DownloadItem item)
        {
            try
            {
                items = serviceClient.DownloadFile(item);

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
    }
}