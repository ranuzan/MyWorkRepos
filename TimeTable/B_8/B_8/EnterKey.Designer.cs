namespace B_8
{
    partial class EnterKey
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Key_textBox = new System.Windows.Forms.TextBox();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.Return = new System.Windows.Forms.PictureBox();
            this.EXIT = new System.Windows.Forms.PictureBox();
            this.confirm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Return)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirm)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(259, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(247, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 33);
            this.label1.TabIndex = 15;
            this.label1.Text = "Email";
            // 
            // Key_textBox
            // 
            this.Key_textBox.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Key_textBox.Location = new System.Drawing.Point(403, 290);
            this.Key_textBox.Name = "Key_textBox";
            this.Key_textBox.Size = new System.Drawing.Size(202, 29);
            this.Key_textBox.TabIndex = 14;
            this.Key_textBox.TextChanged += new System.EventHandler(this.Key_textBox_TextChanged);
            // 
            // Email_textBox
            // 
            this.Email_textBox.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Email_textBox.Location = new System.Drawing.Point(403, 216);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(202, 29);
            this.Email_textBox.TabIndex = 13;
            this.Email_textBox.TextChanged += new System.EventHandler(this.Email_textBox_TextChanged);
            // 
            // Return
            // 
            this.Return.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Return.Image = global::B_8.Properties.Resources.Return;
            this.Return.Location = new System.Drawing.Point(265, 363);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(59, 70);
            this.Return.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Return.TabIndex = 19;
            this.Return.TabStop = false;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // EXIT
            // 
            this.EXIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EXIT.Image = global::B_8.Properties.Resources.exit1;
            this.EXIT.Location = new System.Drawing.Point(177, 120);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(95, 35);
            this.EXIT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EXIT.TabIndex = 18;
            this.EXIT.TabStop = false;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // confirm
            // 
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.Image = global::B_8.Properties.Resources.confirm;
            this.confirm.Location = new System.Drawing.Point(357, 363);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(154, 70);
            this.confirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.confirm.TabIndex = 17;
            this.confirm.TabStop = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // EnterKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key_textBox);
            this.Controls.Add(this.Email_textBox);
            this.Name = "EnterKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterKey";
            ((System.ComponentModel.ISupportInitialize)(this.Return)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EXIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Return;
        private System.Windows.Forms.PictureBox EXIT;
        private System.Windows.Forms.PictureBox confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Key_textBox;
        private System.Windows.Forms.TextBox Email_textBox;
    }
}