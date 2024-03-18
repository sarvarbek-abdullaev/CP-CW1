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
            listView1 = new ListView();
            No = new ColumnHeader();
            URL = new ColumnHeader();
            Status = new ColumnHeader();
            Priority = new ColumnHeader();
            Progress = new ColumnHeader();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            dataSet1BindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataSet1BindingSource).BeginInit();
            SuspendLayout();
            // 
            // tbxUrl
            // 
            tbxUrl.Location = new Point(290, 30);
            tbxUrl.Name = "tbxUrl";
            tbxUrl.Size = new Size(407, 35);
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
            tbxTargetPath.Size = new Size(407, 35);
            tbxTargetPath.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(717, 30);
            button1.Name = "button1";
            button1.Size = new Size(89, 37);
            button1.TabIndex = 4;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(717, 89);
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
            cbxPriority.Size = new Size(212, 38);
            cbxPriority.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(521, 209);
            button3.Name = "button3";
            button3.Size = new Size(165, 37);
            button3.TabIndex = 8;
            button3.Text = "Add to Queue";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { No, URL, Status, Priority, Progress });
            listView1.Location = new Point(36, 285);
            listView1.Name = "listView1";
            listView1.Size = new Size(661, 170);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // URL
            // 
            URL.Width = 300;
            // 
            // Priority
            // 
            Priority.DisplayIndex = 4;
            // 
            // Progress
            // 
            Progress.DisplayIndex = 3;
            // 
            // button4
            // 
            button4.Location = new Point(717, 285);
            button4.Name = "button4";
            button4.Size = new Size(89, 37);
            button4.TabIndex = 10;
            button4.Text = "Start";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(717, 352);
            button5.Name = "button5";
            button5.Size = new Size(89, 37);
            button5.TabIndex = 11;
            button5.Text = "Pause";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(717, 418);
            button6.Name = "button6";
            button6.Size = new Size(89, 37);
            button6.TabIndex = 12;
            button6.Text = "Stop";
            button6.UseVisualStyleBackColor = true;
            // 
            // dataSet1BindingSource
            // 
            dataSet1BindingSource.DataSource = typeof(DataSet1);
            dataSet1BindingSource.Position = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 519);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(listView1);
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
        private ListView listView1;
        private ColumnHeader No;
        private ColumnHeader URL;
        private ColumnHeader Status;
        private ColumnHeader Priority;
        private ColumnHeader Progress;
        private Button button4;
        private Button button5;
        private Button button6;
        private BindingSource dataSet1BindingSource;
    }
}