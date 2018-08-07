namespace A_8
{
    partial class FormExamDepartment_FilterCourses
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
            this.comboBox_Department = new System.Windows.Forms.ComboBox();
            this.label_Department = new System.Windows.Forms.Label();
            this.dataGridView_courses = new System.Windows.Forms.DataGridView();
            this.Column_courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PreReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LectureHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PracticeHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RecHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_GradeCourse = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_courses)).BeginInit();
            this.SuspendLayout();
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
            this.comboBox_Department.Location = new System.Drawing.Point(397, 58);
            this.comboBox_Department.Name = "comboBox_Department";
            this.comboBox_Department.Size = new System.Drawing.Size(214, 24);
            this.comboBox_Department.TabIndex = 0;
            this.comboBox_Department.SelectedIndexChanged += new System.EventHandler(this.comboBox_Department_SelectedIndexChanged);
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Location = new System.Drawing.Point(290, 61);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(82, 17);
            this.label_Department.TabIndex = 1;
            this.label_Department.Text = "Department";
            // 
            // dataGridView_courses
            // 
            this.dataGridView_courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_courses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_courseName,
            this.Column_CourseID,
            this.Column_PreReq,
            this.Column_Credits,
            this.Column_LectureHours,
            this.Column_PracticeHours,
            this.Column_RecHours,
            this.Column_Year,
            this.Column_Semester});
            this.dataGridView_courses.Location = new System.Drawing.Point(12, 137);
            this.dataGridView_courses.Name = "dataGridView_courses";
            this.dataGridView_courses.RowTemplate.Height = 24;
            this.dataGridView_courses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_courses.Size = new System.Drawing.Size(929, 333);
            this.dataGridView_courses.TabIndex = 2;
            this.dataGridView_courses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_courses_CellContentClick);
            this.dataGridView_courses.SelectionChanged += new System.EventHandler(this.dataGridView_courses_SelectionChanged);
            // 
            // Column_courseName
            // 
            this.Column_courseName.HeaderText = "Course Name";
            this.Column_courseName.Name = "Column_courseName";
            // 
            // Column_CourseID
            // 
            this.Column_CourseID.HeaderText = "Course ID";
            this.Column_CourseID.Name = "Column_CourseID";
            // 
            // Column_PreReq
            // 
            this.Column_PreReq.HeaderText = "Prerequisites";
            this.Column_PreReq.Name = "Column_PreReq";
            // 
            // Column_Credits
            // 
            this.Column_Credits.HeaderText = "Credits";
            this.Column_Credits.Name = "Column_Credits";
            // 
            // Column_LectureHours
            // 
            this.Column_LectureHours.HeaderText = "Lecture hours";
            this.Column_LectureHours.Name = "Column_LectureHours";
            // 
            // Column_PracticeHours
            // 
            this.Column_PracticeHours.HeaderText = "Practice Hours";
            this.Column_PracticeHours.Name = "Column_PracticeHours";
            // 
            // Column_RecHours
            // 
            this.Column_RecHours.HeaderText = "Reception hours";
            this.Column_RecHours.Name = "Column_RecHours";
            // 
            // Column_Year
            // 
            this.Column_Year.HeaderText = "Year";
            this.Column_Year.Name = "Column_Year";
            // 
            // Column_Semester
            // 
            this.Column_Semester.HeaderText = "Semester";
            this.Column_Semester.Name = "Column_Semester";
            // 
            // button_GradeCourse
            // 
            this.button_GradeCourse.Enabled = false;
            this.button_GradeCourse.Location = new System.Drawing.Point(63, 51);
            this.button_GradeCourse.Name = "button_GradeCourse";
            this.button_GradeCourse.Size = new System.Drawing.Size(154, 37);
            this.button_GradeCourse.TabIndex = 24;
            this.button_GradeCourse.Text = "Grade This Course";
            this.button_GradeCourse.UseVisualStyleBackColor = true;
            this.button_GradeCourse.Click += new System.EventHandler(this.button_GradeCourse_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(867, 48);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 23;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormExamDepartment_FilterCourses
            // 
            this.AcceptButton = this.button_GradeCourse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(944, 497);
            this.Controls.Add(this.button_GradeCourse);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.dataGridView_courses);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.comboBox_Department);
            this.Name = "FormExamDepartment_FilterCourses";
            this.Text = "FormExamDepartment_FilterCourse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExamDepartment_FilterCourses_FormClosing);
            this.Load += new System.EventHandler(this.FormExamDepartment_FilterCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_courses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Department;
        private System.Windows.Forms.Label label_Department;
        private System.Windows.Forms.DataGridView dataGridView_courses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PreReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LectureHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PracticeHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RecHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Semester;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_GradeCourse;
    }
}