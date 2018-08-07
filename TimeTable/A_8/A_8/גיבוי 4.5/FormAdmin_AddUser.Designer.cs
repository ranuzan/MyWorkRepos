namespace A_8
{
    partial class FormAdmin_AddUser
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
            this.button_Accept = new System.Windows.Forms.Button();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.label_LastName = new System.Windows.Forms.Label();
            this.label_Department = new System.Windows.Forms.Label();
            this.label_Permission = new System.Windows.Forms.Label();
            this.label_AddUser = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.comboBox_Permission = new System.Windows.Forms.ComboBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(146, 306);
            this.button_Accept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(148, 45);
            this.button_Accept.TabIndex = 0;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(126, 108);
            this.label_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(18, 13);
            this.label_ID.TabIndex = 3;
            this.label_ID.Text = "ID";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(91, 142);
            this.label_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password";
            // 
            // label_FirstName
            // 
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.Location = new System.Drawing.Point(87, 175);
            this.label_FirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.Size = new System.Drawing.Size(55, 13);
            this.label_FirstName.TabIndex = 6;
            this.label_FirstName.Text = "First name";
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.Location = new System.Drawing.Point(87, 209);
            this.label_LastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(56, 13);
            this.label_LastName.TabIndex = 9;
            this.label_LastName.Text = "Last name";
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Location = new System.Drawing.Point(81, 280);
            this.label_Department.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(62, 13);
            this.label_Department.TabIndex = 11;
            this.label_Department.Text = "Department";
            this.label_Department.Visible = false;
            // 
            // label_Permission
            // 
            this.label_Permission.AutoSize = true;
            this.label_Permission.Location = new System.Drawing.Point(84, 248);
            this.label_Permission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Permission.Name = "label_Permission";
            this.label_Permission.Size = new System.Drawing.Size(57, 13);
            this.label_Permission.TabIndex = 12;
            this.label_Permission.Text = "Permission";
            // 
            // label_AddUser
            // 
            this.label_AddUser.AutoSize = true;
            this.label_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_AddUser.Location = new System.Drawing.Point(186, 58);
            this.label_AddUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_AddUser.Name = "label_AddUser";
            this.label_AddUser.Size = new System.Drawing.Size(76, 20);
            this.label_AddUser.TabIndex = 13;
            this.label_AddUser.Text = "Add User";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(154, 106);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(140, 20);
            this.textBox_ID.TabIndex = 14;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxID_KeyPress);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Enabled = false;
            this.textBox_Password.Location = new System.Drawing.Point(154, 140);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(140, 20);
            this.textBox_Password.TabIndex = 15;
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Enabled = false;
            this.textBox_FirstName.Location = new System.Drawing.Point(154, 175);
            this.textBox_FirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(140, 20);
            this.textBox_FirstName.TabIndex = 16;
            this.textBox_FirstName.TextChanged += new System.EventHandler(this.textBox_FirstName_TextChanged);
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Enabled = false;
            this.textBox_LastName.Location = new System.Drawing.Point(154, 206);
            this.textBox_LastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(140, 20);
            this.textBox_LastName.TabIndex = 17;
            this.textBox_LastName.TextChanged += new System.EventHandler(this.textBox_LastName_TextChanged);
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
            this.comboBox_Department.Location = new System.Drawing.Point(154, 277);
            this.comboBox_Department.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(140, 21);
            this.comboBox_Department.TabIndex = 18;
            this.comboBox_Department.Visible = false;
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox_Permission
            // 
            this.comboBox_Permission.Enabled = false;
            this.comboBox_Permission.FormattingEnabled = true;
            this.comboBox_Permission.Items.AddRange(new object[] {
            "Student",
            "Secretary",
            "Exam Department",
            "Admin"});
            this.comboBox_Permission.Location = new System.Drawing.Point(154, 245);
            this.comboBox_Permission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Permission.Name = "comboBox_Permission";
            this.comboBox_Permission.Size = new System.Drawing.Size(140, 21);
            this.comboBox_Permission.TabIndex = 19;
            this.comboBox_Permission.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(386, 22);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(45, 35);
            this.button_Back.TabIndex = 20;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormAdmin_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 376);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.comboBox_Permission);
            this.Controls.Add(this.comboBox_Department);
            this.Controls.Add(this.textBox_LastName);
            this.Controls.Add(this.textBox_FirstName);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.label_AddUser);
            this.Controls.Add(this.label_Permission);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.label_LastName);
            this.Controls.Add(this.label_FirstName);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.button_Accept);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAdmin_AddUser";
            this.Text = "Admin_AddUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminAddUser_FormClosing);
            this.Load += new System.EventHandler(this.FormAdminAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.Label label_Permission;
        private System.Windows.Forms.Label label_AddUser;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.ComboBox comboBox_Permission;
        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.Button button_Back;
    }
}