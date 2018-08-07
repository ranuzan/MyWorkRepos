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
    public partial class FormAdmin_ChangePermission : Form
    {
        public FormAdmin_ChangePermission()
        {
            InitializeComponent();
            AcceptButton = button_Accept;
            textBox_UserID.MaxLength = 9;
            comboBox_Permission.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {

            if (textBox_UserID.TextLength > 8)
            {
                comboBox_Permission.Enabled = true;
            }
            else
            {
                comboBox_Permission.Enabled = false;
                comboBox_Permission.Enabled = false;
                button_Accept.Enabled = false;
                checkBox_Agree.Visible = false;
                checkBox_Agree.Checked = false;            }
        }

        private void checkBox_Agree_Click(object sender, EventArgs e)
        {
            if (checkBox_Agree.Checked)
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
            if (SQLFunctions.checkExistsUsers(Convert.ToInt32(textBox_UserID.Text)) == true)
            {
                if(SQLFunctions.checkRole(Convert.ToInt32(textBox_UserID.Text))!=comboBox_Permission.Text)
                 { 
                    SQLFunctions.updateUserRole(Convert.ToInt32(textBox_UserID.Text),comboBox_Permission.Text);
                    MessageBox.Show("User permission was changed to " + comboBox_Permission.Text+".");
                    this.Hide();
                    FormMenuAdmin adminForm = new FormMenuAdmin();
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("This user is already "+comboBox_Permission.Text);
                }
            }
            else
            {
                MessageBox.Show("User ID could not be located in the database");
            }

        }

        private void comboBox_Permission_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox_Permission.SelectedIndex == 0 || comboBox_Permission.SelectedIndex == 1)
            {
                comboBox_Department.Visible = true;
                label_Department.Visible = true;
                checkBox_Agree.Visible = false;
                checkBox_Agree.Checked = false;
            }
            if (comboBox_Permission.SelectedIndex == 2 || comboBox_Permission.SelectedIndex == 3)
            {
                comboBox_Department.Visible = false;
                label_Department.Visible = false;
                checkBox_Agree.Visible = true;
            }
        }

        private void textBox_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FormAdminChangePermission_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox_Agree.Visible = true;
        }
    }
}
