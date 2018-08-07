using B_8.Properties;
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
    public partial class Show_Exams : Form
    {
        DataBase db;
        string last_user;
        SqlDataReader reader;
        static Exam_Deatails ed=null;
         int button_height;
        bool IsClicked = false;
        static Button Previous_button = null;

        public Show_Exams()
        {
            InitializeComponent();
            db = new DataBase();
            button_height = 60;
            this.AutoScroll = true;
            
            
        }
        private string Calc_Dates()
        {
            string days=DateTime.Now.Day.ToString();
            string months = DateTime.Now.Month.ToString();
            string years=DateTime.Now.Year.ToString();
            int int_days= int.Parse(days),int_months=int.Parse(months), int_years=int.Parse(years);
            if (int_months == 2)
            {
                return "A";
            }
            if (int_months>=10 || int_months <= 3)
            {
                if (int_months == 10)
                    if(int_days<30)
                        return "B";

                if (int_months == 3)
                    if(int_days>4)
                        return "B";
                return "Semester A";
            }
            else
            {
                return "Semester B";
            }
            
            
        }
        private void Show_Exams_Load(object sender, EventArgs e)
        {
            try
            {
                string name;
                if (GlobalVariables.User_Permission != "Secretary")
                {
                    toolStripComboBox1.Visible = false;
                    label1.Text = Calc_Dates();

                    this.CenterToScreen();
                    reader = db.Select("*", "NewSchedule");
                    while (reader.Read())
                    {
                        if (reader["LecturerName"].ToString().Trim().Equals(GlobalVariables.Full_Name))
                        {
                            if (reader["Type"].ToString().Trim().Equals("Exam"))
                            {
                                Button button1 = new Button();
                                button1.Size = new Size(panel1.Width, 70);
                                button1.Font = new Font("Georgia", 14, FontStyle.Bold);
                                button1.TextAlign = ContentAlignment.MiddleLeft;
                                button1.Text = reader["Name"].ToString().Trim() + " - " + reader["NumOfExam"].ToString().Trim();
                                button1.Image = Resources.Actions_go_next_icon;
                                button1.ForeColor = Color.White;
                                button1.ImageAlign = ContentAlignment.MiddleRight;
                                //button1.BackColor = Color.White;
                                button1.BackgroundImage = Resources.blue_surface_with_creases_1160_191;
                                button1.BackgroundImageLayout = ImageLayout.Stretch;
                                button1.Click += new EventHandler(button1_Click);
                                button1.Location = new Point(0, button_height);
                                button_height += 70;
                                button1.Name = reader["LecturerName"].ToString().Trim();
                                button1.Cursor = Cursors.Hand;
                                panel1.Controls.Add(button1);
                            }

                        }
                    }
                    reader.Close();
                }
                else
                {
                    this.CenterToScreen();
                    toolStripComboBox1.Visible = true;
                    label1.Text = Calc_Dates();
                    reader = db.Select("*", "NewUsers");
                    while (reader.Read())
                    {
                        if (reader["Role"].ToString().Trim() != "Secretary")
                        {
                            name = reader["FirstName"].ToString().Trim() + " " + reader["LastName"].ToString().Trim();
                            toolStripComboBox1.Items.Add(name);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            if (btn == Previous_button && !IsClicked || Previous_button==null)
            {
                btn.Image = Resources.Actions_go_previous_icon;
                ed = null;
                ed = new Exam_Deatails(btn, this.Location);
                ed.Show();
            }
            else if(btn==Previous_button && IsClicked)
            {
                btn.Image = Resources.Actions_go_next_icon;
                ed.Hide();
            }
            else if(btn!=Previous_button && IsClicked)
            {
                Previous_button.Image = Resources.Actions_go_next_icon;
                ed.Hide();
            }
            else if (btn != Previous_button && !IsClicked)
            {
                btn.Image = Resources.Actions_go_previous_icon;
                ed = null;
                ed = new Exam_Deatails(btn, this.Location);
                ed.Show();

            }
                IsClicked = !IsClicked;
            Previous_button = btn;

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            
              
            
            Show_exam_for_sec(toolStripComboBox1.Text);
            
        }
        private void Show_exam_for_sec(string Lecturer)
        {
            int check_exams = 0;
            try
            {
                if (last_user != Lecturer)
                {
                    button_height = 60;

                    panel1.Controls.Clear();
                    this.CenterToScreen();
                    reader = db.Select("*", "NewSchedule");
                    while (reader.Read())
                    {
                        if (reader["LecturerName"].ToString().Trim().Equals(Lecturer))
                        {

                            if (reader["Type"].ToString().Trim().Equals("Exam"))
                            {
                                Button button1 = new Button();
                                button1.Size = new Size(panel1.Width, 70);
                                button1.Font = new Font("Georgia", 14, FontStyle.Bold);
                                button1.TextAlign = ContentAlignment.MiddleLeft;
                                button1.Text = reader["Name"].ToString().Trim() + " - " + reader["NumOfExam"].ToString().Trim();
                                button1.Image = Resources.Actions_go_next_icon;
                                button1.ForeColor = Color.White;
                                button1.ImageAlign = ContentAlignment.MiddleRight;
                                button1.BackgroundImage = Resources.blue_surface_with_creases_1160_191;
                                button1.BackgroundImageLayout = ImageLayout.Stretch;
                                button1.Click += new EventHandler(button1_Click);
                                button1.Location = new Point(0, button_height);
                                button_height += 70;
                                button1.Name = reader["LecturerName"].ToString().Trim();
                                panel1.Controls.Add(button1);
                                check_exams++;
                                button1.Cursor = Cursors.Hand;
                            }
                        }
                    }
                    reader.Close();
                    last_user = Lecturer;
                    if (check_exams == 0)
                    {
                        label2.Visible = true;
                        label2.Text = "There is no exams at the moment";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            this.Close();
            main m = new main();
            m.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            login log = new B_8.login();
            log.Show();
        }

        private void toolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            this.Close();
            main m = new B_8.main();
            m.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
            Schedule s = new Schedule();
            s.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void toolStripComboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

            if (!toolStripComboBox1.Text.Equals("Lecturer"))
            {

               
                    Show_exam_for_sec(toolStripComboBox1.Text);
                
            }
        }
    }
}
