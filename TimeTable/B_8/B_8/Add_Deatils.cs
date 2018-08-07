using B_8.Properties;
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
    public partial class Add_Deatils : Form
    {

        List<ListView> listviews = new List<ListView>();
        List<Button> buttons = new List<Button>();
        DataBase db;
        List<string> Resposibles = new List<string>();
        SqlDataReader read;
        public string descript;
        public AddToSce addToSce;
        string Role;
        public string Course_ID;
        
        public Add_Deatils()
        {
            InitializeComponent();
            db = new DataBase();
        }

        public Add_Deatils(AddToSce addToSce)
        {
            InitializeComponent();
            this.addToSce = addToSce;
            db = new DataBase();
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            List<string> check_department=new List<string>();
           
            if (listView1.SelectedItems.Count > 0)
            {
                button1.Text = listView1.SelectedItems[0].Text;
                read = db.Select("Department", "NewCourses");
                while (read.Read())
                {
                    if (!check_department.Contains(read[0].ToString().Trim())){
                        check_department.Add(read[0].ToString().Trim());
                        listView2.Items.Add(new ListViewItem(read[0].ToString().Trim()));
                    }
                }
                read.Close();
                
                listView2.Enabled = true;
                listView1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("You didn't choose semester");
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listView3.Items.Clear();

            if (listView2.SelectedItems.Count > 0)
            {
                
                button2.Text = listView2.SelectedItems[0].Text;
                listView3.Enabled = true;
                listView2.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;

                read = db.Select("Unit", "NewCourses");
                List<string> check_units = new List<string>();
                while (read.Read())
                {
                    if (!check_units.Contains(read[0].ToString().Trim()))
                    {
                        check_units.Add(read[0].ToString().Trim());
                        listView3.Items.Add(new ListViewItem(read[0].ToString().Trim()));
                    }
                }
                read.Close();

            }
            else
            {
                listView2.Enabled = false;
                listView1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
                listView2.Items.Clear();
            }
            listView2.SelectedItems.Clear();
        }


        private void listView1_EnabledChanged(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItems.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Deatils_Load(object sender, EventArgs e)
        {
            DateTime Exams_A = GlobalVariables.maxDate;
            DateTime Exams_B = new DateTime(DateTime.Now.Year, 6, 15);
            Exams_B=Exams_B.AddDays(30); 
            Exams_A= Exams_A.AddDays(30);
            if (GlobalVariables.maxDate >= addToSce.chosen_date && GlobalVariables.maxDate <= addToSce.chosen_date) 
                listView1.Items.Add(new ListViewItem("A"));
            else if (Exams_A < addToSce.chosen_date && addToSce.chosen_date <= Exams_A)
                listView1.Items.Add(new ListViewItem("Exams Period A"));
            
            else if (Exams_A < addToSce.chosen_date && addToSce.chosen_date <= new DateTime(DateTime.Now.Year, 6,15))
                listView1.Items.Add(new ListViewItem("B"));
            else if (new DateTime(DateTime.Now.Year, 6,15 ) <= addToSce.chosen_date && addToSce.chosen_date < Exams_B)
                listView1.Items.Add(new ListViewItem("Exams Period B"));
            else
                GlobalVariables.Semester = "Summer Semester";
            
            
            
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addToSce.course_list_items.Clear();
            this.Close();

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            addToSce.button2.BackgroundImage = null;
            addToSce.button2.Image = Resources.add_folder_normal;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            if (listView3.SelectedItems.Count >= 1)
            {
                button3.Text = listView3.SelectedItems[0].Text;
                listView3.Enabled = false;
                button3.Enabled = false;
                listView4.Enabled = true;
                button4.Enabled = true;
                if (button1.Text.Length > 1)
                {
                    read = db.Select("*", "NewCourses", "Semester", button1.Text.Substring(button1.Text.Length-1,1));
                }
                else
                    read = db.Select("*", "NewCourses", "Semester", button1.Text);
                while (read.Read())
                {
                    if(read["Department"].ToString().Trim().Equals(button2.Text) && read["Unit"].ToString().Trim().Equals(button3.Text))
                        listView4.Items.Add(new ListViewItem(read["Name"].ToString().Trim()));
                }
                read.Close();
                if (listView4.Items.Count == 0 )
                {
                    MessageBox.Show("There is no courses in this unit yet, try again");
                    listView3.Enabled = true;
                    button3.Enabled = true;
                    listView4.Enabled = false;
                    button4.Enabled = false;
                    listView3.SelectedItems.Clear();
                    return;
                }
            }
            else
            {
                button3.Enabled = false;
                listView3.Enabled = false;
                button2.Enabled = true;
                listView2.Enabled = true;
                listView3.Items.Clear();
            }
            listView3.SelectedItems.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView5.Items.Clear();
            if (listView4.SelectedItems.Count >= 1)
            {
                button4.Text = listView4.SelectedItems[0].Text;
                read = db.Select("*", "NewCourses", "Name", button4.Text);
                while (read.Read())
                {
                    if (read["Unit"].ToString().Trim().Equals(button3.Text) && read["Department"].ToString().Trim().Equals(button2.Text))
                    {
                        Course_ID = read["ID"].ToString().Trim();
                        break;
                    }
                }
                read.Close();
                listView4.Enabled = false;
                button4.Enabled = false;
                listView5.Enabled = true;
                button5.Enabled = true;
                bool check_if_lect_exist = false;
                DataBase db2 = new DataBase();
                read = db.Select("*", "NewUsers", "Unit", button3.Text);
                SqlDataReader reader2;
                while (read.Read())
                {

                    if (read["Role"].ToString().Trim() == "Lecturer" || read["Role"].ToString().Trim().Equals("Practitioner") || read["Role"].ToString().Trim().Equals("Head Of Department"))
                    {
                        if (read["Department"].ToString().Trim().Equals(button2.Text) && read["Unit"].ToString().Trim().Equals(button3.Text))
                        {
                            reader2 = db2.Select("*", "NewSchedule", "Unit", button3.Text);
                            while (reader2.Read())
                            {

                                
                                if ((read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()).Equals(reader2["LecturerName"].ToString().Trim()))
                                {
                                    if (reader2["Day"].ToString().Trim().Equals(addToSce.day))
                                    {
                                        if (CalcHours(reader2["StartHour"].ToString().Trim(), reader2["EndHour"].ToString().Trim(), addToSce.Start.Text.Substring(0, 2), addToSce.End.Text.Substring(0, 2)))
                                        {
                                            check_if_lect_exist = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            reader2.Close();
                            if (!check_if_lect_exist)
                            {
                                listView5.Items.Add(new ListViewItem(read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()));
                                
                            }
                            check_if_lect_exist = false;
                        }
                    }
                }
                
                read.Close();
                if (listView5.Items.Count == 0 &&listView4.SelectedItems.Count>0)
                {
                    MessageBox.Show("there are no currently lecturers in this course");
                    listView4.Enabled = true;
                    button4.Enabled = true;
                    listView5.Enabled = false;
                    button5.Enabled = false;
                    
                    return;
                }
            }
            
            else
            {
                listView4.Enabled = false;
                button4.Enabled = false;
                listView3.Enabled = true;
                button3.Enabled = true;
                listView4.Items.Clear();
            }
            listView4.SelectedItems.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView6.Items.Clear();

            if (listView5.SelectedItems.Count >= 1)
            {
                button5.Text = listView5.SelectedItems[0].Text;
                if (button1.Text.Equals("Exams Period A") || button1.Text.Equals("Exams Period B"))
                {
                    button6.Text = "Exam";
                    button6.Enabled = true;
                    listView6.Enabled = true;
                    listView6.Items.Add(new ListViewItem("Exam"));
                    listView5.Enabled = false;
                    button5.Enabled = false;
                    button8.Enabled = false;
                    listView8.Enabled = false;
                    return;
                }
                button5.Enabled = false;
                listView5.Enabled = false;
                button6.Enabled = true;
                listView6.Enabled = true;
                read = db.Select("*", "NewUsers");
                while (read.Read())
                {
                    if ((read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()) == listView5.SelectedItems[0].Text)
                    {
                        if (read["Role"].ToString().Trim().Equals("Lecturer"))
                        {
                            listView6.Items.Add(new ListViewItem("Lecture"));
                            listView6.Items.Add(new ListViewItem("ReceptionHour"));
                            break;
                        }
                        if (read["Role"].ToString().Trim().Equals("Practitioner"))
                        {
                            listView6.Items.Add(new ListViewItem("Practice"));
                            listView6.Items.Add(new ListViewItem("ReceptionHour"));
                            break;
                        }
                        if (read["Role"].ToString().Trim().Equals("Head Of Department"))
                        {
                            listView6.Items.Add(new ListViewItem("Lecture"));
                            listView6.Items.Add(new ListViewItem("ReceptionHour"));
                            listView6.Items.Add(new ListViewItem("Meeting"));
                            break;
                        }
                    }
                }
                read.Close();

            }
            else
            {
                listView5.Enabled = false;
                button5.Enabled = false;
                listView4.Enabled = true;
                button4.Enabled = true;
                listView5.Items.Clear();
            }
            listView5.SelectedItems.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView7.Items.Clear();

            bool check_class = false;
            if (addToSce.getClass() != null && listView6.SelectedItems.Count>0)
            {
                listView8.Items.Add(new ListViewItem(addToSce.getClass()));
                listView8.Visible = true;
                button8.Enabled = true;
                button6.Enabled = false;
                listView6.Enabled = false;
                listView6.SelectedItems.Clear();
                return;
            } 
            SqlDataReader reader2;
            DataBase db2 = new DataBase();


            if (listView6.SelectedItems.Count > 0)
            {
                button6.Text = listView6.SelectedItems[0].Text;
                if (button6.Text.Equals("Practice"))
                {
                    listView6.Enabled = false;
                    button6.Enabled = false;
                    listView7.Enabled = true;
                    button7.Enabled = true;
                    read = db.Select("*", "NewUsers");
                    while (read.Read())
                    {
                        if (read["Role"].ToString().Trim().Equals("Lecturer") || read["Role"].ToString().Trim().Equals("Head Of Department"))
                        {
                            if (read["Unit"].ToString().Trim().Equals(button3.Text))
                            {
                                listView7.Items.Add(new ListViewItem(read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim()));
                            }
                        }
                    }
                    read.Close();
                }


                else if (button6.Text.Equals("Meeting"))
                {
                    Description d = new Description(this);
                    d.Show();
                }
                if(button6.Text.Equals("Exam"))
                {
                    button1.Text = button1.Text.Substring(button1.Text.Length - 1, 1);
                }
                listView6.Enabled = false;
                button6.Enabled = false;
                listView8.Enabled = true;
                button8.Enabled = true;
                read = db.Select("*", "NewSchedule");
                reader2 = db2.Select("Name", "Classrooms");
                while (reader2.Read())
                {
                    while (read.Read())
                    {
                        if (reader2[0].ToString().Trim().Equals(read["Classroom"].ToString().Trim()))
                            if (read["Date"].ToString().Trim().Equals(addToSce.date))
                                if (CalcHours(read["StartHour"].ToString().Trim(), read["EndHour"].ToString().Trim(), addToSce.Start.Text.Substring(0, 2), addToSce.End.Text.Substring(0, 2)))
                                {
                                    check_class = true;
                                    break;
                                }
                    }
                    if (!check_class)
                    {
                        listView8.Items.Add(new ListViewItem(reader2[0].ToString().Trim()));
                    }
                    check_class = false;
                }
                reader2.Close();
                read.Close();
            }
            else
            {
                listView6.Enabled = false;
                button6.Enabled = false;
                listView5.Enabled = true;
                button5.Enabled = true;
                listView6.Items.Clear();
            }
            listView6.SelectedItems.Clear();
        }
        private bool CalcHours(string ScheStart, string ScheEnd, string Start, string End)
        {
            int start_sche = Int32.Parse(ScheStart);
            int end_sche = Int32.Parse(ScheEnd);
            int s = Int32.Parse(Start);
            int e = Int32.Parse(End);
            if (start_sche <= s && end_sche > s)
            {
                return true;
            }
            else if (start_sche < e && end_sche >= e)
                return true;
            else
                return false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView8.Items.Clear();

            bool check_class = false;
            SqlDataReader reader2;
            DataBase db2 = new DataBase();
            if (listView7.SelectedItems.Count > 0)
            {
                button7.Text = listView7.SelectedItems[0].Text;
                listView7.Enabled = false;
                button7.Enabled = false;
                listView8.Enabled = true;
                button8.Enabled = true;
                read = db.Select("*", "NewSchedule");
                reader2 = db2.Select("Name", "Classrooms");
                while (reader2.Read())
                {
                    while (read.Read())
                    {
                        if (reader2[0].ToString().Trim().Equals(read["Classroom"].ToString().Trim()))
                            if (read["Date"].ToString().Trim().Equals(addToSce.date))
                                if (CalcHours(read["StartHour"].ToString().Trim(), read["EndHour"].ToString().Trim(), addToSce.Start.Text.Substring(0, 2), addToSce.End.Text.Substring(0, 2)))
                                {
                                    check_class = true;
                                    break;
                                }
                    }
                    if (!check_class)
                    {
                        listView8.Items.Add(new ListViewItem(reader2[0].ToString().Trim()));
                    }
                    check_class = false;
                }
                reader2.Close();
                read.Close();
            }
            else
            {
                listView7.Enabled = false;
                button7.Enabled = false;
                listView6.Enabled = true;
                button6.Enabled = true;
                listView7.Items.Clear();
            }
            listView7.SelectedItems.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView9.Items.Clear();
            if (listView8.SelectedItems.Count > 0)
            {
                button8.Text = listView8.SelectedItems[0].Text;
                if (button6.Text.Equals("Exam"))
                {
                    listView8.Enabled = false;
                    button8.Enabled = false;
                    listView9.Visible = true;
                    button9.Visible = true;
                    listView9.Enabled = true;
                    button9.Enabled = true;
                    listView9.Items.Add(new ListViewItem("A"));
                    listView9.Items.Add(new ListViewItem("B"));
                }
                else
                {
                    if (MessageBox.Show("Did you finish?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

                    {
                        string name;
                        read = db.Select("*", "NewUsers");
                        while (read.Read())
                        {
                            name = read["FirstName"].ToString().Trim() + " " + read["LastName"].ToString().Trim();
                            if (name.Equals(button5.Text))
                                if (read["Department"].ToString().Trim().Equals(button2.Text))
                                {
                                    Role = read["Role"].ToString().Trim();
                                }


                        }
                        read.Close();

                        addToSce.course_list_items.Add(button4.Text);
                        addToSce.course_list_items.Add(Course_ID);
                        addToSce.course_list_items.Add(button2.Text);
                        addToSce.course_list_items.Add(button3.Text);
                        addToSce.course_list_items.Add(Role);
                        addToSce.course_list_items.Add(addToSce.day);
                        addToSce.course_list_items.Add(addToSce.Start.Text.Substring(0, 2));
                        addToSce.course_list_items.Add(addToSce.End.Text.Substring(0, 2));
                        addToSce.course_list_items.Add(button6.Text);
                        addToSce.course_list_items.Add(button8.Text);
                        addToSce.course_list_items.Add(addToSce.date);
                        addToSce.course_list_items.Add(button5.Text);
                        addToSce.course_list_items.Add(button1.Text);
                        if (button6.Text.Equals("Meeting"))
                        {

                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add(descript);
                        }
                        else if (button6.Text.Equals("Practice"))
                        {
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add(button7.Text);
                            addToSce.course_list_items.Add("NULL");
                        }

                        else
                        {
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                            addToSce.course_list_items.Add("NULL");
                        }
                        ListViewGroup group = new ListViewGroup(button5.Text + "-" + button4.Text);
                        ListViewItem item = new ListViewItem(group);
                        item.Text = button6.Text + " , " + addToSce.Start.Text + "-" + addToSce.End.Text;
                        addToSce.temp_course_list.Items.Add(item);
                        this.Close();
                        addToSce.button2.BackgroundImage = null;
                        addToSce.button2.Image = Resources.add_folder_normal;
                    }
                    else
                    {
                        listView8.SelectedItems.Clear();
                    }
                }
            }
            else
            {
                button8.Enabled = false;
                listView8.Enabled = false;
                button7.Enabled = true;
                listView7.Enabled = true;
                listView8.Items.Clear();
            }
            listView8.SelectedItems.Clear();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            read = db.Select("*", "NewUsers","Department",button2.Text);
            if (listView9.SelectedItems.Count > 0)
            {
                button9.Text = listView9.SelectedItems[0].Text;
                while (read.Read())
                {
                    if((read["FirstName"].ToString().Trim()+" " + read["LastName"].ToString().Trim()).Equals(button5.Text)){
                        Role = read["Role"].ToString().Trim();
                    }
                }
                if (MessageBox.Show("Did you finish?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    addToSce.course_list_items.Add(button4.Text);
                    addToSce.course_list_items.Add(Course_ID);
                    addToSce.course_list_items.Add(button2.Text);
                    addToSce.course_list_items.Add(button3.Text);
                    addToSce.course_list_items.Add(Role);
                    addToSce.course_list_items.Add(addToSce.day);
                    addToSce.course_list_items.Add(addToSce.Start.Text.Substring(0, 2));
                    addToSce.course_list_items.Add(addToSce.End.Text.Substring(0, 2));
                    addToSce.course_list_items.Add(button6.Text);
                    addToSce.course_list_items.Add(button8.Text);
                    addToSce.course_list_items.Add(addToSce.date);
                    addToSce.course_list_items.Add(button5.Text);
                    addToSce.course_list_items.Add(button1.Text);
                    addToSce.course_list_items.Add("NULL");
                    addToSce.course_list_items.Add(button9.Text);
                    addToSce.course_list_items.Add("NULL");
                    addToSce.course_list_items.Add("NULL");
                    ListViewGroup group = new ListViewGroup(button5.Text + "-" + button4.Text);
                    ListViewItem item = new ListViewItem(group);
                    item.Text = button5.Text + "-" + button4.Text;
                    addToSce.temp_course_list.Items.Add(item);
                    this.Close();
                }
            }
            else
            {
                listView9.Enabled = false;
                button9.Enabled = false;
                listView7.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    }

