using TestService;

namespace CP.CW1._0012162
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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

        private void button3_Click(object sender, EventArgs e)
        {
            //DownloadFile downloadFile = new DownloadFile
            //{
            //    id = 1,
            //    name = tbxTargetPath.Text,
            //    url = tbxUrl.Text,
            //    priority = (Priority)Enum.Parse(typeof(Priority), cbxPriority.SelectedItem.ToString()), // Get priority from combo box
            //    dateTime = DateTime.Now, // Set the date/time as needed
            //};

            //// Call the GetDownloadFileDataAsync method on the client proxy
            //client.GetDownloadFileDataAsync(downloadFile);

            Service1Client service1 = new Service1Client();

            try
            {
                // Call the DownloadFile method
                string fileUrl = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf"; // Replace with your file URL
                string savePath = @"C:\Users\User\Desktop\"; // Replace with the desired save path
                service1.DownloadFileAsync(fileUrl, savePath);
                MessageBox.Show("All good");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excption: " + ex);
            }
            finally
            {
                // Close the client
                service1.Close();
            }
        }
    }
}