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
    public partial class FormExamDepartment_SearchCourse : Form
    {
        public FormExamDepartment_SearchCourse()
        {
            InitializeComponent();
            this.AcceptButton = button_OK;
        }

        private void textBox_courseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            FormExamDepartment_ShowCourse show_course = new FormExamDepartment_ShowCourse(Convert.ToInt32(textBox_courseID.Text));
            this.Hide();
            show_course.Show();     
        }
        private void FormExamDepartment_SearchCourse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuExamDepartment examDepartment = new FormMenuExamDepartment();
            examDepartment.Show();
        }
    }
}
