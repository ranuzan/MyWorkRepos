using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication6;
using A_8;

namespace B_8
{
    public partial class login : Form
    {
        DataBase db = new DataBase();
        bool IsFound;
        string ID;
        public bool IsUnitTest = false;

        public login(bool fbLogin = false, string _mail = "", string _password = "")
        {
            InitializeComponent();
            IsFound = false;
            /*   Reset User fields   */
            GlobalVariables.User_ID = null;
            GlobalVariables.Full_Name = null;
            GlobalVariables.User_Permission = null;
            GlobalVariables.User_Department = null;
            GlobalVariables.User_Name = null;
            GlobalVariables.User_Email = null;
            IsUnitTest = true;
            if(fbLogin)
            {
                this.Hide();
                textBox1.Text = _mail;
                textBox2.Text = _password;
                button1_Click(new object(), new EventArgs());
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {

            
        }
        

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotMyPassword ss = new ForgotMyPassword();
            ss.Show();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {

           /* if (e.KeyCode == Keys.Enter)
            {
                confirm_Click( sender, new EventArgs());
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAQ ss = FAQ.GetInstance();
            
            ss.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime end_of_exams_semester_a = new DateTime(DateTime.Today.Year, 3, 5);
            DateTime end_of_semester_b = new DateTime(DateTime.Today.Year, 6, 15);
            DateTime end_of_exams_semester_b = new DateTime(DateTime.Today.Year, 7, 15);
            SqlDataReader read = db.Select("*", "NewUsers");
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Logon Failure: unknown ID or invalid password");
                    return;
                }
                if (SQLFunctions.checkExistsEmail(textBox1.Text))
                {
                    if (SQLFunctions.checkLogIn(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text)), textBox2.Text))
                    {
                        this.Hide();

                        if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString()))) == "Student")
                        {
                            FormMenuStudent mainForm = new FormMenuStudent(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString())), textBox2.Text);
                            mainForm.Show();
                        }
                        else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString()))) == "SecretaryA")
                        {
                            FormMenuSecretary mainForm = new FormMenuSecretary(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString())), textBox2.Text);
                            mainForm.Show();
                        }
                        else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString()))) == "Exam Department")
                        {
                            FormMenuExamDepartment mainForm = new FormMenuExamDepartment();
                            mainForm.Show();
                        }
                        else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBox1.Text.ToString()))) == "Admin")
                        {
                            FormMenuAdmin mainForm = new FormMenuAdmin();
                            mainForm.Show();
                        }
                        else
                        {
                            while (read.Read())
                            {
                                if (textBox1.Text == read["Email"].ToString().Trim() && textBox2.Text == read["Password"].ToString().Trim())
                                {

                                    ID = read["ID"].ToString();
                                    // GlobalVariables h;.ID = read["ID"].ToString().Trim();
                                    GlobalVariables.User_ID = read["ID"].ToString().Trim();
                                    GlobalVariables.Full_Name = read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim();
                                    GlobalVariables.User_Permission = read["Role"].ToString().Trim();
                                    GlobalVariables.User_Department = read["Department"].ToString().Trim();
                                    GlobalVariables.User_Email = read["Email"].ToString().Trim();
                                    if (monthCalendar1.MaxDate >= DateTime.Today && monthCalendar1.MinDate <= DateTime.Today)
                                        GlobalVariables.Semester = "A";
                                    else if (monthCalendar1.MaxDate < DateTime.Today && DateTime.Today <= end_of_exams_semester_a)
                                        GlobalVariables.Semester = "Exam Period semester A";
                                    else if (end_of_exams_semester_a < DateTime.Today && DateTime.Today <= end_of_semester_b)
                                        GlobalVariables.Semester = "B";
                                    else if (end_of_exams_semester_b >= DateTime.Today && DateTime.Today > end_of_semester_b)
                                        GlobalVariables.Semester = "Exam Period semester B";
                                    else
                                        GlobalVariables.Semester = "Summer Semester";
                                    IsFound = true;
                                    GlobalVariables.maxDate = monthCalendar1.MaxDate;
                                    GlobalVariables.minDate = monthCalendar1.MinDate;
                                    break;
                                }

                                GlobalVariables.maxDate = monthCalendar1.MaxDate;
                                GlobalVariables.minDate = monthCalendar1.MinDate;
                            }
                            read.Close();
                            
                            if (!IsFound)
                            {
                                MessageBox.Show("You have to sign up before");
                                textBox1.Text = "";
                                textBox2.Text = "";
                                return;
                            }
                            this.Hide();
                            main m=new main();
                            m.Show();
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Logon Failure: unknown ID or invalid password");
                    }
                }
                else
                {
                    MessageBox.Show("Logon Failure: unknown ID or invalid password");
                }
                
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }

        private void buttonFacebookLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
            this.Hide();
            FormFacebookLogin fbLogin = new FormFacebookLogin();
            fbLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("You must enter first email and password");
            }
            else
            {
                if (!SQLFunctions.checkLogIn(SQLFunctions.getIDbyEmail(textBox1.Text), textBox2.Text))
                {
                    MessageBox.Show("Facebook link failure: unknown ID or invalid password");
                }
                else
                {
                    FormFacebookLogin fbLogin = new FormFacebookLogin(true,textBox1.Text);
                    fbLogin.Show();
                }
            }
        }
    }
}
