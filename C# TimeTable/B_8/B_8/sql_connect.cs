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
    public partial class sql_connect
    {
        public sql_connect()
        {
            InitializeComponent();
        }

        private void sql_connect_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn = new SqlConnection("Data Source=team8db.database.windows.net;Persist Security Info=True;User ID=dbadmin;Password=Aa123456");
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand com = new SqlCommand("");
                MessageBox.Show("Connection Open ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            finally
            {
                cnn.Close();
            }
            ListViewGroup opencourse = new ListViewGroup("Open course");
            listView1.Groups.Add(opencourse);
            ListViewItem hedva = new ListViewItem(opencourse);
            hedva.Text = "Hedva";
            listView1.Items.Add(hedva);

        }
    }
}
