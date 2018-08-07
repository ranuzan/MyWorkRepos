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
            userSecretary = new Users(_id);
            combobox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Semester.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\secHelp.chm";

            try
            {
                //Check if already exists before making
                if (!File.Exists(filePath))
                {
                    var data = Properties.Resources.secHelp;
                    using (var ChmStream = new FileStream("SecHelp.chm", FileMode.Create))
                    {
                        ChmStream.Write(data, 0, data.Count());
                        ChmStream.Flush();
                    }
                }
            }
            catch
            {
                //May already be opened

            }

            Help.ShowHelp(this, filePath);

        }

        private void combobox_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            combobox_Semester.Enabled = true;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            DataTable courseProperties = new DataTable();
            int year = 0;
            char semester;
            listView1.Items.Clear();
            if (combobox_Year.SelectedIndex == 0)
                year = 1;
            else if (combobox_Year.SelectedIndex == 1)
                year = 2;
            else if (combobox_Year.SelectedIndex == 2)
                year = 3;
            else if (combobox_Year.SelectedIndex == 3)
                year = 4;
            if (combobox_Semester.SelectedIndex == 0)
                semester ='A';
            else
                semester = 'B';
            courseProperties = SQLFunctions.getCourseDetailsByYearAndSemester(year,semester);
            if (courseProperties != null)
            {
                for (int i = 0; i < courseProperties.Rows.Count; i++)
                {
                    if (userSecretary.getDepartment() == courseProperties.Rows[i]["Department"].ToString())
                        add(courseProperties.Rows[i]["Name"].ToString(), courseProperties.Rows[i]["ID"].ToString(), courseProperties.Rows[i]["Credits"].ToString(), Convert.ToInt32(courseProperties.Rows[i]["LectureHour"].ToString()), courseProperties.Rows[i]["PreReqID"].ToString());

                }
            }
        }
        private void add(string name, string ID, string semesterPoints, int courseHours, string preReq)
        {
            string[] row = {name, ID,semesterPoints, Convert.ToString(courseHours), preReq };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormSecretary_AddOrRemoveLecture addRemove = new FormSecretary_AddOrRemoveLecture(id,password);
            this.Hide();
            addRemove.Show();
        }

        private void buttonReportError_Click(object sender, EventArgs e)
        {
            FormReportError reportError = new FormReportError(userSecretary.getUserID());
            reportError.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
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

        private void FormMenuSecretary_Load(object sender, EventArgs e)
        {

        }
    }
}
