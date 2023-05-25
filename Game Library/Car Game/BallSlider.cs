using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Car_Game
{
    public partial class slider : Form
    {
        public slider()
        {
            InitializeComponent();
            pausepanel.Visible = false;
                
        }
        int ok = 1; //pauza (da/nu)
        int b = 1; //directia
        int i = 4; //viteza
        private void slider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && slidex.Location.X < this.Size.Width - 175)
            {
                slidex.Location = new Point(slidex.Location.X + i+10, slidex.Location.Y);
            }
            else if (e.KeyCode == Keys.Left && slidex.Location.X > 10)
            {
                slidex.Location = new Point(slidex.Location.X - i-10, slidex.Location.Y);
            }
        }

        private void slider_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (ok == 1)
                {
                    label1.Visible = true;
                    pausepanel.Visible = true;
                    ok = 0;
                    timer1.Stop();
                }
                else
                {
                    label1.Visible = false;
                    pausepanel.Visible = false;
                    ok = 1;
                    timer1.Start();
                }
            }
        }

        private void slider_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(b == 1) ball.Location = new Point(ball.Location.X + i, ball.Location.Y + i);
            else if (b == 2) ball.Location = new Point(ball.Location.X + i, ball.Location.Y - i);
            else if (b == 3) ball.Location = new Point(ball.Location.X - i, ball.Location.Y - i);
            else if (b == 4) ball.Location = new Point(ball.Location.X - i, ball.Location.Y + i);
            //incrementeaza pozitia pe directia buna
            if(ball.Location.Y> this.Size.Height - 30)
            {
                timer1.Stop();
                StreamWriter w = new StreamWriter("Clasament.txt", true);
                w.WriteLine("BallSlider " + label3.Text);
                w.Close();
                MessageBox.Show("Your score is " + label3.Text);
                Close();
            }//daca pierzi
            if (ball.Location.Y > this.Size.Height - 100 && slidex.Location.X + 146 > ball.Location.X + 29 && slidex.Location.X < ball.Location.X + 29 && b == 1)
            {
                b = 2;
                label3.Text = (int.Parse(label3.Text)+1).ToString();
                if (int.Parse(label3.Text) % 10 == 0)
                    i = i + 2;
            }
            else if (ball.Location.Y > this.Size.Height - 100 && slidex.Location.X + 146 > ball.Location.X + 29 && slidex.Location.X < ball.Location.X + 29 && b == 4)
            {
                b = 3;
                label3.Text = (int.Parse(label3.Text) + 1).ToString();
                if (int.Parse(label3.Text) % 10 == 0)
                    i = i + 2;
            }//daca rezpingi
            if (ball.Location.X > this.Size.Width - 60 && b == 2)
                b = 3;
            else if (ball.Location.X > this.Size.Width - 60 && b == 1)
                b = 4;//bara dreapta (daca te lovesti)
            if (ball.Location.Y < 0 && b == 3)
                b = 4;
            else if (ball.Location.Y < 0 && b == 2)
                b = 1;//bara sus
            if (ball.Location.X < 0 && b == 4)
                b = 1;
            else if (ball.Location.X < 0 && b == 3)
                b = 2;//bara stanga
        }

        private void slider_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
