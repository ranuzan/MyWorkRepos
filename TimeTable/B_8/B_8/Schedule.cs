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

    public partial class Schedule : Form
    {
        
        int current;
        DataBase db;
        DateTime a;
        DateTime today;
        public  string Course;
        int tempindex;
        string temp;
        int[] button_indexes;
        int Hours_index, Days_index, button_index;
        string rellevant_date;
        public Button[] buttons;
        static string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        static string[] Hours = { "08:00-09:00","09:00-10:00","10:00-11:00","11:00-12:00", "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00" };
        static string[] Hours1 = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00" };
        int size = 91;
        string day;
        string hour;
        DateTime Spec_date=new DateTime(1111,11,11);
        SqlDataReader reader2;

        public Schedule()
        {
            InitializeComponent();
            timer1.Start();
            db = new DataBase();
            buttons = new Button[size];
            rellevant_date = DateTime.Today.ToString();
            temp = GlobalVariables.Semester;
            a = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            today = DateTime.Today;
            this.Spec_date = DateTime.Today;
            
        }
        public Schedule(DateTime Spec_date)
        {
            InitializeComponent();
            timer1.Start();
            db = new DataBase();
            today = Spec_date;
            buttons = new Button[size];
            rellevant_date = today.ToString();
            temp = GlobalVariables.Semester;
            a = new DateTime(today.Year, today.Month, today.Day);
            this.Spec_date = Spec_date;
            monthCalendar1.TodayDate = Spec_date;
            
        }

        private void permission()

        {
            try
            {
                bool flag = false;
                bool flag1 = true;
                if (GlobalVariables.User_Permission == "Secretary")
                {
                    tableLayoutPanel4.Visible = true;
                    Load_Buttons();

                    Init(0, "", a);

                    SqlDataReader reader = db.Select("*", "NewSchedule");
                    
                    while (reader.Read())
                    {
                        if (reader["Semester"].ToString().Trim().Equals(GlobalVariables.Semester))
                        {
                            if (reader["Type"].ToString().Trim().Equals("Exam") || reader["Type"].ToString().Trim().Equals("Meeting"))
                            {
                                string Sun_date = buttons[1].Text.Substring(6 + 1);
                                DateTime tempDate = new DateTime(Int32.Parse(Sun_date.Substring(6)), Int32.Parse(Sun_date.Substring(3, 2)), Int32.Parse(Sun_date.Substring(0, 2)));
                                string Exam_date = reader["Date"].ToString().Trim();
                                DateTime Week_from_now = tempDate.AddDays(6);
                                DateTime ExamDate = new DateTime(Int32.Parse(Exam_date.Substring(6)), Int32.Parse(Exam_date.Substring(3, 2)), Int32.Parse(Exam_date.Substring(0, 2)));

                                int diff = ExamDate.DayOfYear - tempDate.DayOfYear;
                                int diff2 = ExamDate.DayOfYear - Week_from_now.DayOfYear;

                                if (diff >= 0)
                                {
                                    if (diff2 < 0)
                                    {
                                        flag = true;
                                    }

                                }

                            }

                            if (flag == true || (reader["Type"].ToString().Trim() != "Exam" && reader["Type"].ToString().Trim() != "Meeting"))
                            {

                                button_indexes = get_button_index(reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00", reader["Day"].ToString().Trim());
                                for (int i = 0; i < button_indexes.Length; i++)
                                {
                                    buttons[button_indexes[i]].BackgroundImage = Resources.blue_surface_with_creases_1160_191;
                                    buttons[button_indexes[i]].BackgroundImageLayout = ImageLayout.Stretch;
                                    buttons[button_indexes[i]].FlatStyle = FlatStyle.Flat;
                                    buttons[button_indexes[i]].FlatAppearance.BorderSize = 1;
                                    buttons[button_indexes[i]].Text = "...";
                                    buttons[button_indexes[i]].ForeColor = Color.Green;
                                    buttons[button_indexes[i]].Image = Resources.User_Group_icon;
                                    buttons[button_indexes[i]].ImageAlign = ContentAlignment.MiddleLeft;
                                    flag = false;
                                }
                            }

                        }

                    }
                    reader.Close();

                }
                if (GlobalVariables.User_Permission == "Lecturer" || GlobalVariables.User_Permission == "Head Of Department")
                {
                    Build(0);//id == 0 for lec or head of dep
                }
                if (GlobalVariables.User_Permission == "Practitioner")
                {
                    Build(1);
                }
                if (Spec_date != new DateTime(1111, 11, 11))
                {
                    double d = (this.Spec_date - today).TotalDays;
                    Init(Convert.ToInt32(d), this.Spec_date.DayOfWeek.ToString(), this.Spec_date);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }


        private string ExamFilter(SqlDataReader reader)
        {
            try
            {
                if (reader["LecturerName"].ToString().Trim().Equals(GlobalVariables.Full_Name) && (reader["Semester"].ToString().Trim().Equals(GlobalVariables.Semester)|| reader["Type"].ToString().Trim().Equals("Meeting")))
                {
                    if (reader["Type"].ToString().Trim().Equals("Exam") || reader["Type"].ToString().Trim().Equals("Meeting"))
                    {
                        string Sun_date = buttons[1].Text.Substring(6 + 1);
                        DateTime tempDate = new DateTime(Int32.Parse(Sun_date.Substring(6)), Int32.Parse(Sun_date.Substring(3, 2)), Int32.Parse(Sun_date.Substring(0, 2)));
                        string Exam_date = reader["Date"].ToString().Trim();
                        DateTime Week_from_now = tempDate.AddDays(6);
                        DateTime ExamDate = new DateTime(Int32.Parse(Exam_date.Substring(6)), Int32.Parse(Exam_date.Substring(3, 2)), Int32.Parse(Exam_date.Substring(0, 2)));

                        int diff = ExamDate.DayOfYear - tempDate.DayOfYear;
                        int diff2 = ExamDate.DayOfYear - Week_from_now.DayOfYear;

                        if (diff >= 0)
                        {
                            if (diff2 < 0)
                            {
                                return reader["Type"].ToString().Trim();
                            }
                        }

                    }
                }
                return "none";
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");
                return "none";

            }
            finally
            {
            }
        }     
        private void Build(int id)
        {

            try
            {
                tableLayoutPanel4.Visible = false;
                string temp1 = "";
                if (id == 0)
                {
                    temp1 = "Lecture";

                }
                else
                {
                    temp1 = "Practice";
                }
                Load_Buttons();
                Init(0, "", a);

                SqlDataReader reader = db.Select("*", "NewSchedule");
                DataBase db2 = new DataBase();
                
                string hour = " ";
                while (reader.Read())
                {
                    bool flag1 = true;
                    if ((reader["LecturerName"].ToString().Trim().Equals(GlobalVariables.Full_Name) && (reader["Type"].ToString().Trim().Equals(temp1)) || (reader["Type"].ToString().Trim().Equals("ReceptionHours")) || reader["Type"].ToString().Trim().Equals("Meeting") || reader["Type"].ToString().Trim().Equals("Exam")))
                    {

                        if (GlobalVariables.Semester.Equals(reader["Semester"].ToString().Trim()) || reader["Type"].ToString().Trim().Equals("Meeting"))
                        {
                            //
                            
                            reader2 = db2.Select("*", "Constraints");
                            while (reader2.Read())
                            {
                                string Sche_hour = reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00";
                               
                                    
                                    if ((reader["LecturerName"].ToString().Trim() == reader2["FullName"].ToString().Trim() && reader["Day"].ToString().Trim() == reader2["Days"].ToString().Trim() && (reader2["StartHours"].ToString().Trim() + "-" + reader2["EndHours"].ToString().Trim()) == Sche_hour && reader2["Approved"].ToString().Trim() == "true" && Spec_date.ToShortDateString() == reader2["Date"].ToString().Trim()) || check_spec_date(Spec_date,reader2["Date"].ToString().Trim()))
                                    {
                                        hour = reader2["StartHours"].ToString().Trim() + "-" + reader2["EndHours"].ToString().Trim();
                                        flag1 = false;
                                        break;
                                    }
                                }
                            }
                            reader2.Close();
                            if (flag1 == true)
                            {
                                reader2 = db2.Select("*", "Constraints");
                                while (reader2.Read())
                                {
                                    //
                                    if (reader["Type"].ToString().Trim().Equals("Exam") || reader["Type"].ToString().Trim().Equals("Meeting"))
                                    {
                                        if (ExamFilter(reader) != "Exam" && ExamFilter(reader) != "Meeting")
                                        {
                                            flag1 = false;
                                        }
                                    }
                                    if (flag1 == true)
                                    {


                                        button_indexes = get_button_index(reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00", reader["Day"].ToString().Trim());

                                        for (int i = 0; i < button_indexes.Length; i++)
                                        {
                                            buttons[button_indexes[i]].BackColor = Color.Green;
                                            if (reader["Type"].ToString().Trim() == "Meeting")
                                            {
                                                buttons[button_indexes[i]].Text = reader["Type"].ToString().Trim();
                                                buttons[button_indexes[i]].Name = reader["LectureID"].ToString().Trim();
                                            }
                                            else
                                                buttons[button_indexes[i]].Text = reader["Name"].ToString().Trim();
                                            buttons[button_indexes[i]].Enabled = true;
                                            buttons[button_indexes[i]].FlatStyle = FlatStyle.Flat;
                                            buttons[button_indexes[i]].FlatAppearance.BorderSize = 1;
                                            buttons[button_indexes[i]].Click += new EventHandler(showClassDate);
                                            buttons[button_indexes[i]].Name = reader["LectureID"].ToString().Trim();
                                        }
                                    }
                                }
                                reader2.Close();
                            }
                        
                    }
                }
                
                reader.Close();
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

        private bool check_spec_date(DateTime spec_date, string ConstraintsDate)
        {
            
            for (int i = 1; i < 7; i++)
            {
                if (ConstraintsDate.Equals(buttons[i].Text.Substring(buttons[i].Text.Length - 10)))
                {
                    return true;
                }
            }
            return false;
        }

        private void showClassDate(object s,EventArgs e)
        {
            Button btn = (Button)s;
            ShowClassInSchedule scis = new ShowClassInSchedule(btn);
            scis.Show();
            
        }
        private int calc_hours(string start, string end)
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
           
            return e-s;
        }
        private int[] get_button_index(string hour,string day)
        {

            string start, end;
            if (hour.Length == 9)
            {
                start = "0" + hour.Substring(0, 4);
                end="0"+ hour.Substring(4);
                hour = start + "-" + end;
            }
           else if (hour.Length == 10)
            {
                if (hour[0] == '8' || hour[0]=='9')
                {
                    start ="0"+ hour.Substring(0, 4);
                    end = hour.Substring(5);
                    hour = start + "-" + end;
                }
                else
                {
                    start = hour.Substring(0, 5);
                    end ="0"+ hour.Substring(6);
                    hour = start + "-" + end;
                }
            }
            this.hour = hour;
            int[] indexes;
            this.day = day;
            
            start = hour.Substring(0, 5);
            end = hour.Substring(6);
            int diff = calc_hours(start, end);
            indexes = new int[diff];
            for (int j = 0; j < indexes.Length; j++)
            {
                if (j == 0)
                {
                    for (int i = 0; i < Hours1.Length; i++)
                    {

                        if (start == Hours1[i])
                        {
                            Hours_index = i + 1;
                            break;
                        }
                    }
                    for (int i = 0; i < days.Length; i++)
                    {
                        if (days[i] == day)
                        {
                            Days_index = i + 1;
                            break;
                        }
                    }
                    indexes[j] = Hours_index * 7 + Days_index;
                    tempindex = indexes[j];
                }
                else
                {
                    indexes[j] = tempindex + 7*j;
                }
            }
            return indexes;
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            if(GlobalVariables.User_Permission=="Head Of Department")
            {
                toolStripMenuItem12.Visible = true;
            }
            permission();
            this.CenterToScreen();
        

            menuStrip1.Items[1].Text = today.ToString("dd/MM/yyyy");
            menuStrip1.Items[3].Text = "Hello " + GlobalVariables.Full_Name;
            ShowConstraints();
        }

        private void ShowConstraints()
        {
            try
            {
                SqlDataReader read;
                DataBase db1 = new DataBase();
                ListViewItem item;
                read = db1.Select("*", "Constraints");
                while (read.Read())
                {
                    if (read["Seen"].ToString().Trim().Equals("false"))
                    {
                        ListViewGroup group = new ListViewGroup(read["FullName"].ToString().Trim() + " " + read["User_ID"].ToString().Trim() + " " + read["Date"].ToString().Trim() + " " + read["Days"].ToString().Trim() + " " + read["StartHours"].ToString().Trim() + "-" + read["EndHours"].ToString().Trim() + " " + read["Course"].ToString().Trim());
                        item = new ListViewItem(group);
                        item.Text = read["Notes"].ToString().Trim();
                        group.Name = read["SerialNumber"].ToString().Trim();
                        listView1.Groups.Add(group);
                        listView1.Items.Add(item);
                    }

                }
                read.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");

            }
            finally
            {
               
            }
        }
        public void Init(int spec_date,string specday, DateTime d)
        {
            bool flag = false;
            int day = 0, count = 0;
            string day_of_the_week;
            if (spec_date == 0)
                spec_date = 0;
            else
                spec_date = spec_date - 1;

            if (specday == "")
            {
                day_of_the_week = today.DayOfWeek.ToString();
            }
            else
            {
                day_of_the_week = specday;
            }
            for (int i=0; i<days.Length; i++)
            {
                if (days[i] == day_of_the_week)
                {
                    flag = true;
                    day = i*( - 1);
                }
            }
            if (flag==false)
            {
                day = -7;
            }
            int j = 0,day_index= today.Day*(-1);
             
    
            for (int i = 1; i <= days.Length; i++)
            {
                buttons[i].Font = new Font("Georgia", 7);
                if (d.AddDays(day).DayOfWeek.ToString() == "Saturday")
                {
                    i--;
                   
                }
                else
                {
                    buttons[i].Text = d.AddDays(day).DayOfWeek + "\n" + d.AddDays(day).ToString("dd/MM/yyyy");
                    buttons[i].BackgroundImage = Resources.expences_button_png_hi;
                    buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i].BackColor = Color.Transparent;
                    buttons[i].FlatAppearance.BorderSize = 0;
                    buttons[i].Enabled = true;
                }
                day++;
                day_index++;
            }
            for (int i = 7; j < Hours.Length; i += 7)
            {
                
                buttons[i].Text = Hours[j];
                buttons[i].Enabled = true;
                buttons[i].BackgroundImage = Resources.expences_button_png_hi;
                buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                buttons[i].BackColor = Color.Transparent;
                
                j +=1;
            }
        }

        private void DynamicButton_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            int hours_index=0, days_index=0;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] == btn)
                {
                    hours_index = i / 7;
                     days_index = i % 7;
                    hour = Hours[hours_index - 1];
                    day  = days[days_index - 1];
                }
            }


            string date = buttons[days_index].Text.Substring(day.Length+1);
                
                
            AddToSce s = new AddToSce(btn,day,hour,date,buttons[1],this);
            
            s.Show();
            
        }
       
        private void Load_Buttons()
        {

            int x, y;
            x = 0;
            y = 35;
            int count = 7;
            for (int i = 1; i <= size; i++)
            {

                Button btn = new Button();
                btn.Cursor = Cursors.Hand;
                btn.Location = new Point(x, y);
                btn.Height = 40;
                btn.Width = 120;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Blue;
                btn.Dock = DockStyle.Fill;
                btn.Text = "";
                btn.Name = "DynamicButton";
                btn.Font = new Font("Georgia", 10);
                if (GlobalVariables.User_Permission == "Secretary")
                    btn.Click += new EventHandler(DynamicButton_Click);
                if (GlobalVariables.User_Permission != "Secretary")
                {
                    btn.Enabled = false;
                }
                x += 120;

                if (i == 1)
                {
                    btn.Text = "Days\\Hours";
                    btn.Enabled = false;
                }
                if (i % count == 0)
                {
                    x = 0;
                    y += 40;
                }


                tableLayoutPanel3.Controls.Add(btn);
                buttons[i - 1] = btn;
            }
        }
       
        private void home_Click(object sender, EventArgs e)
        {
            GlobalVariables.Semester = temp; 
            this.Hide();
            main ss = new main();
            ss.Show();
        }
        public void InitUpdats()
        {

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                monthCalendar1.Visible = !monthCalendar1.Visible;


        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            menuStrip1.Items[2].Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = !monthCalendar1.Visible;

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Close();
            main m = new main();
            m.Show();

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (GlobalVariables.maxDate >= monthCalendar1.SelectionEnd && GlobalVariables.minDate <= monthCalendar1.SelectionEnd && GlobalVariables.Semester != "A")
            {
                if (MessageBox.Show("Are you sure you want to switch semester?", "SWITCH SEMESTER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GlobalVariables.Semester = "A";
                    Schedule s = new Schedule();
                    this.Close();
                    s.Show();
                }

            }
            if (GlobalVariables.maxDate <= monthCalendar1.SelectionEnd && GlobalVariables.Semester == "A")
            {
                if (MessageBox.Show("Are you sure you want to switch semester?", "SWITCH SEMESTER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GlobalVariables.Semester = "B";
                    Schedule s = new Schedule();
                    this.Hide();
                    s.Show();
                }

            }
            if (MessageBox.Show("Are you sure you want to switch Week?", "SWITCH Week", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Schedule sche = new Schedule(monthCalendar1.SelectionEnd);
                sche.Show();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Close();
            Show_Exams s = new Show_Exams();
            s.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Close();
            Semester_Schedule s = new Semester_Schedule();
            s.Show();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void tableLayoutPanel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                current = listView1.SelectedIndices[0];
            List<string> group_selected = new List<string>();
            if (listView1.SelectedItems.Count > 0)
            {

                string group_info = listView1.SelectedItems[0].Group.Header;
                string[] groups = group_info.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                group_selected = new List<string>();
                group_selected.Add(listView1.SelectedItems[0].Group.Name);
                for (int i = 0; i < groups.Length; i++)
                {
                    group_selected.Add(groups[i]);
                }
                group_selected.Add(listView1.Items[0].Text);
            }
            if (group_selected.Count > 0)
            {
                DeleteWeeklySchedule dw = new DeleteWeeklySchedule(group_selected);
                dw.ShowDialog();
                listView1.Items[current].Remove();
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            this.Close();
            new Schedule().Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            new Meeting().Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void EXIT_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        
    }
}
