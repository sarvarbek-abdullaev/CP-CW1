namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbxUrl = new TextBox();
            tbxTargetPath = new TextBox();
            btnBrowse = new Button();
            cbxPriority = new ComboBox();
            btnAddToQueue = new Button();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            listViewDownloadQueue = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            identifier = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btnPause = new Button();
            btnResume = new Button();
            btnCancel = new Button();
            listViewDownloadedFiles = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            lblFile1 = new Label();
            lblFileTime1 = new Label();
            pbFile1 = new ProgressBar();
            btnStart = new Button();
            btnStartAll = new Button();
            btnPauseAll = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(32, 56);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 36);
            label1.TabIndex = 0;
            label1.Text = "Enter Download URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 114);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 0;
            label2.Text = "Enter Target Path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 172);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 0;
            label3.Text = "Enter Priority";
            // 
            // tbxUrl
            // 
            tbxUrl.Location = new Point(240, 57);
            tbxUrl.Margin = new Padding(5, 6, 5, 6);
            tbxUrl.Name = "tbxUrl";
            tbxUrl.Size = new Size(686, 35);
            tbxUrl.TabIndex = 1;
            tbxUrl.TextChanged += downloadUrlInput_TextChanged;
            // 
            // tbxTargetPath
            // 
            tbxTargetPath.Location = new Point(240, 114);
            tbxTargetPath.Margin = new Padding(5, 6, 5, 6);
            tbxTargetPath.Name = "tbxTargetPath";
            tbxTargetPath.Size = new Size(547, 35);
            tbxTargetPath.TabIndex = 1;
            tbxTargetPath.TextChanged += targetPathInput_TextChanged;
            tbxTargetPath.Leave += targetPathInput_Leave;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(797, 109);
            btnBrowse.Margin = new Padding(5, 6, 5, 6);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(129, 46);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += browseButton_Click;
            // 
            // cbxPriority
            // 
            cbxPriority.FormattingEnabled = true;
            cbxPriority.Location = new Point(240, 169);
            cbxPriority.Margin = new Padding(5, 6, 5, 6);
            cbxPriority.Name = "cbxPriority";
            cbxPriority.Size = new Size(461, 38);
            cbxPriority.TabIndex = 3;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.Location = new Point(719, 167);
            btnAddToQueue.Margin = new Padding(5, 6, 5, 6);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(207, 46);
            btnAddToQueue.TabIndex = 2;
            btnAddToQueue.Text = "Add to Queue";
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Click += addToQueueButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 271);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(180, 30);
            label4.TabIndex = 0;
            label4.Text = "Download Queue:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // listViewDownloadQueue
            // 
            listViewDownloadQueue.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, identifier, columnHeader7 });
            listViewDownloadQueue.FullRowSelect = true;
            listViewDownloadQueue.Location = new Point(14, 337);
            listViewDownloadQueue.Margin = new Padding(5, 6, 5, 6);
            listViewDownloadQueue.Name = "listViewDownloadQueue";
            listViewDownloadQueue.Size = new Size(959, 250);
            listViewDownloadQueue.TabIndex = 4;
            listViewDownloadQueue.UseCompatibleStateImageBehavior = false;
            listViewDownloadQueue.View = View.Details;
            listViewDownloadQueue.SelectedIndexChanged += listViewDownloadQueue_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "URL";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Path";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Progress";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Priority";
            columnHeader5.Width = 100;
            // 
            // identifier
            // 
            identifier.Text = "Identifier";
            identifier.Width = 120;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "TimeLeft";
            columnHeader7.Width = 120;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(995, 406);
            btnPause.Margin = new Padding(5, 6, 5, 6);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(129, 46);
            btnPause.TabIndex = 5;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += buttonPause_Click;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(995, 473);
            btnResume.Margin = new Padding(5, 6, 5, 6);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(129, 46);
            btnResume.TabIndex = 6;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += buttonResume_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(995, 541);
            btnCancel.Margin = new Padding(5, 6, 5, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 46);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += buttonCancel_Click;
            // 
            // listViewDownloadedFiles
            // 
            listViewDownloadedFiles.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14 });
            listViewDownloadedFiles.Location = new Point(14, 703);
            listViewDownloadedFiles.Margin = new Padding(5, 6, 5, 6);
            listViewDownloadedFiles.Name = "listViewDownloadedFiles";
            listViewDownloadedFiles.Size = new Size(959, 250);
            listViewDownloadedFiles.TabIndex = 8;
            listViewDownloadedFiles.UseCompatibleStateImageBehavior = false;
            listViewDownloadedFiles.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "ID";
            columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "URL";
            columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Path";
            columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Progress";
            columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Priority";
            columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Identifier";
            columnHeader13.Width = 120;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "TimeLeft";
            columnHeader14.Width = 120;
            // 
            // lblFile1
            // 
            lblFile1.AutoSize = true;
            lblFile1.Location = new Point(21, 599);
            lblFile1.Margin = new Padding(5, 0, 5, 0);
            lblFile1.Name = "lblFile1";
            lblFile1.Size = new Size(187, 30);
            lblFile1.TabIndex = 13;
            lblFile1.Text = "Files Downloading:";
            // 
            // lblFileTime1
            // 
            lblFileTime1.AutoSize = true;
            lblFileTime1.Location = new Point(470, 638);
            lblFileTime1.Margin = new Padding(5, 0, 5, 0);
            lblFileTime1.Name = "lblFileTime1";
            lblFileTime1.Size = new Size(33, 30);
            lblFileTime1.TabIndex = 20;
            lblFileTime1.Text = "0s";
            // 
            // pbFile1
            // 
            pbFile1.Location = new Point(32, 638);
            pbFile1.Name = "pbFile1";
            pbFile1.Size = new Size(365, 40);
            pbFile1.Step = 0;
            pbFile1.TabIndex = 21;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(995, 337);
            btnStart.Margin = new Padding(5, 6, 5, 6);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(129, 46);
            btnStart.TabIndex = 22;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStartAll
            // 
            btnStartAll.Location = new Point(1155, 337);
            btnStartAll.Margin = new Padding(5, 6, 5, 6);
            btnStartAll.Name = "btnStartAll";
            btnStartAll.Size = new Size(129, 46);
            btnStartAll.TabIndex = 23;
            btnStartAll.Text = "Start All";
            btnStartAll.UseVisualStyleBackColor = true;
            btnStartAll.Click += btnStartAll_Click;
            // 
            // btnPauseAll
            // 
            btnPauseAll.Location = new Point(1155, 406);
            btnPauseAll.Margin = new Padding(5, 6, 5, 6);
            btnPauseAll.Name = "btnPauseAll";
            btnPauseAll.Size = new Size(129, 46);
            btnPauseAll.TabIndex = 24;
            btnPauseAll.Text = "Pause All";
            btnPauseAll.UseVisualStyleBackColor = true;
            btnPauseAll.Click += btnPauseAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1435, 1107);
            Controls.Add(btnPauseAll);
            Controls.Add(btnStartAll);
            Controls.Add(btnStart);
            Controls.Add(pbFile1);
            Controls.Add(lblFileTime1);
            Controls.Add(lblFile1);
            Controls.Add(listViewDownloadedFiles);
            Controls.Add(btnCancel);
            Controls.Add(btnResume);
            Controls.Add(btnPause);
            Controls.Add(listViewDownloadQueue);
            Controls.Add(cbxPriority);
            Controls.Add(btnAddToQueue);
            Controls.Add(btnBrowse);
            Controls.Add(tbxTargetPath);
            Controls.Add(tbxUrl);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Download Manager";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbxUrl;
        private TextBox tbxTargetPath;
        private Button btnBrowse;
        private ComboBox cbxPriority;
        private Button btnAddToQueue;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private ListView listViewDownloadQueue;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnPause;
        private Button btnResume;
        private Button btnCancel;
        private ColumnHeader identifier;
        private ColumnHeader columnHeader7;
        private ListView listViewDownloadedFiles;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private Label lblFile1;
        private Label label6;
        private Label label7;
        private Label lblFileTime1;
        private ProgressBar pbFile1;
        private Button btnStart;
        private Button btnStartAll;
        private Button btnPauseAll;
    }
}