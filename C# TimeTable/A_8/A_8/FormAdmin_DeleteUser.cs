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
    public partial class FormAdmin_DeleteUser : Form
    {
        public FormAdmin_DeleteUser()
        {
            InitializeComponent();
            DataTable users = new DataTable();
            
            this.AcceptButton = button_Accept;
            users=SQLFunctions.getUsers();
            if(users!=null)
            {
                for(int i=0;i<users.Rows.Count;i++)
                {
                    string[] row = { users.Rows[i]["ID"].ToString(), users.Rows[i]["FirstName"].ToString(), users.Rows[i]["LastName"].ToString(), users.Rows[i]["Role"].ToString(), users.Rows[i]["Department"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    listView1.Items.Add(item);
                }
            }
        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void checkBox_Accept_Click(object sender, EventArgs e)
        {
            if(checkBox_Accept.Checked)
            {
                button_Accept.Enabled = true;
            }
            else
            {
                button_Accept.Enabled = false;
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if(SQLFunctions.checkExistsUsers(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text))==true)
            {
                SQLFunctions.deleteUser(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                MessageBox.Show("User with ID: "+ listView1.SelectedItems[0].SubItems[0].Text+" was deleted!");
                this.Hide();
                FormMenuAdmin adminForm = new FormMenuAdmin();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("User ID could not be located in the database");
            }
       
        }

        private void textBox_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FormAdminDeleteUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void label_Headline_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_Accept.Visible = true;
        }
    }
}
