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
    
    public partial class Form2 : Form
    {
        int life = 5;
        bool gameover = false;
        public Form2()
        {
            InitializeComponent();
        }
        bool right, left;
        Gamer[] g = new Gamer[10];
        private void Form2_Load(object sender, EventArgs e)
        {
                
                timer2.Start();
                ScoreTime.Start();
                for (int i = 0; i < 8; i++)
                {
                    g[i] = new Gamer(i + 80 + i * 80, i + 80, this);
                    
                }
                colT.Start();
               
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timer == 0)
            {
                timer1.Stop();
                ScoreTime.Start();
            }
            
        }
      
        int timeleft;
        int timer;
        private void ScoreTimer_Tick(object sender, EventArgs e)
        {
             timeleft = Convert.ToInt32(label6.Text);
            timeleft = timeleft - 1;
            label6.Text = Convert.ToString(timeleft);
            if (timeleft == 0)
            {
                ScoreTime.Stop();
                //message that the game is over//
                MessageBox.Show("time Is Up!!!");
                Environment.Exit(1);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        int keyer = 0;
        private void Form2_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Left)
                left = true;
            if (e.KeyCode == Keys.P) // freeze
            {
                if (keyer == 0)
                {
                    keyer = 1;
                    pictureBox1.Enabled = false;
                    timer1.Stop();
                    timer2.Stop();
                    ScoreTime.Stop();
                }
                else
                    if (keyer == 1)
                    {
                        keyer = 0;
                        pictureBox1.Enabled = true;
                        timer1.Start();
                        timer2.Start();
                        ScoreTime.Start();
                    }
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e) // שחרור לחיצה 
        {
            if (e.KeyCode == Keys.Right)
                right = false;
            if (e.KeyCode == Keys.Left)
                left = false;
        }

        private void timer2_Tick(object sender, EventArgs e) // תנועת הסל
        {
            if (right == true)
            {
                if (pictureBox1.Right < 855)
                    pictureBox1.Left += 5;
            }
            if (left == true)
            {
                if (pictureBox1.Left > 0)
                    pictureBox1.Left -= 5;  
            }
        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        int score = 0;
        private void pictureBox1_Move(object sender, EventArgs e)
        {
            
        }

        private void colT_Tick(object sender, EventArgs e) // touch  with the pics
        {
            for (int i = 0; i < 8; i++)
            {
                if (g[i].Collision(pictureBox1) == 1)
                {
                    score += 2;
                    label4.Text = "" + score;
                    
                }
                else if (g[i].Collision(pictureBox1) == 2)
                {
                    life--;
                    label2.Text = "" + life;
                    score -= 1;
                    label4.Text = "" + score;

                    if (life == 0)
                    {
                        gameover = true;
                        colT.Stop();
                    }
                }
            }
            if (gameover)
            {
                MessageBox.Show("Game Is Over Amigoo You Lost HHHH");
                Environment.Exit(1);
            }
        }

        private void life_Tick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
