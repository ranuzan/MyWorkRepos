namespace A_8
{
    partial class FormExamDepartment_SearchCourse
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
            this.textBox_courseID = new System.Windows.Forms.TextBox();
            this.label_courseID = new System.Windows.Forms.Label();
            this.label_Headline = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_courseID
            // 
            this.textBox_courseID.Location = new System.Drawing.Point(122, 63);
            this.textBox_courseID.Name = "textBox_courseID";
            this.textBox_courseID.Size = new System.Drawing.Size(114, 22);
            this.textBox_courseID.TabIndex = 0;
            this.textBox_courseID.TextChanged += new System.EventHandler(this.textBox_courseID_TextChanged);
            // 
            // label_courseID
            // 
            this.label_courseID.AutoSize = true;
            this.label_courseID.Location = new System.Drawing.Point(46, 66);
            this.label_courseID.Name = "label_courseID";
            this.label_courseID.Size = new System.Drawing.Size(70, 17);
            this.label_courseID.TabIndex = 1;
            this.label_courseID.Text = "Course ID";
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(55, 9);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(181, 29);
            this.label_Headline.TabIndex = 2;
            this.label_Headline.Text = "Search Course";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(80, 115);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(109, 38);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(214, 115);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 38);
            this.button_Back.TabIndex = 23;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormExamDepartment_SearchCourse
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(282, 186);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.label_courseID);
            this.Controls.Add(this.textBox_courseID);
            this.Name = "FormExamDepartment_SearchCourse";
            this.Text = "FormExamDepartment_SearchCourse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExamDepartment_SearchCourse_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_courseID;
        private System.Windows.Forms.Label label_courseID;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Back;
    }
}