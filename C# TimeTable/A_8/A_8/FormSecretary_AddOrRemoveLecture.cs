using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        DateTime lecture_date;
        public FormSecretary_AddOrRemoveLecture(int _id, string _password)
        {
            InitializeComponent();
            comboBox_year.Items.Add(DateTime.Today.Year);
            comboBox_year.Items.Add(DateTime.Today.Year + 1);
            string department;
            DataTable coursesProperties = new DataTable();
            List<int> coursesID = new List<int>();
            List<int> lecturesID = new List<int>();

            id = _id;
            password = _password;
            department = SQLFunctions.getUsersDepartment(id);
            DataTable LecturesByDepartment = SQLFunctions.getLecturesByDepartment(department);
            coursesProperties = SQLFunctions.findCoursePropertiesByDepartment(department);
            for (int i = 0; i < coursesProperties.Rows.Count; i++)
            {
                coursesID.Add(Convert.ToInt32(coursesProperties.Rows[i]["ID"]));
            }

            if (LecturesByDepartment.Rows != null)
            {
                for (int j = 0; j < LecturesByDepartment.Rows.Count; j++)
                {
                    lectureIDS.Add(Convert.ToInt32(LecturesByDepartment.Rows[j]["LectureID"].ToString()));
                    comboBox_Lectures.Items.Add(LecturesByDepartment.Rows[j]["Name"].ToString() + " " + LecturesByDepartment.Rows[j]["LectureID"].ToString());
                }

            }
            this.AcceptButton = button_accept;
            textBox_StartTime.MaxLength = 2;
            textBox_EndTime.MaxLength = 2;
            textBox_day.MaxLength = 2;
            textBox_month.MaxLength = 2;
            textBox_title.MaxLength = 48;
            comboBox_day.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_month.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_year.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_AddRemove.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Lectures.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void comboBox_AddRemove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                button_accept.Text = "Add Lesson";
                label_description.Visible = true;
                textBox_description.Visible = true;
                comboBox_Lectures.Enabled = true;
                label_startTime00.Visible = true;
                label_EndTime00.Visible = true;
                label_startTime.Visible = false;
                label_endTime.Visible = false;
                textBox_day.Visible = true;
                textBox_month.Visible = true;
                comboBox_day.Visible = false;
                comboBox_month.Visible = false;
                textBox_StartTime.Visible = true;
                textBox_EndTime.Visible = true;
                label_Time.Visible = true;
            }
            else if (comboBox_AddRemove.SelectedIndex == 1)
            {
                button_accept.Text = "Remove Lesson";
                label_description.Visible = true;
                textBox_description.Visible = true;
                comboBox_Lectures.Enabled = true;
                label_startTime00.Visible = false;
                label_EndTime00.Visible = false;
                textBox_day.Visible = false;
                textBox_month.Visible = false;
                comboBox_day.Visible = true;
                comboBox_month.Visible = true;
                textBox_StartTime.Visible = false;
                textBox_EndTime.Visible = false;
                label_Time.Visible = false;
            }
            else
            {
                button_accept.Text = "Add Event";
                comboBox_Lectures.Text = "";
                comboBox_Lectures.Enabled = false;
                textBox_title.Text = "";
                label_startTime00.Visible = true;
                label_EndTime00.Visible = true;
                textBox_day.Visible = true;
                textBox_month.Visible = true;
                comboBox_day.Visible = false;
                comboBox_month.Visible = false;
                textBox_StartTime.Visible = true;
                textBox_EndTime.Visible = true;
                label_Time.Visible = true;
                label_startTime.Visible = false;
                label_endTime.Visible = false;
            }
            check_details();
        }
        public bool checkTextBox()
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                if ((textBox_StartTime.TextLength > 0) && (textBox_EndTime.TextLength >= 1) && (textBox_day.TextLength >= 1) && (textBox_month.TextLength >= 1))
                    return true;
            }
            else
            {
                if ((textBox_StartTime.TextLength > 0) && (textBox_EndTime.TextLength >= 1) && (textBox_day.TextLength >= 1) && (textBox_month.TextLength >= 1))
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
            check_details();
        }

        private void textBox_year_TextChanged(object sender, EventArgs e)
        {
            check_details();
        }

        private void textBox_StartTime_TextChanged(object sender, EventArgs e)
        {
            check_details();
        }

        private void textBox_EndTime_TextChanged(object sender, EventArgs e)
        {
            check_details();
        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            check_details();
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            int lectureID;
            List<int> studentIDs = new List<int>();
            string dayForConstraints;
            string month;

            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                if (verify_details() == true)
                {
                    SQLFunctions.addChange(textBox_title.Text, textBox_description.Text, Convert.ToInt32(textBox_StartTime.Text), Convert.ToInt32(textBox_EndTime.Text), Convert.ToInt32(textBox_day.Text), Convert.ToInt32(textBox_month.Text), Convert.ToInt32(comboBox_year.Text), lectureIDS[comboBox_Lectures.SelectedIndex]);

                    MessageBox.Show("Lesson was successfuly added");
                }
            }
            else if (comboBox_AddRemove.SelectedIndex == 1)
            {

                lectureID = lectureIDS[comboBox_Lectures.SelectedIndex];
                SQLFunctions.addChange(textBox_title.Text, textBox_description.Text, Convert.ToInt32(label_startTime.Text), Convert.ToInt32(label_endTime.Text), Convert.ToInt32(comboBox_day.Text), Convert.ToInt32(comboBox_month.Text), Convert.ToInt32(comboBox_year.Text), lectureID);

                DateTime day = new DateTime(Convert.ToInt32(comboBox_year.Items[comboBox_year.SelectedIndex]), Convert.ToInt32(comboBox_month.Items[comboBox_month.SelectedIndex]), Convert.ToInt32(comboBox_day.Items[comboBox_day.SelectedIndex]));
                month = comboBox_month.Items[comboBox_month.SelectedIndex].ToString();

                if ((Convert.ToInt32(comboBox_day.Items[comboBox_day.SelectedIndex])) < 10)
                {
                    dayForConstraints = "0" + comboBox_day.Items[comboBox_day.SelectedIndex].ToString();
                }
                else
                    dayForConstraints = comboBox_day.Items[comboBox_day.SelectedIndex].ToString();
                if ((Convert.ToInt32(comboBox_month.Items[comboBox_day.SelectedIndex])) < 10)
                {
                    month = "0" + month;
                }
                if (day > (new DateTime(Convert.ToInt32(day.Year), 03, 05)) && day < (new DateTime(Convert.ToInt32(day.Year), 6, 15)))
                {
                    SQLFunctions.addConstraint(SQLFunctions.getLecturerIDByLecturerName(SQLFunctions.findLecturerNameByLectureID(lectureID)), day.DayOfWeek.ToString(), (label_startTime.Text + ":00").ToString(), (label_endTime.Text + ":00").ToString(), textBox_description.Text.ToString(), SQLFunctions.findLecturerNameByLectureID(lectureID), (dayForConstraints + "/" + month + "/" + comboBox_year.Items[comboBox_year.SelectedIndex].ToString()), "B", (SQLFunctions.covertLectureIDtoLectureName(lectureIDS[comboBox_Lectures.SelectedIndex])).ToString());
                }
                else if (day > new DateTime(Convert.ToInt32(day.Year), 10, 30) && day < new DateTime(Convert.ToInt32(day.Year), 2, 4))
                    SQLFunctions.addConstraint(SQLFunctions.getLecturerIDByLecturerName(SQLFunctions.findLecturerNameByLectureID(lectureID)), day.DayOfWeek.ToString(), (label_startTime.Text + ":00").ToString(), (label_endTime.Text + ":00").ToString(), textBox_description.Text.ToString(), SQLFunctions.findLecturerNameByLectureID(lectureID), (dayForConstraints + "/" + month + "/" + comboBox_year.Items[comboBox_year.SelectedIndex].ToString()), "A", (SQLFunctions.covertLectureIDtoLectureName(lectureIDS[comboBox_Lectures.SelectedIndex])).ToString());
                MessageBox.Show("Lesson was successfuly removed");
            }
            else if (comboBox_AddRemove.SelectedIndex == 2)
            {
                if (verify_details() == true)
                {
                    DateTime day = new DateTime(Convert.ToInt32(comboBox_year.Items[comboBox_year.SelectedIndex]), Convert.ToInt32(textBox_month.Text), Convert.ToInt32(textBox_day.Text));
                    month = textBox_month.Text.ToString();
                    dayForConstraints = textBox_day.Text.ToString();
                    if (Convert.ToInt32(textBox_day.Text) < 10)
                    {
                        if (!textBox_day.Text.Contains('0'))
                            dayForConstraints = "0" + textBox_day.Text;

                    }

                    if (Convert.ToInt32(textBox_month.Text) < 10)
                    {
                        if (!textBox_month.Text.Contains('0'))
                            month = "0" + textBox_month.Text;

                    }
                    SQLFunctions.addChange(textBox_title.Text, textBox_description.Text, Convert.ToInt32(textBox_StartTime.Text), Convert.ToInt32(textBox_EndTime.Text), Convert.ToInt32(textBox_day.Text), Convert.ToInt32(textBox_month.Text), Convert.ToInt32(comboBox_year.Text), 0);
                    if (day > new DateTime(Convert.ToInt32(day.Year), 3, 5) && day < new DateTime(Convert.ToInt32(day.Year), 6, 15))
                        SQLFunctions.addConstraint("0", day.DayOfWeek.ToString(), (textBox_StartTime.Text + ":00").ToString(), (textBox_EndTime.Text + ":00").ToString(), textBox_description.Text.ToString(), "", (dayForConstraints + "/" + month + "/" + comboBox_year.Items[comboBox_year.SelectedIndex].ToString()), "B", "General");
                    else if (day > new DateTime(Convert.ToInt32(day.Year), 10, 30) && day < new DateTime(Convert.ToInt32(day.Year), 2, 4))
                        SQLFunctions.addConstraint("0", day.DayOfWeek.ToString(), (textBox_StartTime.Text + ":00").ToString(), (textBox_EndTime.Text + ":00").ToString(), textBox_description.Text.ToString(), "", (dayForConstraints + "/" + month + "/" + comboBox_year.Items[comboBox_year.SelectedIndex].ToString()), "A", "General");
                    MessageBox.Show("Event was successfuly Added");
                }
            }
            foreach (Control c in this.Controls)
            {
                if ((c.GetType() == typeof(TextBox)) || (c.GetType() == typeof(ComboBox)))
                    c.Text = "";
            }
        }

        public bool verify_details()
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                if ((Convert.ToInt32(textBox_month.Text) < 13) && (Convert.ToInt32(textBox_month.Text) > 0))
                {
                    if (!(Convert.ToInt32(textBox_day.Text) > DateTime.DaysInMonth(Convert.ToInt32(comboBox_year.Text), Convert.ToInt32(textBox_month.Text)) || Convert.ToInt32(textBox_day.Text) < 0))
                    {
                        if ((Convert.ToInt32(textBox_StartTime.Text) >= 8 && Convert.ToInt32(textBox_StartTime.Text) <= 21) && (Convert.ToInt32(textBox_EndTime.Text) >= 8 && Convert.ToInt32(textBox_EndTime.Text) <= 21) && (Convert.ToInt32(textBox_StartTime.Text) < Convert.ToInt32(textBox_EndTime.Text)))
                        {
                            return true;
                        }

                        else
                            MessageBox.Show("Incorrect time");
                    }
                    else
                        MessageBox.Show("Incorrect day");
                }
                else
                {
                    MessageBox.Show("Incorrect month");
                }
            }
            else if (comboBox_AddRemove.SelectedIndex == 2)
            {
                if ((Convert.ToInt32(textBox_month.Text) < 13) && (Convert.ToInt32(textBox_month.Text) > 0))
                {
                    if (!(Convert.ToInt32(textBox_day.Text) > DateTime.DaysInMonth(Convert.ToInt32(comboBox_year.Text), Convert.ToInt32(textBox_month.Text)) || Convert.ToInt32(textBox_day.Text) < 0))
                    {
                        if ((Convert.ToInt32(textBox_StartTime.Text) >= 8 && Convert.ToInt32(textBox_StartTime.Text) <= 21) && (Convert.ToInt32(textBox_EndTime.Text) >= 8 && Convert.ToInt32(textBox_EndTime.Text) <= 21) && (Convert.ToInt32(textBox_StartTime.Text) < Convert.ToInt32(textBox_EndTime.Text)))
                        {
                            return true;
                        }

                        else
                            MessageBox.Show("Incorrect time");
                    }
                    else
                        MessageBox.Show("Incorrect day");
                }
                else
                {
                    MessageBox.Show("Incorrect month");
                }
            }
            return false;
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
            DateTime today = DateTime.Today;
            string lecture_day;
            int i = 0;
            int index = 0;

            if (comboBox_AddRemove.SelectedIndex == 0)
                textBox_title.Text = comboBox_Lectures.SelectedItem.ToString();
            else if (comboBox_AddRemove.SelectedIndex == 1)
            {


                DataTable lecture = SQLFunctions.getLectureDataTable(lectureIDS[comboBox_Lectures.SelectedIndex]);
                label_startTime.Text = (lecture.Rows[0]["StartHour"].ToString());
                label_endTime.Text = (lecture.Rows[0]["EndHour"].ToString());
                if (lecture != null)
                {
                    comboBox_day.Items.Clear();
                    comboBox_month.Items.Clear();
                    comboBox_year.Items.Clear();
                    lecture_day = lecture.Rows[0]["day"].ToString();
                    if (lecture_day == "SUN")
                        lecture_day = "Sunday";
                    else if (lecture_day == "MON")
                        lecture_day = "Monday";
                    else if (lecture_day == "TUE")
                        lecture_day = "Tuesday";
                    else if (lecture_day == "WED")
                        lecture_day = "Wednesday";
                    else if (lecture_day == "THU")
                        lecture_day = "Thursday";
                    else if (lecture_day == "FRI")
                        lecture_day = "Friday";

                    for (i = 0; i < 7; i++)
                    {
                        if (lecture_day == Convert.ToString(today.DayOfWeek))
                            index = i;
                        today = today.AddDays(1);
                    }
                    textBox_title.Text = comboBox_Lectures.SelectedItem.ToString() + " Canceled";
                    today = today.AddDays(index);
                    lecture_date = today;
                    lecture_date = lecture_date.AddDays(-7);
                    for (i = 0; i < 20; i++)
                    {
                        if (DateTime.Today <= lecture_date)
                        {
                            if (!comboBox_month.Items.Contains(Convert.ToString(lecture_date.Month)))
                                comboBox_month.Items.Add(Convert.ToString(lecture_date.Month));
                            if (!comboBox_year.Items.Contains(Convert.ToString(lecture_date.Year)))
                                comboBox_year.Items.Add(Convert.ToString(lecture_date.Year));
                            lecture_date = lecture_date.AddDays(7);
                        }
                    }


                }
            }
            check_details();
        }
        private void comboBox_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AddRemove.SelectedIndex == 1)
            {
                if (comboBox_day.SelectedIndex != -1 && comboBox_month.SelectedIndex != -1 && comboBox_day.SelectedIndex != -1)
                {
                    label_EndTime00.Visible = true;
                    label_startTime00.Visible = true;
                }
            }
            check_details();
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        private void comboBox_month_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_year.SelectedIndex == -1)
                comboBox_year.SelectedIndex = 0;
            DateTime month = new DateTime(Convert.ToInt32(comboBox_year.Items[comboBox_year.SelectedIndex]), Convert.ToInt32(comboBox_month.Items[comboBox_month.SelectedIndex]), 1);
            string lecture_day = Convert.ToString(lecture_date.DayOfWeek);
            comboBox_day.Items.Clear();
            foreach (DateTime day in EachDay(month, month.AddDays(DateTime.DaysInMonth(month.Year, month.Month) - 1)))
            {
                if (lecture_day == day.DayOfWeek.ToString())
                    comboBox_day.Items.Add(day.Day);
            }
            check_details();
        }
        public void check_details()
        {
            if (comboBox_AddRemove.SelectedIndex == 0)
            {
                if (comboBox_Lectures.SelectedIndex > -1)
                {
                    if (textBox_day.Text.Length > 0 && textBox_month.Text.Length > 0 && comboBox_year.SelectedIndex > -1)
                    {
                        if (textBox_StartTime.Text.Length > 0 && textBox_EndTime.Text.Length > 0)
                        {
                            if (textBox_title.Text.Length > 0 && textBox_description.Text.Length > 0)
                            {
                                button_accept.Enabled = true;
                                return;
                            }
                        }
                    }
                }

            }
            else if (comboBox_AddRemove.SelectedIndex == 2)
            {
                if (textBox_day.Text.Length > 0 && textBox_month.Text.Length > 0 && comboBox_year.SelectedIndex > -1)
                {
                    if (textBox_StartTime.Text.Length > 0 && textBox_EndTime.Text.Length > 0)
                    {
                        if (textBox_title.Text.Length > 0 && textBox_description.Text.Length > 0)
                        {
                            button_accept.Enabled = true;
                            return;
                        }
                    }
                }
            }
            else if (comboBox_AddRemove.SelectedIndex == 1)
            {
                if (comboBox_Lectures.SelectedIndex > -1)
                {
                    if (comboBox_day.SelectedIndex > -1 && comboBox_month.SelectedIndex > -1 && comboBox_year.SelectedIndex > -1)
                    {
                        if (textBox_title.Text.Length > 0 && textBox_description.Text.Length > 0)
                        {
                            button_accept.Enabled = true;
                            return;
                        }
                    }
                }
            }

            button_accept.Enabled = false;
        }
    
        private void comboBox_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_day.SelectedIndex!=-1 && comboBox_month.SelectedIndex != -1 && comboBox_day.SelectedIndex != -1)
            {
                label_EndTime00.Visible = true;
                label_startTime00.Visible = true;
                label_endTime.Visible = true;
                label_startTime.Visible = true;
            }
            check_details();
        }

        private void textBox_title_TextChanged(object sender, EventArgs e)
        {
            check_details();
        }

        private void textBox_StartTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_EndTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_day_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_month_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
