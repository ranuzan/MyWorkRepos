using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_8
{
    public partial class FormFacebookLogin : Form
    {
        bool link;
        string mail;
        string fbMail = "-1-1-1-1-1-1-1-1-";

        public FormFacebookLogin(bool _link = false, string _mail="")
        {
            InitializeComponent();
            timer1.Start();
            link = _link;
            mail = _mail;
        }

        private void FormFacebookLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() != "https://www.facebook.com/" && webBrowser1.Url.ToString() != "https://www.facebook.com/settings/" && webBrowser1.Url.ToString() != "https://www.facebook.com/login/" && webBrowser1.Url.ToString() != "https://www.facebook.com/checkpoint/?next")
                {
                    webBrowser1.Navigate("https://www.facebook.com/login/");
                    label1.Visible = false;
                }


                if (webBrowser1.Url.ToString() == "https://www.facebook.com/")
                {
                    webBrowser1.Visible = false;
                    fbLogin();
                }

                else if (webBrowser1.Url.ToString() == "https://www.facebook.com/settings/")
                {
                    timer1.Stop();
                    this.Hide();
                    try
                    {
                        login1();
                    }
                    catch
                    {
                        timer1.Start();
                    }
                }
            }
            catch
            {

            }
        }

        private void fbLogin()
        {
            webBrowser1.Navigate("https://www.facebook.com/settings/");

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.ToString() == "https://www.facebook.com/settings/")
            {
                webBrowser1.Visible = false;
                label1.Visible = true;
                foreach (HtmlElement elem in webBrowser1.Document.All)
                {
                    if (elem.GetAttribute("classname") == "fbSettingsListItemContent fcg")
                    {
                        if (elem.InnerText.Contains("@") && elem.InnerText.Contains(":"))
                        {
                            string tempfbmail = @elem.InnerText;
                            fbMail = tempfbmail.Substring(tempfbmail.IndexOf(@":") + 2);
                        }
                    }
                }
            }
            else
                webBrowser1.Visible = true;
        }

        private void login1()
        {
            if (!link)
            {
                DataRow dataRow = SQLFunctions.checkFbLogIn(fbMail);

                if (dataRow == null)
                {
                    MessageBox.Show("This facebook account is not linked to any system user\nPlease link your Facebook account and try again");
                    B_8.login login = new B_8.login();
                    login.Show();
                }
                else if (SQLFunctions.checkLogIn(Convert.ToInt32(dataRow[0]), dataRow[1].ToString()))
                {
                    if (SQLFunctions.checkRole(Convert.ToInt32(dataRow[0])) == "Student")
                    {
                        FormMenuStudent mainForm = new FormMenuStudent(Convert.ToInt32(dataRow[0]), dataRow[1].ToString());
                        mainForm.Show();
                    }
                    else if (SQLFunctions.checkRole(Convert.ToInt32(dataRow[0])) == "SecretaryA")
                    {
                        FormMenuSecretary mainForm = new FormMenuSecretary(Convert.ToInt32(dataRow[0]), dataRow[1].ToString());
                        mainForm.Show();
                    }
                    else if (SQLFunctions.checkRole(Convert.ToInt32(dataRow[0])) == "Exam Department")
                    {
                        FormMenuExamDepartment mainForm = new FormMenuExamDepartment();
                        mainForm.Show();
                    }
                    else if (SQLFunctions.checkRole(Convert.ToInt32(dataRow[0])) == "Admin")
                    {
                        FormMenuAdmin mainForm = new FormMenuAdmin();
                        mainForm.Show();
                    }
                    else
                    {
                        B_8.login login = new B_8.login(true, SQLFunctions.convertFbMailToMail(fbMail), dataRow[1].ToString());
                    }
                }
            }
            else
            {
                SQLFunctions.linkFbAccount(mail, fbMail);
                MessageBox.Show("Your facebook account was succesfuly linked");
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            B_8.login login = new B_8.login();
            login.Show();
            this.Dispose();
        }
    }
}
