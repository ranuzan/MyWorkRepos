namespace A_8
{
    partial class FormAdmin_RemoveClassroom
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
            this.textBox_ClassName = new System.Windows.Forms.TextBox();
            this.label_ClassName = new System.Windows.Forms.Label();
            this.checkBox_Accept = new System.Windows.Forms.CheckBox();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(35, 20);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(183, 25);
            this.label_Headline.TabIndex = 0;
            this.label_Headline.Text = "Remove Classroom";
            // 
            // textBox_ClassName
            // 
            this.textBox_ClassName.Location = new System.Drawing.Point(118, 63);
            this.textBox_ClassName.Name = "textBox_ClassName";
            this.textBox_ClassName.Size = new System.Drawing.Size(100, 22);
            this.textBox_ClassName.TabIndex = 1;
            this.textBox_ClassName.TextChanged += new System.EventHandler(this.textBox_ClassName_TextChanged);
            this.textBox_ClassName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ClassName_KeyPress);
            // 
            // label_ClassName
            // 
            this.label_ClassName.AutoSize = true;
            this.label_ClassName.Location = new System.Drawing.Point(29, 66);
            this.label_ClassName.Name = "label_ClassName";
            this.label_ClassName.Size = new System.Drawing.Size(83, 17);
            this.label_ClassName.TabIndex = 2;
            this.label_ClassName.Text = "Class Name";
            // 
            // checkBox_Accept
            // 
            this.checkBox_Accept.AutoSize = true;
            this.checkBox_Accept.Location = new System.Drawing.Point(84, 112);
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
            this.button_Accept.Location = new System.Drawing.Point(50, 150);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(102, 50);
            this.button_Accept.TabIndex = 4;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(171, 150);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 50);
            this.button_Back.TabIndex = 22;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormAdminRemoveClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 223);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.checkBox_Accept);
            this.Controls.Add(this.label_ClassName);
            this.Controls.Add(this.textBox_ClassName);
            this.Controls.Add(this.label_Headline);
            this.Name = "FormAdminRemoveClassroom";
            this.Text = "FormAdminRemoveClassroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminRemoveClassroom_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.TextBox textBox_ClassName;
        private System.Windows.Forms.Label label_ClassName;
        private System.Windows.Forms.CheckBox checkBox_Accept;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Back;
    }
}