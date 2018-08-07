using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{
    public partial class FormMenuSecretary : Form
    {
        int id;
        string password;
        Users userSecretary = new Users();
        public FormMenuSecretary(int _id, string _password)
        {
            InitializeComponent();
            id = _id;
            password = _password;
            userSecretary = new Users(_id, _password, SQLFunctions.covertStudentIDtoStudentFirstName(_id),SQLFunctions.covertStudentIDtoStudentLastName(_id), SQLFunctions.getStudentDepartment(_id));
            combobox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Semester.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void FormMenuSecretary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   comboBoxYear.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\SecretaryHelp.chm";

            try
            {
                //Check if already exists before making
                if (!File.Exists(filePath))
                {
                    var data = Properties.Resources.SecretaryHelp;
                    using (var ChmStream = new FileStream("SecretaryHelp.chm", FileMode.Create))
                    {
                        ChmStream.Write(data, 0, data.Count());
                        ChmStream.Flush();
                    }
                    MessageBox.Show("file made");
                }
            }
            catch
            {
                //May already be opened

            }

            Help.ShowHelp(this, filePath);

        }

        private void SemesterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void combobox_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            combobox_Semester.Enabled = true;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            List<string> courseProperties = new List<string>();
            double yearSemester = 0;
            listView1.Items.Clear();
            if (combobox_Year.SelectedIndex == 0)
                yearSemester = 1;
            else if (combobox_Year.SelectedIndex == 1)
                yearSemester = 2;
            else if (combobox_Year.SelectedIndex == 2)
                yearSemester = 3;
            else if (combobox_Year.SelectedIndex == 3)
                yearSemester = 4;
            if (combobox_Semester.SelectedIndex == 0)
                yearSemester += 0.1;
            else
                yearSemester += 0.2;
            courseProperties = SQLFunctions.getCourseDetailsByYearAndSemester(yearSemester);
            if (courseProperties != null)
            {
                for (int i = 0; i < courseProperties.Count; i += 9)
                {
                    if (userSecretary.getDepartment() == courseProperties[i + 8])
                        add(courseProperties[i], courseProperties[i + 1], " ", " ", " ", courseProperties[i + 3], Convert.ToInt32(courseProperties[i + 4] + courseProperties[i + 5]), courseProperties[i + 2]);

                }
            }
        }
        private void add(string name, string ID, string Lecturer, string cls, string classCount, string semesterPoints, int courseHours, string preReq)
        {
            string[] row = {name, ID, Lecturer, cls, classCount,semesterPoints, Convert.ToString(courseHours), preReq };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  comboBoxSemester.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            List<string> courseProperties = new List<string>();
            double yearSemester=0;
            dataGridView1.Rows.Clear();
            if (comboBoxYear.SelectedIndex == 0)
                yearSemester = 1;
            else if (comboBoxYear.SelectedIndex == 1)
                yearSemester = 2;
            else if (comboBoxYear.SelectedIndex == 2)
                yearSemester = 3;
            else if (comboBoxYear.SelectedIndex == 3)
                yearSemester = 4;
            if (comboBoxSemester.SelectedIndex == 0)
                yearSemester += 0.1;
            else
                yearSemester += 0.2;
          //  courseProperties = SQLFunctions.getLectureDetailsByYearAndSemester(yearSemester);
            if (courseProperties != null)
            {
                for (int i = 0; i < courseProperties.Count; i += 9)
                {
                    dataGridView1.Rows.Add(courseProperties[i], courseProperties[i+7], courseProperties[i + 4], courseProperties[i + 5], courseProperties[i + 6]);
                }
            }
        }

        private void FormSecretary_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormSecretary_AddOrRemoveLecture addRemove = new FormSecretary_AddOrRemoveLecture(id,password);
            this.Hide();
            addRemove.Show();
        }
    }
}
