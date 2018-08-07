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
        public Users()
        {
            id = 0;
            password = "0";
            firstName = "none";
            lastName = "none";
        }
        public Users(int id,string password,string firstName,string lastName)
        {

        }
    }
}
