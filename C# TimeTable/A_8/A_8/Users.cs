using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace A_8
{
    class Users
    {
        int id;
        string password;
        string firstName;
        string lastName;
        string department;

        public Users() { }

        public Users(int _id)
        {
            DataRow row = SQLFunctions.getUserProperties(_id);

            id = _id;
            password = row["Password"].ToString();
            firstName = row["FirstName"].ToString();
            lastName = row["LastName"].ToString();
            department = row["Department"].ToString();
        }

        public int getUserID()
        {
            return id;
        }

        public string getUserName()
        {
            return firstName + " " + lastName;
        }

        public string getDepartment()
        {
            return department;
        }
    }
}
