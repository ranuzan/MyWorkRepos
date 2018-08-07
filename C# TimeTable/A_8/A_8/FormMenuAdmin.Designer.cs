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
            this.label_Headline = new System.Windows.Forms.Label();
            this.labelNotificationCount = new System.Windows.Forms.Label();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonViewErrors = new System.Windows.Forms.Button();
            this.button_ChangePermission = new System.Windows.Forms.Button();
            this.button_RemoveClassroom = new System.Windows.Forms.Button();
            this.button_AddClassroom = new System.Windows.Forms.Button();
            this.button_DeleteUser = new System.Windows.Forms.Button();
            this.button_AddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Headline.Location = new System.Drawing.Point(21, 18);
            this.label_Headline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(173, 31);
            this.label_Headline.TabIndex = 5;
            this.label_Headline.Text = "Admin Menu";
            // 
            // labelNotificationCount
            // 
            this.labelNotificationCount.AutoSize = true;
            this.labelNotificationCount.BackColor = System.Drawing.Color.Red;
            this.labelNotificationCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNotificationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotificationCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNotificationCount.Location = new System.Drawing.Point(623, 179);
            this.labelNotificationCount.Name = "labelNotificationCount";
            this.labelNotificationCount.Size = new System.Drawing.Size(17, 18);
            this.labelNotificationCount.TabIndex = 9;
            this.labelNotificationCount.Text = "1";
            this.labelNotificationCount.Visible = false;
            // 
            // button_LogOut
            // 
            this.button_LogOut.BackColor = System.Drawing.Color.Transparent;
            this.button_LogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LogOut.ForeColor = System.Drawing.Color.White;
            this.button_LogOut.Image = global::A_8.Properties.Resources.logoff;
            this.button_LogOut.Location = new System.Drawing.Point(596, 12);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(2);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(20, 20);
            this.button_LogOut.TabIndex = 6;
            this.button_LogOut.UseVisualStyleBackColor = false;
            this.button_LogOut.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = global::A_8.Properties.Resources.exit;
            this.buttonExit.Location = new System.Drawing.Point(621, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(20, 20);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonViewErrors
            // 
            this.buttonViewErrors.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonViewErrors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonViewErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonViewErrors.ForeColor = System.Drawing.Color.White;
            this.buttonViewErrors.Image = global::A_8.Properties.Resources.error;
            this.buttonViewErrors.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonViewErrors.Location = new System.Drawing.Point(441, 178);
            this.buttonViewErrors.Margin = new System.Windows.Forms.Padding(2);
            this.buttonViewErrors.Name = "buttonViewErrors";
            this.buttonViewErrors.Size = new System.Drawing.Size(200, 100);
            this.buttonViewErrors.TabIndex = 7;
            this.buttonViewErrors.Text = "Errors";
            this.buttonViewErrors.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonViewErrors.UseVisualStyleBackColor = false;
            this.buttonViewErrors.Click += new System.EventHandler(this.buttonViewErrors_Click);
            // 
            // button_ChangePermission
            // 
            this.button_ChangePermission.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_ChangePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ChangePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ChangePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_ChangePermission.ForeColor = System.Drawing.Color.White;
            this.button_ChangePermission.Image = global::A_8.Properties.Resources.changePermission;
            this.button_ChangePermission.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_ChangePermission.Location = new System.Drawing.Point(441, 71);
            this.button_ChangePermission.Margin = new System.Windows.Forms.Padding(2);
            this.button_ChangePermission.Name = "button_ChangePermission";
            this.button_ChangePermission.Size = new System.Drawing.Size(200, 100);
            this.button_ChangePermission.TabIndex = 4;
            this.button_ChangePermission.Text = "Change Permission";
            this.button_ChangePermission.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_ChangePermission.UseVisualStyleBackColor = false;
            this.button_ChangePermission.Click += new System.EventHandler(this.button5_Click);
            // 
            // button_RemoveClassroom
            // 
            this.button_RemoveClassroom.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_RemoveClassroom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoveClassroom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RemoveClassroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_RemoveClassroom.ForeColor = System.Drawing.Color.White;
            this.button_RemoveClassroom.Image = global::A_8.Properties.Resources.removeClassroom;
            this.button_RemoveClassroom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_RemoveClassroom.Location = new System.Drawing.Point(234, 178);
            this.button_RemoveClassroom.Margin = new System.Windows.Forms.Padding(2);
            this.button_RemoveClassroom.Name = "button_RemoveClassroom";
            this.button_RemoveClassroom.Size = new System.Drawing.Size(200, 100);
            this.button_RemoveClassroom.TabIndex = 3;
            this.button_RemoveClassroom.Text = "Remove Classroom";
            this.button_RemoveClassroom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_RemoveClassroom.UseVisualStyleBackColor = false;
            this.button_RemoveClassroom.Click += new System.EventHandler(this.button_RemoveClassroom_Click);
            // 
            // button_AddClassroom
            // 
            this.button_AddClassroom.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_AddClassroom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_AddClassroom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddClassroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_AddClassroom.ForeColor = System.Drawing.Color.White;
            this.button_AddClassroom.Image = global::A_8.Properties.Resources.addClassroom;
            this.button_AddClassroom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_AddClassroom.Location = new System.Drawing.Point(234, 71);
            this.button_AddClassroom.Margin = new System.Windows.Forms.Padding(2);
            this.button_AddClassroom.Name = "button_AddClassroom";
            this.button_AddClassroom.Size = new System.Drawing.Size(200, 100);
            this.button_AddClassroom.TabIndex = 2;
            this.button_AddClassroom.Text = "Add Classroom";
            this.button_AddClassroom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_AddClassroom.UseVisualStyleBackColor = false;
            this.button_AddClassroom.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_DeleteUser
            // 
            this.button_DeleteUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_DeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_DeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_DeleteUser.ForeColor = System.Drawing.Color.White;
            this.button_DeleteUser.Image = global::A_8.Properties.Resources.removeUser;
            this.button_DeleteUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DeleteUser.Location = new System.Drawing.Point(27, 178);
            this.button_DeleteUser.Margin = new System.Windows.Forms.Padding(2);
            this.button_DeleteUser.Name = "button_DeleteUser";
            this.button_DeleteUser.Size = new System.Drawing.Size(200, 100);
            this.button_DeleteUser.TabIndex = 1;
            this.button_DeleteUser.Text = "Remove User";
            this.button_DeleteUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_DeleteUser.UseVisualStyleBackColor = false;
            this.button_DeleteUser.Click += new System.EventHandler(this.button_DeleteUser_Click);
            // 
            // button_AddUser
            // 
            this.button_AddUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_AddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_AddUser.ForeColor = System.Drawing.Color.White;
            this.button_AddUser.Image = global::A_8.Properties.Resources.addUser;
            this.button_AddUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_AddUser.Location = new System.Drawing.Point(27, 71);
            this.button_AddUser.Margin = new System.Windows.Forms.Padding(2);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(200, 100);
            this.button_AddUser.TabIndex = 0;
            this.button_AddUser.Text = "Add User";
            this.button_AddUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_AddUser.UseVisualStyleBackColor = false;
            this.button_AddUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button_LogOut;
            this.ClientSize = new System.Drawing.Size(669, 306);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelNotificationCount);
            this.Controls.Add(this.buttonViewErrors);
            this.Controls.Add(this.button_LogOut);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.button_ChangePermission);
            this.Controls.Add(this.button_RemoveClassroom);
            this.Controls.Add(this.button_AddClassroom);
            this.Controls.Add(this.button_DeleteUser);
            this.Controls.Add(this.button_AddUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuAdmin_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuAdmin_Load);
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
        private System.Windows.Forms.Button buttonViewErrors;
        private System.Windows.Forms.Label labelNotificationCount;
        private System.Windows.Forms.Button buttonExit;
    }
}