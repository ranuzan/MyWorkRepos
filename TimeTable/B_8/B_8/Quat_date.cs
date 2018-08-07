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
    public partial class Quat_date : Form
    {
        
        DataBase db = new DataBase();
        private Button b;
        private string day, hour,date;
        SqlDataReader read,read2;
        public int counter = 0, startH, endH;
        public string Shour, Ehour;
        public Quat_date(Button btn)
        {
            try
            {
                string data, day, houer;
                b = new Button();
                b = btn;
                this.Show();
                CenterToScreen();
                InitializeComponent();
                comboBox2.Visible = false;
                label3.Text = "" + btn.Text + " is a: ";
                label6.Text = "Time of use in " + btn.Text;
              button1.Visible = false;

                // read = db.Select("Name", "Classrooms");
                read = db.Select("*", "Classrooms");
                while (read.Read())
                {
                    if (read["Name"].ToString().Trim().Equals(btn.Text))
                    {
                        label5.Text = read["Type"].ToString().Trim();
                    }
                }

                read.Close();

                read2 = db.Select("*", "NewSchedule", "Classroom", btn.Text);
                while (read2.Read())
                {
                    startH = Int32.Parse(read2["StartHour"].ToString().Trim());
                    endH = Int32.Parse(read2["EndHour"].ToString().Trim());
                    Shour = read2["StartHour"].ToString().Trim()+":" + "00";
                    Ehour = read2["EndHour"].ToString().Trim() + ":" + "00"; 

                    if (read2["StartHour"].ToString().Length == 1)
                    {
                        Shour = "0" + Shour;
                    }
                    if (read2["EndHour"].ToString().Length == 1)
                    {
                        Ehour = "0" + Ehour;
                    }

                    if (read2["Classroom"].ToString().Trim().Equals(btn.Text))
                    {
                        ListViewItem lv = new ListViewItem(read2["Date"].ToString());
                        lv.SubItems.Add(read2["Day"].ToString().Trim());
                        lv.SubItems.Add(Shour +  "-" + Ehour);
                        listView1.Items.Add(lv);
                        counter++;
                    }

                }
            
                read2.Close();
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




        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            main ss = new main();
            ss.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != null)
            {
                button1.Visible = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Quat_date_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int calchouer = endH - startH;
            string subHour, subHour2;

            if (comboBox1.Text == null||comboBox1.Text=="")
            {
                MessageBox.Show("You have to fill the Hours");
                return;
            }


            else
            {
                hour = comboBox1.Text;
                int inthourcombo = Int32.Parse(hour.Substring(0,2));
                int hourlistStart;
                int hourlistEnd;
                date = monthCalendar1.SelectionStart.ToShortDateString();
                day = monthCalendar1.SelectionStart.DayOfWeek.ToString();



                for (int i = 0; i < counter; i++)
                {
                    if (listView1.Items[i].Text.ToString().Trim() == monthCalendar1.SelectionStart.ToShortDateString().Substring(0, 10))
                    {
                        subHour = listView1.Items[i].SubItems[2].Text.Substring(0, 5);
                        subHour2= listView1.Items[i].SubItems[2].Text.Substring(6, 2);
                        hourlistStart = Int32.Parse(subHour.Substring(0,2));
                        hourlistEnd = Int32.Parse(subHour2);
                        if (subHour == comboBox1.Text||((inthourcombo<= hourlistEnd && inthourcombo>= hourlistStart)))
                        {
                            MessageBox.Show("This class is occupied in this hour");
                            return;
                        }
                    }
                }
                AddToSce addSce = new AddToSce(b, day, hour, date, b, null, this, b.Text);
                addSce.Show();
            }
        }

    }
}
