using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace B_8
{
    public partial class ShowClassInSchedule : Form
    {
        private Button btn;
        DataBase db;
        SqlDataReader reader;

        public ShowClassInSchedule()
        {
            InitializeComponent();
        }

        public ShowClassInSchedule(Button btn)
        {
            InitializeComponent();
            this.btn = btn;
            db = new DataBase();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ShowClassInSchedule_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.CenterToScreen();
                reader = db.Select("*", "NewSchedule", "LectureID", btn.Name);
                while (reader.Read())
                {
                    if (reader["Type"].ToString().Trim().Equals(btn.Text))
                    { 
                        label1.Visible = false;
                        label3.Text += reader["Date"].ToString().Trim();
                        label2.Text += reader["Classroom"].ToString().Trim();
                        label4.Text += reader["StartHour"].ToString().Trim()+":00"+"-"+reader["EndHour"].ToString().Trim()+":00";
                        label5.Text += " "+btn.Text;
                    }
                    else
                    {
                        
                        label1.Text += reader["Name"].ToString().Trim();
                        label3.Text += reader["Date"].ToString().Trim();
                        label2.Text += reader["Classroom"].ToString().Trim();
                        label4.Text += reader["StartHour"].ToString().Trim() + ":00" + "-" + reader["EndHour"].ToString().Trim() + ":00";
                        label5.Text += " "+reader["Type"].ToString().Trim();
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sl");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
