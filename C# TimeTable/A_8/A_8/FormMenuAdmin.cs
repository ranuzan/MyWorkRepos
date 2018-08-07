using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{ 
    public partial class FormMenuAdmin : Form
    {
        public FormMenuAdmin()
        {
            InitializeComponent();

            int newNotificationCount = 0;
            DataTable notifications = SQLFunctions.getErrors();
            if (notifications != null)
            {
                for (int i = 0; i < notifications.Rows.Count; i++)
                {
                    if (notifications.Rows[i]["Viewed"].ToString() == "False")
                        newNotificationCount++;
                }


                if (newNotificationCount > 0)
                {
                    labelNotificationCount.Text = newNotificationCount.ToString();
                    labelNotificationCount.Visible = true;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Add_user();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Add_classroom();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Change_Permission();
        }

        private void button_DeleteUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Delete_user();
        }

        private void button_RemoveClassroom_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Remove_classroom();
        }

        private void FormMenuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonViewErrors_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdminViewErros viewErrors = new FormAdminViewErros();
            viewErrors.Show();
        }

        private void FormMenuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
