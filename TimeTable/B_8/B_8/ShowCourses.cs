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
    public partial class ShowCourses : Form
    {
        DataBase db = new DataBase();


        public ShowCourses()
        {
            InitializeComponent();
         //   listView1.Visible=false;

        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void ShowCourses_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                string sem = comboBox2.Text;
                if (sem != null)
                {
                    SqlDataReader read = db.Select("*", "NewCourses");
                    while (read.Read())
                    {
                        if (read["Semester"].ToString().Trim() == sem)
                        {
                            if (read["Department"].ToString().Trim() == GlobalVariables.User_Department)
                            {
                                ListViewItem row = new ListViewItem(read["Name"].ToString().Trim());
                                row.SubItems.Add(read["ID"].ToString().Trim());
                                row.SubItems.Add(read["Credits"].ToString().Trim());
                                row.SubItems.Add(read["LectureHour"].ToString().Trim());
                                row.SubItems.Add(read["PracticeHour"].ToString().Trim());
                                row.SubItems.Add(read["ReceptionHour"].ToString().Trim());
                                row.SubItems.Add(read["Semester"].ToString().Trim());
                                row.SubItems.Add(read["Year"].ToString().Trim());
                                row.SubItems.Add(read["Department"].ToString().Trim());
                                listView1.Items.Add(row);
                            }

                        }
                    }
                    read.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sl");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main();
            ss.Show();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
