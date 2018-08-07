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

            if (textBoxID.Text == "")
            {
                MessageBox.Show("Logon Failure: unknown ID or invalid password");
                return;
            }

            if (SQLFunctions.checkLogIn(Convert.ToInt32(textBoxID.Text), textBoxPassword.Text))
            {
                this.Hide();

                if (SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Student")
                {
                    FormMenuStudent mainForm = new FormMenuStudent(Convert.ToInt32(textBoxID.Text), textBoxPassword.Text);
                    mainForm.Show();

                }
                else if (SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Secretary")
                {
                    FormMenuSecretary mainForm = new FormMenuSecretary(Convert.ToInt32(textBoxID.Text), textBoxPassword.Text);
                    mainForm.Show();
                }
                else if (SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Exam Department")
                {
                    FormMenuExamDepartment mainForm = new FormMenuExamDepartment();
                    mainForm.Show();
                }
                else if (SQLFunctions.checkRole(Convert.ToInt32(textBoxID.Text)) == "Admin")
                {
                    FormMenuAdmin mainForm = new FormMenuAdmin();
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("Unknown Error");
                }
            }
            else
            {
                MessageBox.Show("Logon Failure: unknown ID or invalid password");
            }
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
