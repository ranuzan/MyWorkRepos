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
        int id = 0;
        Student userStudnet = new Student();
        List<Courses> allowedCoursesProperties = new List<Courses>();
        int week=0;
        string addRemove;

        public FormMenuStudent(int _id, string _password)
        {
            InitializeComponent();
            comboBox_courses.DropDownStyle = ComboBoxStyle.DropDown;
            id=_id;
            userStudnet = new Student(_id);

            if (userStudnet.getNotification())
                pictureBox1.Visible = true;

            List<int> allowedCoursesIDs = SQLFunctions.findAllowedCoursesForStudent(userStudnet.getUserID(), userStudnet.getYear(), userStudnet.getSemester(), userStudnet.getDepartment());

            for(int i=0;i< allowedCoursesIDs.Count;i++)
            {
                if ((new Courses(allowedCoursesIDs[i])).getCourseName() != null)
                {
                    allowedCoursesProperties.Add(new Courses(allowedCoursesIDs[i]));
                }
            }

            for (int i = 0; i < allowedCoursesProperties.Count; i++)
                comboBox_courses.Items.Add(allowedCoursesProperties[i].getCourseName());

            label3.Text = "Hello: " + userStudnet.getUserName();

            label_weeklyHoursShow.Text = Convert.ToString(userStudnet.getWeaklyHours());

            refreshTimeTable(tableLayoutPanel3);

            if (userStudnet.getNotification())
                pictureBox1.Visible = true;
        }

        private bool checkTimeTableAtAdding(int _courseIndex, int _lessonIndex)
        {
            Lesson lessonToAdd = allowedCoursesProperties[_courseIndex].getLessons()[_lessonIndex];

            for (int i = 0; i < allowedCoursesProperties.Count; i++)
            {
                if (allowedCoursesProperties[i].getCourseID() == allowedCoursesProperties[_courseIndex].getCourseID())
                {
                    for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                    {
                        if (allowedCoursesProperties[i].getLessons()[j].getType() == lessonToAdd.getType() &&
                            userStudnet.getRegisteredLessonsIDs().Contains(allowedCoursesProperties[i].getLessons()[j].getLessonID()))
                        {
                            MessageBox.Show("You already added " + allowedCoursesProperties[_courseIndex].getCourseName() + " " + lessonToAdd.getType());
                            return false;
                        }
                    }
                }
            }

            for (int i = 0; i < allowedCoursesProperties.Count; i++)
            {
                for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                {
                    if (userStudnet.getRegisteredLessonsIDs().Contains(allowedCoursesProperties[i].getLessons()[j].getLessonID()) &&
                        allowedCoursesProperties[i].getLessons()[j].getDay() == lessonToAdd.getDay())
                    {
                        if ((lessonToAdd.getStartTime() >= allowedCoursesProperties[i].getLessons()[j].getStartTime() && lessonToAdd.getStartTime() < allowedCoursesProperties[i].getLessons()[j].getEndTime()) ||
                            (lessonToAdd.getEndTime() > allowedCoursesProperties[i].getLessons()[j].getStartTime() && lessonToAdd.getEndTime() <= allowedCoursesProperties[i].getLessons()[j].getEndTime()))
                        {
                            MessageBox.Show("You already have lesson on these hours");
                            return false;
                        }
                    }
                }
            }

            if (lessonToAdd.getType() == "Lecture" && userStudnet.getSemeterPoints() + allowedCoursesProperties[_courseIndex].getCredits() > 30)
            {
                    MessageBox.Show("Semester points is over");
                    return false;
            }

            if (SQLFunctions.getNumberOfRegisteredStudentsAtLesson(lessonToAdd.getLessonID()) >= new Lesson(lessonToAdd.getLessonID()).getClassroom().getCapacity())
            {
                MessageBox.Show("This class is full");
                return false;
            }

            return true;
        }

        private bool checkTimeTableAtSaving()
        {
            List<int> lecturesCoursesIDs = new List<int>();
            List<int> practicesCoursesIDs = new List<int>();

            if (userStudnet.getSemeterPoints() < 10)
            {
                MessageBox.Show("You must have at least 10 semester points");
                return false;
            }

            for (int i = 0; i < allowedCoursesProperties.Count; i++)
            {
                for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                {
                    if (userStudnet.getRegisteredLessonsIDs().Contains(allowedCoursesProperties[i].getLessons()[j].getLessonID()))
                    {
                        if (allowedCoursesProperties[i].getLessons()[j].getType() == "Lecture")
                            lecturesCoursesIDs.Add(allowedCoursesProperties[i].getCourseID());
                        else if (allowedCoursesProperties[i].getLessons()[j].getType() == "Practice")
                            practicesCoursesIDs.Add(allowedCoursesProperties[i].getCourseID());
                    }
                }
            }

            if (!(lecturesCoursesIDs.All(practicesCoursesIDs.Contains) && practicesCoursesIDs.All(lecturesCoursesIDs.Contains)))
            {
                MessageBox.Show("Not all lectures has a practices or not all pratices has a lectures");
                return false;
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            buttonEditTimeTable.Visible = true;


            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            button_weeklyView.Visible = true;
            button_semesterView.Visible = false;
            button_previous.Visible = false;
            button_next.Visible = false;
            button_currentWeek.Visible = false;
            labelNext.Visible = false;
            labelBack.Visible = false;
            labelCurrentWeek.Visible = false;
            Sundaylabel.Text = "Sunday";
            Mondaylabel.Text = "Monday";
            Tuesdaylabel.Text = "Tuesday";
            Wednesdaylabel.Text = "Wednesday";
            Thursdaylabel.Text = "Thursday";
            Fridaylabel.Text = "Friday";
            Sundaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Mondaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Tuesdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Wednesdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Thursdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Fridaylabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        public void weekley_view(int day= 0)
        {
            week += day;
            DateTime date = DateTime.Today;
            date = date.AddDays(week);
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(0).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(1).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n " + date.AddDays(2).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(3).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(4).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(5).ToShortDateString();
            }
            else if (date.DayOfWeek == DayOfWeek.Monday)
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(-1).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(0).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(1).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(2).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(3).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(4).ToShortDateString();
            }
            else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(-2).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(-1).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(0).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(1).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(2).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(3).ToShortDateString();
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(-3).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(-2).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(-1).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(0).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(1).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(2).ToShortDateString();
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                Sundaylabel.Text = "Sunday" + "\n" + date.AddDays(-4).ToShortDateString(); 
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(-3).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(-2).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(-1).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(0).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(1).ToShortDateString();
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(-5).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(-4).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(-3).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(-2).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(-1).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(0).ToShortDateString();
            }
            else
            {
                Sundaylabel.Text = "Sunday " + "\n" + date.AddDays(-6).ToShortDateString();
                Mondaylabel.Text = "Monday " + "\n" + date.AddDays(-5).ToShortDateString();
                Tuesdaylabel.Text = "Tuesday " + "\n" + date.AddDays(-4).ToShortDateString();
                Wednesdaylabel.Text = "Wednesday " + "\n" + date.AddDays(-3).ToShortDateString();
                Thursdaylabel.Text = "Thursday " + "\n" + date.AddDays(-2).ToShortDateString();
                Fridaylabel.Text = "Friday " + "\n" + date.AddDays(-1).ToShortDateString();
            }
            Sundaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Mondaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Tuesdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Wednesdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Thursdaylabel.TextAlign = ContentAlignment.MiddleCenter;
            Fridaylabel.TextAlign = ContentAlignment.MiddleCenter;
        }

      
        private void button6_Click(object sender, EventArgs e)
        {
            buttonAddCourses.Visible = false;
            buttonRemoveCourses.Visible = false;
            buttonSaveChanges.Visible = false;
            listView1.Visible = false;
            comboBox_courses.Visible = false;
            buttonEditTimeTable.Visible = false;


            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

            button_semesterView.Visible = true;
            button_weeklyView.Visible = false;
            button_previous.Visible = true;
            button_next.Visible = true;
            button_currentWeek.Visible = true;
            labelBack.Visible = true;
            labelNext.Visible = true;
            labelCurrentWeek.Visible = true;

            Sundaylabel.AutoSize = true;
            Mondaylabel.AutoSize = true;
            Tuesdaylabel.AutoSize = true;
            Wednesdaylabel.AutoSize = true;
            Thursdaylabel.AutoSize = true;
            Fridaylabel.AutoSize = true;

            Sundaylabel.TextAlign = ContentAlignment.TopLeft;
            Mondaylabel.TextAlign = ContentAlignment.TopLeft;
            Tuesdaylabel.TextAlign = ContentAlignment.TopLeft;
            Wednesdaylabel.TextAlign = ContentAlignment.TopLeft;
            Thursdaylabel.TextAlign = ContentAlignment.TopLeft;
            Fridaylabel.TextAlign = ContentAlignment.TopLeft;
            weekley_view();

            checkChanges();
           
        }

        public void checkChanges()
        {
            List<int> LectureIDS = new List<int>();
            List<List<int>> studentList = new List<List<int>>();
            List<int> studentsInLecture = new List<int>();
            int lecID = 200003;
            string description = "";
            int start = 13;
            int end = 17;
            int day = 1;
            int month = 5;
            int year = 2017;

            DataTable changes_dt = SQLFunctions.getChanges();
            DataTable studentsTimeTable = SQLFunctions.getStudentsTimetable(id);
           
            if (changes_dt != null && studentsTimeTable != null)
            {
                for (int i = 0; i < changes_dt.Rows.Count; i++)
                {
                    LectureIDS.Add(Convert.ToInt32(changes_dt.Rows[i]["LectureID"]));
                }
                for (int i = 0; i < LectureIDS.Count; i++)
                {
                    for (int j = 0; j < studentsTimeTable.Rows.Count; j++)
                    {
                        
                        if (LectureIDS[i] == 0||Convert.ToInt32(studentsTimeTable.Rows[j]["LectureID"]) == LectureIDS[i])
                        {
                            studentsInLecture.Add(Convert.ToInt32(studentsTimeTable.Rows[j]["StudentID"]));
                        }
                        if (studentsInLecture != null)
                            studentList.Add(studentsInLecture);
                    }
                }
                for (int j = 0; j < changes_dt.Rows.Count; j++)
                {
                    for (int h = 0; h < studentsTimeTable.Rows.Count; h++)
                    {
                        if (Convert.ToInt32(studentsTimeTable.Rows[h]["LectureID"]) == LectureIDS[j]||LectureIDS[j]==0)
                        {
                            lecID = Convert.ToInt32(changes_dt.Rows[j]["LectureID"]);
                            if (lecID != 0)
                            {
                                if (studentList[j] == null || !studentList[j].Contains(userStudnet.getUserID()))
                                    continue;
                            }
                            description = changes_dt.Rows[j]["Description"].ToString();
                            start = Convert.ToInt32(changes_dt.Rows[j]["Starts"]);
                            end = Convert.ToInt32(changes_dt.Rows[j]["Ends"]); ;
                            day = Convert.ToInt32(changes_dt.Rows[j]["day"]);
                            month = Convert.ToInt32(changes_dt.Rows[j]["month"]);
                            year = Convert.ToInt32(changes_dt.Rows[j]["year"]);
                            DateTime date = new DateTime(year, month, day);
                            DayOfWeek weekday = date.DayOfWeek;

                            foreach (var k in tableLayoutPanel3.Controls)
                            {
                                if (k is Label)
                                {
                                    var z = (Label)k;
                                    if (z.Text.Contains(date.ToShortDateString()))
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
                                                        x.BackColor = Color.Aqua;
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
            }
        }
        public string checkDay(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday)
                return "Sunday";
            else if (day == DayOfWeek.Monday)
                return "Monday";
            else if (day == DayOfWeek.Tuesday)
                return "Tuesday";
            else if (day == DayOfWeek.Wednesday)
                return "Wednesday";
            else if (day == DayOfWeek.Thursday)
                return "Thursday";
            else if (day == DayOfWeek.Friday)
                return "Friday";
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
                    x.BackColor = Mondaylabel.BackColor;
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

            if (addRemove == "Add")
            {
                if (checkTimeTableAtAdding(courseIndex, lessonIndex))
                {
                    userStudnet.addLessonToRegisteredLessonsIDs(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getLessonID());

                    userStudnet.addWeeklyHours(allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getEndTime() - allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getStartTime());

                    if (allowedCoursesProperties[courseIndex].getLessons()[lessonIndex].getType() == "Lecture")
                        userStudnet.addSemesterPoint(allowedCoursesProperties[courseIndex].getCredits());
                }
            }
            else if (addRemove == "Remove")
            {
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
            List<string> classroom = new List<string>();

            label_weeklyHoursShow.Text = userStudnet.getWeaklyHours().ToString();

            labelSemesterPoints.Text = userStudnet.getSemeterPoints().ToString();
            if (userStudnet.getSemeterPoints() < 10 || userStudnet.getSemeterPoints() > 30)
                labelSemesterPoints.ForeColor = Color.Red;
            else labelSemesterPoints.ForeColor = Color.Green;
            if (userStudnet.getRegisteredLessonsIDs() != null)
            {
                for (int k = 0; k < userStudnet.getRegisteredLessonsIDs().Count; k++)
                {
                    for (int i = 0; i < allowedCoursesProperties.Count; i++)
                    {
                        for (int j = 0; j < allowedCoursesProperties[i].getLessons().Count; j++)
                        {
                            if (allowedCoursesProperties[i].getLessons()[j].getLessonID() == userStudnet.getRegisteredLessonsIDs()[k])
                            {
                                name.Add(allowedCoursesProperties[i].getCourseName());
                                type.Add(allowedCoursesProperties[i].getLessons()[j].getType());
                                day.Add(allowedCoursesProperties[i].getLessons()[j].getDay());
                                startTime.Add(allowedCoursesProperties[i].getLessons()[j].getStartTime());
                                endTime.Add(allowedCoursesProperties[i].getLessons()[j].getEndTime());
                                classroom.Add(allowedCoursesProperties[i].getLessons()[j].getClassroom().getName());
                            }
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
                                    x.Text = name[j] + "\n" + type[j] + "\n" + classroom[j];
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
            DateTime date = DateTime.Today;
            weekley_view(7);
            checkChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTimeTable(tableLayoutPanel3);
            refreshTimeTable(tableLayoutPanel3);

          
            DateTime date = DateTime.Today;
            weekley_view(-7);
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
            comboBox_courses.Text = "Please select course...";
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
            if (checkTimeTableAtSaving())
            {
                buttonSaveChanges.Visible = false;
                buttonAddCourses.Visible = false;
                listView1.Visible = false;
                buttonRemoveCourses.Visible = false;
                comboBox_courses.Visible = false;
                buttonEditTimeTable.Visible = true;
                SQLFunctions.addLecturesToStudent(userStudnet.getUserID(), userStudnet.getRegisteredLessonsIDs(), userStudnet.getSemeterPoints(), userStudnet.getWeaklyHours());
                MessageBox.Show("Timetable was saved");
            }
        }

        private void refreshCoursesToRemove()
        {
            listView1.Items.Clear();

            if (userStudnet.getRegisteredLessonsIDs() == null)
                return;

            for (int i = 0; i<userStudnet.getRegisteredLessonsIDs().Count; i++)
            {
                for (int j = 0; j<allowedCoursesProperties.Count; j++)
                {
                    for (int k = 0; k<allowedCoursesProperties[j].getLessons().Count; k++)
                    {
                        if (allowedCoursesProperties[j].getLessons()[k].getLessonID() == userStudnet.getRegisteredLessonsIDs()[i])
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

        private void buttonReportError_Click(object sender, EventArgs e)
        {
            FormReportError reportError = new FormReportError(userStudnet.getUserID());
            reportError.Show();
        }

        private void buttonViewChanges_Click(object sender, EventArgs e)
        {
            //change window + notiication
            FormStudent_ViewChanges viewChange = new FormStudent_ViewChanges(userStudnet.getUserID());
            viewChange.Show();
            userStudnet.setNotification(false);
            pictureBox1.Visible = false;
            SQLFunctions.ChangeStudentNotificationState(new List<int> { userStudnet.getUserID() }, "False");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelNotificationCount_Click(object sender, EventArgs e)
        {

        }

        private void FormMenuStudent_Load(object sender, EventArgs e)
        {

        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            // log out option for student
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonViewGrades_Click(object sender, EventArgs e)
        {
            FormStudent_StudentGrades grades = new FormStudent_StudentGrades(userStudnet.getUserID());
            grades.Show();
        }

        private void buttonChanges_Click(object sender, EventArgs e)
        {
            //change window + notiication
            FormStudent_ViewChanges viewChange = new FormStudent_ViewChanges(userStudnet.getUserID());
            viewChange.Show();
            userStudnet.setNotification(false);
            pictureBox1.Visible = false;
            SQLFunctions.ChangeStudentNotificationState(new List<int> { userStudnet.getUserID() }, "False");
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }
    }
}
