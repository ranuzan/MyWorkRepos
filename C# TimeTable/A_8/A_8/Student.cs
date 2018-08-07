using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace A_8
{
    class Student : Users
    {
        int year;
        string semester;
        List<int> failedCoursesID;
        float semesterPoints;
        bool notification;
        int weeklyHours;
        List<int> registeredLessonsIDs;

        public Student() : base() { }

        public Student(int _id) : base(_id)
        {
            DataRow row = SQLFunctions.getStudentProperties(_id);

            year = Convert.ToInt32(row["Year"]);
            semester = (row["Semester"]).ToString();
            failedCoursesID = SQLFunctions.getStudentFailedCoursesIDs(_id);
            semesterPoints = (float)Convert.ToDouble(row["SemesterPoint"]);
            notification = Convert.ToBoolean(row["Notification"]);
            weeklyHours = Convert.ToInt32(row["WeeklyHours"]);
            registeredLessonsIDs = SQLFunctions.findStudentLecturesIDs(_id);
        }
        public bool getNotification()
        {
            return notification;
        }
        public void setNotification(bool notification)
        {
            this.notification=notification;
        }

        public List<int> getRegisteredLessonsIDs()
        {
            return registeredLessonsIDs;
        }

        public int getWeaklyHours()
        {
            return weeklyHours;
        }

        public int getYear()
        {
            return year;
        }
        public float getSemeterPoints()
        {
            return semesterPoints;
        }
        public string getSemester()
        {
            return semester;
        }

        public void addLessonToRegisteredLessonsIDs(int _lessonID)
        {
            registeredLessonsIDs.Add(_lessonID);
        }

        public void removeLessonFromRegisteredLessonsIDs(int _lessonID)
        {
            registeredLessonsIDs.Remove(_lessonID);
        }

        public void addSemesterPoint(float _points)
        {
            semesterPoints += _points;
        }

        public void removeSemesterPoint(float _points)
        {
            semesterPoints -= _points;
        }

        public void addWeeklyHours(int _weeklyHours)
        {
            weeklyHours += _weeklyHours;
        }

        public void removeWeeklyHours(int _weeklyHours)
        {
            weeklyHours -= _weeklyHours;
        }
    }
}
