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
    }
}
