using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_8
{
    class Admin:Users
    {
        private bool notifications;
        public Admin():base()
        {
            notifications = false;
        }

    }
}
