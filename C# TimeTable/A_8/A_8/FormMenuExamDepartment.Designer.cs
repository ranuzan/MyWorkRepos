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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuExamDepartment));
            this.button_LogOut = new System.Windows.Forms.Button();
            this.button_GradeStudent = new System.Windows.Forms.Button();
            this.button_SearchCourse = new System.Windows.Forms.Button();
            this.button_departmentFiltering = new System.Windows.Forms.Button();
            this.buttonReportError = new System.Windows.Forms.Button();
            this.label_Headline = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_LogOut
            // 
            this.button_LogOut.BackColor = System.Drawing.Color.Transparent;
            this.button_LogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LogOut.ForeColor = System.Drawing.Color.White;
            this.button_LogOut.Image = global::A_8.Properties.Resources.logoff;
            this.button_LogOut.Location = new System.Drawing.Point(391, 12);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(2);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(20, 20);
            this.button_LogOut.TabIndex = 0;
            this.button_LogOut.UseVisualStyleBackColor = false;
            this.button_LogOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_GradeStudent
            // 
            this.button_GradeStudent.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_GradeStudent.FlatAppearance.BorderColor = System.Drawing.Color.MintCream;
            this.button_GradeStudent.FlatAppearance.BorderSize = 0;
            this.button_GradeStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_GradeStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_GradeStudent.ForeColor = System.Drawing.Color.White;
            this.button_GradeStudent.Image = ((System.Drawing.Image)(resources.GetObject("button_GradeStudent.Image")));
            this.button_GradeStudent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_GradeStudent.Location = new System.Drawing.Point(27, 71);
            this.button_GradeStudent.Margin = new System.Windows.Forms.Padding(2);
            this.button_GradeStudent.Name = "button_GradeStudent";
            this.button_GradeStudent.Size = new System.Drawing.Size(200, 100);
            this.button_GradeStudent.TabIndex = 1;
            this.button_GradeStudent.Text = "Grade Student";
            this.button_GradeStudent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_GradeStudent.UseCompatibleTextRendering = true;
            this.button_GradeStudent.UseVisualStyleBackColor = false;
            this.button_GradeStudent.Click += new System.EventHandler(this.button_GradeStudent_Click);
            // 
            // button_SearchCourse
            // 
            this.button_SearchCourse.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_SearchCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SearchCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_SearchCourse.ForeColor = System.Drawing.Color.White;
            this.button_SearchCourse.Image = ((System.Drawing.Image)(resources.GetObject("button_SearchCourse.Image")));
            this.button_SearchCourse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_SearchCourse.Location = new System.Drawing.Point(234, 71);
            this.button_SearchCourse.Margin = new System.Windows.Forms.Padding(2);
            this.button_SearchCourse.Name = "button_SearchCourse";
            this.button_SearchCourse.Size = new System.Drawing.Size(200, 100);
            this.button_SearchCourse.TabIndex = 3;
            this.button_SearchCourse.Text = "Search Course";
            this.button_SearchCourse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_SearchCourse.UseVisualStyleBackColor = false;
            this.button_SearchCourse.Click += new System.EventHandler(this.button_SearchCourse_Click);
            // 
            // button_departmentFiltering
            // 
            this.button_departmentFiltering.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_departmentFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_departmentFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_departmentFiltering.ForeColor = System.Drawing.Color.White;
            this.button_departmentFiltering.Image = ((System.Drawing.Image)(resources.GetObject("button_departmentFiltering.Image")));
            this.button_departmentFiltering.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_departmentFiltering.Location = new System.Drawing.Point(234, 178);
            this.button_departmentFiltering.Margin = new System.Windows.Forms.Padding(2);
            this.button_departmentFiltering.Name = "button_departmentFiltering";
            this.button_departmentFiltering.Size = new System.Drawing.Size(200, 100);
            this.button_departmentFiltering.TabIndex = 4;
            this.button_departmentFiltering.Text = "Filter Courses by Depart.";
            this.button_departmentFiltering.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_departmentFiltering.UseVisualStyleBackColor = false;
            this.button_departmentFiltering.Click += new System.EventHandler(this.button_departmentFiltering_Click);
            // 
            // buttonReportError
            // 
            this.buttonReportError.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonReportError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonReportError.ForeColor = System.Drawing.Color.White;
            this.buttonReportError.Image = global::A_8.Properties.Resources.error;
            this.buttonReportError.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportError.Location = new System.Drawing.Point(27, 178);
            this.buttonReportError.Name = "buttonReportError";
            this.buttonReportError.Size = new System.Drawing.Size(200, 100);
            this.buttonReportError.TabIndex = 5;
            this.buttonReportError.Text = "Report Error";
            this.buttonReportError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportError.UseVisualStyleBackColor = false;
            this.buttonReportError.Click += new System.EventHandler(this.buttonReportError_Click);
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Century Gothic", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Headline.Location = new System.Drawing.Point(21, 18);
            this.label_Headline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(313, 31);
            this.label_Headline.TabIndex = 7;
            this.label_Headline.Text = "Exam Department Menu";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = global::A_8.Properties.Resources.exit;
            this.buttonExit.Location = new System.Drawing.Point(416, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(20, 20);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMenuExamDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button_LogOut;
            this.ClientSize = new System.Drawing.Size(464, 306);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.buttonReportError);
            this.Controls.Add(this.button_departmentFiltering);
            this.Controls.Add(this.button_SearchCourse);
            this.Controls.Add(this.button_GradeStudent);
            this.Controls.Add(this.button_LogOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMenuExamDepartment";
            this.Text = "ExamDepratment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.Button button_GradeStudent;
        private System.Windows.Forms.Button button_SearchCourse;
        private System.Windows.Forms.Button button_departmentFiltering;
        private System.Windows.Forms.Button buttonReportError;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button buttonExit;
    }
}