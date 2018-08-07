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
    public partial class FormStudent_StudentGrades : Form
    {
        int id;
        public FormStudent_StudentGrades(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void StudentGrades_Load(object sender, EventArgs e)
        {
            List<string> studentsGrades = new List<string>();
            studentsGrades = SQLFunctions.getStudentsGrades(id);
            if (studentsGrades != null)
            {
                int k = 0;
                for (int i = 0;i<studentsGrades.Count; i+=2)
                {
                    //marks failed in red (under 56)
                    dataGridView1.Rows.Add(SQLFunctions.covertCourseIDtoCourseName(Convert.ToInt32(studentsGrades[i])), studentsGrades[i+1]);
                    if (Convert.ToInt32(studentsGrades[i + 1]) < 56)
                    {
                        dataGridView1.Rows[k].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    k++;
                }
            }
        }

        private void StudentGrades_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
