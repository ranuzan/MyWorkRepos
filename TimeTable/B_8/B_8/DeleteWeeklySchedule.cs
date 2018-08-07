using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_8
{
    public partial class DeleteWeeklySchedule : Form
    {
        List<string> constrains_details;
        DataBase db = new DataBase();
        public bool IsUnitTest = false;

        public DeleteWeeklySchedule()
        {
            InitializeComponent();
            this.CenterToScreen();
            IsUnitTest = true;
        }

        public DeleteWeeklySchedule(List<string> list)
        {
            InitializeComponent();
            constrains_details = new List <string> ();
            this.constrains_details = list;
        }
        private void DeleteWeeklySchedule_Load(object sender, EventArgs e)
        {
            if (constrains_details.Count > 0)
            {
                label1.Text = constrains_details[1] + " " + constrains_details[2];
                label2.Text = constrains_details[3];
                label3.Text = constrains_details[4];
                label4.Text = constrains_details[5];
                label5.Text = constrains_details[6];
                label7.Text = constrains_details[7];
                label6.Text = constrains_details[8];
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            try
            {
                db.Update("true", "Constraints", "Seen", (constrains_details[0]));
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Colud not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void APPROVED_Click(object sender, EventArgs e)
        {
            try
            {
                db.Update("true", "Constraints", "Seen", (constrains_details[0]));
                db.Update("true", "Constraints", "Approved", (constrains_details[0]));
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Colud not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }
    }
}
