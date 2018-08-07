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

    public partial class Course_Filtering_Suitability : Form
    {
        DataBase db;
        SqlDataReader reader;
        List<string> list_of_dep;
        ComboBox combobox3;
        public bool IsUnitTest = false;

        public Course_Filtering_Suitability()
        {
            InitializeComponent();
            IsUnitTest = true;

        }

        private void Course_Filtering_Suitability_Load(object sender, EventArgs e)
        {
            try
            {

                db = new DataBase();
                if (GlobalVariables.User_Permission == "Secretary")
                {
                    textBox1.Visible = false;
                    list_of_dep = new List<string>();
                    comboBox2.Text = "Depratment";
                    comboBox2.Enabled = false;
                    combobox3 = new ComboBox();
                    combobox3.Location = textBox1.Location;
                    combobox3.Size = textBox1.Size;
                    tableLayoutPanel2.Controls.Add(combobox3);
                    reader = db.Select("Department", "Courses");
                    while (reader.Read())
                    {
                        if (!list_of_dep.Contains(reader[0].ToString().Trim()))
                        {
                            list_of_dep.Add(reader[0].ToString().Trim());
                        }
                    }
                    reader.Close();
                    foreach (string item in list_of_dep)
                    {
                        combobox3.Items.Add(item);
                    }
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show("Colud not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main();
            ss.Show();
        }

        private void logOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
            login ss = new login();
            ss.Show();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string filter1 = comboBox2.Text;
                string search = textBox1.Text;
                listView1.Items.Clear();
                if (GlobalVariables.User_Permission != "Secretary")
                {
                    reader = db.Select("*", "Courses");

                    while (reader.Read())
                    {
                        if (reader[filter1].ToString().Trim().Contains(search.Trim()))
                        {
                            ListViewItem row = new ListViewItem(reader["Name"].ToString().Trim());
                            row.SubItems.Add(reader["ID"].ToString().Trim());
                            row.SubItems.Add(reader["Credits"].ToString().Trim());
                            row.SubItems.Add(reader["LectureHour"].ToString().Trim());
                            row.SubItems.Add(reader["PracticeHour"].ToString().Trim());
                            row.SubItems.Add(reader["ReceptionHour"].ToString().Trim());
                            row.SubItems.Add(reader["Semester"].ToString().Trim());
                            row.SubItems.Add(reader["Year"].ToString().Trim());
                            row.SubItems.Add(reader["Department"].ToString().Trim());
                            listView1.Items.Add(row);
                        }
                    }
                    reader.Close();
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("Could Not Found " + search + " in " + filter1, "Failed!", MessageBoxButtons.OK);
                    }
                }
                else
                {


                    string comboboxValue = combobox3.Text;
                    reader = db.Select("*", "Courses", "Department", comboboxValue);
                    while (reader.Read())
                    {
                        ListViewItem row = new ListViewItem(reader["Name"].ToString().Trim());
                        row.SubItems.Add(reader["ID"].ToString().Trim());
                        row.SubItems.Add(reader["Credits"].ToString().Trim());
                        row.SubItems.Add(reader["LectureHour"].ToString().Trim());
                        row.SubItems.Add(reader["PracticeHour"].ToString().Trim());
                        row.SubItems.Add(reader["ReceptionHour"].ToString().Trim());
                        row.SubItems.Add(reader["Semester"].ToString().Trim());
                        row.SubItems.Add(reader["Year"].ToString().Trim());
                        row.SubItems.Add(reader["Department"].ToString().Trim());
                        listView1.Items.Add(row);
                    }
                    reader.Close();
                }
            }
            catch(Exception exp) {
                MessageBox.Show("Colud not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new B_8.login();
            l.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
