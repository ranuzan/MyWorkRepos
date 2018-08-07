using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace A_8
{
    class Lesson
    {
        private int lessonID;
        private string day;
        private int starts;
        private int ends;
        private string type;
        private Classroom classroom;

        public Lesson(int _id)
        {
            DataRow row = SQLFunctions.getLessonProperties(_id);

            lessonID = _id;
            day = row["Day"].ToString();
            starts = Convert.ToInt32(row["StartHour"]);
            ends = Convert.ToInt32(row["EndHour"]);
            type = row["Type"].ToString();
            classroom = new Classroom(row["Classroom"].ToString());
        }

        public int getLessonID()
        {
            return lessonID;
        }

        public string getDay()
        {
            return day;
        }
        public int getStartTime()
        {
            return starts;
        }
        public int getEndTime()
        {
            return ends;
        }
        public string getType()
        {
            return type;
        }

        public Classroom getClassroom()
        {
            return classroom;
        }
    }
}
