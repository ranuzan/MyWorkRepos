namespace A_8
{
    partial class FormMenuSecretary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuSecretary));
            this.combobox_Year = new System.Windows.Forms.ComboBox();
            this.combobox_Semester = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.buttonReportError = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Headline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combobox_Year
            // 
            this.combobox_Year.BackColor = System.Drawing.Color.DodgerBlue;
            this.combobox_Year.Cursor = System.Windows.Forms.Cursors.Default;
            this.combobox_Year.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combobox_Year.ForeColor = System.Drawing.Color.White;
            this.combobox_Year.FormattingEnabled = true;
            this.combobox_Year.Items.AddRange(new object[] {
            "Year 1",
            "Year 2",
            "Year 3",
            "Year 4"});
            this.combobox_Year.Location = new System.Drawing.Point(36, 82);
            this.combobox_Year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combobox_Year.Name = "combobox_Year";
            this.combobox_Year.Size = new System.Drawing.Size(199, 24);
            this.combobox_Year.TabIndex = 2;
            this.combobox_Year.Text = "Choose a year";
            this.combobox_Year.SelectedIndexChanged += new System.EventHandler(this.combobox_Year_SelectedIndexChanged);
            // 
            // combobox_Semester
            // 
            this.combobox_Semester.BackColor = System.Drawing.Color.DodgerBlue;
            this.combobox_Semester.Enabled = false;
            this.combobox_Semester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combobox_Semester.ForeColor = System.Drawing.Color.White;
            this.combobox_Semester.FormattingEnabled = true;
            this.combobox_Semester.Items.AddRange(new object[] {
            "Semester A",
            "Semester B"});
            this.combobox_Semester.Location = new System.Drawing.Point(255, 82);
            this.combobox_Semester.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combobox_Semester.Name = "combobox_Semester";
            this.combobox_Semester.Size = new System.Drawing.Size(199, 24);
            this.combobox_Semester.TabIndex = 3;
            this.combobox_Semester.Text = "Choose a semester";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(36, 127);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(673, 222);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CourseName";
            this.columnHeader6.Width = 192;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CourseID";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SemeterPoints";
            this.columnHeader5.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CourseHours";
            this.columnHeader7.Width = 99;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Pre course";
            this.columnHeader8.Width = 64;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(36, 366);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(329, 123);
            this.button4.TabIndex = 7;
            this.button4.Text = "Add or Remove Lecture";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Show
            // 
            this.Show.BackColor = System.Drawing.Color.DodgerBlue;
            this.Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Show.ForeColor = System.Drawing.Color.White;
            this.Show.Location = new System.Drawing.Point(473, 82);
            this.Show.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(236, 26);
            this.Show.TabIndex = 5;
            this.Show.Text = "Show";
            this.Show.UseVisualStyleBackColor = false;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.ForeColor = System.Drawing.Color.White;
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.Location = new System.Drawing.Point(635, 15);
            this.helpBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(27, 25);
            this.helpBtn.TabIndex = 5;
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // buttonReportError
            // 
            this.buttonReportError.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonReportError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReportError.ForeColor = System.Drawing.Color.White;
            this.buttonReportError.Image = global::A_8.Properties.Resources.error;
            this.buttonReportError.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportError.Location = new System.Drawing.Point(380, 366);
            this.buttonReportError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonReportError.Name = "buttonReportError";
            this.buttonReportError.Size = new System.Drawing.Size(329, 123);
            this.buttonReportError.TabIndex = 8;
            this.buttonReportError.Text = "Report Error";
            this.buttonReportError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportError.UseVisualStyleBackColor = false;
            this.buttonReportError.Click += new System.EventHandler(this.buttonReportError_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = global::A_8.Properties.Resources.exit;
            this.buttonExit.Location = new System.Drawing.Point(704, 15);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(27, 25);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::A_8.Properties.Resources.logoff;
            this.button1.Location = new System.Drawing.Point(671, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Headline.Location = new System.Drawing.Point(28, 22);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(263, 39);
            this.label_Headline.TabIndex = 11;
            this.label_Headline.Text = "Secretary Menu";
            // 
            // FormMenuSecretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(747, 508);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.combobox_Year);
            this.Controls.Add(this.combobox_Semester);
            this.Controls.Add(this.buttonReportError);
            this.Controls.Add(this.helpBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenuSecretary";
            this.Text = "SecreteryMenu";
            this.Load += new System.EventHandler(this.FormMenuSecretary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox combobox_Year;
        private System.Windows.Forms.ComboBox combobox_Semester;
        private System.Windows.Forms.Button Show;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonReportError;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_Headline;
    }
}