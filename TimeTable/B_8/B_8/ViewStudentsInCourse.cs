using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace B_8
{
    public partial class ViewStudentsInCourse : Form
    {
        DataBase db = new DataBase();

        public ViewStudentsInCourse()
        {
            InitializeComponent();
            listView1.Visible = false;
        }

        private void ViewStudentsInCourse_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                SqlDataReader read = db.Select("*", "NewCourses");
                while (read.Read())
                {
                    if (read["Unit"].ToString().Trim() == GlobalVariables.User_Department)
                    {
                        comboBox2.Items.Add(read["Name"].ToString().Trim());

                    }
                }
                read.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlDataReader read2 = db.Select("*", "StudentsTimeTable"); 
                DataBase db2 = new DataBase();
                SqlDataReader read3; ;
                listView1.Visible = true;
                listView1.Items.Clear();
                List<string> student_id = new List<string>();
                while (read2.Read())
                {
                    read3 = db2.Select("*", "NewSchedule");
                    while (read3.Read())
                    {
                        if (read2["LectureID"].ToString().Trim()== read3["LectureID"].ToString().Trim() && read3["Name"].ToString().Trim() == comboBox2.Text)
                        {
                            if (!student_id.Contains(read2["StudentID"].ToString().Trim()))
                            {
                                student_id.Add(read2["StudentID"].ToString().Trim());
                                ListViewItem row = new ListViewItem(read2["StudentID"].ToString().Trim());
                                row.SubItems.Add(read3["Name"].ToString().Trim());
                                listView1.Items.Add(row);
                            }
                            
                        }
                    }
                    read3.Close();
                }
                read2.Close();
                if (student_id.Count==0)
                {
                    MessageBox.Show("No students registered for this course");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main(); ss.Show();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
