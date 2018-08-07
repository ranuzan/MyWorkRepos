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
    public partial class Description : Form
    {
        DataBase db;
        Add_Deatils add_details;
        
        public Description(Add_Deatils add_details)
        {
            InitializeComponent();
            db = new DataBase();
            this.add_details = add_details;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            this.Close();
            add_details.button8.Enabled = false;
            add_details.listView8.Enabled = false;
            add_details.listView8.Items.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 10)
            {
                add_details.descript = textBox1.Text;
                textBox1.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Text box must contain at least 10 characters");
                textBox1.Clear();
            }
        }

        private void Description_Load(object sender, EventArgs e)
        {

        }
    }
}
