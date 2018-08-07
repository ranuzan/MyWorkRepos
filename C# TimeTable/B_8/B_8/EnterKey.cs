using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_8
{
    public partial class EnterKey : Form
    {
        // 
        string email = "email";
        string key = "key";
        string name = "New User Registration";
        public bool IsUnitTest = false;

        public EnterKey()
        {
            InitializeComponent();
            IsUnitTest = true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            name = "New User Registration";

            if (Email_textBox.Text == email)
            {
                if (Key_textBox.Text == key)
                {
                    MessageBox.Show("class: " + name);
                    this.Hide();

                    NewUserRegistration ss = new NewUserRegistration();
                    ss.Show();
                }
                else
                    MessageBox.Show("Wrong Key!\n Enter the 6-character KEY you received in the subscription.");
            }
            else
                MessageBox.Show("Wrong Input");
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void Email_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Key_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                confirm_Click(sender, new EventArgs());
            }
        }

        private void EnterKey_Load(object sender, EventArgs e)
        {

        }
    }
}
