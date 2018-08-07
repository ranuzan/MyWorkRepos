using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_8
{
    class Lesson
    {
        private int lessonID;
        private string day;
        private int starts;
        private int ends;
        private string type;
        public Lesson(int id,string day,int start,int end,string type)
        {
            lessonID = id;
            this.day = day;
            starts = start;
            ends = end;
            this.type = type;
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
    }
}
