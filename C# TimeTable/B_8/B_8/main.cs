using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace B_8
{
    public partial class main : Form
    {
      
        private DataBase db = new DataBase();
        public bool IsUnitTest = false;

        public main()
        {
            string s = "09";
            InitializeComponent();
            Load_Class lc = new Load_Class(this);
            lc.Dock = DockStyle.Fill;
            panel1.Controls.Add(lc);

            IsUnitTest = true;


        }

    
        private void log_out_Click(object sender, EventArgs e)
        {
            Hide();
            login ss = new login();

            ss.Show();

        }

        public void permission()
        {
            if (GlobalVariables.User_Permission == "Lecturer")
            {
                Add_course_to_system.Visible = false;
                Add_course_to_system.Enabled = false;
                Delete_course.Visible = false;
                Delete_course.Enabled = false;
                Add_User.Visible = false;
                Add_User.Enabled = false;
                button1.Visible = false;
                Display_courses.Visible = false;

            }
            else if (GlobalVariables.User_Permission == "Head Of Department")
            {
                Add_course_to_system.Visible = false;
                Add_course_to_system.Enabled = false;
                Delete_course.Visible = false;
                Delete_course.Enabled = false;
                Add_User.Visible = false;
                Add_User.Enabled = false;
                button1.Visible = false;
                Display_courses.Visible = false;
                toolStripMenuItem9.Visible = true;
                

            }
            else if (GlobalVariables.User_Permission == "Practitioner")
            {
                Add_course_to_system.Visible = false;
                Add_course_to_system.Enabled = false;
                Delete_course.Visible = false;
                Delete_course.Enabled = false;
                Add_User.Visible = false;
                Add_User.Enabled = false;
                button1.Visible = false;
                Display_courses.Visible = false;


            }
            else if (GlobalVariables.User_Permission == "Secretary")
            {
                
                Constraints.Visible = false;
                Constraints.Enabled = false;
                Show_course_by_semester.Visible = false;
                Show_course_by_semester.Enabled = false;
                Show_students.Visible = false;
                Show_students.Enabled = false;
                button2.Visible = false;
            }
        }
        public void setMenuStrip()
        {
            if (db.isconnected)
            {
                menuStrip1.Items[0].Text = "SQL: Connected";
                menuStrip1.Items[0].ForeColor = Color.Green;
            }
            else
            {
                menuStrip1.Items[0].Text = "SQL: DisConnected";
                menuStrip1.Items[0].ForeColor = Color.Red;
            }

            menuStrip1.Items[1].Text = DateTime.Today.ToString("dd / MM / yyyy");
            menuStrip1.Items[3].Text = "Hello "+GlobalVariables.Full_Name;
        }
        private void main_Load(object sender, EventArgs e)
        {

            permission();
            setMenuStrip();
            Load_Class lc = new Load_Class(this);
            lc.Dock = DockStyle.Fill;
            panel1.Controls.Add(lc);
            
        }

      
        private void EXIT_Click(object sender, EventArgs e)
        {
         
        }

        
     

       


       

    

   


        private void WeeklySchedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            WeeklySchedule c = new WeeklySchedule();
            c.Show();
        }

        private void EXIT_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            menuStrip1.Items[2].Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                this.Hide();
                Show_Exams se = new Show_Exams();
                se.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Constraints c = new Constraints();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
             new DeleteCourse().Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewUserRegistration ss = new NewUserRegistration();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ShowCourses show = new ShowCourses();
            show.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule schedule = new Schedule();
            schedule.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course_Filtering_Suitability c = new Course_Filtering_Suitability();
            c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ViewStudentsInCourse viewstudents = new ViewStudentsInCourse();
            viewstudents.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            new ListCourses().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            new AddCourse().Show();
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            About_Us a = new About_Us();
            a.Show();
        }

      
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (GlobalVariables.User_Permission == "Secretary")
            {
                
                return;
            }
            this.Close();
            Semester_Schedule s = new Semester_Schedule();
            s.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Close();
            login log = new login();
            log.Show();
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            About_Us a = new About_Us();
            a.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
             new ClassDepartment().Show();
                
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            new Meeting().Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            
            new Contact_Us().Show();
           
        }
    }
}
