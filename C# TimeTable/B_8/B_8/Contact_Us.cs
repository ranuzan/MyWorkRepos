using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_8
{
    public partial class Contact_Us : Form
    {
        DataBase db = new DataBase();
        bool IsFound = false;
        public bool IsUnitTest = false;

        public Contact_Us()
        {
            InitializeComponent();
            IsUnitTest = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string Email = textBox5.Text;
            if (Email != null)
            {
                SqlDataReader read = db.Select("*", "NewUsers");
                try
                {
                    while (read.Read())
                    {
                        if (Email == read["Email"].ToString().Trim())
                        {

                            SmtpClient client = new SmtpClient("Smtp.gmail.com", 587);
                            client.EnableSsl = true;
                            client.Timeout = 10000;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new System.Net.NetworkCredential("spForgot8@gmail.com", "aA123456");

                            string Message = "From: " + textBox1.Text + " " + Email + " subject: " + textBox3.Text + " Message: " + textBox2.Text;
                            MailMessage mm = new MailMessage("spForgot8@gmail.com", "baritzhak10@gmail.com", textBox1.Text, Message);
                            mm.BodyEncoding = UTF8Encoding.UTF8;
                            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                            client.Send(mm);

                            MessageBox.Show("Your message has been received.");
                            this.Close();
                           
                            IsFound = true;
                            break;


                        }
                    }

                    if (!IsFound)
                        MessageBox.Show("Email: " + Email + " NOT Found!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Contact_Us_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
