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
        string department;
        int weeklyHours;
        string[] failedCourses;
        float semesterPoints;
        bool notification;

        public bool addCourse(int courseID)
        {
            return false;
        }

        public bool deleteCourse(int courseID)
        {
            return false;
        }

        public bool passWeek(DateTime date)
        {
            return false;
        }

        public bool searchWeek(DateTime date)
        {
            return false;
        }

        public bool toCurrentWeek()
        {
            return false;
        }

        public bool changeView(bool type)
        {
            return false;
        }



    }
}
