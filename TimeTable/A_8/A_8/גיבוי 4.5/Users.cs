using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Users(int _id, string _password, string _firstName, string _lastName, string _department)
        {
            id = _id;
            password = _password;
            firstName = _firstName;
            lastName = _lastName;
            department = _department;
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
