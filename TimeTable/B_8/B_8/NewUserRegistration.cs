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
    public partial class NewUserRegistration : Form
    {
        string username,first, last, id, password, password_again,email, Role, department,unit;
        DataBase db = new DataBase();
        SqlDataReader reader;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                first = textBox1.Text;
                last = textBox2.Text;
                ////username = first + last[0] + last[1];

                reader = db.Select("*", "NewUsers", "Email", textBox6.Text);
                int count = 0, count_id = 0;
                while (reader.Read())
                {
                    if (reader["Email"].ToString().Trim().Equals(textBox6.Text))
                        count++;
                }
                reader.Close();
                reader = db.Select("*", "NewUsers", "ID", textBox3.Text);

                while (reader.Read())
                {
                    if (reader["ID"].ToString().Trim().Equals(textBox3.Text))
                        count_id++;
                }
                reader.Close();
                if (count == 0 && count_id == 0)
                {
                    reader.Close();
                    id = textBox3.Text;
                    password = textBox4.Text;
                    password_again = textBox5.Text;
                    email = textBox6.Text;
                    Role = role.Text;
                    department = Department_comboBox.Text;
                    unit = comboBox1.Text;
                    if (password == password_again)
                    {
                        db.InsertUser(first, last, id, email, password, Role, department, unit);
                        this.Hide();
                        main ss = new main();
                        ss.Show();
                    }
                    else
                        MessageBox.Show("Wrong input!\n The passwords are Different");
                }
                else if (count != 0)
                {
                    MessageBox.Show("Wrong input!\n Email already exist in the system");

                }
                else if (count_id != 0)
                {
                    MessageBox.Show("Wrong input!\n ID already exist in the system");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to sql");
            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Department_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void NewUserRegistration_Load(object sender, EventArgs e)
        {

        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main ss = new main();
            ss.Show();
        }

        private void role_SelectedIndexChanged(object sender, EventArgs e) { }

        

        public NewUserRegistration()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //


        }

        private void Department_Click(object sender, EventArgs e) { }
    }
}
