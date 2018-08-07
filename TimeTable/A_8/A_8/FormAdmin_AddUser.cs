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
    public partial class FormAdmin_AddUser : Form
    {

        public FormAdmin_AddUser()
        {
            InitializeComponent();
            this.AcceptButton = button_Accept;
            textBox_ID.MaxLength = 9;
            textBox_Password.MaxLength=15;
            textBox_FirstName.MaxLength = 15;
            textBox_LastName.MaxLength = 20;
            comboBox_Permission.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;
       
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (SQLFunctions.checkExistsUsers(Convert.ToInt32(textBox_ID.Text)) == false)
            {
                if (!SQLFunctions.checkExistsEmail(textBox_email.Text))
                {
                    if (textBox_email.Text.Contains("@"))
                    {
                        if (comboBox_Permission.Text == "Student Secretary")
                        {
                            SQLFunctions.insertUser(textBox_email.Text, Convert.ToInt32(textBox_ID.Text), textBox_Password.Text, textBox_FirstName.Text, textBox_LastName.Text, "SecretaryA", comboBox_Department.Text);
                        }
                        else if (comboBox_Permission.Text == "Department Secretary")
                        {
                            SQLFunctions.insertUser(textBox_email.Text, Convert.ToInt32(textBox_ID.Text), textBox_Password.Text, textBox_FirstName.Text, textBox_LastName.Text, "Secretary", comboBox_Department.Text);
                        }
                   
                        else
                        {
                            SQLFunctions.insertUser(textBox_email.Text, Convert.ToInt32(textBox_ID.Text), textBox_Password.Text, textBox_FirstName.Text, textBox_LastName.Text, comboBox_Permission.Text, comboBox_Department.Text);
                        }
                        if (comboBox_Permission.SelectedIndex == 3)
                        {
                            MessageBox.Show(textBox_LastName.Text + " " + textBox_FirstName.Text + " was added as an " + comboBox_Permission.Text);
                        }
                        else if(comboBox_Permission.SelectedIndex==2)
                        {
                            MessageBox.Show(textBox_LastName.Text + " " + textBox_FirstName.Text + " was added as an " + comboBox_Permission.Text + " employee");
                        }
                        else 
                        {
                            MessageBox.Show(textBox_LastName.Text + " " + textBox_FirstName.Text + " was added as a " + comboBox_Permission.Text + " in " + comboBox_Department.Text + " department.");
                        }
                        this.Hide();
                        FormMenuAdmin adminForm = new FormMenuAdmin();
                        adminForm.Show();
                    }
                    else
                        MessageBox.Show("Invalid Email address");
                }
               else
                   MessageBox.Show("Email " + textBox_email.Text + " is already registered in the system");
            }
            else
            {
                MessageBox.Show("Student " + textBox_FirstName.Text + " is already registered in the system");
            }
        }
        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Accept.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if(comboBox_Permission.SelectedIndex == 2||comboBox_Permission.SelectedIndex==3)
            {
                comboBox_Department.Visible = false;
                label_Department.Visible = false;
                button_Accept.Enabled = true;
            }
            else 
            {
                comboBox_Department.Visible = true;
                label_Department.Visible = true;
                button_Accept.Enabled = false;
            }
        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ID.TextLength > 8)
            {
                textBox_Password.Enabled = true;
            }
            else
            {
                textBox_Password.Enabled = false;
            }
        }
        private void textBox_LastName_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (textBox_LastName.TextLength > 0)
            {
                comboBox_Permission.Enabled = true;
            }
            else
            {
                comboBox_Permission.Enabled = false;
            }
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Password.TextLength > 0)
            {
                textBox_FirstName.Enabled = true;
            }
            else
            {
                textBox_FirstName.Enabled = false;
            }
        }

        private void textBox_FirstName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_FirstName.TextLength > 0)
            {
                textBox_LastName.Enabled = true;
            }
            else
            {
                textBox_LastName.Enabled = false;
            }
        }

        private void textBox_LastName_TextChanged(object sender, EventArgs e)
        {
             if (textBox_LastName.TextLength > 0)
            {
                comboBox_Permission.Enabled = true;
            }
            else
            {
                comboBox_Permission.Enabled = false;
            }
        }

        private void FormAdminAddUser_Load(object sender, EventArgs e)
        {

        }

        private void FormAdminAddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void textBox_email_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox_email.TextLength > 0)
            {
                textBox_ID.Enabled = true;
            }
            else
            {
                textBox_ID.Enabled = false;
            }
        }
    }
}
