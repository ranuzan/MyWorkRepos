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
    public partial class AddToSce : Form
    {

        DataBase db = new DataBase();
        SqlDataReader reader;
        public string hour, day, date;
        string[] Types = { "Practice", "Lecture", "Exam", "ReceptionHours", "Meeting" };
        Dictionary<ComboBox, string> last_pick = new Dictionary<ComboBox, string>();
        List<int> LectureID;
        string temp_name, temp_ID, Class_name;
        Button B;
        static string[] Hours1 = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00" };

        List<ListViewItem> List_Items = new List<ListViewItem>();
        List<ListViewGroup> List_Groups = new List<ListViewGroup>();
        List<string> Resposibles = new List<string>();
        List<ComboBox> comboboxes = new List<ComboBox>();
        Button btn;
        public Schedule parent;
        public Quat_date parent1;
        ListViewItem item;
        ListViewGroup group;
        DateTime ExamDate;
        public List<string> course_list_items;
        public int chosen_day;
        public int chosen_year;
        public int chosen_month;
        public DateTime chosen_date;
        public AddToSce(Button b, string day, string hour, string date, Button btn, Schedule s = null, Quat_date c = null, string ClassName = null)
        {

            InitializeComponent();

            if (ClassName != null)
            {
                Class_name = ClassName;
            }
            this.hour = hour;
            this.day = day;
            parent = s;
            parent1 = c;
            button2.Enabled = false;

            this.date = date;
            Text = day + " , " + hour;
            CenterToScreen();
            B = b;
            this.btn = btn;
            LectureID = new List<int>();
            course_list_items = new List<string>();

        }
        private bool calc_hours(string start, string end, string current_hour)
        {
            string temp_start, temp_end;
            if (start.Length == 4)
            {
                temp_start = "0" + start;
                start = temp_start;
            }
            if (end.Length == 4)
            {
                temp_end = "0" + end;
                start = temp_end;
            }
            int s, e, Current;
            if (current_hour[0] == '0')
            {

                Current = current_hour[1] - 48;
            }
            else
            {
                Current = 10 * (current_hour[0] - 48) + (current_hour[1] - 48);
            }
            if (start[0] == '0')
            {
                s = start[1] - 48;
            }
            else
            {
                s = 10 * (start[0] - 48) + (start[1] - 48);
            }
            if (end[0] == '0')
            {
                e = end[1] - 48;
            }
            else
            {
                e = 10 * (end[0] - 48) + (end[1] - 48);
            }

            return Current >= s && Current < e;
        }
        private void AddToSce_Load(object sender, EventArgs e)
        {
            button2.Image = Resources.add_folder_normal;
            DateTime Summer_date = new DateTime(DateTime.Now.Year,7, 15);
            chosen_day = Int32.Parse(date.Substring(0, 2));
            chosen_year = Int32.Parse(date.Substring(6, 4));
            chosen_month = Int32.Parse(date.Substring(3, 2));
            chosen_date = new DateTime(chosen_year, chosen_month,chosen_day);
            if(chosen_date>Summer_date && chosen_date<new DateTime(DateTime.Now.Year,10, 30))
            {
                MessageBox.Show("You can't add or delete courses in summer semester");
                this.Close();
                return;
            }
            bool help = false;
            Start.Text = hour.Substring(0, 5);

            foreach (string item in Hours1)
            {

                if (Int32.Parse(item.Substring(0, 2)) > Int32.Parse(Start.Text.Substring(0, 2)))
                {
                    End.Items.Add(item);
                }
            }

            SqlDataReader reader3 = db.Select("*", "NewSchedule");
            while (reader3.Read())
            {
                help = true;
                string start, end;
                start = reader3["StartHour"].ToString().Trim() + ":00";
                end = reader3["EndHour"].ToString().Trim() + ":00";
                if (day == reader3["Day"].ToString().Trim() && calc_hours(start, end, hour.Substring(0, 5)) && reader3["Semester"].ToString().Trim().Equals(GlobalVariables.Semester))
                {

                    if (reader3["Type"].ToString().Trim() == "Exam")
                    {

                        if (Check_exam_date(btn, reader3["Date"].ToString().Trim()))
                        {
                            group = new ListViewGroup(reader3["LecturerName"].ToString().Trim() + "-" + reader3["Type"].ToString().Trim() + "/" + reader3["NumOfExam"].ToString().Trim());
                            item = new ListViewItem(group);
                            item.Text = reader3["Name"].ToString().Trim() + " , " + reader3["StartHour"].ToString().Trim()+":00"+"-"+ reader3["EndHour"].ToString().Trim()+":00";
                            Course_list.Groups.Add(group);
                            Course_list.Items.Add(item);
                            help = true;
                            group = null;
                            item = null;
                            continue;
                        }
                        help = false;

                    }

                    if (help)
                    {
                        group = new ListViewGroup(reader3["LecturerName"].ToString().Trim() + "-" + reader3["Type"].ToString().Trim());
                        item = new ListViewItem(group);
                        item.Name = reader3["Classroom"].ToString().Trim();
                        item.Text = reader3["Name"].ToString().Trim() + " , " + reader3["StartHour"].ToString().Trim() + ":00" + "-" + reader3["EndHour"].ToString().Trim() + ":00";
                        Course_list.Groups.Add(group);
                        Course_list.Items.Add(item);
                        group = null;
                        item = null;
                    }
                }
            }
            reader3.Close();

        }



        private bool Check_exam_date(Button btn, string ED)
        {
            string Sun_date = btn.Text.Substring(6 + 1);
            DateTime tempDate = new DateTime(Int32.Parse(Sun_date.Substring(6)), Int32.Parse(Sun_date.Substring(3, 2)), Int32.Parse(Sun_date.Substring(0, 2)));
            string Exam_date = ED;
            DateTime Week_from_now = tempDate.AddDays(6);
            ExamDate = new DateTime(Int32.Parse(Exam_date.Substring(6)), Int32.Parse(Exam_date.Substring(3, 2)), Int32.Parse(Exam_date.Substring(0, 2)));
            int diff = ExamDate.DayOfYear - tempDate.DayOfYear;
            int diff2 = ExamDate.DayOfYear - Week_from_now.DayOfYear;

            if (diff >= 0)
            {
                if (diff2 < 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (End.Text != "Browse")
            {
                
                if (List_Items.Count >= 1)
                {
                    for (int i = 0; i < List_Items.Count; i++)
                    {
                        //if (i > 0)
                        //{
                        //    if (List_Groups[0].Header.Equals(List_Groups[0].Header))
                        //    {
                        //        MessageBox.Show(Lect.Text + " is already teaching in this day");
                        //        return;
                        //    }
                        //}
                        //   db.InsertSce(List_Groups[i].Header, hour, day, List_Items[i].Text, date,Type1.Text,Class.Text,Department.Text,Semester.Text,NumOfExam.Text);

                        //if (check_if_course_exist(Course_list.Items[i].Group.Header, hour, day, Course_list.Items[i].Text,date))
                        //      db.InsertSce(Course_list.Items[i].Group.Header, hour, day, Course_list.Items[i].Text,date);  
                    }

                }
                if (db.help == null)
                {
                    MessageBox.Show("Success!!");
                }
                B.Text = "...";
                this.Close();
                if (parent != null)
                {
                    parent.Close();
                }
                else if (parent1 != null)
                {
                    parent1 = null;
                }
                Schedule s2 = new Schedule();
                s2.Show();
            }
            else
            {
                MessageBox.Show("You haven't chose end hour");
            }
        }

        private bool check_if_course_exist(string LecturerName, string hour, string day, string Course_name, string date)
        {
            SqlDataReader reader4 = db.Select("*", "NewSchedule");
            while (reader4.Read())
            {
                if (LecturerName == reader4["LecturerName"].ToString().Trim())
                {
                    if (hour == (reader4["StartHour"].ToString().Trim()+":00"+"-"+ reader4["EndHour"].ToString().Trim()+":00"))
                    {
                        if (day == reader4["Day"].ToString().Trim())
                        {
                            if (Course_name == reader4["Name"].ToString().Trim())
                            {
                                reader4.Close();
                                return false;
                            }
                        }
                    }
                }
            }
            reader4.Close();
            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (temp_course_list.SelectedItems.Count>=1)
            {
                if (course_list_items.Count == 0)
                {
                    MessageBox.Show("This course is already exist in the current schedule");
                    return;
                }
                try
                {
                   
                        hour = Start.Text + "-" + End.Text;
                        ListViewGroup group=new ListViewGroup(temp_course_list.SelectedItems[0].Text);
                        ListViewItem item = new ListViewItem(group);
                        item.Text = temp_course_list.SelectedItems[0].Text;
                        Course_list.Items.Add(item);
                        Course_list.Groups.Add(group);
                        DataBase db = new DataBase();
                        check = db.InsertSce(course_list_items[0],Int32.Parse(course_list_items[1]), course_list_items[2], course_list_items[3], course_list_items[4], course_list_items[5], Int32.Parse(course_list_items[6]), Int32.Parse(course_list_items[7]), course_list_items[8], course_list_items[9], course_list_items[10], course_list_items[11],course_list_items[12], course_list_items[13], course_list_items[14], course_list_items[15], course_list_items[16]);
                        course_list_items.Clear();
                        temp_course_list.Clear();
                        
                    
                }
                catch (Exception )

                {
                    MessageBox.Show("Couldn't connect to sql server");
                }
                if (check)
                {
                    MessageBox.Show("The course was successfully added");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error occurred");
                }
            }
            else
            {
                MessageBox.Show("Your Course details list is empty");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Course_list.SelectedItems.Count == 1)
            {
                string c_name = Course_list.SelectedItems[0].Text.Split(new char[] { ',' })[0];
                SqlDataReader reader = db.Select("*", "NewSchedule");
                while (reader.Read())
                {
                    if (reader["Name"].ToString().Trim().Equals(c_name.Trim()))
                    {
                        if (reader["Classroom"].ToString().Trim().Equals(Course_list.SelectedItems[0].Name))
                        {

                            LectureID.Add(Int32.Parse(reader["LectureID"].ToString().Trim()));
                            break;

                        }
                    }
                }
                reader.Close();
                if (LectureID.Count == 1)
                {

                    if (MessageBox.Show("Are you sure to delete?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataBase db2 = new DataBase();
                        SqlCommand cmd = new SqlCommand("DELETE FROM NewSchedule WHERE LectureID = @sn", db2.cnn);
                        cmd.Parameters.AddWithValue("@sn", LectureID[0]);
                        db2.Connect();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Success");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error");
                        }
                        Course_list.Items.Remove(Course_list.SelectedItems[0]);
                    }
                    
                    
                }
            }
        }
            
        


        private bool calc_hours(string start, string end)
        {

            string temp_start, temp_end;
            if (start.Length == 4)
            {
                temp_start = "0" + start;
                start = temp_start;
            }
            if (end.Length == 4)
            {
                temp_end = "0" + end;
                start = temp_end;
            }
            int s, e, Hour;
            if (start[0] == '0')
            {
                s = start[1] - 48;
            }
            else
            {
                s = 10 * (start[0] - 48) + (start[1] - 48);
            }
            if (end[0] == '0')
            {
                e = end[1] - 48;
            }
            else
            {
                e = 10 * (end[0] - 48) + (end[1] - 48);
            }
            if (hour[0] == '0')
            {
                Hour = hour[1] - 48;
            }
            else
            {
                Hour = 10 * (hour[0] - 48) + (hour[1] - 48);
            }
            if (s <= Hour && e >= Hour)
            {
                return false;
            }
            return true;
        }










        private void Start_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Course_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.End.Text != "Browse")
            {
                button2.BackgroundImage = Resources.add_folder_normal;
                button2.Enabled = true;
                Add_Deatils f = new B_8.Add_Deatils(this);
                f.Show();
            }
            else
            {
                MessageBox.Show("You haven't chose end hour");
            }


        }

       

       
        private void End_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (End.SelectedText != "Browse")
            {
                button2.Image = Resources.add_folder_loading;
                button2.Enabled = true;
            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void changeClass(string ClassName)
        {
        }
        public bool check_if_exist(string name)
        {
            reader = db.Select("*", "NewSchedule","LecturerName",name);
            while (reader.Read())
            {
                if (reader["Date"].ToString().Trim().Equals(date))
                {
                    if (calc_hours(reader["StartHour"].ToString().Trim(), reader["EndHour"].ToString().Trim(), hour))
                    {

                    }
                }
            }

            
            return true;
        }
        public string getClass()
        {
            if (Class_name != null)
            {
                return Class_name;
            }
            return null;
        }
    }

}
