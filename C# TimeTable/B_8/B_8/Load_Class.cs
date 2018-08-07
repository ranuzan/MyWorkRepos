using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace B_8
{
    public partial class Load_Class : UserControl
    {
        Lecturer[] lecturer;
        DataBase db;
        SqlDataReader reader;
        int count = 0;
        main parent;

        public Load_Class(main m )
        {
            InitializeComponent();
            db = new DataBase();
            this.parent = m;
            button1.ForeColor = Color.Black;
        }

        private void Load_Class_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                db.cnn.Open();
                SqlCommand counter = new SqlCommand("select count(ID) From NewUsers", db.cnn);
                reader = counter.ExecuteReader();
                reader.Read();
                count = Int32.Parse(reader[0].ToString().Trim());
                reader.Close();
                db.cnn.Close();
                lecturer = new Lecturer[count];
                reader = db.Select("*", "NewUsers");
                for (int i = 0; i < count; i++)
                {

                    reader.Read();
                    lecturer[i] = new Lecturer();
                    
                    lecturer[i].FirstName = reader["FirstName"].ToString().Trim();
                    lecturer[i].LastName = reader["LastName"].ToString().Trim();
                    lecturer[i].Password = reader["Password"].ToString().Trim();
                    lecturer[i].Email = reader["Email"].ToString().Trim();
                    lecturer[i].Role = reader["Role"].ToString().Trim();
                    lecturer[i].Department = reader["Department"].ToString().Trim();
                    lecturer[i].Unit = reader["Unit"].ToString().Trim();
                }
                reader.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                db.CloseConnection();
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
  
            parent.panel1.Controls.Remove(this);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        public int return_count()
        {
            return count;
        }
    }
}
