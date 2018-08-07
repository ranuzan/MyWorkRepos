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
    public partial class FormAdminViewErros : Form
    {
        List<List<string>> errors = new List<List<string>>();

        public FormAdminViewErros()
        {
            InitializeComponent();

            DataTable dataTable = SQLFunctions.getErrors();
            if (dataTable != null)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    List<string> error = new List<string>();

                    error.Add(dataTable.Rows[i]["ErrorID"].ToString());
                    error.Add(dataTable.Rows[i]["Department"].ToString() + " department " + dataTable.Rows[i]["Role"].ToString() + " " + dataTable.Rows[i]["FirstName"].ToString() + " " + dataTable.Rows[i]["LastName"].ToString());
                    error.Add(dataTable.Rows[i]["Title"].ToString());
                    error.Add(dataTable.Rows[i]["Description"].ToString());
                    error.Add(dataTable.Rows[i]["Viewed"].ToString());

                    errors.Add(error);

                    if (errors[i][4] == "False")
                    {
                        ListViewItem item = new ListViewItem(errors[i][2]);
                        item.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        listViewTitle.Items.Insert(0, item);
                        continue;
                    }

                    listViewTitle.Items.Add(errors[i][2]);
                }
            }
        }

        private void listViewTitle_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxFrom.Text = errors[listViewTitle.FocusedItem.Index][1];
            textBoxDescription.Text = errors[listViewTitle.FocusedItem.Index][3];
            listViewTitle.FocusedItem.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            errors[listViewTitle.FocusedItem.Index][4] = "True";
        }

        private void FormAdminViewErros_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            List<int> errorIDs = new List<int>();

            for (int i = 0; i < errors.Count; i++)
            {
                if (errors[i][4] == "True")
                    errorIDs.Add(Convert.ToInt32(errors[i][0]));
            }

            SQLFunctions.updateErrorsStatus(errorIDs);

            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void listViewTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button_ClearList_Click(object sender, EventArgs e)
        {
            if (listViewTitle.Items.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete all the errors?", "Clear Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listViewTitle.Clear();
                    SQLFunctions.ClearErrors();
                    textBoxFrom.Clear();
                    textBoxDescription.Clear();
                }
            }
            else
            {
                MessageBox.Show("There were no errors to delete");
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin adminForm = new FormMenuAdmin();
            adminForm.Show();
        }
    }
}
