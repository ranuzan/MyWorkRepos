namespace B_8
{
    partial class WeeklySchedule
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.ChooseDate = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EXIT = new System.Windows.Forms.PictureBox();
            this.logOut = new System.Windows.Forms.PictureBox();
            this.home = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 67);
            this.monthCalendar1.MaxDate = new System.DateTime(2017, 6, 15, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2016, 10, 30, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // ChooseDate
            // 
            this.ChooseDate.Location = new System.Drawing.Point(18, 22);
            this.ChooseDate.Name = "ChooseDate";
            this.ChooseDate.Size = new System.Drawing.Size(108, 23);
            this.ChooseDate.TabIndex = 1;
            this.ChooseDate.Text = "Choose Date";
            this.ChooseDate.UseVisualStyleBackColor = true;
            this.ChooseDate.Click += new System.EventHandler(this.ChooseDate_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(18, 51);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(199, 20);
            this.maskedTextBox1.TabIndex = 2;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::B_8.Properties.Resources.confirm_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(145, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // EXIT
            // 
            this.EXIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EXIT.Image = global::B_8.Properties.Resources.exit1;
            this.EXIT.Location = new System.Drawing.Point(310, 185);
            this.EXIT.Margin = new System.Windows.Forms.Padding(2);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(106, 34);
            this.EXIT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EXIT.TabIndex = 57;
            this.EXIT.TabStop = false;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // logOut
            // 
            this.logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOut.Image = global::B_8.Properties.Resources.logout_button;
            this.logOut.Location = new System.Drawing.Point(310, 22);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(106, 34);
            this.logOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logOut.TabIndex = 56;
            this.logOut.TabStop = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // home
            // 
            this.home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home.Image = global::B_8.Properties.Resources.home_button;
            this.home.Location = new System.Drawing.Point(310, 102);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(106, 34);
            this.home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.home.TabIndex = 55;
            this.home.TabStop = false;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // WeeklySchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 231);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.home);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.ChooseDate);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "WeeklySchedule";
            this.Text = "WeeklySchedule";
            this.Load += new System.EventHandler(this.WeeklySchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.home)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button ChooseDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.PictureBox EXIT;
        private System.Windows.Forms.PictureBox logOut;
        private System.Windows.Forms.PictureBox home;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}