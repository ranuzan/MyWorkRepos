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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            textBoxID.MaxLength = 9;
            textBoxPassword.PasswordChar = '*';
            this.AcceptButton = buttonLogin;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (SQLFunctions.checkLogIn(Convert.ToInt32(textBoxID.Text), textBoxPassword.Text))
            {
                this.Hide();
                
                if (SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Student")
                {
                    FormMenuStudent mainForm = new FormMenuStudent();
                    mainForm.Show();
                }
                else if(SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Secretary")
                {
                    FormMenuSecretary mainForm = new FormMenuSecretary();
                    mainForm.Show();
                }
                else if(SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Exam Department")
                {
                    FormMenuExamDepratment mainForm = new FormMenuExamDepratment();
                    mainForm.Show();
                }
                else if(SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Admin")
                {

                }
                else
                {
                    MessageBox.Show("Unknown Error");
                }
            }
            else
            {
                MessageBox.Show("Logon Failure: unknown ID or bad password");
            }
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
