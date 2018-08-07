namespace A_8
{
    partial class FormAdmin_ChangePermission
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
            this.label_Headline = new System.Windows.Forms.Label();
            this.button_Accept = new System.Windows.Forms.Button();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label_UserID = new System.Windows.Forms.Label();
            this.checkBox_Agree = new System.Windows.Forms.CheckBox();
            this.comboBox_Permission = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Back = new System.Windows.Forms.Button();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.label_Department = new System.Windows.Forms.Label();
            this.comboBox_users = new System.Windows.Forms.ComboBox();
            this.label_instructions = new System.Windows.Forms.Label();
            this.label_selectUser = new System.Windows.Forms.Label();
            this.comboBox_Year = new System.Windows.Forms.ComboBox();
            this.comboBox_Semester = new System.Windows.Forms.ComboBox();
            this.label_year = new System.Windows.Forms.Label();
            this.label_Semester = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(232, 9);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(183, 25);
            this.label_Headline.TabIndex = 0;
            this.label_Headline.Text = "Change Permission";
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(249, 357);
            this.button_Accept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(117, 55);
            this.button_Accept.TabIndex = 1;
            this.button_Accept.Text = "Update Permission";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(116, 126);
            this.textBox_UserID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(135, 22);
            this.textBox_UserID.TabIndex = 2;
            this.textBox_UserID.TextChanged += new System.EventHandler(this.textBox_UserID_TextChanged);
            this.textBox_UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_UserID_KeyPress);
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Location = new System.Drawing.Point(34, 129);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(55, 17);
            this.label_UserID.TabIndex = 3;
            this.label_UserID.Text = "User ID";
            // 
            // checkBox_Agree
            // 
            this.checkBox_Agree.AutoSize = true;
            this.checkBox_Agree.Location = new System.Drawing.Point(279, 319);
            this.checkBox_Agree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Agree.Name = "checkBox_Agree";
            this.checkBox_Agree.Size = new System.Drawing.Size(75, 21);
            this.checkBox_Agree.TabIndex = 4;
            this.checkBox_Agree.Text = "I Agree";
            this.checkBox_Agree.UseVisualStyleBackColor = true;
            this.checkBox_Agree.Visible = false;
            this.checkBox_Agree.Click += new System.EventHandler(this.checkBox_Agree_Click);
            // 
            // comboBox_Permission
            // 
            this.comboBox_Permission.Enabled = false;
            this.comboBox_Permission.FormattingEnabled = true;
            this.comboBox_Permission.Items.AddRange(new object[] {
            "Student",
            "Students Secretary",
            "Exam Department",
            "Admin",
            "Lecturer",
            "Practitioner",
            "Head Of Department",
            "Department Secretary"});
            this.comboBox_Permission.Location = new System.Drawing.Point(116, 193);
            this.comboBox_Permission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Permission.Name = "comboBox_Permission";
            this.comboBox_Permission.Size = new System.Drawing.Size(135, 24);
            this.comboBox_Permission.TabIndex = 5;
            this.comboBox_Permission.SelectedIndexChanged += new System.EventHandler(this.comboBox_Permission_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Permission";
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(402, 363);
            this.button_Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 21;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // comboBox_Department
            // 
            this.comboBox_Department.FormattingEnabled = true;
            this.comboBox_Department.Items.AddRange(new object[] {
            "Software",
            "Electrical ",
            "Structural",
            "Mechanical",
            "Chemical",
            "Industry & Management"});
            this.comboBox_Department.Location = new System.Drawing.Point(116, 249);
            this.comboBox_Department.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(135, 24);
            this.comboBox_Department.TabIndex = 22;
            this.comboBox_Department.Visible = false;
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.comboBox_Department_SelectedIndexChanged);
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Location = new System.Drawing.Point(17, 252);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(82, 17);
            this.label_Department.TabIndex = 23;
            this.label_Department.Text = "Department";
            this.label_Department.Visible = false;
            // 
            // comboBox_users
            // 
            this.comboBox_users.FormattingEnabled = true;
            this.comboBox_users.Location = new System.Drawing.Point(392, 126);
            this.comboBox_users.Name = "comboBox_users";
            this.comboBox_users.Size = new System.Drawing.Size(242, 24);
            this.comboBox_users.TabIndex = 24;
            this.comboBox_users.SelectedIndexChanged += new System.EventHandler(this.comboBox_users_SelectedIndexChanged);
            // 
            // label_instructions
            // 
            this.label_instructions.AutoSize = true;
            this.label_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_instructions.Location = new System.Drawing.Point(185, 72);
            this.label_instructions.Name = "label_instructions";
            this.label_instructions.Size = new System.Drawing.Size(264, 25);
            this.label_instructions.TabIndex = 25;
            this.label_instructions.Text = "Insert user ID or select a user";
            // 
            // label_selectUser
            // 
            this.label_selectUser.AutoSize = true;
            this.label_selectUser.Location = new System.Drawing.Point(295, 129);
            this.label_selectUser.Name = "label_selectUser";
            this.label_selectUser.Size = new System.Drawing.Size(91, 17);
            this.label_selectUser.TabIndex = 26;
            this.label_selectUser.Text = "Select a user";
            // 
            // comboBox_Year
            // 
            this.comboBox_Year.FormattingEnabled = true;
            this.comboBox_Year.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_Year.Location = new System.Drawing.Point(371, 249);
            this.comboBox_Year.Name = "comboBox_Year";
            this.comboBox_Year.Size = new System.Drawing.Size(55, 24);
            this.comboBox_Year.TabIndex = 27;
            this.comboBox_Year.Visible = false;
            this.comboBox_Year.SelectedIndexChanged += new System.EventHandler(this.comboBox_Year_SelectedIndexChanged);
            // 
            // comboBox_Semester
            // 
            this.comboBox_Semester.Enabled = false;
            this.comboBox_Semester.FormattingEnabled = true;
            this.comboBox_Semester.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBox_Semester.Location = new System.Drawing.Point(519, 249);
            this.comboBox_Semester.Name = "comboBox_Semester";
            this.comboBox_Semester.Size = new System.Drawing.Size(55, 24);
            this.comboBox_Semester.TabIndex = 28;
            this.comboBox_Semester.Visible = false;
            this.comboBox_Semester.SelectedIndexChanged += new System.EventHandler(this.comboBox_Semester_SelectedIndexChanged);
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Location = new System.Drawing.Point(327, 253);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(38, 17);
            this.label_year.TabIndex = 29;
            this.label_year.Text = "Year";
            this.label_year.Visible = false;
            // 
            // label_Semester
            // 
            this.label_Semester.AutoSize = true;
            this.label_Semester.Enabled = false;
            this.label_Semester.Location = new System.Drawing.Point(445, 253);
            this.label_Semester.Name = "label_Semester";
            this.label_Semester.Size = new System.Drawing.Size(68, 17);
            this.label_Semester.TabIndex = 30;
            this.label_Semester.Text = "Semester";
            this.label_Semester.Visible = false;
            // 
            // FormAdmin_ChangePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 454);
            this.Controls.Add(this.label_Semester);
            this.Controls.Add(this.label_year);
            this.Controls.Add(this.comboBox_Semester);
            this.Controls.Add(this.comboBox_Year);
            this.Controls.Add(this.label_selectUser);
            this.Controls.Add(this.label_instructions);
            this.Controls.Add(this.comboBox_users);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Permission);
            this.Controls.Add(this.checkBox_Agree);
            this.Controls.Add(this.label_UserID);
            this.Controls.Add(this.textBox_UserID);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.label_Headline);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAdmin_ChangePermission";
            this.Text = "FormAdminChangePermission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminChangePermission_FormClosing);
            this.Load += new System.EventHandler(this.FormAdmin_ChangePermission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label_UserID;
        private System.Windows.Forms.CheckBox checkBox_Agree;
        private System.Windows.Forms.ComboBox comboBox_Permission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.ComboBox comboBox_users;
        private System.Windows.Forms.Label label_instructions;
        private System.Windows.Forms.Label label_selectUser;
        private System.Windows.Forms.ComboBox comboBox_Year;
        private System.Windows.Forms.ComboBox comboBox_Semester;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.Label label_Semester;
    }
}