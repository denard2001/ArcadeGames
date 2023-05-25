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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        int i = 5;
        Random r = new Random();
        int x1; int x2; int x3;
        int y1; int y2; int y3;
        int e1; int e2; int e3; // se misca sus/jos inamicii

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && ship.Location.X < this.Size.Width - 100)
            {
                ship.Location = new Point(ship.Location.X + i + 5, ship.Location.Y);
            }
            else if (e.KeyCode == Keys.Left && ship.Location.X > 10)
            {
                ship.Location = new Point(ship.Location.X - i - 5, ship.Location.Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == false)
            {
                pictureBox3.Location = new Point(ship.Location.X + 40, ship.Location.Y - 31);
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 10);
                if (pictureBox3.Location.Y <= -80)
                    pictureBox3.Visible = false;
            }

            if(pictureBox3.Location.X >= enemy1.Location.X && pictureBox3.Location.X <= enemy1.Location.X + 100)
                if(pictureBox3.Location.Y <= enemy1.Location.Y + 50)
                {
                    pictureBox3.Visible = false;
                    x1 = r.Next(0, 850);
                    y1 = r.Next(0, 200);
                    enemy1.Location = new Point(x1, y1);
                    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                }
            if (pictureBox3.Location.X >= enemy2.Location.X && pictureBox3.Location.X <= enemy2.Location.X + 100)
                if (pictureBox3.Location.Y <= enemy2.Location.Y + 50)
                {
                    pictureBox3.Visible = false;
                    x2 = r.Next(0, 850);
                    y2 = r.Next(0, 200);
                    enemy2.Location = new Point(x2, y2);
                    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                }
            if (pictureBox3.Location.X >= enemy3.Location.X && pictureBox3.Location.X <= enemy3.Location.X + 100)
                if (pictureBox3.Location.Y <= enemy3.Location.Y + 50)
                {
                    pictureBox3.Visible = false;
                    x3 = r.Next(0, 850);
                    y3 = r.Next(0, 200);
                    enemy3.Location = new Point(x3, y3);
                    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                }

        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == false)
            {
                pictureBox1.Location = new Point(enemy2.Location.X + 50, enemy2.Location.Y + 51);
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 10);
                if (pictureBox1.Location.Y >= 700)
                    pictureBox1.Visible = false;
            }
            if (e2 == 1)
            {
                enemy2.Location = new Point(enemy2.Location.X, enemy2.Location.Y + 2);
                if (enemy2.Location.Y > 200)
                    e2 = 0;
            }
            else
            {
                enemy2.Location = new Point(enemy2.Location.X, enemy2.Location.Y - 2);
                if (enemy2.Location.Y < 10)
                    e2 = 1;
            }

            if (pictureBox2.Visible == false)
            {
                pictureBox2.Location = new Point(enemy3.Location.X + 50, enemy3.Location.Y + 51);
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 10);
                if (pictureBox2.Location.Y >= 700)
                    pictureBox2.Visible = false;
            }
            if (e3 == 1)
            {
                enemy3.Location = new Point(enemy3.Location.X, enemy3.Location.Y + 2);
                if (enemy3.Location.Y > 200)
                    e3 = 0;
            }
            else
            {
                enemy3.Location = new Point(enemy3.Location.X, enemy3.Location.Y - 2);
                if (enemy3.Location.Y < 10)
                    e3 = 1;
            }

            if (pictureBox4.Visible == false)
            {
                pictureBox4.Location = new Point(enemy1.Location.X + 50, enemy1.Location.Y + 51);
                pictureBox4.Visible = true;
            }
            else
            {
                pictureBox4.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y + 10);
                if (pictureBox4.Location.Y >= 700)
                    pictureBox4.Visible = false;
            }
            if (e1 == 1)
            {
                enemy1.Location = new Point(enemy1.Location.X, enemy1.Location.Y + 2);
                if (enemy1.Location.Y > 200)
                    e1 = 0;
            }
            else
            {
                enemy1.Location = new Point(enemy1.Location.X, enemy1.Location.Y - 2);
                if (enemy1.Location.Y < 10)
                    e1 = 1;
            }

            //momentul cand mori
            if (pictureBox1.Location.Y + 30 >= ship.Location.Y && pictureBox1.Location.Y + 30 <= ship.Location.Y + 60)
                if (pictureBox1.Location.X >= ship.Location.X && pictureBox1.Location.X <= ship.Location.X + 50)
                {
                    timer1.Stop();
                    timer2.Stop();
                    StreamWriter w = new StreamWriter("Clasament.txt", true);
                    w.WriteLine("SpaceWar " + label2.Text);
                    w.Close();
                    MessageBox.Show("Your score is " + label2.Text);
                    Close();
                }
            if (pictureBox2.Location.Y + 30 >= ship.Location.Y && pictureBox2.Location.Y + 30 <= ship.Location.Y + 60)
                if (pictureBox2.Location.X >= ship.Location.X && pictureBox2.Location.X <= ship.Location.X + 50)
                {
                    timer1.Stop();
                    timer2.Stop();
                    StreamWriter w = new StreamWriter("Clasament.txt", true);
                    w.WriteLine("SpaceWar " + label2.Text);
                    w.Close();
                    MessageBox.Show("Your score is " + label2.Text);
                    Close();
                }
            if (pictureBox4.Location.Y + 30 >= ship.Location.Y && pictureBox4.Location.Y + 30 <= ship.Location.Y + 60)
                if (pictureBox4.Location.X >= ship.Location.X && pictureBox4.Location.X <= ship.Location.X + 50)
                {
                    timer1.Stop();
                    timer2.Stop();
                    StreamWriter w = new StreamWriter("Clasament.txt", true);
                    w.WriteLine("SpaceWar " + label2.Text);
                    w.Close();
                    MessageBox.Show("Your score is " + label2.Text);
                    Close();
                }
        }
    }
}
