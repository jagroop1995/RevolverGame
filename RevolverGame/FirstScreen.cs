using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevolverGame
{
    public partial class FirstScreen : Form
    {
        Timer tmr;

        public FirstScreen()
        {
            InitializeComponent();
        }

        private void FirstScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            GameScreen gs = new GameScreen();
            gs.Show();
            this.Hide();
        }
    }
}
