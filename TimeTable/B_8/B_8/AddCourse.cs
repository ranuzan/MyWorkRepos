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
    public partial class AddCourse : Form
    {
        DataBase db = new DataBase();
        public bool IsUnitTest = false;
        SqlDataReader read;
        public AddCourse()
        {
            InitializeComponent();
            IsUnitTest = true;
        }
        
        private void AddCourse_Load(object sender, EventArgs e) {
            List<string> check_depart = new List<string>();
            List<string> check_unit = new List<string>();
            read = db.Select("Department" ,"NewCourses");
            while (read.Read())
            {
                if (!check_depart.Contains(read[0].ToString().Trim()))
                {
                    Department_combo.Items.Add(read[0].ToString().Trim());
                    check_depart.Add(read[0].ToString().Trim());
                }
               
            }
            read.Close();
            check_depart.Clear();
            read = db.Select("Unit", "NewCourses");
            while (read.Read())
            {
                
                if (!check_unit.Contains(read[0].ToString().Trim()))
                {
                    Unit_combo.Items.Add(read[0].ToString().Trim());
                    check_unit.Add(read[0].ToString().Trim());
                }
            }
            read.Close();

        }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }

      
       
        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            string name = textBox1.Text;
            
            string credits = textBox3.Text;
            string lectureH = textBox4.Text;
            string practiceH = textBox5.Text;
            string receiptH = textBox6.Text;
            string semester = comboBox2.Text;
            string Year = comboBox4.Text;
            string department = Department_combo.Text;
            string unit = Unit_combo.Text;
            string PrereqiD = PreReqID.Text;
            try
            {
                if (name != null  && credits != null && lectureH != null && practiceH != null && receiptH != null && Year != null && semester != null && department != null && unit != null)
                    if ( Int32.Parse(lectureH) > 0 & Int32.Parse(practiceH) > 0 & Int32.Parse(receiptH) > 0)// & Int32.Parse(Year) > 0)

                        check = db.InsertCourse(name, credits, lectureH, practiceH, receiptH, semester, Year, department, unit, PrereqiD);
                if (check)
                {
                    MessageBox.Show("The course" + " " + name + " has been added successfully");
                    ClearAll();
                }
                else
                    MessageBox.Show("Error occured!");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Could not insert");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();

            }
        }
        private void ClearAll()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.Text = "";
            comboBox4.Text = "";
            Unit_combo.Text = "";
            Department_combo.Text = "";

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
