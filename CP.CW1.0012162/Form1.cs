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

        private DownloadItem FindFileGoingToBeDownloaded()
        {
            try
            {
                //for (int i = 0; i < items.Length; i++)
                //{
                //    return items[i];
                //}
                return items[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding file: {ex.Message}");
            }
            return null;
        }

        private async void DownloadFile(DownloadItem item)
        {
            try
            {
                DownloadItem[] items = serviceClient.DownloadFile(item);

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

        private void btnDownload1_Click(object sender, EventArgs e)
        {
            btnGetNext1.Visible = false;
            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

            progressBar1.Value = 100;
            btnGetNext1.Visible = true;
        }

        private void btnDownload2_Click(object sender, EventArgs e)
        {
            btnGetNext2.Visible = false;
            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

            progressBar2.Value = 100;
            btnGetNext2.Visible = true;
        }

        private void btnDownload3_Click(object sender, EventArgs e)
        {
            btnGetNext3.Visible = false;
            DownloadItem item = FindFileGoingToBeDownloaded();
            DownloadFile(item);

            progressBar3.Value = 100;
            btnGetNext3.Visible = true;
        }

        private void btnGetNext1_Click(object sender, EventArgs e)
        {
            btnGetNext1.Visible = false;
            progressBar1.Value = 0;

            // need to update the label
        }

        private void btnGetNext2_Click(object sender, EventArgs e)
        {
            btnGetNext2.Visible = false;
            progressBar2.Value = 0;

            // need to update the label
        }

        private void btnGetNext3_Click(object sender, EventArgs e)
        {
            btnGetNext3.Visible = false;
            progressBar3.Value = 0;

            // need to update the label
        }
    }
}