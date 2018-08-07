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

        public Admin(int _id) :base(_id)
        {
            notifications = false;
        }
        public static void Add_user()
        {
            FormAdmin_AddUser addUserForm = new FormAdmin_AddUser();
            addUserForm.Show();
        }
        public static void Add_classroom()
        {

            FormAdmin_AddClassroom add_class = new FormAdmin_AddClassroom();
            add_class.Show();
        }
        public static void Delete_user()
        {

            FormAdmin_DeleteUser delete_user = new FormAdmin_DeleteUser();
            delete_user.Show();
        }
        public static void Remove_classroom()
        {

            FormAdmin_RemoveClassroom remove_classroom = new FormAdmin_RemoveClassroom();
            remove_classroom.Show();
        }
        public static void Change_Permission()
        {

            FormAdmin_ChangePermission change_permission = new FormAdmin_ChangePermission();
            change_permission.Show();
        }

    }
}
