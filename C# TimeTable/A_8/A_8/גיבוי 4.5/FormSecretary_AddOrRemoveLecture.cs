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
    public partial class FormSecretary_AddOrRemoveLecture : Form
    {
        int id;
        string password;
        List<int> lectureIDS = new List<int>();
        public FormSecretary_AddOrRemoveLecture(int _id, string _password)
        {
            InitializeComponent();

            string department;
            List<string> coursesProperties=new List<string>();
            List<int> coursesID = new List<int>();
            List<int> lecturesID = new List<int>();
            id = _id;
            password = _password;
            department=SQLFunctions.getUsersDepartment(id);
            coursesProperties=SQLFunctions.findCoursePropertiesByDepartment(department);
            for(int i=1;i<coursesProperties.Count;i+=9)
            {
                coursesID.Add(Convert.ToInt32(coursesProperties[i]));
            }
           
            for (int i = 0; i < coursesID.Count; i++)
            {
                lecturesID=SQLFunctions.findLecturesIDsForCourse(coursesID[i]);
                for (int j = 0; j < lecturesID.Count; j++)
                {
                    lectureIDS.Add(lecturesID[j]);
                    comboBox_Lectures.Items.Add(SQLFunctions.covertLectureIDtoLectureName(lecturesID[j]) + " " + lecturesID[j]);
                }
            }
           
            comboBox_Lectures.Items.Add("All");
            this.AcceptButton = button_accept;
            textBox_StartTime.MaxLength = 2;
            textBox_EndTime.MaxLength = 2;
            textBox_day.MaxLength = 2;
            textBox_month.MaxLength = 2;
            textBox_year.MaxLength = 2;
            comboBox_AddRemove.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Lectures.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void comboBox_AddRemove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                button_accept.Text = "Add course";
                label_description.Visible = true;
                textBox_description.Visible = true;
            }
            else
            {
                button_accept.Text = "Remove Course";
                label_description.Visible = false;
                textBox_description.Visible = false;
            }
            comboBox_Lectures.Enabled = true;
        }

        public bool checkTextBox()
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                if ((textBox_StartTime.TextLength > 0) && (textBox_EndTime.TextLength >=1) && (textBox_day.TextLength >= 1) && (textBox_month.TextLength >= 1) && (textBox_year.Text.Length == 2) && textBox_description.Text.Length > 1)
                    return true;
            }
            else
            {
                if ((textBox_StartTime.TextLength > 0) && (textBox_EndTime.TextLength >= 1) && (textBox_day.TextLength >= 1) && (textBox_month.TextLength >= 1) && (textBox_year.TextLength == 2))
                    return true;
              
            }
            return false;
        }
        private void textBox_day_TextChanged(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void textBox_month_TextChanged(object sender, EventArgs e)
        {
            if(checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void textBox_year_TextChanged(object sender, EventArgs e)
        {
            if(checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void textBox_StartTime_TextChanged(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void textBox_EndTime_TextChanged(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            if (checkTextBox() == true)
                button_accept.Enabled = true;
            else
                button_accept.Enabled = false;
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            int lectureID;
            if ((2000 + Convert.ToInt32(textBox_year.Text) < 2100) && (2000 + Convert.ToInt32(textBox_year.Text) > 2000)&& (Convert.ToInt32(textBox_month.Text)<13) && (Convert.ToInt32(textBox_month.Text)>0))
            {
                if (!(Convert.ToInt32(textBox_day.Text) > DateTime.DaysInMonth(2000+Convert.ToInt32(textBox_year.Text), Convert.ToInt32(textBox_month.Text))|| Convert.ToInt32(textBox_day.Text)<0))
                {
                    if((Convert.ToInt32(textBox_StartTime.Text)>=8 && Convert.ToInt32(textBox_StartTime.Text) <= 21)&& (Convert.ToInt32(textBox_EndTime.Text) >= 8 && Convert.ToInt32(textBox_EndTime.Text) <= 21)&&(Convert.ToInt32(textBox_StartTime.Text)< Convert.ToInt32(textBox_EndTime.Text)))
                    {
                        if (comboBox_AddRemove.SelectedIndex == 0)
                        {
                            if (comboBox_Lectures.SelectedItem.ToString() != "All")
                            {
                                lectureID = lectureIDS[comboBox_Lectures.SelectedIndex];
                                SQLFunctions.addChange(textBox_description.Text, Convert.ToInt32(textBox_StartTime.Text), Convert.ToInt32(textBox_EndTime.Text), Convert.ToInt32(textBox_day.Text), Convert.ToInt32(textBox_month.Text), 2000 + Convert.ToInt32(textBox_year.Text), lectureID);
                            }
                            else
                            {
                                SQLFunctions.addChange(textBox_description.Text, Convert.ToInt32(textBox_StartTime.Text), Convert.ToInt32(textBox_EndTime.Text), Convert.ToInt32(textBox_day.Text), Convert.ToInt32(textBox_month.Text), 2000 + Convert.ToInt32(textBox_year.Text), 0);
                            }
                        }
                        else
                        {
                            lectureID = lectureIDS[comboBox_Lectures.SelectedIndex];
                            SQLFunctions.addChange("Canceled", Convert.ToInt32(textBox_StartTime.Text), Convert.ToInt32(textBox_EndTime.Text), Convert.ToInt32(textBox_day.Text), Convert.ToInt32(textBox_month.Text), 2000 + Convert.ToInt32(textBox_year.Text), lectureID);
                        }
                        FormMenuSecretary secForm = new FormMenuSecretary(id, password);
                        this.Hide();
                        secForm.Show();   
                    }

                    else
                        MessageBox.Show("Incorrect values");
                }
                else
                    MessageBox.Show("Incorrect values");
            }
            else
            {
                MessageBox.Show("Incorrect values");
            }
        }

        private void FormSecretary_AddOrRemoveLecture_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            FormMenuSecretary secForm = new FormMenuSecretary(id, password);
            this.Hide();
            secForm.Show();
        }

        private void FormSecretary_AddOrRemoveLecture_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_LectureID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
                textBox_description.Text = comboBox_Lectures.SelectedItem.ToString();
        }
    }
}
