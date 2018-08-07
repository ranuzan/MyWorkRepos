namespace A_8
{
    partial class FormExamDepartment_GradeStudent
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
            this.comboBox_CourseList = new System.Windows.Forms.ComboBox();
            this.label_Course = new System.Windows.Forms.Label();
            this.textBox_grade = new System.Windows.Forms.TextBox();
            this.label_grade = new System.Windows.Forms.Label();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_headline = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_CourseList
            // 
            this.comboBox_CourseList.FormattingEnabled = true;
            this.comboBox_CourseList.Location = new System.Drawing.Point(365, 247);
            this.comboBox_CourseList.Name = "comboBox_CourseList";
            this.comboBox_CourseList.Size = new System.Drawing.Size(125, 24);
            this.comboBox_CourseList.TabIndex = 3;
            this.comboBox_CourseList.Visible = false;
            this.comboBox_CourseList.SelectedIndexChanged += new System.EventHandler(this.comboBox_CourseList_SelectedIndexChanged);
            // 
            // label_Course
            // 
            this.label_Course.AutoSize = true;
            this.label_Course.Location = new System.Drawing.Point(298, 250);
            this.label_Course.Name = "label_Course";
            this.label_Course.Size = new System.Drawing.Size(53, 17);
            this.label_Course.TabIndex = 4;
            this.label_Course.Text = "Course";
            this.label_Course.Visible = false;
            // 
            // textBox_grade
            // 
            this.textBox_grade.Location = new System.Drawing.Point(365, 287);
            this.textBox_grade.Name = "textBox_grade";
            this.textBox_grade.Size = new System.Drawing.Size(53, 22);
            this.textBox_grade.TabIndex = 5;
            this.textBox_grade.Visible = false;
            this.textBox_grade.TextChanged += new System.EventHandler(this.textBox_grade_TextChanged);
            this.textBox_grade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_grade_KeyPress);
            // 
            // label_grade
            // 
            this.label_grade.AutoSize = true;
            this.label_grade.Location = new System.Drawing.Point(311, 290);
            this.label_grade.Name = "label_grade";
            this.label_grade.Size = new System.Drawing.Size(48, 17);
            this.label_grade.TabIndex = 6;
            this.label_grade.Text = "Grade";
            this.label_grade.Visible = false;
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(341, 328);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(96, 33);
            this.button_Accept.TabIndex = 7;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Visible = false;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(615, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 22;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(84, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(670, 179);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Student Name";
            this.columnHeader1.Width = 133;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Student ID";
            this.columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Year";
            this.columnHeader3.Width = 133;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Semester";
            this.columnHeader4.Width = 133;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Department";
            this.columnHeader5.Width = 133;
            // 
            // label_headline
            // 
            this.label_headline.AutoSize = true;
            this.label_headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_headline.Location = new System.Drawing.Point(278, 118);
            this.label_headline.Name = "label_headline";
            this.label_headline.Size = new System.Drawing.Size(230, 46);
            this.label_headline.TabIndex = 24;
            this.label_headline.Text = "Insert grade";
            this.label_headline.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 25;
            // 
            // FormExamDepartment_GradeStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(808, 363);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_headline);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.label_grade);
            this.Controls.Add(this.textBox_grade);
            this.Controls.Add(this.label_Course);
            this.Controls.Add(this.comboBox_CourseList);
            this.Name = "FormExamDepartment_GradeStudent";
            this.Text = "FormExamDepartmentGradeStudent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExamDepartmentGradeStudent_FormClosing);
            this.Load += new System.EventHandler(this.FormExamDepartment_GradeStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_CourseList;
        private System.Windows.Forms.Label label_Course;
        private System.Windows.Forms.TextBox textBox_grade;
        private System.Windows.Forms.Label label_grade;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label_headline;
        private System.Windows.Forms.TextBox textBox1;
    }
}