namespace A_8
{
    partial class FormExamDepartment_ShowCourse
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_studentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_gradeStudent = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_CourseID,
            this.Column_CourseName,
            this.Column_studentID,
            this.Column_StudentName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(789, 316);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column_CourseID
            // 
            this.Column_CourseID.HeaderText = "Course ID";
            this.Column_CourseID.Name = "Column_CourseID";
            this.Column_CourseID.Width = 185;
            // 
            // Column_CourseName
            // 
            this.Column_CourseName.HeaderText = "Course Name";
            this.Column_CourseName.Name = "Column_CourseName";
            this.Column_CourseName.Width = 185;
            // 
            // Column_studentID
            // 
            this.Column_studentID.HeaderText = "Student ID";
            this.Column_studentID.Name = "Column_studentID";
            this.Column_studentID.Width = 185;
            // 
            // Column_StudentName
            // 
            this.Column_StudentName.HeaderText = "Student Name";
            this.Column_StudentName.Name = "Column_StudentName";
            this.Column_StudentName.Width = 185;
            // 
            // button_gradeStudent
            // 
            this.button_gradeStudent.Location = new System.Drawing.Point(333, 449);
            this.button_gradeStudent.Name = "button_gradeStudent";
            this.button_gradeStudent.Size = new System.Drawing.Size(134, 58);
            this.button_gradeStudent.TabIndex = 1;
            this.button_gradeStudent.Text = "Grade this student";
            this.button_gradeStudent.UseVisualStyleBackColor = true;
            this.button_gradeStudent.Click += new System.EventHandler(this.button_GradeStudent_Click_1);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(713, 28);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 24;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormExamDepartment_ShowCourse
            // 
            this.AcceptButton = this.button_gradeStudent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(813, 519);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_gradeStudent);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormExamDepartment_ShowCourse";
            this.Text = "FormExamDepartment_ShowCourse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExamDepartment_ShowCourse_FormClosing);
            this.Load += new System.EventHandler(this.FormExamDepartment_ShowCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_studentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_StudentName;
        private System.Windows.Forms.Button button_gradeStudent;
        private System.Windows.Forms.Button button_Back;
    }
}