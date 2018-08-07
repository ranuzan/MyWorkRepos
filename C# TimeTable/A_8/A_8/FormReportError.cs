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
    public partial class FormReportError : Form
    {
        int userID;
        public FormReportError(int _userID)
        {
            userID = _userID;
            InitializeComponent();
        }

        private void FormAdmin_ErrorNotifications_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_title.TextLength > 0)
                button_Submit.Enabled = true;
            else
                button_Submit.Enabled = false;
        }

        private void button_Submit_Click(object sender, EventArgs e)
        {
            SQLFunctions.addError(userID, textBox_title.Text, textBox_description.Text);
            MessageBox.Show("Your error has been submitted");
            textBox_title.Text = "";
            button_Submit.Enabled = false;
            textBox_description.Text = "";
            this.Close();
        }

        private void FormReportError_Load(object sender, EventArgs e)
        {

        }

        private void button_Back_Click(object sender, EventArgs e)
        {
         
        }
    }
}
