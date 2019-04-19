using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread tt = new Thread(new ThreadStart(MainForm)); 
            tt.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            tt.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        public void MainForm()
        {
            Application.Run(new Prog());
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
