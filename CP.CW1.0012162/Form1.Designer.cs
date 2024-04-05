namespace CP.CW1._0012162
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
            tbxUrl = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbxTargetPath = new TextBox();
            button1 = new Button();
            btnTarget = new Button();
            label3 = new Label();
            cbxPriority = new ComboBox();
            button3 = new Button();
            listView = new ListView();
            No = new ColumnHeader();
            URL = new ColumnHeader();
            Status = new ColumnHeader();
            Priority = new ColumnHeader();
            Progress = new ColumnHeader();
            dataSet1BindingSource = new BindingSource(components);
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            progressLabelName1 = new Label();
            progressLabelName2 = new Label();
            progressLabelName3 = new Label();
            btnDownload3 = new Button();
            btnDownload2 = new Button();
            btnDownload1 = new Button();
            btnGetNext3 = new Button();
            btnGetNext2 = new Button();
            btnGetNext1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataSet1BindingSource).BeginInit();
            SuspendLayout();
            // 
            // tbxUrl
            // 
            tbxUrl.Location = new Point(290, 30);
            tbxUrl.Name = "tbxUrl";
            tbxUrl.Size = new Size(514, 35);
            tbxUrl.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 33);
            label1.Name = "label1";
            label1.Size = new Size(204, 30);
            label1.TabIndex = 1;
            label1.Text = "Enter Download URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 92);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 3;
            label2.Text = "Enter Target Path";
            // 
            // tbxTargetPath
            // 
            tbxTargetPath.Location = new Point(290, 89);
            tbxTargetPath.Name = "tbxTargetPath";
            tbxTargetPath.Size = new Size(514, 35);
            tbxTargetPath.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(836, 33);
            button1.Name = "button1";
            button1.Size = new Size(89, 37);
            button1.TabIndex = 4;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(836, 92);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(89, 37);
            btnTarget.TabIndex = 5;
            btnTarget.Text = "...";
            btnTarget.UseVisualStyleBackColor = true;
            btnTarget.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 152);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 6;
            label3.Text = "Enter Priority";
            // 
            // cbxPriority
            // 
            cbxPriority.FormatString = "N0";
            cbxPriority.FormattingEnabled = true;
            cbxPriority.Items.AddRange(new object[] { "5", "4", "3", "2", "1" });
            cbxPriority.Location = new Point(290, 152);
            cbxPriority.Name = "cbxPriority";
            cbxPriority.Size = new Size(296, 38);
            cbxPriority.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(630, 153);
            button3.Name = "button3";
            button3.Size = new Size(165, 37);
            button3.TabIndex = 8;
            button3.Text = "Add to Queue";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { No, URL, Status, Priority, Progress });
            listView.Location = new Point(36, 285);
            listView.Name = "listView";
            listView.Size = new Size(889, 170);
            listView.TabIndex = 9;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // No
            // 
            No.Text = "No";
            // 
            // URL
            // 
            URL.Text = "Url";
            URL.Width = 300;
            // 
            // Status
            // 
            Status.Text = "Status";
            // 
            // Priority
            // 
            Priority.DisplayIndex = 4;
            Priority.Text = "Priority";
            // 
            // Progress
            // 
            Progress.DisplayIndex = 3;
            Progress.Text = "Progress";
            // 
            // dataSet1BindingSource
            // 
            dataSet1BindingSource.DataSource = typeof(DataSet1);
            dataSet1BindingSource.Position = 0;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(36, 488);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(315, 40);
            progressBar1.TabIndex = 13;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(36, 551);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(315, 40);
            progressBar2.TabIndex = 14;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(36, 611);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(315, 40);
            progressBar3.TabIndex = 15;
            // 
            // progressLabelName1
            // 
            progressLabelName1.AutoSize = true;
            progressLabelName1.Location = new Point(402, 491);
            progressLabelName1.Name = "progressLabelName1";
            progressLabelName1.Size = new Size(111, 30);
            progressLabelName1.TabIndex = 16;
            progressLabelName1.Text = "File Name:";
            // 
            // progressLabelName2
            // 
            progressLabelName2.AutoSize = true;
            progressLabelName2.Location = new Point(402, 551);
            progressLabelName2.Name = "progressLabelName2";
            progressLabelName2.Size = new Size(111, 30);
            progressLabelName2.TabIndex = 17;
            progressLabelName2.Text = "File Name:";
            // 
            // progressLabelName3
            // 
            progressLabelName3.AutoSize = true;
            progressLabelName3.Location = new Point(402, 611);
            progressLabelName3.Name = "progressLabelName3";
            progressLabelName3.Size = new Size(111, 30);
            progressLabelName3.TabIndex = 18;
            progressLabelName3.Text = "File Name:";
            // 
            // btnDownload3
            // 
            btnDownload3.Location = new Point(751, 620);
            btnDownload3.Name = "btnDownload3";
            btnDownload3.Size = new Size(174, 37);
            btnDownload3.TabIndex = 21;
            btnDownload3.Text = "Download";
            btnDownload3.UseVisualStyleBackColor = true;
            btnDownload3.Click += btnDownload3_Click;
            // 
            // btnDownload2
            // 
            btnDownload2.Location = new Point(751, 554);
            btnDownload2.Name = "btnDownload2";
            btnDownload2.Size = new Size(174, 37);
            btnDownload2.TabIndex = 20;
            btnDownload2.Text = "Download";
            btnDownload2.UseVisualStyleBackColor = true;
            btnDownload2.Click += btnDownload2_Click;
            // 
            // btnDownload1
            // 
            btnDownload1.Location = new Point(751, 488);
            btnDownload1.Name = "btnDownload1";
            btnDownload1.Size = new Size(174, 37);
            btnDownload1.TabIndex = 19;
            btnDownload1.Text = "Download";
            btnDownload1.UseVisualStyleBackColor = true;
            btnDownload1.Click += btnDownload1_Click;
            // 
            // btnGetNext3
            // 
            btnGetNext3.Location = new Point(945, 620);
            btnGetNext3.Name = "btnGetNext3";
            btnGetNext3.Size = new Size(174, 37);
            btnGetNext3.TabIndex = 24;
            btnGetNext3.Text = "Get Next";
            btnGetNext3.UseVisualStyleBackColor = true;
            btnGetNext3.Visible = false;
            btnGetNext3.Click += btnGetNext3_Click;
            // 
            // btnGetNext2
            // 
            btnGetNext2.Location = new Point(945, 554);
            btnGetNext2.Name = "btnGetNext2";
            btnGetNext2.Size = new Size(174, 37);
            btnGetNext2.TabIndex = 23;
            btnGetNext2.Text = "Get Next";
            btnGetNext2.UseVisualStyleBackColor = true;
            btnGetNext2.Visible = false;
            btnGetNext2.Click += btnGetNext2_Click;
            // 
            // btnGetNext1
            // 
            btnGetNext1.Location = new Point(945, 488);
            btnGetNext1.Name = "btnGetNext1";
            btnGetNext1.Size = new Size(174, 40);
            btnGetNext1.TabIndex = 22;
            btnGetNext1.Text = "Get Next";
            btnGetNext1.UseVisualStyleBackColor = true;
            btnGetNext1.Visible = false;
            btnGetNext1.Click += btnGetNext1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 678);
            Controls.Add(btnGetNext3);
            Controls.Add(btnGetNext2);
            Controls.Add(btnGetNext1);
            Controls.Add(btnDownload3);
            Controls.Add(btnDownload2);
            Controls.Add(btnDownload1);
            Controls.Add(progressLabelName3);
            Controls.Add(progressLabelName2);
            Controls.Add(progressLabelName1);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(listView);
            Controls.Add(button3);
            Controls.Add(cbxPriority);
            Controls.Add(label3);
            Controls.Add(btnTarget);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(tbxTargetPath);
            Controls.Add(label1);
            Controls.Add(tbxUrl);
            Name = "Form1";
            Text = "Download Manager";
            ((System.ComponentModel.ISupportInitialize)dataSet1BindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxUrl;
        private Label label1;
        private Label label2;
        private TextBox tbxTargetPath;
        private Button button1;
        private Button btnTarget;
        private Label label3;
        private ComboBox cbxPriority;
        private Button button3;
        private ListView listView;
        private ColumnHeader No;
        private ColumnHeader URL;
        private ColumnHeader Status;
        private ColumnHeader Priority;
        private ColumnHeader Progress;
        private BindingSource dataSet1BindingSource;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private Label progressLabelName1;
        private Label progressLabelName2;
        private Label progressLabelName3;
        private Button btnDownload3;
        private Button btnDownload2;
        private Button btnDownload1;
        private Button btnGetNext3;
        private Button btnGetNext2;
        private Button btnGetNext1;
    }
}