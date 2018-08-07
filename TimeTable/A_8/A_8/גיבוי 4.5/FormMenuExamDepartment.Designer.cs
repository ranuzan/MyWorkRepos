namespace A_8
{
    partial class FormMenuExamDepartment
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
            this.button_LogOut = new System.Windows.Forms.Button();
            this.button_GradeStudent = new System.Windows.Forms.Button();
            this.label_Headline = new System.Windows.Forms.Label();
            this.button_SearchCourse = new System.Windows.Forms.Button();
            this.button_departmentFiltering = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_LogOut
            // 
            this.button_LogOut.Location = new System.Drawing.Point(12, 33);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(123, 45);
            this.button_LogOut.TabIndex = 0;
            this.button_LogOut.Text = "Logout";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_GradeStudent
            // 
            this.button_GradeStudent.Location = new System.Drawing.Point(268, 146);
            this.button_GradeStudent.Name = "button_GradeStudent";
            this.button_GradeStudent.Size = new System.Drawing.Size(124, 51);
            this.button_GradeStudent.TabIndex = 1;
            this.button_GradeStudent.Text = "Grade Student";
            this.button_GradeStudent.UseVisualStyleBackColor = true;
            this.button_GradeStudent.Click += new System.EventHandler(this.button_GradeStudent_Click);
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(184, 33);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(290, 39);
            this.label_Headline.TabIndex = 2;
            this.label_Headline.Text = "Exam Department";
            // 
            // button_SearchCourse
            // 
            this.button_SearchCourse.Location = new System.Drawing.Point(268, 218);
            this.button_SearchCourse.Name = "button_SearchCourse";
            this.button_SearchCourse.Size = new System.Drawing.Size(124, 51);
            this.button_SearchCourse.TabIndex = 3;
            this.button_SearchCourse.Text = "Search Course";
            this.button_SearchCourse.UseVisualStyleBackColor = true;
            this.button_SearchCourse.Click += new System.EventHandler(this.button_SearchCourse_Click);
            // 
            // button_departmentFiltering
            // 
            this.button_departmentFiltering.Location = new System.Drawing.Point(268, 291);
            this.button_departmentFiltering.Name = "button_departmentFiltering";
            this.button_departmentFiltering.Size = new System.Drawing.Size(124, 54);
            this.button_departmentFiltering.TabIndex = 4;
            this.button_departmentFiltering.Text = "Show courses by department";
            this.button_departmentFiltering.UseVisualStyleBackColor = true;
            this.button_departmentFiltering.Click += new System.EventHandler(this.button_departmentFiltering_Click);
            // 
            // FormMenuExamDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::A_8.Properties.Resources.data_analytics;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button_LogOut;
            this.ClientSize = new System.Drawing.Size(567, 415);
            this.Controls.Add(this.button_departmentFiltering);
            this.Controls.Add(this.button_SearchCourse);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.button_GradeStudent);
            this.Controls.Add(this.button_LogOut);
            this.Name = "FormMenuExamDepartment";
            this.Text = "ExamDepratment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuExamDepratment_FormClosing);
            this.Load += new System.EventHandler(this.FormMenuExamDepratment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Button button_GradeStudent;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button button_SearchCourse;
        private System.Windows.Forms.Button button_departmentFiltering;
    }
}