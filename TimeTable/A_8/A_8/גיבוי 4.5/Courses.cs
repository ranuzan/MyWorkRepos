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
        private char semester;
        private string department;
        private List<Lesson> lessonsList;

        public Courses(int id)
        {
            DataTable courseProperties = SQLFunctions.getCourseProperties(id);
            courseID = id;
            DataRow row = courseProperties.Rows[0];
            name = row["Name"].ToString();
            if (row["PreReqID"] == DBNull.Value)
                preReqID = -1;
            else
                preReqID = Convert.ToInt32(row["PreReqID"]);
            credits = (float)Convert.ToDouble(row["Credits"]);
            lectureHours = Convert.ToInt32(row["LectureHour"]);
            practiceHours = Convert.ToInt32(row["PracticeHour"]);
            receptionHours = Convert.ToInt32(row["receiptHour"]);
            year = Convert.ToInt32(row["yearSemester"]);
            if ((Convert.ToInt32(row["yearSemester"]) % 1 * 10) == 1)
                semester = 'A';
            else
                semester = 'B';   
            department = row["Department"].ToString();
            lessonsList = new List<Lesson>();
            foreach (DataRow rows in courseProperties.Rows)
            {
                Lesson lesson = new Lesson(Convert.ToInt32(rows["LectureID"]), rows["day"].ToString(),Convert.ToInt32(rows["starts"]), Convert.ToInt32(rows["ends"]), rows["Type"].ToString());
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
        public char getSemester()
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
