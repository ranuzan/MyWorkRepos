using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace B_8
{
    public partial class ListCourses : Form
    {
        DataBase db = new DataBase();
        public bool IsUnitTest = false;
        SqlDataReader read;

        public ListCourses()
        {
            InitializeComponent();
            
            IsUnitTest = true;


        }

        private void Year_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Year_Department.Text != null)
                {
                    combo_box.Enabled = true;
                }
                if (combo_box.Text != null)
                {
                    read = db.Select("*", "NewCourses",Year_Department.Text,combo_box.Text);
                    listView1.Items.Clear();

                    while (read.Read())
                    {
                        ListViewItem item = new ListViewItem(read["Name"].ToString().Trim());
                        item.SubItems.Add(read["ID"].ToString().Trim());
                        item.SubItems.Add(read["Credits"].ToString().Trim());
                        item.SubItems.Add(read["LectureHour"].ToString().Trim());
                        item.SubItems.Add(read["PracticeHour"].ToString().Trim());
                        item.SubItems.Add(read["ReceptionHour"].ToString().Trim());
                        item.SubItems.Add(read["Semester"].ToString().Trim());
                        item.SubItems.Add(read["Year"].ToString().Trim());
                        item.SubItems.Add(read["Department"].ToString().Trim());
                        listView1.Items.Add(item);

                      
                    }
                    read.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }

        }

        private void Department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void Yaer_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Year_Department.Text == "Year")
            {
                combo_box.Items.Clear();
                combo_box.Enabled = true;
                combo_box.Items.Add("1");
                combo_box.Items.Add("2");
                combo_box.Items.Add("3");
                combo_box.Items.Add("4");
            }
            if (Year_Department.Text == "Department")
            {
                List<string> check_depart = new List<string>();
                combo_box.Items.Clear();
                combo_box.Enabled = true;
                read = db.Select("Department", "NewCourses");
                while (read.Read())
                {
                    if (!check_depart.Contains(read[0].ToString().Trim()))
                    {
                        combo_box.Items.Add(read[0].ToString().Trim());
                        check_depart.Add(read[0].ToString().Trim());
                    }
                }
                read.Close();
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Hide();
            login Main = new login();
            Main.Show();
        }

        private void ListCourses_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            main ss = new main();
            ss.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

