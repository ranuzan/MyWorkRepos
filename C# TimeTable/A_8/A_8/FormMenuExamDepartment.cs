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

        private void buttonReportError_Click(object sender, EventArgs e)
        {
            FormReportError reportError = new FormReportError(324798313);
            reportError.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }
    }
}
