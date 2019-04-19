using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Prog : Form
    {
        public Prog()
        {
            InitializeComponent();
        }

        //start position = center screen
        //show in task bar = false 
        // prograss bar + timer = intevral = 32 

        // new thread in the mainform


        private void ProgTimer_Tick(object sender, EventArgs e) // timer for the prograss bar
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100) ProgTimer.Stop();
        }
    }
}
