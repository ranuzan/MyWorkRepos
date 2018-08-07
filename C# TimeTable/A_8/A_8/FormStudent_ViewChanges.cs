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
    public partial class FormStudent_ViewChanges : Form
    {
        List<List<string>> changes = new List<List<string>>();
        Student userStudent = new Student();
        public FormStudent_ViewChanges(int id)
        {
            InitializeComponent();
            int index = 0;
            userStudent = new Student(id);
            DataTable datatable = SQLFunctions.getTimeTableChanges();
            if (datatable != null && userStudent.getRegisteredLessonsIDs() != null)
            {
                for (int i = 0; i < userStudent.getRegisteredLessonsIDs().Count; i++)
                {
                    for (int j = 0; j < datatable.Rows.Count; j++)
                    {
                        if (userStudent.getRegisteredLessonsIDs()[i] == Convert.ToInt32(datatable.Rows[j]["LectureID"]))
                        {
                            List<string> change = new List<string>();
                            change.Add(datatable.Rows[j]["Title"].ToString());
                            change.Add(datatable.Rows[j]["Description"].ToString());
                            change.Add(datatable.Rows[j]["Starts"].ToString());
                            change.Add(datatable.Rows[j]["Ends"].ToString());
                            change.Add(datatable.Rows[j]["day"].ToString());
                            change.Add(datatable.Rows[j]["month"].ToString());
                            change.Add(datatable.Rows[j]["year"].ToString());
                            changes.Add(change);
                            listViewTitle.Items.Add(changes[index++][0]);
                        }                    
                    }

                }
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    if (Convert.ToInt32(datatable.Rows[i]["LectureID"]) == 0)
                    {
                        List<string> change = new List<string>();
                        change.Add(datatable.Rows[i]["Title"].ToString());
                        change.Add(datatable.Rows[i]["Description"].ToString());
                        change.Add(datatable.Rows[i]["Starts"].ToString());
                        change.Add(datatable.Rows[i]["Ends"].ToString());
                        change.Add(datatable.Rows[i]["day"].ToString());
                        change.Add(datatable.Rows[i]["month"].ToString());
                        change.Add(datatable.Rows[i]["year"].ToString());
                        changes.Add(change);
                        listViewTitle.Items.Add(changes[index++][0]);
                    }
                }
            }
        }

        private void FormStudent_ViewChanges_Load(object sender, EventArgs e)
        {

        }

        private void listViewTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDescription.Text = changes[listViewTitle.FocusedItem.Index][4] + "/" + changes[listViewTitle.FocusedItem.Index][5] + "/" + changes[listViewTitle.FocusedItem.Index][6]+System.Environment.NewLine + changes[listViewTitle.FocusedItem.Index][2] + ":00-" + changes[listViewTitle.FocusedItem.Index][3] + ":00"; ;
            textBoxDescription.Text +=System.Environment.NewLine+ changes[listViewTitle.FocusedItem.Index][1];
           
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
