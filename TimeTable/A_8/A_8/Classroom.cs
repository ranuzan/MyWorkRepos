using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace A_8
{
    class Classroom
    {
        string name;
        int capacity;

        public Classroom(string _name)
        {
            DataRow row = SQLFunctions.getClassroomProperties(_name);

            name = _name;
            capacity = Convert.ToInt32(row["Capacity"]);
        }

        public int getCapacity()
        {
            return capacity;
        }

        public string getName()
        {
            return name;
        }
    }
}
