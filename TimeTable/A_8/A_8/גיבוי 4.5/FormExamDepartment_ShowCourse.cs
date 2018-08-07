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
    public partial class FormExamDepartment_ShowCourse : Form
    {
        int courseID;
        int studentID;
        string courseName;
        List<int> LecturesID = new List<int>();
        List<int> StudentsID = new List<int>();
        public FormExamDepartment_ShowCourse(int course_ID)
        {
            InitializeComponent();
            courseID = course_ID;
            LecturesID = SQLFunctions.getStudentDetailsByCourseID(courseID);
            courseName = SQLFunctions.covertCourseIDtoCourseName(courseID);
            if (LecturesID != null && StudentsID != null)
            {
                for (int i = 0; i < LecturesID.Count; i++)
                {
                    if (SQLFunctions.getStudentsIDfromLectureID(LecturesID[i]) != null)
                    {
                        if (StudentsID.Count == 0)
                        {
                            StudentsID = (SQLFunctions.getStudentsIDfromLectureID(LecturesID[i]));
                        }
                        else
                        {
                            StudentsID.Union(SQLFunctions.getStudentsIDfromLectureID(LecturesID[i])).ToList();
                        }
                    }
                }
                for (int i = 0; i < StudentsID.Count; i++)
                {
                    dataGridView1.Rows.Add(courseID, courseName, StudentsID[i], SQLFunctions.covertStudentIDtoStudentLastName(Convert.ToInt32(StudentsID[i])) + " " + SQLFunctions.covertStudentIDtoStudentFirstName(Convert.ToInt32(StudentsID[i])));
                }
            }
        }
        private void FormExamDepartment_ShowCourse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (LecturesID != null && StudentsID != null)
            {
                if (LecturesID.Count > 0 && StudentsID.Count > 0)
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                        string a = Convert.ToString(selectedRow.Cells[0].Value);
                        courseID = Convert.ToInt32(a);
                        a = Convert.ToString(selectedRow.Cells[2].Value);
                        studentID = Convert.ToInt32(a);
                        button_gradeStudent.Enabled = true;
                    }
                }
                else
                {
                    button_gradeStudent.Enabled = false;
                }
            }
        }
        private void button_GradeStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormExamDepartment_GradeStudent gradeStudent = new FormExamDepartment_GradeStudent(courseID,studentID);
            gradeStudent.Show();
        }


        private void button_GradeStudent_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormExamDepartment_GradeStudent gradeStudent = new FormExamDepartment_GradeStudent(courseID, studentID);
            gradeStudent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuExamDepartment filterCourses = new FormMenuExamDepartment();
            filterCourses.Show();
        }

        private void FormExamDepartment_ShowCourse_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
