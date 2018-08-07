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
            this.SuspendLayout();
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(54, 22);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(183, 25);
            this.label_Headline.TabIndex = 0;
            this.label_Headline.Text = "Change Permission";
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(85, 197);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(117, 55);
            this.button_Accept.TabIndex = 1;
            this.button_Accept.Text = "Update Permission";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(107, 56);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(134, 22);
            this.textBox_UserID.TabIndex = 2;
            this.textBox_UserID.TextChanged += new System.EventHandler(this.textBox_UserID_TextChanged);
            this.textBox_UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_UserID_KeyPress);
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Location = new System.Drawing.Point(46, 59);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(55, 17);
            this.label_UserID.TabIndex = 3;
            this.label_UserID.Text = "User ID";
            // 
            // checkBox_Agree
            // 
            this.checkBox_Agree.AutoSize = true;
            this.checkBox_Agree.Location = new System.Drawing.Point(107, 170);
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
            "Secretary",
            "Exam Department",
            "Admin"});
            this.comboBox_Permission.Location = new System.Drawing.Point(107, 92);
            this.comboBox_Permission.Name = "comboBox_Permission";
            this.comboBox_Permission.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Permission.TabIndex = 5;
            this.comboBox_Permission.SelectedIndexChanged += new System.EventHandler(this.comboBox_Permission_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Permission";
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(230, 197);
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
            this.comboBox_Department.Location = new System.Drawing.Point(107, 133);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Department.TabIndex = 22;
            this.comboBox_Department.Visible = false;
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.comboBox_Department_SelectedIndexChanged);
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Location = new System.Drawing.Point(19, 136);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(82, 17);
            this.label_Department.TabIndex = 23;
            this.label_Department.Text = "Department";
            this.label_Department.Visible = false;
            // 
            // FormAdminChangePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 264);
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
            this.Name = "FormAdminChangePermission";
            this.Text = "FormAdminChangePermission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminChangePermission_FormClosing);
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
    }
}