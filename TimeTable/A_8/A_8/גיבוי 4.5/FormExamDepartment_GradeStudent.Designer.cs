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
            this.textBox_studentID = new System.Windows.Forms.TextBox();
            this.label_studentID = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.comboBox_CourseList = new System.Windows.Forms.ComboBox();
            this.label_Course = new System.Windows.Forms.Label();
            this.textBox_grade = new System.Windows.Forms.TextBox();
            this.label_grade = new System.Windows.Forms.Label();
            this.button_Accept = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_studentID
            // 
            this.textBox_studentID.Location = new System.Drawing.Point(104, 55);
            this.textBox_studentID.Name = "textBox_studentID";
            this.textBox_studentID.Size = new System.Drawing.Size(125, 22);
            this.textBox_studentID.TabIndex = 0;
            this.textBox_studentID.TextChanged += new System.EventHandler(this.textBox_studentID_TextChanged);
            this.textBox_studentID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_studentID_KeyPress);
            // 
            // label_studentID
            // 
            this.label_studentID.AutoSize = true;
            this.label_studentID.Location = new System.Drawing.Point(77, 58);
            this.label_studentID.Name = "label_studentID";
            this.label_studentID.Size = new System.Drawing.Size(21, 17);
            this.label_studentID.TabIndex = 1;
            this.label_studentID.Text = "ID";
            // 
            // button_OK
            // 
            this.button_OK.Enabled = false;
            this.button_OK.Location = new System.Drawing.Point(104, 141);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(96, 33);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // comboBox_CourseList
            // 
            this.comboBox_CourseList.FormattingEnabled = true;
            this.comboBox_CourseList.Location = new System.Drawing.Point(104, 55);
            this.comboBox_CourseList.Name = "comboBox_CourseList";
            this.comboBox_CourseList.Size = new System.Drawing.Size(125, 24);
            this.comboBox_CourseList.TabIndex = 3;
            this.comboBox_CourseList.Visible = false;
            this.comboBox_CourseList.SelectedIndexChanged += new System.EventHandler(this.comboBox_CourseList_SelectedIndexChanged);
            // 
            // label_Course
            // 
            this.label_Course.AutoSize = true;
            this.label_Course.Location = new System.Drawing.Point(45, 58);
            this.label_Course.Name = "label_Course";
            this.label_Course.Size = new System.Drawing.Size(53, 17);
            this.label_Course.TabIndex = 4;
            this.label_Course.Text = "Course";
            this.label_Course.Visible = false;
            // 
            // textBox_grade
            // 
            this.textBox_grade.Location = new System.Drawing.Point(147, 96);
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
            this.label_grade.Location = new System.Drawing.Point(93, 99);
            this.label_grade.Name = "label_grade";
            this.label_grade.Size = new System.Drawing.Size(48, 17);
            this.label_grade.TabIndex = 6;
            this.label_grade.Text = "Grade";
            this.label_grade.Visible = false;
            // 
            // button_Accept
            // 
            this.button_Accept.Enabled = false;
            this.button_Accept.Location = new System.Drawing.Point(104, 141);
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
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Back.Location = new System.Drawing.Point(260, 23);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(47, 43);
            this.button_Back.TabIndex = 22;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormExamDepartment_GradeStudent
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Back;
            this.ClientSize = new System.Drawing.Size(319, 199);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.label_grade);
            this.Controls.Add(this.textBox_grade);
            this.Controls.Add(this.label_Course);
            this.Controls.Add(this.comboBox_CourseList);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_studentID);
            this.Controls.Add(this.textBox_studentID);
            this.Name = "FormExamDepartment_GradeStudent";
            this.Text = "FormExamDepartmentGradeStudent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExamDepartmentGradeStudent_FormClosing);
            this.Load += new System.EventHandler(this.FormExamDepartment_GradeStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_studentID;
        private System.Windows.Forms.Label label_studentID;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ComboBox comboBox_CourseList;
        private System.Windows.Forms.Label label_Course;
        private System.Windows.Forms.TextBox textBox_grade;
        private System.Windows.Forms.Label label_grade;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Button button_Back;
    }
}