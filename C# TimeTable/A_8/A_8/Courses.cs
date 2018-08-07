using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace A_8
{
    class Courses
    {
        private int courseID;
        private string name;
        private int preReqID;
        private float credits;
        private int lectureHours;
        private int practiceHours;
        private int receptionHours;
        private int year;
        private string semester;
        private string department;
        private List<Lesson> lessonsList;

        public Courses(int id)
        {
            DataTable courseProperties = SQLFunctions.getCourseProperties(id);
            if (courseProperties == null)
                return;
            DataRow row = courseProperties.Rows[0];
            courseID = id;
            name = row["Name"].ToString();
            if (row["PreReqID"] == DBNull.Value)
                preReqID = -1;
            else
                preReqID = Convert.ToInt32(row["PreReqID"]);
            credits = (float)Convert.ToDouble(row["Credits"]);
            lectureHours = Convert.ToInt32(row["LectureHour"]);
            practiceHours = Convert.ToInt32(row["PracticeHour"]);
            receptionHours = Convert.ToInt32(row["ReceptionHour"]);
            year = Convert.ToInt32(row["Year"]);
            semester = (row["Semester"]).ToString();
            department = row["Department"].ToString();
            lessonsList = new List<Lesson>();
            foreach (DataRow rows in courseProperties.Rows)
            {
                Lesson lesson = new Lesson(Convert.ToInt32(rows["LectureID"]));
                lessonsList.Add(lesson);
            }
        }

        public int getCourseID()
        {
            return courseID;
        }

        public string getCourseName()
        {
            return name;
        }

        public int getPreReqCourseID()
        {
            return preReqID;
        }

        public float getCredits()
        {
            return credits;
        }

        public int getLectureHours()
        {
            return lectureHours;
        }

        public int getPracticeHours()
        {
            return practiceHours;
        }

        public int getReceptionHours()
        {
            return receptionHours;
        }

        public int getYear()
        {
            return year;
        }

        public string getSemester()
        {
            return semester;
        }

        public string getDepartment()
        {
            return department;
        }

        public List<Lesson> getLessons()
        {
            return lessonsList;
        }

    }
}
