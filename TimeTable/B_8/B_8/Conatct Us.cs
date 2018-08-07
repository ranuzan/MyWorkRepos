using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mime;
using System.Net.Mail;
using System.Net;

namespace B_8
{
    public partial class Conatct_Us : Form
    {

        public Conatct_Us()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Host = "smtp.gmail.com";

                mail.From = new MailAddress("yosefbar10@gmail.com");
                mail.To.Add("sarahnetanyahu10@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;

                SmtpServer.Credentials = new System.Net.NetworkCredential("yosefbar10@gmail.com", ""); // User Mail Name And Mail Password
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Conatct_Us_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
     
        }
    }
}
