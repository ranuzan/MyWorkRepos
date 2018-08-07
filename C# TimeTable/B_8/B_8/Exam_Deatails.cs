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
    public partial class Exam_Deatails : Form
    {
        DataBase db;
        SqlDataReader reader;
        private Button btn;
        private string combobox1;
        public bool IsUnitTest = false;

        public Exam_Deatails()
        {
            InitializeComponent();
            IsUnitTest = true;
        }

        public Exam_Deatails(Button btn,Point location)
        {
            InitializeComponent();
            this.btn = btn;
             
            
            this.CenterToScreen();
            this.Location= new Point(location.X + btn.Width,55+ location.Y+btn.Location.Y);
            db = new DataBase();

        }

        private void Exam_Deatails_Load(object sender, EventArgs e)
        {
            try
            {
                reader = db.Select("*", "NewSchedule");
                while (reader.Read())
                {
                    if (reader["LecturerName"].ToString().Trim().Equals(btn.Name) && reader["Name"].ToString().Trim().Equals(btn.Text.Substring(0, btn.Text.Length - 4)))
                        if (reader["NumOfExam"].ToString().Trim() == (btn.Text[btn.Text.Length - 1].ToString()))
                        {

                            label1.Text += btn.Text.Substring(0, btn.Text.Length - 4);
                            label2.Text += reader["LecturerName"].ToString().Trim();
                            label3.Text += reader["StartHour"].ToString().Trim()+":00"+"-"+ reader["EndHour"].ToString().Trim() + ":00";
                            label4.Text += reader["Day"].ToString().Trim() + " , " + reader["Date"].ToString().Trim();

                        }

                }
                reader.Close();
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
