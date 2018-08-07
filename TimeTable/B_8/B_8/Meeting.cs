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
    public partial class Meeting : Form
    {
        DataBase db;
        SqlDataReader reader;
        List<Button> buttons_list;
        public Meeting()
        {
            InitializeComponent();
            db = new DataBase();
            buttons_list = new List<Button>();
        }

        private void Meeting_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            int NO_meeting = 1;
            reader = db.Select("*", "NewSchedule", "LecturerName", GlobalVariables.Full_Name);
            while (reader.Read())
            {

                if (reader["Type"].ToString().Equals("Meeting"))
                {
                    ListViewItem row = new ListViewItem(NO_meeting.ToString());
                    row.SubItems.Add(reader["Classroom"].ToString());
                    row.SubItems.Add(reader["Date"].ToString());
                    row.SubItems.Add(reader["Day"].ToString().Trim());
                    row.SubItems.Add(reader["StartHour"].ToString()+":00");
                    row.SubItems.Add(reader["EndHour"].ToString()+ ":00");
                    row.SubItems.Add(reader["Description"].ToString().Trim());
                    listView1.Items.Add(row);
                    NO_meeting++;
                }
            }
            reader.Close();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
