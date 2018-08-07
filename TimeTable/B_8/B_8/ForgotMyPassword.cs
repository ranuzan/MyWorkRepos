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
using System.Net.Mail;
using System.Net;

namespace B_8
{
    public partial class ForgotMyPassword : Form
    {
        DataBase db = new DataBase();
        bool IsFound;
        public bool IsUnitTest = false;


        public ForgotMyPassword()
        {
            InitializeComponent();
            IsFound = false;
            IsUnitTest = true;
        }

        private void ForgotMyPassword_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox1.Text;
            if (Email != null)
            {
                SqlDataReader read = db.Select("*", "NewUsers");
                try
                {
                    while (read.Read())
                    {/*"baritzhak10@gmail.com" */
                        if (Email == read["Email"].ToString().Trim())
                        {

                            SmtpClient client = new SmtpClient("Smtp.gmail.com", 587);
                            client.EnableSsl = true;
                            client.Timeout = 10000;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new System.Net.NetworkCredential("spForgot8@gmail.com", "aA123456");

                            MailMessage mm = new MailMessage("spForgot8@gmail.com", Email, "Your password", read["Password"].ToString().Trim());
                            mm.BodyEncoding = UTF8Encoding.UTF8;
                            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                            client.Send(mm);

                            MessageBox.Show("We Found Your Email:  " + Email + "\ncheck your Email..");
                            this.Hide();
                            login ss = new login();
                            ss.Show();
                            IsFound = true;
                            break;
                        }
                    }
                   
                    if (!IsFound)
                        MessageBox.Show("Email: " + Email + " NOT Found!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (db.isconnected == true)
                        db.CloseConnection();
                }
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ss = new login();
            ss.Show();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Confirm_forgot_TextChanged(object sender, EventArgs e) { }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

        