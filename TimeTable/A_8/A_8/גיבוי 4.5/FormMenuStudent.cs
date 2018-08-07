using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{
    public partial class FormMenuStudent : Form
    {
        Student userStudnet = new Student();
        List<Courses> allowedCoursesProperties = new List<Courses>();
        int week=0;
        string addRemove;

        public FormMenuStudent(int _id, string _password)
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            comboBox_courses.DropDownStyle = ComboBoxStyle.DropDownList;

            userStudnet = new Student(_id, _password);

            List<int> allowedCoursesIDs = SQLFunctions.findAllowedCoursesForStudent(userStudnet.getUserID(), userStudnet.getYear(), userStudnet.getSemester(), userStudnet.getDepartment());

            for(int i=0;i< allowedCoursesIDs.Count;i++)
            {
                allowedCoursesProperties.Add(new Courses(allowedCoursesIDs[i]));
                comboBox_courses.Items.Add(allowedCoursesProperties[i].getCourseName());
            }

            label3.Text = "Hello: " + userStudnet.getUserName();

            label_weeklyHoursShow.Text = Convert.ToString(userStudnet.getWeaklyHours());

            refreshTimeTable(tableLayoutPanel3);
        }

        private bool checkTimeTable()
        {
            List<int> lecturesIDs = SQLFunctions.findStudentLecturesIDs(userStudnet.getUserID());
            List<int> lectureCoursesIDs = new List<int>();
            List<int> practiceCoursesIDs = new List<int>();

            if (userStudnet.getSemeterPoints() < 10 || userStudnet.getSemeterPoints() > 30)
            {
                MessageBox.Show("Semester points doesn't meet requirment");
                return false;
            }

            for (int i = 0; i < lecturesIDs.Count; i++)
            {
                if ((SQLFunctions.findLectureProperties(lecturesIDs[i])[7]) == "Lecture")
                    lectureCoursesIDs.Add(Convert.ToInt32(SQLFunctions.findLectureProperties(lecturesIDs[i])[2]));
                if ((SQLFunctions.findLectureProperties(lecturesIDs[i])[7]) == "Practice")
                    practiceCoursesIDs.Add(Convert.ToInt32(SQLFunctions.findLectureProperties(lecturesIDs[i])[2]));
            }

            if ((lectureCoursesIDs.Count != lectureCoursesIDs.Distinct().Count()) || (practiceCoursesIDs.Count != practiceCoursesIDs.Distinct().Count()))
            {
                MessageBox.Show("Exists duplicated letures");
                return false;
            }

            if (!(lectureCoursesIDs.All(practiceCoursesIDs.Contains) && practiceCoursesIDs.All(lectureCoursesIDs.Contains)))
            {
                MessageBox.Show("Not all lectures has a practice or not all pratice has a lecture");
                return false;
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            button_weeklyView.Visible = true;
            button_semesterView.Visible = false;
            button_previous.Visible = false;
            button_next.Visible = false;
            button_currentWeek.Visible = false;
            SUNlabel.Text = "Sunday";
            MONlabel.Text = "Monday";
            TUElabel.Text = "Tuesday";
            WEDlabel.Text = "Wednesday";
            THUlabel.Text = "Thursday";
            FRIlabel.Text = "Friday";
            SUNlabel.TextAlign = ContentAlignment.MiddleCenter;
            MONlabel.TextAlign = ContentAlignment.MiddleCenter;
            TUElabel.TextAlign = ContentAlignment.MiddleCenter;
            WEDlabel.TextAlign = ContentAlignment.MiddleCenter;
            THUlabel.TextAlign = ContentAlignment.MiddleCenter;
            FRIlabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // log out option for student
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        public void weekley_view()
        {
            DateTime date = DateTime.Today;
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(0);
                MONlabel.Text = "Monday " + date.AddDays(1);
                TUElabel.Text = "Tuesday " + date.AddDays(2);
                WEDlabel.Text = "Wednesday " + date.AddDays(3);
                THUlabel.Text = "Thursday " + date.AddDays(4);
                FRIlabel.Text = "Friday " + date.AddDays(5);
            }
            else if (date.DayOfWeek == DayOfWeek.Monday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-1);
                MONlabel.Text = "Monday " + date.AddDays(0);
                TUElabel.Text = "Tuesday " + date.AddDays(1);
                WEDlabel.Text = "Wednesday " + date.AddDays(2);
                THUlabel.Text = "Thursday " + date.AddDays(3);
                FRIlabel.Text = "Friday " + date.AddDays(4);
            }
            else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-2);
                MONlabel.Text = "Monday " + date.AddDays(-1);
                TUElabel.Text = "Tuesday " + date.AddDays(0);
                WEDlabel.Text = "Wednesday " + date.AddDays(1);
                THUlabel.Text = "Thursday " + date.AddDays(2);
                FRIlabel.Text = "Friday " + date.AddDays(3);
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-3);
                MONlabel.Text = "Monday " + date.AddDays(-2);
                TUElabel.Text = "Tuesday " + date.AddDays(-1);
                WEDlabel.Text = "Wednesday " + date.AddDays(0);
                THUlabel.Text = "Thursday " + date.AddDays(1);
                FRIlabel.Text = "Friday " + date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-4);
                MONlabel.Text = "Monday " + date.AddDays(-3);
                TUElabel.Text = "Tuesday " + date.AddDays(-2);
                WEDlabel.Text = "Wednesday " + date.AddDays(-1);
                THUlabel.Text = "Thursday " + date.AddDays(0);
                FRIlabel.Text = "Friday " + date.AddDays(1);
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-5);
                MONlabel.Text = "Monday " + date.AddDays(-4);
                TUElabel.Text = "Tuesday " + date.AddDays(-3);
                WEDlabel.Text = "Wednesday " + date.AddDays(-2);
                THUlabel.Text = "Thursday " + date.AddDays(-1);
                FRIlabel.Text = "Friday " + date.AddDays(0);
            }
            else
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-6);
                MONlabel.Text = "Monday " + date.AddDays(-5);
                TUElabel.Text = "Tuesday " + date.AddDays(-4);
                WEDlabel.Text = "Wednesday " + date.AddDays(-3);
                THUlabel.Text = "Thursday " + date.AddDays(-2);
                FRIlabel.Text = "Friday " + date.AddDays(-1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            button_semesterView.Visible = true;
            button_weeklyView.Visible = false;
            button_previous.Visible = true;
            button_next.Visible = true;
            button_currentWeek.Visible = true;

            SUNlabel.AutoSize = true;
            MONlabel.AutoSize = true;
            TUElabel.AutoSize = true;
            WEDlabel.AutoSize = true;
            THUlabel.AutoSize = true;
            FRIlabel.AutoSize = true;
            //MiddleLeft
            //MiddleRight
            SUNlabel.TextAlign = ContentAlignment.TopLeft;
            MONlabel.TextAlign = ContentAlignment.TopLeft;
            TUElabel.TextAlign = ContentAlignment.TopLeft;
            WEDlabel.TextAlign = ContentAlignment.TopLeft;
            THUlabel.TextAlign = ContentAlignment.TopLeft;
            FRIlabel.TextAlign = ContentAlignment.TopLeft;
            weekley_view();

            checkChanges();
           
        }
        public void checkChanges()
        {
            int lecID = 200003;
            string description = "";
            int start = 13;
            int end = 17;
            int day = 1;
            int month = 5;
            int year = 2017;
            List <string> list = SQLFunctions.getChanges();

            if (list != null)
            {
                for (int j = 0; j < list.Count; j += 7)
                {

                    lecID = Convert.ToInt32(list[j]);
                    if (lecID != 0)
                    {
                        List<int> studentList = SQLFunctions.getStudentsIDfromLectureID(lecID);
                        if (studentList == null || !studentList.Contains(userStudnet.getUserID()))
                            continue;
                    }

                    description = list[j+1];
                    start = Convert.ToInt32(list[j + 2]);
                    end = Convert.ToInt32(list[j + 3]);
                    day = Convert.ToInt32(list[j + 4]);
                    month = Convert.ToInt32(list[j + 5]);
                    year = Convert.ToInt32(list[j + 6]);

                    DateTime date = new DateTime(year, month, day);
                    DayOfWeek weekday = date.DayOfWeek;

                    foreach (var k in tableLayoutPanel3.Controls)
                    {
                        if (k is Label)
                        {
                            var z = (Label)k;
                            if (z.Text.Contains(date.ToString()))
                            {
                                for (int i = start; i < end; i++)
                                {
                                    string labelName = checkDay(weekday) + i.ToString();
                                    foreach (var c in tableLayoutPanel3.Controls)
                                    {
                                        if (c is Label)
                                        {
                                            var x = (Label)c;
                                            if (x.Name == labelName)
                                            {
                                                x.Text = description;
                                                x.BackColor = Color.Wheat;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

        }
        public string checkDay(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday)
                return "SUN";
            else if (day == DayOfWeek.Monday)
                return "MON";
            else if (day == DayOfWeek.Tuesday)
                return "TUE";
            else if (day == DayOfWeek.Wednesday)
                return "WED";
            else if (day == DayOfWeek.Thursday)
                return "THU";
            else if (day == DayOfWeek.Friday)
                return "FRI";
            return "error";
        }

        public Boolean clearTimeTable(TableLayoutPanel tlp)
        {
            foreach (var c in tlp.Controls)
            {
                if (c is Label)
                {
                    var x = (Label)c;
                    if (!x.Name.Contains("label"))
                        x.Text = "";
                    x.BackColor = MONlabel.BackColor;
                }
            }
            return true;
        }
        private void FormMenuStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "Max Semeter points : 30";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Min Semeter points : 10";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //takes relevant courses from sql
            //(only ones with matching year and semeter and department)
            listView1.Items.Clear();

            for (int i = 0; i < allowedCoursesProperties.Count; i++)
            {
                if (allowedCoursesProperties[i].getCourseName() == comboBox_courses.Text)
                {
                    for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                    {
                        add(allowedCoursesProperties[i].getCourseName(),
                            allowedCoursesProperties[i].getLessons()[j].getType(),
                            allowedCoursesProperties[i].getLessons()[j].getDay(),
                            allowedCoursesProperties[i].getLessons()[j].getStartTime(),
                            allowedCoursesProperties[i].getLessons()[j].getEndTime(),
                            allowedCoursesProperties[i].getLessons()[j].getLessonID());
                    }
                    break;
                }
            }
        }

        private void add(string name,string type,string day,int start,int end, int lectureID)
        {
            string hour = start+":00"+" - "+end+":00";
            string[] row = { name, type, day, hour, Convert.ToString(lectureID)};
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int courseIndex = -1;
            int lessonIndex = -1;

            if (addRemove == "Add")
            {
                for (int i = 0; i < allowedCoursesProperties.Count; i++)
                {
                    for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                    {
                        if (allowedCoursesProperties[i].getLessons()[j].getLessonID().ToString() == listView1.SelectedItems[0].SubItems[4].Text)
                        {
                            courseIndex = i;
                            lessonIndex = j;
                            break;
                        }
                    }
                }

                for (int i = allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getStartTime(); i < allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getEndTime(); i++)
                {
                    string labelName = allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getDay() + Convert.ToString(i);
                    foreach (var c in tableLayoutPanel3.Controls)
                    {
                        if (c is Label)
                        {
                            var x = (Label)c;
                            if (x.Name == labelName && x.Text != "")
                            {
                                MessageBox.Show("Course exists at this hours");
                                return;
                            }
                        }
                    }
                }

                userStudnet.addWeeklyHours(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getEndTime() - allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getStartTime());

                userStudnet.addLessonToRegisteredLessonsIDs(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getLessonID());

                if (allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getType() == "Lecture")
                    userStudnet.addSemesterPoint(allowedCoursesProperties[courseIndex].getCredits());
            }
            else if (addRemove == "Remove")
            {
                for (int i = 0; i < allowedCoursesProperties.Count; i++)
                {
                    for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                    {
                        if (allowedCoursesProperties[i].getLessons()[j].getLessonID().ToString() == listView1.SelectedItems[0].SubItems[4].Text)
                        {
                            courseIndex = i;
                            lessonIndex = j;
                            break;
                        }
                    }
                }

                userStudnet.removeWeeklyHours(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getEndTime() - allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getStartTime());

                userStudnet.removeLessonFromRegisteredLessonsIDs(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getLessonID());

                if (allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getType() == "Lecture")
                    userStudnet.removeSemesterPoint(allowedCoursesProperties[courseIndex].getCredits());

                refreshCoursesToRemove();
            }

            refreshTimeTable(tableLayoutPanel3);
        }

        private void refreshTimeTable(TableLayoutPanel tableLayoutPanel3)
        {
            clearTimeTable(tableLayoutPanel3);

            List<string> name = new List<string>();
            List<string> type = new List<string>();
            List<string> day = new List<string>();
            List<int> startTime = new List<int>();
            List<int> endTime = new List<int>();

            label_weeklyHoursShow.Text = userStudnet.getWeaklyHours().ToString();

            labelSemesterPoints.Text = "Current semester point : " + userStudnet.getSemeterPoints().ToString();
            if (userStudnet.getSemeterPoints() < 10 || userStudnet.getSemeterPoints() > 30)
                labelSemesterPoints.BackColor = Color.Red;
            else labelSemesterPoints.BackColor = Color.Green;

            for (int k = 0; k < userStudnet.getRegisteredCoursesIDs().Count; k++)
            {
                for (int i = 0; i < allowedCoursesProperties.Count; i++)
                {
                    for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                    {
                        if (allowedCoursesProperties[i].getLessons()[j].getLessonID() == userStudnet.getRegisteredCoursesIDs()[k])
                        {
                            name.Add(allowedCoursesProperties[i].getCourseName());
                            type.Add(allowedCoursesProperties[i].getLessons()[j].getType());
                            day.Add(allowedCoursesProperties[i].getLessons()[j].getDay());
                            startTime.Add(allowedCoursesProperties[i].getLessons()[j].getStartTime());
                            endTime.Add(allowedCoursesProperties[i].getLessons()[j].getEndTime());
                        }
                    }
                }
            }

            for (int j = 0; j < name.Count; j++)
            {
                for (int i = startTime[j]; i < endTime[j]; i++)
                {
                    string labelName = day[j] + Convert.ToString(i);
                    foreach (var c in tableLayoutPanel3.Controls)
                    {
                        if (c is Label)
                        {
                            var x = (Label)c;
                            if (x.Name == labelName)
                            {
                                if (x.Text == "")
                                {
                                    x.Text = name[j] + " - " + type[j];
                                    x.BackColor = Color.White;
                                    break;
                                }   
                            }
                        }
                    }
                }
            }
        }

        private void Grades_Click(object sender, EventArgs e)
        {
            FormStudent_StudentGrades grades = new FormStudent_StudentGrades(userStudnet.getUserID());
            grades.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            week += 7;
            DateTime date = DateTime.Today;
            date = date.AddDays(week);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {

                SUNlabel.Text = "Sunday " + date.AddDays(0);
                MONlabel.Text = "Monday " + date.AddDays(1);
                TUElabel.Text = "Tuesday " + date.AddDays(2);
                WEDlabel.Text = "Wednesday " + date.AddDays(3);
                THUlabel.Text = "Thursday " + date.AddDays(4);
                FRIlabel.Text = "Friday " + date.AddDays(5);
            }
            else if (date.DayOfWeek == DayOfWeek.Monday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-1);
                MONlabel.Text = "Monday " + date.AddDays(0);
                TUElabel.Text = "Tuesday " + date.AddDays(1);
                WEDlabel.Text = "Wednesday " + date.AddDays(2);
                THUlabel.Text = "Thursday " + date.AddDays(3);
                FRIlabel.Text = "Friday " + date.AddDays(4);
            }
            else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-2);
                MONlabel.Text = "Monday " + date.AddDays(-1);
                TUElabel.Text = "Tuesday " + date.AddDays(0);
                WEDlabel.Text = "Wednesday " + date.AddDays(1);
                THUlabel.Text = "Thursday " + date.AddDays(2);
                FRIlabel.Text = "Friday " + date.AddDays(3);
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-3);
                MONlabel.Text = "Monday " + date.AddDays(-2);
                TUElabel.Text = "Tuesday " + date.AddDays(-1);
                WEDlabel.Text = "Wednesday " + date.AddDays(0);
                THUlabel.Text = "Thursday " + date.AddDays(1);
                FRIlabel.Text = "Friday " + date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-4);
                MONlabel.Text = "Monday " + date.AddDays(-3);
                TUElabel.Text = "Tuesday " + date.AddDays(-2);
                WEDlabel.Text = "Wednesday " + date.AddDays(-1);
                THUlabel.Text = "Thursday " + date.AddDays(0);
                FRIlabel.Text = "Friday " + date.AddDays(1);
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-5);
                MONlabel.Text = "Monday " + date.AddDays(-4);
                TUElabel.Text = "Tuesday " + date.AddDays(-3);
                WEDlabel.Text = "Wednesday " + date.AddDays(-2);
                THUlabel.Text = "Thursday " + date.AddDays(-1);
                FRIlabel.Text = "Friday " + date.AddDays(0);
            }
            else
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-6);
                MONlabel.Text = "Monday " + date.AddDays(-5);
                TUElabel.Text = "Tuesday " + date.AddDays(-4);
                WEDlabel.Text = "Wednesday " + date.AddDays(-3);
                THUlabel.Text = "Thursday " + date.AddDays(-2);
                FRIlabel.Text = "Friday " + date.AddDays(-1);
            }
            checkChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            week -= 7;
            DateTime date = DateTime.Today;
            date = date.AddDays(week);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {

                SUNlabel.Text = "Sunday " + date.AddDays(0);
                MONlabel.Text = "Monday " + date.AddDays(1);
                TUElabel.Text = "Tuesday " + date.AddDays(2);
                WEDlabel.Text = "Wednesday " + date.AddDays(3);
                THUlabel.Text = "Thursday " + date.AddDays(4);
                FRIlabel.Text = "Friday " + date.AddDays(5);
            }
            else if (date.DayOfWeek == DayOfWeek.Monday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-1);
                MONlabel.Text = "Monday " + date.AddDays(0);
                TUElabel.Text = "Tuesday " + date.AddDays(1);
                WEDlabel.Text = "Wednesday " + date.AddDays(2);
                THUlabel.Text = "Thursday " + date.AddDays(3);
                FRIlabel.Text = "Friday " + date.AddDays(4);
            }
            else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-2);
                MONlabel.Text = "Monday " + date.AddDays(-1);
                TUElabel.Text = "Tuesday " + date.AddDays(0);
                WEDlabel.Text = "Wednesday " + date.AddDays(1);
                THUlabel.Text = "Thursday " + date.AddDays(2);
                FRIlabel.Text = "Friday " + date.AddDays(3);
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-3);
                MONlabel.Text = "Monday " + date.AddDays(-2);
                TUElabel.Text = "Tuesday " + date.AddDays(-1);
                WEDlabel.Text = "Wednesday " + date.AddDays(0);
                THUlabel.Text = "Thursday " + date.AddDays(1);
                FRIlabel.Text = "Friday " + date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-4);
                MONlabel.Text = "Monday " + date.AddDays(-3);
                TUElabel.Text = "Tuesday " + date.AddDays(-2);
                WEDlabel.Text = "Wednesday " + date.AddDays(-1);
                THUlabel.Text = "Thursday " + date.AddDays(0);
                FRIlabel.Text = "Friday " + date.AddDays(1);
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-5);
                MONlabel.Text = "Monday " + date.AddDays(-4);
                TUElabel.Text = "Tuesday " + date.AddDays(-3);
                WEDlabel.Text = "Wednesday " + date.AddDays(-2);
                THUlabel.Text = "Thursday " + date.AddDays(-1);
                FRIlabel.Text = "Friday " + date.AddDays(0);
            }
            else
            {
                SUNlabel.Text = "Sunday " + date.AddDays(-6);
                MONlabel.Text = "Monday " + date.AddDays(-5);
                TUElabel.Text = "Tuesday " + date.AddDays(-4);
                WEDlabel.Text = "Wednesday " + date.AddDays(-3);
                THUlabel.Text = "Thursday " + date.AddDays(-2);
                FRIlabel.Text = "Friday " + date.AddDays(-1);
            }
            checkChanges();
        }

        private void button_currentWeek_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);
            week = 0;
            weekley_view();
            checkChanges();

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            buttonAddCourses.Visible = true;
            buttonRemoveCourses.Visible = true;
            buttonEditTimeTable.Visible = false;
            buttonSaveChanges.Visible = true;
        }

        private void buttonAddCourses_Click(object sender, EventArgs e)
        {
            addRemove = "Add";
            listView1.Items.Clear();
            listView1.Visible = true;
            comboBox_courses.Visible = true;
        }

        private void buttonRemoveCourses_Click(object sender, EventArgs e)
        {
            addRemove = "Remove";
            listView1.Items.Clear();
            listView1.Visible = true;
            comboBox_courses.Visible = false;
            refreshCoursesToRemove();
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (checkTimeTable())
            {
                SQLFunctions.addLecturesToStudent(userStudnet.getUserID(), userStudnet.getRegisteredCoursesIDs(), userStudnet.getSemeterPoints(), userStudnet.getWeaklyHours());
                MessageBox.Show("Timetable was saved");
            }
        }

        private void refreshCoursesToRemove()
        {
            listView1.Items.Clear();

            for (int i = 0; i<userStudnet.getRegisteredCoursesIDs().Count; i++)
            {
                for (int j = 0; j<allowedCoursesProperties.Count; j++)
                {
                    for (int k = 0; k<allowedCoursesProperties[j].getLessons().Count; k++)
                    {
                        if (allowedCoursesProperties[j].getLessons()[k].getLessonID() == userStudnet.getRegisteredCoursesIDs()[i])
                        {
                            add(allowedCoursesProperties[j].getCourseName(),
                                allowedCoursesProperties[j].getLessons()[k].getType(),
                                allowedCoursesProperties[j].getLessons()[k].getDay(),
                                allowedCoursesProperties[j].getLessons()[k].getStartTime(),
                                allowedCoursesProperties[j].getLessons()[k].getEndTime(),
                                allowedCoursesProperties[j].getLessons()[k].getLessonID());
                        }
                    }
                }
            }
        }
    }
}
