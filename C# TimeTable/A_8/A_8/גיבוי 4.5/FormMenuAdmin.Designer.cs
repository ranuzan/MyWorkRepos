namespace A_8
{
    partial class FormMenuAdmin
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
            this.button_AddUser = new System.Windows.Forms.Button();
            this.button_DeleteUser = new System.Windows.Forms.Button();
            this.button_AddClassroom = new System.Windows.Forms.Button();
            this.button_RemoveClassroom = new System.Windows.Forms.Button();
            this.button_ChangePermission = new System.Windows.Forms.Button();
            this.label_Headline = new System.Windows.Forms.Label();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_AddUser
            // 
            this.button_AddUser.Location = new System.Drawing.Point(122, 116);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(236, 60);
            this.button_AddUser.TabIndex = 0;
            this.button_AddUser.Text = "Add User";
            this.button_AddUser.UseVisualStyleBackColor = true;
            this.button_AddUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_DeleteUser
            // 
            this.button_DeleteUser.Location = new System.Drawing.Point(122, 204);
            this.button_DeleteUser.Name = "button_DeleteUser";
            this.button_DeleteUser.Size = new System.Drawing.Size(236, 61);
            this.button_DeleteUser.TabIndex = 1;
            this.button_DeleteUser.Text = "Delete User";
            this.button_DeleteUser.UseVisualStyleBackColor = true;
            this.button_DeleteUser.Click += new System.EventHandler(this.button_DeleteUser_Click);
            // 
            // button_AddClassroom
            // 
            this.button_AddClassroom.Location = new System.Drawing.Point(581, 116);
            this.button_AddClassroom.Name = "button_AddClassroom";
            this.button_AddClassroom.Size = new System.Drawing.Size(236, 60);
            this.button_AddClassroom.TabIndex = 2;
            this.button_AddClassroom.Text = "Add Classroom";
            this.button_AddClassroom.UseVisualStyleBackColor = true;
            this.button_AddClassroom.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_RemoveClassroom
            // 
            this.button_RemoveClassroom.Location = new System.Drawing.Point(581, 204);
            this.button_RemoveClassroom.Name = "button_RemoveClassroom";
            this.button_RemoveClassroom.Size = new System.Drawing.Size(236, 61);
            this.button_RemoveClassroom.TabIndex = 3;
            this.button_RemoveClassroom.Text = "Remove Classroom";
            this.button_RemoveClassroom.UseVisualStyleBackColor = true;
            this.button_RemoveClassroom.Click += new System.EventHandler(this.button_RemoveClassroom_Click);
            // 
            // button_ChangePermission
            // 
            this.button_ChangePermission.Location = new System.Drawing.Point(122, 298);
            this.button_ChangePermission.Name = "button_ChangePermission";
            this.button_ChangePermission.Size = new System.Drawing.Size(236, 60);
            this.button_ChangePermission.TabIndex = 4;
            this.button_ChangePermission.Text = "Change Permission";
            this.button_ChangePermission.UseVisualStyleBackColor = true;
            this.button_ChangePermission.Click += new System.EventHandler(this.button5_Click);
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(365, 53);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(197, 37);
            this.label_Headline.TabIndex = 5;
            this.label_Headline.Text = "Admin Menu";
            // 
            // button_LogOut
            // 
            this.button_LogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_LogOut.Location = new System.Drawing.Point(581, 410);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(226, 52);
            this.button_LogOut.TabIndex = 6;
            this.button_LogOut.Text = "Log Out";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_LogOut;
            this.ClientSize = new System.Drawing.Size(888, 518);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.button_ChangePermission);
            this.Controls.Add(this.button_RemoveClassroom);
            this.Controls.Add(this.button_AddClassroom);
            this.Controls.Add(this.button_DeleteUser);
            this.Controls.Add(this.button_AddUser);
            this.Name = "FormMenuAdmin";
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.Button button_DeleteUser;
        private System.Windows.Forms.Button button_AddClassroom;
        private System.Windows.Forms.Button button_RemoveClassroom;
        private System.Windows.Forms.Button button_ChangePermission;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button button_LogOut;
    }
}