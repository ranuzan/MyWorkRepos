namespace A_8
{
    partial class FormSecretary_AddOrRemoveLecture
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
            this.comboBox_AddRemove = new System.Windows.Forms.ComboBox();
            this.label_AddRemove = new System.Windows.Forms.Label();
            this.textBox_StartTime = new System.Windows.Forms.TextBox();
            this.label_startTime00 = new System.Windows.Forms.Label();
            this.label_EndTime00 = new System.Windows.Forms.Label();
            this.textBox_EndTime = new System.Windows.Forms.TextBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.textBox_day = new System.Windows.Forms.TextBox();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_dd = new System.Windows.Forms.Label();
            this.label_MM = new System.Windows.Forms.Label();
            this.textBox_month = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label_description = new System.Windows.Forms.Label();
            this.button_accept = new System.Windows.Forms.Button();
            this.comboBox_Lectures = new System.Windows.Forms.ComboBox();
            this.label_Lecture = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.comboBox_day = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.label_startTime = new System.Windows.Forms.Label();
            this.label_endTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_AddRemove
            // 
            this.comboBox_AddRemove.FormattingEnabled = true;
            this.comboBox_AddRemove.Items.AddRange(new object[] {
            "Add Lecture",
            "Remove Lecture",
            "Add Event"});
            this.comboBox_AddRemove.Location = new System.Drawing.Point(157, 57);
            this.comboBox_AddRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_AddRemove.Name = "comboBox_AddRemove";
            this.comboBox_AddRemove.Size = new System.Drawing.Size(283, 24);
            this.comboBox_AddRemove.TabIndex = 0;
            this.comboBox_AddRemove.SelectedIndexChanged += new System.EventHandler(this.comboBox_AddRemove_SelectedIndexChanged);
            // 
            // label_AddRemove
            // 
            this.label_AddRemove.AutoSize = true;
            this.label_AddRemove.Location = new System.Drawing.Point(49, 60);
            this.label_AddRemove.Name = "label_AddRemove";
            this.label_AddRemove.Size = new System.Drawing.Size(90, 17);
            this.label_AddRemove.TabIndex = 1;
            this.label_AddRemove.Text = "Select Action";
            // 
            // textBox_StartTime
            // 
            this.textBox_StartTime.Location = new System.Drawing.Point(157, 166);
            this.textBox_StartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_StartTime.Name = "textBox_StartTime";
            this.textBox_StartTime.Size = new System.Drawing.Size(27, 22);
            this.textBox_StartTime.TabIndex = 2;
            this.textBox_StartTime.TextChanged += new System.EventHandler(this.textBox_StartTime_TextChanged);
            this.textBox_StartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_StartTime_KeyPress);
            // 
            // label_startTime00
            // 
            this.label_startTime00.AutoSize = true;
            this.label_startTime00.Location = new System.Drawing.Point(182, 170);
            this.label_startTime00.Name = "label_startTime00";
            this.label_startTime00.Size = new System.Drawing.Size(37, 17);
            this.label_startTime00.TabIndex = 4;
            this.label_startTime00.Text = ":00 -";
            // 
            // label_EndTime00
            // 
            this.label_EndTime00.AutoSize = true;
            this.label_EndTime00.Location = new System.Drawing.Point(246, 170);
            this.label_EndTime00.Name = "label_EndTime00";
            this.label_EndTime00.Size = new System.Drawing.Size(28, 17);
            this.label_EndTime00.TabIndex = 6;
            this.label_EndTime00.Text = ":00";
            // 
            // textBox_EndTime
            // 
            this.textBox_EndTime.Location = new System.Drawing.Point(221, 166);
            this.textBox_EndTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_EndTime.Name = "textBox_EndTime";
            this.textBox_EndTime.Size = new System.Drawing.Size(27, 22);
            this.textBox_EndTime.TabIndex = 5;
            this.textBox_EndTime.TextChanged += new System.EventHandler(this.textBox_EndTime_TextChanged);
            this.textBox_EndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_EndTime_KeyPress);
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(98, 170);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(43, 17);
            this.label_Time.TabIndex = 7;
            this.label_Time.Text = "Time:";
            // 
            // textBox_day
            // 
            this.textBox_day.Location = new System.Drawing.Point(157, 133);
            this.textBox_day.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_day.Name = "textBox_day";
            this.textBox_day.Size = new System.Drawing.Size(45, 22);
            this.textBox_day.TabIndex = 8;
            this.textBox_day.TextChanged += new System.EventHandler(this.textBox_day_TextChanged);
            this.textBox_day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_day_KeyPress);
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Location = new System.Drawing.Point(27, 136);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(114, 17);
            this.label_Date.TabIndex = 9;
            this.label_Date.Text = "Date DD/MM/YY:";
            // 
            // label_dd
            // 
            this.label_dd.AutoSize = true;
            this.label_dd.Location = new System.Drawing.Point(272, 136);
            this.label_dd.Name = "label_dd";
            this.label_dd.Size = new System.Drawing.Size(12, 17);
            this.label_dd.TabIndex = 10;
            this.label_dd.Text = "/";
            // 
            // label_MM
            // 
            this.label_MM.AutoSize = true;
            this.label_MM.Location = new System.Drawing.Point(207, 136);
            this.label_MM.Name = "label_MM";
            this.label_MM.Size = new System.Drawing.Size(12, 17);
            this.label_MM.TabIndex = 12;
            this.label_MM.Text = "/";
            // 
            // textBox_month
            // 
            this.textBox_month.Location = new System.Drawing.Point(221, 133);
            this.textBox_month.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_month.Name = "textBox_month";
            this.textBox_month.Size = new System.Drawing.Size(45, 22);
            this.textBox_month.TabIndex = 11;
            this.textBox_month.TextChanged += new System.EventHandler(this.textBox_month_TextChanged);
            this.textBox_month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_month_KeyPress);
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(157, 226);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(283, 155);
            this.textBox_description.TabIndex = 14;
            this.textBox_description.TextChanged += new System.EventHandler(this.textBox_description_TextChanged);
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(58, 229);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(83, 17);
            this.label_description.TabIndex = 15;
            this.label_description.Text = "Description:";
            // 
            // button_accept
            // 
            this.button_accept.Enabled = false;
            this.button_accept.Location = new System.Drawing.Point(157, 395);
            this.button_accept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(117, 37);
            this.button_accept.TabIndex = 16;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // comboBox_Lectures
            // 
            this.comboBox_Lectures.Enabled = false;
            this.comboBox_Lectures.FormattingEnabled = true;
            this.comboBox_Lectures.Location = new System.Drawing.Point(157, 97);
            this.comboBox_Lectures.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Lectures.Name = "comboBox_Lectures";
            this.comboBox_Lectures.Size = new System.Drawing.Size(283, 24);
            this.comboBox_Lectures.TabIndex = 23;
            this.comboBox_Lectures.SelectedIndexChanged += new System.EventHandler(this.comboBox_LectureID_SelectedIndexChanged);
            // 
            // label_Lecture
            // 
            this.label_Lecture.AutoSize = true;
            this.label_Lecture.Location = new System.Drawing.Point(83, 97);
            this.label_Lecture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Lecture.Name = "label_Lecture";
            this.label_Lecture.Size = new System.Drawing.Size(56, 17);
            this.label_Lecture.TabIndex = 24;
            this.label_Lecture.Text = "Lecture";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(102, 197);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(39, 17);
            this.label_title.TabIndex = 25;
            this.label_title.Text = "Title:";
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(157, 197);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(283, 22);
            this.textBox_title.TabIndex = 26;
            this.textBox_title.TextChanged += new System.EventHandler(this.textBox_title_TextChanged);
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Location = new System.Drawing.Point(290, 133);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(63, 24);
            this.comboBox_year.TabIndex = 27;
            this.comboBox_year.SelectedIndexChanged += new System.EventHandler(this.comboBox_year_SelectedIndexChanged);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(393, 395);
            this.button_Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 22;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // comboBox_day
            // 
            this.comboBox_day.FormattingEnabled = true;
            this.comboBox_day.Location = new System.Drawing.Point(157, 133);
            this.comboBox_day.Name = "comboBox_day";
            this.comboBox_day.Size = new System.Drawing.Size(45, 24);
            this.comboBox_day.TabIndex = 28;
            this.comboBox_day.Visible = false;
            this.comboBox_day.SelectedIndexChanged += new System.EventHandler(this.comboBox_day_SelectedIndexChanged);
            // 
            // comboBox_month
            // 
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(221, 133);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(45, 24);
            this.comboBox_month.TabIndex = 29;
            this.comboBox_month.Visible = false;
            this.comboBox_month.SelectedIndexChanged += new System.EventHandler(this.comboBox_month_SelectedIndexChanged);
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(160, 170);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(24, 17);
            this.label_startTime.TabIndex = 30;
            this.label_startTime.Text = "00";
            this.label_startTime.Visible = false;
            // 
            // label_endTime
            // 
            this.label_endTime.AutoSize = true;
            this.label_endTime.Location = new System.Drawing.Point(225, 170);
            this.label_endTime.Name = "label_endTime";
            this.label_endTime.Size = new System.Drawing.Size(24, 17);
            this.label_endTime.TabIndex = 31;
            this.label_endTime.Text = "00";
            this.label_endTime.Visible = false;
            // 
            // FormSecretary_AddOrRemoveLecture
            // 
            this.AcceptButton = this.button_accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 449);
            this.Controls.Add(this.label_endTime);
            this.Controls.Add(this.label_startTime);
            this.Controls.Add(this.comboBox_month);
            this.Controls.Add(this.comboBox_day);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_Lecture);
            this.Controls.Add(this.comboBox_Lectures);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label_MM);
            this.Controls.Add(this.textBox_month);
            this.Controls.Add(this.label_dd);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.textBox_day);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_EndTime00);
            this.Controls.Add(this.textBox_EndTime);
            this.Controls.Add(this.label_startTime00);
            this.Controls.Add(this.textBox_StartTime);
            this.Controls.Add(this.label_AddRemove);
            this.Controls.Add(this.comboBox_AddRemove);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSecretary_AddOrRemoveLecture";
            this.Text = "FormSecretary_AddOrRemoveLecture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSecretary_AddOrRemoveLecture_FormClosing);
            this.Load += new System.EventHandler(this.FormSecretary_AddOrRemoveLecture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_AddRemove;
        private System.Windows.Forms.Label label_AddRemove;
        private System.Windows.Forms.TextBox textBox_StartTime;
        private System.Windows.Forms.Label label_startTime00;
        private System.Windows.Forms.Label label_EndTime00;
        private System.Windows.Forms.TextBox textBox_EndTime;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.TextBox textBox_day;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_dd;
        private System.Windows.Forms.Label label_MM;
        private System.Windows.Forms.TextBox textBox_month;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.ComboBox comboBox_Lectures;
        private System.Windows.Forms.Label label_Lecture;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.ComboBox comboBox_day;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.Label label_endTime;
    }
}