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
    public partial class Info : Form
    {
        DataBase db;
        SqlDataReader reader;
        List<string> Courses;
        public Info()
        {

            InitializeComponent();
            db = new DataBase();
            Courses = new List<string>();
        }

        private void Info_Load(object sender, EventArgs e)
        {

            if (GlobalVariables.Semester == "A")
            {
                label12.Text = @"30/10/2017";
                label13.Text = @"04/02/2018";
            }
            else
            {
                label12.Text = @"05/03/2018";
                label13.Text = @"15/06/2018";
            }
            name.Text = GlobalVariables.Full_Name;
            User_name.Text = GlobalVariables.User_ID;
            Department.Text = GlobalVariables.User_Department;
            if (GlobalVariables.User_Permission.Equals("Lecturer") || GlobalVariables.User_Permission.Equals("Head of Department"))
            {
                NOL.Text = NumberOfCourse().ToString();
                NOLS.Text = (NumberOfCourse() * 13).ToString();
                NOP.Text = "0";
                NOPS.Text = "0";
                NORH.Text = "2";
            }
            else if (GlobalVariables.User_Permission.Equals("Secretary"))
            {
                NOL.Text = "0";
                NOLS.Text = "0";
                NOP.Text = "0";
                NOPS.Text = "0";
            }
            else
            {
                NOLS.Text = "0";
                NOPS.Text = (NumberOfCourse() * 13).ToString();
                NOP.Text = "0";
                NOL.Text = NumberOfCourse().ToString();
                NORH.Text = "2";
            }
            NORH.Text = "0";
            Email.Text = GlobalVariables.User_Email;
            
        }
        private double NumberOfCourse()
        {
            try
            {
                reader = db.Select("*", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);

                while (reader.Read())
                {
                    if (reader["Semester"].ToString().Trim().Equals(GlobalVariables.Semester))
                    {
                        if (!(Courses.Contains(reader["Name"].ToString().Trim())))
                        {
                            Courses.Add(reader["Name"].ToString().Trim());
                        }
                    }
                }
                reader.Close();
                return check_credits();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Could not connect to sql");
                return 0;
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private double check_credits()
        {
            try
            {
                reader = db.Select("*", "NewCourses", "Department", GlobalVariables.User_Department);
                double sum = 0;
                foreach (string item in Courses)
                {
                    while (reader.Read())
                    {
                        if (reader["Name"].ToString().Trim().Equals(item))
                        {
                            if (GlobalVariables.User_Permission == "Lecturer")
                            {
                                if (reader["Credits"].ToString().Trim().Length > 1)
                                {
                                    sum += Int32.Parse(reader["Credits"].ToString().Trim()) - 1;
                                    sum -= 0.5;
                                }
                                else
                                    sum += Int32.Parse(reader["Credits"].ToString().Trim()) - 1;
                            }
                            else
                            {
                                if (Int32.Parse(reader["Credits"].ToString().Trim()) >= 4)
                                {
                                    sum += 2;
                                }
                                else
                                {
                                    sum += 1;
                                }
                            }
                        }
                    }
                }
                reader.Close();
                return sum;
            }
            catch(Exception exp)
            {
                MessageBox.Show("Could not connect to sql");
                return 0;

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

