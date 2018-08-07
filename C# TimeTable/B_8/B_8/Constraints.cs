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
    public partial class Constraints : Form
    {

        DataBase db = new DataBase();
        DateTime minDate, maxDate;
        public bool IsUnitTest = false;
        SqlDataReader read;
        string LectureID=null;
        public Constraints()
        {
            InitializeComponent();
            minDate = new DateTime(2016, 10, 30);
            maxDate = new DateTime(2017, 3, 4);
            Semester.Text = GlobalVariables.Semester;
            Days.Text = DateTime.Now.DayOfWeek.ToString().Trim();
            StartHours.Text = "08:00";
            EndHours.Text = "08:00";
            IsUnitTest = true;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = monthCalendar1.SelectionStart.ToShortDateString();
                if (MessageBox.Show("Are you sure you want to add this message?", "Insert to DataBase", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    db.InsertContstraints(GlobalVariables.User_ID, Days.Text, StartHours.Text, EndHours.Text, Notes.Text, date, Semester.Text, Course.Text);
                    this.Hide();
                    main m = new B_8.main();
                    m.Show();
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
        
        private void Constraints_Load(object sender, EventArgs e)
        {
            load();
            
        }
        
        private void load()
        {
            try
            {
                SqlDataReader read = db.Select("Name", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);
                DataBase db2 = new DataBase();
                SqlDataReader read2;
                List<string> courses = new List<string>();

                while (read.Read())
                {

                    read2 = db2.Select("Semester", "NewCourses", "Name", read[0].ToString().Trim());
                    while (read2.Read())
                    {
                        if (!courses.Contains(read[0].ToString().Trim()) && Semester.Text == read2[0].ToString().Trim())
                            courses.Add(read[0].ToString().Trim());
                    }
                    read2.Close();

                }
                read.Close();
                foreach (string item in courses)
                {
                    Course.Items.Add(item);
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
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Days_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Days.Text = monthCalendar1.SelectionStart.DayOfWeek.ToString();
            if (maxDate >= monthCalendar1.SelectionStart && minDate <= monthCalendar1.SelectionStart)
                Semester.Text = "A";
            else
                Semester.Text = "B";
            Course.Items.Clear();
            load();



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = monthCalendar1.SelectionStart.ToShortDateString();
                if (MessageBox.Show("Are you sure you want to add this message?", "Insert to DataBase", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    read = db.Select("*", "NewSchedule", "Date", date);
                    while (read.Read())
                    {
                        
                        if(Int32.Parse(read["StartHour"].ToString().Trim())==(Int32.Parse(StartHours.Text.Substring(0,2))) && Int32.Parse(read["EndHour"].ToString().Trim())==Int32.Parse(EndHours.Text.Substring(0,2)))
                        {
                            if (read["LecturerName"].ToString().Trim().Equals(GlobalVariables.Full_Name) && read["Name"].ToString().Trim().Equals(Course.Text))
                            {
                                LectureID = read["LectureID"].ToString().Trim();
                                break;
                            }
                        }
                    }
                    read.Close();
                    if (LectureID == null)
                    {
                        MessageBox.Show("There is no lecture in this date");
                        return;
                    }
                    db.InsertChanges(LectureID, Notes.Text, Notes.Text, StartHours.Text.Substring(0, 2), EndHours.Text.Substring(0, 2), date.Substring(0, 2), date.Substring(3, 2), date.Substring(6, 4));
                    db.InsertContstraints(GlobalVariables.User_ID, Days.Text, StartHours.Text, EndHours.Text, Notes.Text, date, Semester.Text, Course.Text);
                    this.Hide();
                    
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Colud not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
