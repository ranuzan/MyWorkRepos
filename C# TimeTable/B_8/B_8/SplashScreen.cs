using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_8
{
    public partial class SplashScreen : Form
    {
        main m = new main();

        public SplashScreen()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
         
            timer1.Start();
            m.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Stop();
                
                m.Show();
                Hide();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
