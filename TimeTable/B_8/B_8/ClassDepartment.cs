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

namespace B_8
{
    public partial class ClassDepartment : Form
    {

        DataBase db = new DataBase();
        SqlDataReader read;
        List<Button> buttons = new List<Button>();
        public bool IsUnitTest = false;

        public ClassDepartment()
        {
            InitializeComponent();
            CenterToScreen();
            IsUnitTest = true;

        }

        private void ClassDepartment_Load(object sender, EventArgs e)
        {
            try
            {
                CenterToScreen();
                int i = 0, j = 0;
                read = db.Select("*", "Classrooms");
                while (read.Read())
                {
                    Button btn = new Button();

                    btn.Dock = DockStyle.Fill;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Text = read["Name"].ToString().Trim();
                    btn.Click += new EventHandler(button_click);
                    buttons.Add(btn);
                    tableLayoutPanel2.Controls.Add(btn, j, i);
                    j++;
                    if (j % 11 == 0)
                        i++;
                }
                read.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Could not connect to sql");

            }
            finally
            {
                if (db.isconnected == true)
                    db.CloseConnection();
            }
        }
        private void button_click(object s,EventArgs e)
        {

            Button btn = (Button)s;
            Quat_date qu = new Quat_date(btn);
            qu.Show();

            //   MessageBox.Show(btn.Text);

        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            main ss = new main();
            ss.Show();
        }
       
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
