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
    public partial class Semester_Schedule : Form
    {

        SqlDataReader reader;
        SqlDataReader reader2;
        List<string> responsibles;
        List<string> courses;
        DataBase db;
        Dictionary<string, Button> dict;
        string[] Hours = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00" };
        string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        static string last_user = null;
        List<Button> buttons;
        string Type;
        public Semester_Schedule()
        {
            InitializeComponent();
            this.CenterToScreen();
            responsibles = new List<string>();
            courses = new List<string>();
            db = new DataBase();
            dict = new Dictionary<string, Button>();
            init_dict();
           InitList();

            buttons = new List<Button>();
            Type = "Lecture";
        }

        private void InitList()
        {
            try
            {
                SqlDataReader r = db.Select("*", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);
                while (r.Read())
                {
                    responsibles.Add(r["Responsible"].ToString().Trim());
                    courses.Add(r["Name"].ToString().Trim());
                }
                r.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            finally
            {
              
            }
        }

        public Semester_Schedule(string type)
        {
            InitializeComponent();
            this.CenterToScreen();
            responsibles = new List<string>();
            db = new DataBase();
            courses = new List<string>();
            InitList();
            courses = new List<string>();
            dict = new Dictionary<string, Button>();
            init_dict();
            buttons = new List<Button>();
            this.Type = type;
            toolStripComboBox1.Text = type;
        }


        private void init_dict()
        {
            dict["08:00"] = button8;
            dict["09:00"] = button9;
            dict["10:00"] = button10;
            dict["11:00"] = button11;
            dict["12:00"] = button12;
            dict["13:00"] = button13;
            dict["14:00"] = button14;
            dict["15:00"] = button15;
            dict["16:00"] = button16;
            dict["17:00"] = button17;
            dict["18:00"] = button18;
            dict["19:00"] = button19;
            dict["20:00"] = button20;
        }

        private void Show_Practice_Schedule_Load(object sender, EventArgs e)
        {


            Init();
        }



        private void prac_or_lec_hours(SqlDataReader reader)
        {

            try
            {
                foreach (string item in Hours)
                {
                    if (reader["StartHour"].ToString().Trim() + ":00"==item && reader["Semester"].ToString().Trim().Equals(GlobalVariables.Semester))

                        if (reader["Type"].ToString().Trim() == Type)
                        {
                            this.Controls.Add(Build_button(reader, item));
                            return;
                        }


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            finally
            {
               
            }
        }
           
                
       

        private Button Build_button(SqlDataReader reader,string item)
        {
            Button button = new Button();

            try
            {
                int dif = 0, day_index = 0;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackgroundImage = Resources.rectangle_icon;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                day_index = get_day_index(reader["Day"].ToString().Trim());
                dif = diff(reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00");
                button.Location = new Point(dict[item].Location.X + (dict[item].Size.Width * day_index) + 4 * (dif + 1), dict[item].Location.Y);
                button.Size = new Size(dict[item].Size.Width, dict[item].Size.Height * (dif + 1) + 5 * (dif));
                button.Text = Type + "\n" + reader["Name"].ToString().Trim() + "\n" + reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00";
                button.BackColor = Color.Transparent;
                buttons.Add(button);

                return button;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sl");
                return button;
            }
            
        }
        private void Init()
        {
            try
            {
                if (GlobalVariables.User_Permission == "Lecturer" || GlobalVariables.User_Permission == "Head of Department")
                {
                    if (Type == "Practice")
                    {
                        reader = db.Select("*", "NewSchedule", "Responsible", GlobalVariables.Full_Name);
                    }
                    else
                    {
                        reader = db.Select("*", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);
                    }
                }

                else
                {
                    if (Type == "Practice")
                    {
                        reader = db.Select("*", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);
                    }
                    else
                    {
                        for (int i = 0; i < responsibles.Count; i++)
                        {
                            reader = db.Select("*", "NewSchedule", "LecturerName", responsibles[i]);
                            while (reader.Read())
                            {
                                if (reader["Name"].ToString().Trim().Equals(courses[i]))
                                {
                                    prac_or_lec_hours(reader);

                                }
                            }
                            reader.Close();

                        }
                        return;

                    }
                }

                while (reader.Read())
                {
                    prac_or_lec_hours(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            finally
            {
                //if(db.isconnected==true)
                //    db.CloseConnection();
            }
        }
        private int get_day_index(string day)
        {
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    return i + 1;
                }

            }
            return -1;
        }

        private int diff(string hour)
        {
            string start = hour.Substring(0, 2), end = hour.Substring(6, 2);

            return Int32.Parse(end) - Int32.Parse(start);
        }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }



        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }







        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            Schedule sche = new Schedule();
            sche.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
            last_user = toolStripComboBox1.Text;
            this.Close();
            Semester_Schedule s = new Semester_Schedule(last_user);
            s.Show();
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();
        }
    }
}

