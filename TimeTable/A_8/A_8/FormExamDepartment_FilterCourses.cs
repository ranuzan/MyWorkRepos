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
    public partial class FormExamDepartment_FilterCourses : Form
    {
        int courseID;
        public FormExamDepartment_FilterCourses()
        {
            InitializeComponent();
            comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormExamDepartment_FilterCourses_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormExamDepartment_FilterCourses_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filter courses by department
            dataGridView_courses.Rows.Clear();
            List<string> row=new List<string>(8);
            int i = 0;
            DataTable courseList_dt = SQLFunctions.findCoursePropertiesByDepartment(comboBox_Department.Text);
            if (courseList_dt != null)
            {
                for (i = 0; i < courseList_dt.Rows.Count; i++)
                {
                    dataGridView_courses.Rows.Add(courseList_dt.Rows[i]["Name"].ToString(), Convert.ToInt32(courseList_dt.Rows[i]["ID"]), (courseList_dt.Rows[i]["PreReqID"]).ToString(), Convert.ToInt32(courseList_dt.Rows[i]["Credits"]), Convert.ToInt32(courseList_dt.Rows[i]["LectureHour"]), Convert.ToInt32(courseList_dt.Rows[i]["PracticeHour"]), Convert.ToInt32(courseList_dt.Rows[i]["ReceptionHour"]), Convert.ToInt32(courseList_dt.Rows[i]["Year"]), Convert.ToChar(courseList_dt.Rows[i]["Semester"]));
                }
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuExamDepartment examDepartment = new FormMenuExamDepartment();
            examDepartment.Show();
        }

        private void dataGridView_courses_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_courses.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView_courses.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView_courses.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[1].Value);
                if (a != "")
                {
                    courseID = Convert.ToInt32(a);
                    button_GradeCourse.Enabled = true;
                }
                else
                    button_GradeCourse.Enabled = false;
                }
        }

        private void button_GradeCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormExamDepartment_ShowCourse showCourse = new FormExamDepartment_ShowCourse(courseID);
            showCourse.Show();
        }

        private void dataGridView_courses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
