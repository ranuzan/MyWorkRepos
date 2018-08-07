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
    public partial class FormAdmin_RemoveClassroom : Form
    {
        public FormAdmin_RemoveClassroom()
        {
            InitializeComponent();
            this.AcceptButton = button_Accept;
            DataTable classes=SQLFunctions.getClassrooms();
            if(classes!=null)
            {
                for(int i=0;i<classes.Rows.Count;i++)
                {
                    string[] row = {classes.Rows[i]["Name"].ToString(),classes.Rows[i]["Capacity"].ToString(),classes.Rows[i]["Type"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    listView1.Items.Add(item);
                }
            }
        }

        private void checkBox_Accept_Click(object sender, EventArgs e)
        {
            if (checkBox_Accept.Checked)
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
            if (SQLFunctions.checkExistsClassroom(listView1.SelectedItems[0].SubItems[0].Text) == true)
            {
                SQLFunctions.deleteClassroom(listView1.SelectedItems[0].SubItems[0].Text);
                MessageBox.Show("Class "+ listView1.SelectedItems[0].SubItems[0].Text + " was deleted!");
                this.Hide();
                FormMenuAdmin adminForm = new FormMenuAdmin();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("Classroom was not found");
            }
        }

        private void textBox_ClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void FormAdminRemoveClassroom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }



        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_Accept.Visible = true;

        }
    }
}
