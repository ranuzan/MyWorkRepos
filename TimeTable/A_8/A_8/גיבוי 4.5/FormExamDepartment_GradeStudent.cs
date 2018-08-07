using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{
    public partial class FormExamDepartment_GradeStudent : Form
    {
        public FormExamDepartment_GradeStudent(int course_ID = 0,int student_ID=0)
        {
            InitializeComponent();
            textBox_studentID.MaxLength = 9;
            textBox_grade.MaxLength = 3;
            comboBox_CourseList.DropDownStyle = ComboBoxStyle.DropDownList;
            if (student_ID != 0 && course_ID != 0)
            {
                
                textBox_studentID.Text =Convert.ToString(student_ID);
                textBox_studentID.Visible = false;
                comboBox_CourseList.Items.Add(Convert.ToString(SQLFunctions.covertCourseIDtoCourseName(course_ID)));
                comboBox_CourseList.SelectedIndex = 0;
                comboBox_CourseList.Visible = false;
                label_studentID.Visible = false;
                textBox_grade.Visible = true;
                label_grade.Visible = true;
                button_OK.Visible = false;
                button_Accept.Visible = true;
             
            }
        }

        private void textBox_studentID_TextChanged(object sender, EventArgs e)
        {
            if (textBox_studentID.TextLength > 8)
            {
                button_OK.Enabled = true;
            }
            else
            {
                button_OK.Enabled = false;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            List<string> coursesNames = new List<string>();
            List<int> coursesID = new List<int>();
            int flag = 0;
            if (SQLFunctions.checkExistsUsers(Convert.ToInt32(textBox_studentID.Text)) == true)
            {
                int j = 0;
                comboBox_CourseList.Visible = true;
                label_Course.Visible = true;
                textBox_studentID.Visible = false;
                button_OK.Visible = false;
                label_studentID.Visible = false;
                button_Accept.Visible = true;
                AcceptButton = button_Accept;
                List<int> lecturesList = SQLFunctions.findStudentLecturesIDs(Convert.ToInt32(textBox_studentID.Text));
                for (int i = 0; i < lecturesList.Count; i++)
                {
                    flag = 0;
                    for (j = 0; j < coursesID.Count; j++)
                        if (Convert.ToInt32(SQLFunctions.findLectureProperties(lecturesList[i])[2]) == coursesID[j])
                            flag = 1;
                    if (flag == 0)
                    {  
                       coursesID.Add(Convert.ToInt32(SQLFunctions.findLectureProperties(lecturesList[i])[2]));
                       coursesNames.Add(SQLFunctions.findCourseProperties(coursesID[j])[0]);
                    }
                }
                for (int i = 0; i < coursesNames.Count; i++)
                {
                    comboBox_CourseList.Items.Add(coursesNames[i]);
                }
            }
            else
            {
                MessageBox.Show("This student isnt registered");
            }
        }

        private void FormExamDepartmentGradeStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox_CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_grade.Visible = true;
            label_grade.Visible = true;
        }

        private void textBox_studentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_grade_TextChanged(object sender, EventArgs e)
        {
            if (textBox_grade.TextLength > 1)
            {
                button_Accept.Enabled = true;
            }
            else
            {
                button_Accept.Enabled = false;
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(textBox_grade.Text) < 0 || Convert.ToInt32(textBox_grade.Text) > 100)
            {
                MessageBox.Show("Invalid grade");
            }
            else if (SQLFunctions.isStudentGraded(Convert.ToInt32(textBox_studentID.Text), SQLFunctions.covertCourseNametoCourseID(comboBox_CourseList.Text)) == true)
            {
                SQLFunctions.updateGradeToStudent(Convert.ToInt32(textBox_studentID.Text), SQLFunctions.covertCourseNametoCourseID(comboBox_CourseList.Text), Convert.ToInt32(textBox_grade.Text));
                MessageBox.Show("Student with the ID " + textBox_studentID.Text + " old grade was override, with the grade " + textBox_grade.Text + " in course " + comboBox_CourseList.Text);
                this.Hide();
                FormMenuExamDepartment examDepartment = new FormMenuExamDepartment();
                examDepartment.Show();
            }
            else
            {
              
                SQLFunctions.addGradeToStudent(Convert.ToInt32(textBox_studentID.Text), SQLFunctions.covertCourseNametoCourseID(comboBox_CourseList.Text), Convert.ToInt32(textBox_grade.Text));
                MessageBox.Show("Student with the ID " + textBox_studentID.Text + " was graded " + textBox_grade.Text + " in course " + comboBox_CourseList.Text);
                this.Hide();
                FormMenuExamDepartment examDepartment = new FormMenuExamDepartment();
                examDepartment.Show();
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuExamDepartment examDepartment = new FormMenuExamDepartment();
            examDepartment.Show();
        }

        private void FormExamDepartment_GradeStudent_Load(object sender, EventArgs e)
        {

        }
    }
    
}
