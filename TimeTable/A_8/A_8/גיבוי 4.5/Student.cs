using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_8
{
    class Student : Users
    {
        int year;
        bool semester;
        List<int> failedCoursesID;
        float semesterPoints;
        bool notification;
        int weeklyHours;
        List<int> registeredLessonsIDs;

        public Student() : base() { }

        public Student(int _id, string _password) : base(_id, _password, SQLFunctions.covertStudentIDtoStudentFirstName(_id), SQLFunctions.covertStudentIDtoStudentLastName(_id), SQLFunctions.getStudentDepartment(_id))
        {
            year = SQLFunctions.getStudentYear(_id);
            semester = SQLFunctions.getStudentSemester(_id);
            failedCoursesID = SQLFunctions.getStudentFailedCoursesIDs(_id);
            semesterPoints = SQLFunctions.getStudentSemesterPoints(_id);
            notification = SQLFunctions.getStudentNotificationsState(_id);
            weeklyHours = SQLFunctions.getStudentWeeklyHours(_id);
            registeredLessonsIDs = SQLFunctions.findStudentLecturesIDs(_id);
        }

        public List<int> getRegisteredCoursesIDs()
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
        public bool getSemester()
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
