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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxID.MaxLength = 9;
            textBoxPassword.PasswordChar = '*';
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (SQLFunctions.checkLogIn(Convert.ToInt32(textBoxID.Text), textBoxPassword.Text))
            {
                this.Hide();
                MenuStudentForm mainForm = new MenuStudentForm();
                mainForm.Show();
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
