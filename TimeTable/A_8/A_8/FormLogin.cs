//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace A_8
//{
//    public partial class FormLogin : Form
//    {
//        public FormLogin()
//        {
//            InitializeComponent();
//            textBoxPassword.PasswordChar = '*';
//            this.AcceptButton = buttonLogin;
//        }

//        private void buttonLogin_Click(object sender, EventArgs e)
//        {
//            if (textBoxID.Text == "")
//            {
//                MessageBox.Show("Logon Failure: unknown ID or invalid password");
//                return;
//            }
//            if (SQLFunctions.checkExistsEmail(textBoxID.Text))
//            {
//                if (SQLFunctions.checkLogIn(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text)), textBoxPassword.Text))
//                {
//                    this.Hide();

//                    if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString()))) == "Student")
//                    {
//                        FormMenuStudent mainForm = new FormMenuStudent(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString())), textBoxPassword.Text);
//                        mainForm.Show();

//                    }
//                    else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString()))) == "Secretary")
//                    {
//                        FormMenuSecretary mainForm = new FormMenuSecretary(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString())), textBoxPassword.Text);
//                        mainForm.Show();
//                    }
//                    else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString()))) == "Exam Department")
//                    {
//                        FormMenuExamDepartment mainForm = new FormMenuExamDepartment();
//                        mainForm.Show();
//                    }
//                    else if (SQLFunctions.checkRole(Convert.ToInt32(SQLFunctions.getIDbyEmail(textBoxID.Text.ToString()))) == "Admin")
//                    {
//                        FormMenuAdmin mainForm = new FormMenuAdmin();
//                        mainForm.Show();
//                    }
//                    else
//                    {
//                         ;
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Logon Failure: unknown ID or invalid password");
//                }
//            }
//            else
//            {
//                MessageBox.Show("Logon Failure: unknown ID or invalid password");
//            }
//        }

         

//        private void FormLogin_Load(object sender, EventArgs e)
//        {

//        }

//        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            Application.Exit();
//        }

//        private void textBoxID_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void buttonFacebookLogin_Click(object sender, EventArgs e)
//        {
//            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
//            this.Hide();
//            //FormFacebookLogin fbLogin = new FormFacebookLogin();
//            fbLogin.Show();
//        }
//    }
//}
