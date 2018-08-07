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
    public partial class FormMenuExamDepartment : Form
    {
        public FormMenuExamDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void FormMenuExamDepratment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_GradeStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExamDepartment.Grade_student();
        }

        private void button_SearchCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExamDepartment.SearchCourse();
        }

        private void button_departmentFiltering_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExamDepartment.FilterCourseByDepartment();
        }

        private void FormMenuExamDepratment_Load(object sender, EventArgs e)
        {

        }
    }
}
