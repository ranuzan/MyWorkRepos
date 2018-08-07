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
    public partial class FormAdmin_ChangePermission : Form
    {
        DataTable allUsers = new DataTable();
        public FormAdmin_ChangePermission()
        {
            InitializeComponent();
            AcceptButton = button_Accept;
            textBox_UserID.MaxLength = 9;
            comboBox_Permission.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_users.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Department.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Semester.DropDownStyle = ComboBoxStyle.DropDownList;
            DataTable users = new DataTable();
            users = SQLFunctions.getUsers();
            allUsers = users;
            for(int i=0;i<users.Rows.Count;i++)
            {
                if(users.Rows[i]["Role"].ToString()=="SecretaryA")
                    comboBox_users.Items.Add(users.Rows[i]["LastName"].ToString() + " " + users.Rows[i]["FirstName"].ToString() + " - Students Secretary");
                else if(users.Rows[i]["Role"].ToString() == "Secretary")
                    comboBox_users.Items.Add(users.Rows[i]["LastName"].ToString() + " " + users.Rows[i]["FirstName"].ToString() + " - Department Secretary");
                else
                    comboBox_users.Items.Add(users.Rows[i]["LastName"].ToString() + " " + users.Rows[i]["FirstName"].ToString() + " - " + users.Rows[i]["Role"].ToString());
            }
        }

        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox_UserID.TextLength > 8)
            {
                comboBox_Permission.Enabled = true;
                comboBox_users.Enabled = false;
            }
            else
            {
                comboBox_users.Enabled = true;
                comboBox_Permission.Enabled = false;
                comboBox_Permission.Enabled = false;
                button_Accept.Enabled = false;
                checkBox_Agree.Visible = false;
                checkBox_Agree.Checked = false;            }
        }

        private void checkBox_Agree_Click(object sender, EventArgs e)
        {
            if (checkBox_Agree.Checked)
            {
                button_Accept.Enabled = true;
            }
            else
            {
                button_Accept.Enabled = false;
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {

            if (textBox_UserID.Enabled == true)
            {
                if (SQLFunctions.checkExistsUsers(Convert.ToInt32(textBox_UserID.Text)) == true)
                {
                    if (SQLFunctions.checkRole(Convert.ToInt32(textBox_UserID.Text)) != comboBox_Permission.Text|| comboBox_Permission.Text=="Student")
                    {
                        if(comboBox_Permission.Text== "Students Secretary")
                            SQLFunctions.updateUserRole(Convert.ToInt32(textBox_UserID.Text), "SecretaryA", comboBox_Department.Text);
                        else if (comboBox_Permission.Text == "Department Secretary")
                            SQLFunctions.updateUserRole(Convert.ToInt32(textBox_UserID.Text), "Secretary", comboBox_Department.Text);
                        else
                            SQLFunctions.updateUserRole(Convert.ToInt32(textBox_UserID.Text), comboBox_Permission.Text,comboBox_Department.Text);
                        if (comboBox_Permission.SelectedIndex == 0)
                        {
                            if (SQLFunctions.checkExistsStudents(Convert.ToInt32(textBox_UserID.Text)) == true)
                            {
                                SQLFunctions.updateStudentYearAndSemester(Convert.ToInt32(Convert.ToInt32(textBox_UserID.Text)), Convert.ToInt32(comboBox_Year.Text), Convert.ToChar(comboBox_Semester.Text));
                            }
                            else
                            {
                                SQLFunctions.addStudent(Convert.ToInt32(Convert.ToInt32(textBox_UserID.Text)), Convert.ToInt32(comboBox_Year.Text), Convert.ToChar(comboBox_Semester.Text));
                            }
                        }
                        else
                        {
                            if (SQLFunctions.checkExistsStudents(Convert.ToInt32(textBox_UserID.Text)) == true)
                            {
                                SQLFunctions.deleteStudent(Convert.ToInt32(Convert.ToInt32(textBox_UserID.Text)));
                            }
                        }
                        MessageBox.Show("User permission was changed to " + comboBox_Permission.Text + ".");
                        this.Hide();
                        FormMenuAdmin adminForm = new FormMenuAdmin();
                        adminForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("This user is already " + comboBox_Permission.Text);
                    }
                }
                else
                {
                    MessageBox.Show("User was not found");
                }
            }
            else
            {
                if (SQLFunctions.checkExistsUsers(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString())) == true)
                {
                    if (SQLFunctions.checkRole(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString())) != comboBox_Permission.Text || comboBox_Permission.Text == "Student") 
                    {
                        if (comboBox_Permission.Text == "Students Secretary")
                            SQLFunctions.updateUserRole(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()), "SecretaryA",comboBox_Department.Text);
                        else if (comboBox_Permission.Text == "Department Secretary")
                            SQLFunctions.updateUserRole(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()), "Secretary",comboBox_Department.Text);
                        else
                            SQLFunctions.updateUserRole(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()), comboBox_Permission.Text,comboBox_Department.Text);
                        if (comboBox_Permission.SelectedIndex == 0)
                        {
                            if (SQLFunctions.checkExistsStudents(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString())) == true)
                            {
                                SQLFunctions.updateStudentYearAndSemester(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()), Convert.ToInt32(comboBox_Year.Text), Convert.ToChar(comboBox_Semester.Text));
                            }
                            else
                            {
                                SQLFunctions.addStudent(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()), Convert.ToInt32(comboBox_Year.Text), Convert.ToChar(comboBox_Semester.Text));
                            }
                        }
                        else
                        {
                            if (SQLFunctions.checkExistsStudents(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString())) == true)
                            {
                                SQLFunctions.deleteStudent(Convert.ToInt32(allUsers.Rows[comboBox_users.SelectedIndex]["ID"].ToString()));
                            }
                        }
                        MessageBox.Show("User permission was changed to " + comboBox_Permission.Text + ".");
                        this.Hide();
                        FormMenuAdmin adminForm = new FormMenuAdmin();
                        adminForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("User was not found");
                }
            }
            
       

        }

        private void comboBox_Permission_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
            if(comboBox_Permission.SelectedIndex==0)
            {
                label_year.Visible = true;
                label_Semester.Visible = true;
                comboBox_Year.Visible = true;
                comboBox_Semester.Visible = true;
                comboBox_Department.Visible = false;
                label_Department.Visible = false;
                checkBox_Agree.Visible = false;
                checkBox_Agree.Checked = false;
            }
     
            else if (comboBox_Permission.SelectedIndex == 2 || comboBox_Permission.SelectedIndex == 3)
            {
                comboBox_Department.Visible = false;
                label_Department.Visible = false;
                checkBox_Agree.Visible = true;
                label_year.Visible = false;
                label_Semester.Visible = false;
                comboBox_Year.Visible = false;
                comboBox_Semester.Visible = false;
                comboBox_Department.Text = "General";
                
            }
            else 
            {
                comboBox_Department.Visible = true;
                label_Department.Visible = true;
                checkBox_Agree.Visible = false;
                checkBox_Agree.Checked = false;
                label_year.Visible = false;
                label_Semester.Visible = false;
                comboBox_Year.Visible = false;
                comboBox_Semester.Visible = false;
            }
        }

        private void textBox_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FormAdminChangePermission_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void comboBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            checkBox_Agree.Visible = true;
        }

        private void FormAdmin_ChangePermission_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_UserID.Enabled = false;
            comboBox_Permission.Enabled = true;
        }

        private void comboBox_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Semester.Enabled = true;
            label_Semester.Enabled = true;
        }

        private void comboBox_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
                comboBox_Department.Visible = true;
                label_Department.Visible = true;
        }
    }
}
