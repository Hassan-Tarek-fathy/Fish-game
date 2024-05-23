using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication39
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void bubble()
        {
            Random r = new Random();
            int i;
           foreach( Control j in this.Controls)
            {
                if ( j is PictureBox && j.Tag == "bubble")
                {
                    j.Top -= 5;
                    if(j.Top < 0)
                    {
                        i = r.Next(10, 500);
                        j.Location = new Point(i,400);
                    }
                }

            }
        }
        int score =0;
        private void fishmove()
        {
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "fish")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(700, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(700, i);
                        score++;
                        label1.Text = score.ToString();
                        play.Size += new Size(2,2);
                        progressBar1.Value += 5;
                        if (progressBar1.Value > 99)
                        {
                           
                            //ضع هنا خيارات الانتقال الى المرحلة التاليه
                            //في جال لم تضع شيئاً سيحدث خطأ عند وصول البروجرس الى % 100
                        }
                    }

                }

            }
        }

        private void enemymove()
        {
            Random r = new Random();
            int i;
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "enemy")
                {
                    j.Left -= 2;
                    if (j.Left < 0)
                    {
                        i = r.Next(48, 303);
                        j.Location = new Point(700, i);
                    }
                    if (play.Bounds.IntersectsWith(j.Bounds))
                    {
                        if(play.Size == new Size(60, 40))
                        {
                            label2.Visible = true;
                            timer1.Stop();
                            label2.Text = "لقد خسرت انتهت اللعبة";
                            play.Hide();
                        }
                        else { play.Size = new Size(60, 40); j.Left = 700; }

                        //i = r.Next(48, 303);
                        //j.Location = new Point(700, i);
                        //score++;
                        //label1.Text = score.ToString();
                        //play.Size += new Size(2, 2);
                        //progressBar1.Value += 5;
                        //if (progressBar1.Value > 99)
                        {

                        }
                    }

                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if(play.Top > 50) { play.Top -= 10; }
                    break;

                case Keys.Down:
                    if (play.Top < 330) { play.Top += 10; }
                    break;

                case Keys.Right:
                    if (play.Right < 660) { play.Left += 10; }
                    play.Image = Properties.Resources.playr1;
                    break;

                case Keys.Left:
                    if (play.Left > 0) { play.Left -= 10; }
                    play.Image = Properties.Resources.playr2;
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            play.Top += 1;
            bubble();
            fishmove();
            enemymove();
        }
    }
}
