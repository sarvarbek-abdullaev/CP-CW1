namespace CP.CW1._0012162
{
    public partial class Form1 : Form
    {
        private readonly ServiceReference1.Service1Client serviceClient;


        public Form1()
        {
            InitializeComponent();
            serviceClient = new ServiceReference1.Service1Client();

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
            try
            {
                if (string.IsNullOrEmpty(tbxTargetPath.Text))
                {
                    MessageBox.Show("Choose the folder for downloadable file");
                } 
                else if(string.IsNullOrEmpty(tbxUrl.Text))
                {
                    MessageBox.Show("Write the file Url to download");
                } 
                else
                {
                    serviceClient.DownloadFile(tbxUrl.Text, Properties.Settings.Default.Path);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
        }
    }
}