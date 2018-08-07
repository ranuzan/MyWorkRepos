namespace A_8
{
    partial class FormReportError
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.button_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(73, 79);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(35, 17);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Title";
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(29, 117);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(79, 17);
            this.label_description.TabIndex = 1;
            this.label_description.Text = "Description";
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(126, 76);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(313, 22);
            this.textBox_title.TabIndex = 2;
            this.textBox_title.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(126, 114);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(313, 274);
            this.textBox_description.TabIndex = 3;
            // 
            // button_Submit
            // 
            this.button_Submit.Enabled = false;
            this.button_Submit.Location = new System.Drawing.Point(126, 422);
            this.button_Submit.Name = "button_Submit";
            this.button_Submit.Size = new System.Drawing.Size(139, 55);
            this.button_Submit.TabIndex = 4;
            this.button_Submit.Text = "Submit Error";
            this.button_Submit.UseVisualStyleBackColor = true;
            this.button_Submit.Click += new System.EventHandler(this.button_Submit_Click);
            // 
            // FormReportError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 519);
            this.Controls.Add(this.button_Submit);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label_title);
            this.Name = "FormReportError";
            this.Text = "FormAdmin_ErrorNotifications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_ErrorNotifications_FormClosing);
            this.Load += new System.EventHandler(this.FormReportError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Button button_Submit;
    }
}