namespace A_8
{
    partial class FormAdmin_DeleteUser
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
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label_Headline = new System.Windows.Forms.Label();
            this.label_UserID = new System.Windows.Forms.Label();
            this.checkBox_Accept = new System.Windows.Forms.CheckBox();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(35, 66);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(128, 22);
            this.textBox_UserID.TabIndex = 0;
            this.textBox_UserID.TextChanged += new System.EventHandler(this.textBox_UserID_TextChanged);
            this.textBox_UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_UserID_KeyPress);
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.ForeColor = System.Drawing.Color.Black;
            this.label_Headline.Location = new System.Drawing.Point(25, 9);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(146, 29);
            this.label_Headline.TabIndex = 1;
            this.label_Headline.Text = "Delete User";
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Location = new System.Drawing.Point(12, 71);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(21, 17);
            this.label_UserID.TabIndex = 2;
            this.label_UserID.Text = "ID";
            // 
            // checkBox_Accept
            // 
            this.checkBox_Accept.AutoSize = true;
            this.checkBox_Accept.Location = new System.Drawing.Point(59, 103);
            this.checkBox_Accept.Name = "checkBox_Accept";
            this.checkBox_Accept.Size = new System.Drawing.Size(68, 21);
            this.checkBox_Accept.TabIndex = 3;
            this.checkBox_Accept.Text = "Agree";
            this.checkBox_Accept.UseVisualStyleBackColor = true;
            this.checkBox_Accept.Visible = false;
            this.checkBox_Accept.Click += new System.EventHandler(this.checkBox_Accept_Click);
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(30, 144);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(82, 40);
            this.button_Accept.TabIndex = 4;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(134, 143);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 22;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormAdminDeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 199);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.checkBox_Accept);
            this.Controls.Add(this.label_UserID);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.textBox_UserID);
            this.Name = "FormAdminDeleteUser";
            this.Text = "FormAdminDeleteUsercs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminDeleteUser_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Label label_UserID;
        private System.Windows.Forms.CheckBox checkBox_Accept;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Back;
    }
}