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
            textBox_ClassName.MaxLength = 10;
            this.AcceptButton = button_Accept;
        }

        private void textBox_ClassName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ClassName.TextLength > 0)
            {
                checkBox_Accept.Visible = true;
            }
            else
            {
                checkBox_Accept.Visible = false;
                checkBox_Accept.Checked = false;
                button_Accept.Enabled = false;
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
            if (SQLFunctions.checkExistsClassroom(textBox_ClassName.Text) == true)
            {
                SQLFunctions.deleteClassroom(textBox_ClassName.Text);
                MessageBox.Show("Class "+ textBox_ClassName.Text+" was deleted!");
                this.Hide();
                FormMenuAdmin adminForm = new FormMenuAdmin();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("Classroom could not be located in the database");
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
    }
}
