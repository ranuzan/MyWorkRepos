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
    public partial class FormAdmin_AddClassroom : Form
    {
        public FormAdmin_AddClassroom()
        {
            InitializeComponent();
            textBox_ClassName.MaxLength = 10;
            textBox_Capacity.MaxLength = 3;
            this.AcceptButton = button_AddClass;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SQLFunctions.checkExistsClassroom(textBox_ClassName.Text) == false)
            {
                SQLFunctions.addClassroom(textBox_ClassName.Text, Convert.ToInt32(textBox_Capacity.Text));
                MessageBox.Show("class " + textBox_ClassName.Text + " was added with " + textBox_Capacity.Text + " seats.");
                this.Hide();
                FormMenuAdmin adminForm = new FormMenuAdmin();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("class " + textBox_ClassName.Text + " is already exists.");
            }
        }

        private void textBox_ClassName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_ClassName.TextLength > 0)
            {
                textBox_Capacity.Enabled = true;
            }
            else
            {
                textBox_Capacity.Enabled = false;
            }
        }

        private void textBox_Capacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_Capacity_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Capacity.TextLength > 0)
            {
                button_AddClass.Enabled = true;
            }
            else
            {
                button_AddClass.Enabled = false;
            }
        }

        private void textBox_ClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void FormAdminAddClassroom_FormClosing(object sender, FormClosingEventArgs e)
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
