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
    public partial class WeeklySchedule : Form
    {
        public WeeklySchedule()
        {
            InitializeComponent();
        }

        private void ChooseDate_Click(object sender, EventArgs e)
        {
            if(!monthCalendar1.Visible)
                monthCalendar1.Visible = true;
            else
                monthCalendar1.Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            maskedTextBox1.Text = monthCalendar1.SelectionEnd.ToString();

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main(); ss.Show();
        }

        private void WeeklySchedule_Load(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "  /  /")
            {
                this.Hide();
                Schedule ss = new Schedule();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please choose date");
            }
        }
    }
}
