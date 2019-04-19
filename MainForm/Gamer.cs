using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    class Gamer
    {
        PictureBox b = new PictureBox();
        Point loc; // start location
        Thread t; //parallel movement 
        Form f;//where money fall
        static int size = 50;
        Random r = new Random();
        delegate void setTopCallBack(int top);//for context switch
        bool isMoney;
        // this class for money ..
        public Gamer(int loc1, int loc2, Form f)
        {
                //se parameters
                loc = new Point(loc1, loc2);
                this.f = f;
                
                //set image
                b.Image = global::MainForm.Properties.Resources.m;
                b.SizeMode = PictureBoxSizeMode.StretchImage;
                isMoney = true;
                b.SetBounds(loc1, loc2, 40, 40);//set image location
                f.Controls.Add(b);//add ball to form
                //set thread and start
                t = new Thread(new ThreadStart(fall));
                t.Start();
        }
        // this class for bombs ...
        public Gamer(int loc1, int loc2, Form f,int x)
        {
            //se parameters
            loc = new Point(loc1, loc2);
            this.f = f;
            //set image
            b.Image = global::MainForm.Properties.Resources.boom;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            isMoney = false;
            b.SetBounds(loc1, loc2, 40, 40);//set image location
            f.Controls.Add(b);//add ball to form
            //set thread and start
            t = new Thread(new ThreadStart(fall));
            t.Start();
        }
        public int Collision(PictureBox b) // if the basket touch the images 
        {

            if (b.Bounds.IntersectsWith(this.b.Bounds))
            {
                if (isMoney)
                    return 1; // if touch the money
                else
                {
                    return 2; // if touch the bomb
                    
                }
            }
            return 0; // if touch nothing
        }

        public void fall()
        {
            while (true)
            {
                if (b.Top + size >= f.Height)
                    setTop(0);
                setTop(r.Next(25, 30)); //new randomally location 
                Thread.Sleep(100);
            }
        }

        public void setTop(int top)
        { //התבקש לעשות פעולה על אובייקט שנמצא בתהליכון אחר
            if (f.InvokeRequired)
            {
                //צור מצביע לפונקציה
                setTopCallBack d = new setTopCallBack(setTop);
                //בצע מיתוג עם הפונקיצה והערך שיש לשנות
                f.Invoke(d, new object[] { top });

            }
            else
            {
                if (top == 0)
                {
                    int i = r.Next(0,2); // הצגת באופן רנדומלי כל פעם 
                    if (i == 0)
                    {
                        b.Image = global::MainForm.Properties.Resources.m;
                        isMoney = true;
                    }
                    else
                    {
                        b.Image = global::MainForm.Properties.Resources.boom;
                        isMoney = false;
                    }
                    b.Top = 0;
                }
                else
                    b.Top += top;
            }
        }
    }
}
