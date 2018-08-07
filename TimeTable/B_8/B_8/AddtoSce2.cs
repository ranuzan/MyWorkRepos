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
    public partial class AddtoSce2 : Form
    {
        List<ListView> listviews = new List<ListView>();
        List<Button> buttons = new List<Button>();
        DataBase db = new DataBase();
        List<string> Resposibles = new List<string>();
        bool IsClicked = false;
        string[] Types = { "Practice", "Lecture", "Exam", "ReceptionHours", "Meeting" };

        SqlDataReader read;
        public AddtoSce2()
        {
            InitializeComponent();

            listviews.Add(listView1);
            listviews.Add(listView2);
            listviews.Add(listView3);
            listviews.Add(listView4);
            listviews.Add(listView5);
            listviews.Add(listView6);
            listviews.Add(listView7);
            listviews.Add(listView8);
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsClicked = !IsClicked;
            if (listView1.SelectedItems.Count > 0)
            {
                listView2.Enabled = true;
                listView1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                button1.Text = listView1.SelectedItems[0].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
         
               
          
            
            if (listView2.SelectedItems.Count > 0)
            {
                listView3.Enabled = true;
                listView2.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                button2.Text = listView2.SelectedItems[0].Text;
                read = db.Select("*", "Courses", "Department", button2.Text);

                while (read.Read())
                {
                    listView3.Items.Add(new ListViewItem(read["Name"].ToString().Trim()));

                }
                read.Close();

            }
            else
            {
                listView2.Enabled = false;
                listView1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
      

            if (listView4.SelectedItems.Count > 0)
            {
                listView5.Enabled = true;
                listView4.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = true;
                button4.Text = listView4.SelectedItems[0].Text;
                read = db.Select("*", "UsersB", "Department", listView2.SelectedItems[0].Text);
                for (int i = 0; i < Resposibles.Count; i++)
                {
                    Resposibles[i].Remove(i);
                }
                while (read.Read())
                {
                    if (read["Role"].ToString().Trim().Equals("Lecturer") || read["Role"].ToString().Trim().Equals("Head of Department"))
                        Resposibles.Add(read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim());
                    if ((read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()).Equals(listView4.SelectedItems[0].Text))
                    {
                        if (read["Role"].ToString().Trim() != "Secretary" && read["Role"].ToString().Trim() != "Practitioner")
                        {
                            listView5.Items.Clear();

                            for (int i = 1; i < 5; i++)
                            {
                                listView5.Items.Add(new ListViewItem(Types[i]));
                            }

                        }
                        if (read["Role"].ToString().Trim() == "Practitioner")
                        {
                            listView5.Items.Clear();

                            listView5.Items.Add(new ListViewItem(Types[0]));
                            listView5.Items.Add(new ListViewItem(Types[3]));


                        }
                    }
                }
                read.Close();
            }
            else
            {
                listView4.Clear();
                listView4.Enabled = false;
                listView3.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            if (listView3.SelectedItems.Count > 0)
            {
                listView4.Enabled = true;
                listView3.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                button3.Text = listView3.SelectedItems[0].Text;
                read = db.Select("*", "UsersB", "Department", button2.Text);

                while (read.Read())
                {
                    if (read["Role"].ToString().Trim() != "Secretary")
                        listView4.Items.Add(new ListViewItem(read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()));
                   
                }
                read.Close();


                listView2.SelectedItems.Clear();
            


            }
            else
            {
                listView3.Clear();
                listView3.Enabled = false;
                listView2.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                listView6.Enabled = true;
                listView5.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = true;
                if (listView5.SelectedItems[0].Text.Equals("Exam"))
                    {
                    listView8.Visible = true;
                    listView8.Enabled = true;
                }
                button5.Text = listView5.SelectedItems[0].Text;
                if (button5.Text == "Practice")
                {
                    read = db.Select("*", "UsersB", "Department", button2.Text);

                    while (read.Read())
                    {
                        if (read["Role"].ToString().Trim() == "Practitioner" && button4.Text.Equals(read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()))
                            for (int i = 0; i < Resposibles.Count; i++)
                            {
                                listView6.Items.Add(Resposibles[i]);

                            }
                    }
                    read.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView6.SelectedItems.Count > 0)
            {
                listView7.Enabled = true;
                listView6.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = true;
                button6.Text = listView6.SelectedItems[0].Text;
                read = db.Select("Name", "Classrooms");

                while (read.Read())
                {
                    listView7.Items.Add(read[0].ToString().Trim());
                }
                read.Close();
            }
    }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView7.SelectedItems.Count > 0)
            {
                listView8.Enabled = true;
                listView7.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = true;
                button7.Text = listView6.SelectedItems[0].Text;
            }
            }
    }
}
