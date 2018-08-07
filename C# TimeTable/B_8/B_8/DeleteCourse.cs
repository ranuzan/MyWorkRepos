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
    public partial class DeleteCourse : Form
    {
        DataBase db = new DataBase();
        public bool IsUnitTest = false;
        SqlDataReader reader;
        public DeleteCourse()
        {
            InitializeComponent();
            IsUnitTest = true;
        }
        /********delete all*****************/
        /*
         * SqlCommand cmd = new SqlCommand("DELETE FROM Courses", db.cnn);
         * db.Connect();
         * cmd.ExecuteNonQuery();
         * 
         */

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text!= "Course" && (string)comboBox2.SelectedItem != "ID")
                {
                    if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        db.Connect();
                        SqlCommand cmd = new SqlCommand("DELETE FROM NewCourses WHERE Name = @id", db.cnn);
                        cmd.Parameters.AddWithValue("@id",comboBox1.Text);
                        if (db.cnn.State.ToString().Equals("Closed"))
                        {
                            db.cnn.Open();
                        }
                        cmd.ExecuteNonQuery();
                        DataBase.numofcourses--;
                        MessageBox.Show("The course "+ comboBox1.Text + " has been deleted");
                        new DeleteCourse().Show();
                    }
                }
            }
          
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString()); 
                MessageBox.Show("Colud not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main();
            ss.Show();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss =  new login();
            ss.Show();
        }

        private void DeleteCourse_Load(object sender, EventArgs e)
        {
            reader = db.Select("Name", "NewCourses");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString().Trim());
            }
            reader.Close();
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Course")
            {
                comboBox2.Enabled = true;
                    reader = db.Select("ID", "NewCourses", "Name", comboBox1.Text);
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader[0].ToString().Trim());
                    }
                    reader.Close();
                
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "Course" && comboBox2.Text != "ID")
                {
                    if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        db.Connect();
                        SqlCommand cmd = new SqlCommand("DELETE FROM NewCourses WHERE ID = @id", db.cnn);
                        cmd.Parameters.AddWithValue("@id", comboBox2.Text);
                        if (db.cnn.State.ToString().Equals("Closed"))
                        {
                            db.cnn.Open();
                        }
                        cmd.ExecuteNonQuery();
                        DataBase.numofcourses--;
                        MessageBox.Show("The course " + comboBox1.Text + " has been deleted");
                        new DeleteCourse().Show();
                    }
                }
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
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
