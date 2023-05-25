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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            finish.Visible = false;
        }

        Random r = new Random();
        int x;
        int score=0;
        int ok1 = 0;
        int ok2 = 0;
        int ok3 = 0;
        int gamespeed = 0;
        int ok4 = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            enemy(gamespeed);
            gameover();
        }

        void enemy(int speed)
        {
            x=r.Next(0,500);
            if (enemy1.Top >= 500)
            {
                enemy1.Location = new Point(x, 0);
                ok1 = 1;
            }
            else
                enemy1.Top += speed;
                 if (enemy2.Top >= 500)
                 {
                     enemy2.Location = new Point(x, 0);
                     ok2 = 1;
                 }
                 else
                     enemy2.Top += speed;
                 if (enemy3.Top >= 500)
                 {
                     enemy3.Location = new Point(x, 0);
                     ok3 = 1;
                  }
                 else
                     enemy3.Top += speed;
                 if(ok1==1 && ok2 ==1 && ok3 ==1)
                 {
                     score++;
                     coin.Text = "Score=" + score.ToString();
                     ok1 = 0;
                     ok2 = 0;
                     ok3 = 0;
                 }
        }
        
        void gameover()
        {
            if(car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                finish.Visible = true;
                StreamWriter w = new StreamWriter("Clasament.txt", true);
                w.WriteLine("CarGame " + score.ToString());
                w.Close();
                finish.Text = "        Wasted" + "\r\n" + "Your score is " + score.ToString();
                ok4 = 1;
                
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                finish.Visible = true;
                StreamWriter w = new StreamWriter("Clasament.txt", true);
                w.WriteLine("CarGame " + score.ToString());
                w.Close();
                finish.Text = "        Wasted" + "\r\n" + "Your score is " + score.ToString();
                ok4 = 1;
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                finish.Visible = true;
                StreamWriter w = new StreamWriter("Clasament.txt", true);
                w.WriteLine("CarGame " + score.ToString());
                w.Close();
                finish.Text = "        Wasted" + "\r\n" + "Your score is " + score.ToString();
                ok4 = 1;
                
            }
        }

        void moveline(int speed)
        {
            if (pictureBox1.Top >= 500)
                pictureBox1.Top = 0;
            else
                pictureBox1.Top += speed;
            if (pictureBox2.Top >= 500)
                pictureBox2.Top = 0;
            else
                pictureBox2.Top += speed;
            if (pictureBox3.Top >= 500)
                pictureBox3.Top = 0;
            else
                pictureBox3.Top += speed;
            if (pictureBox4.Top >= 500)
                pictureBox4.Top = 0;
            else
                pictureBox4.Top += speed;
            if (pictureBox5.Top >= 500)
                pictureBox5.Top = 0;
            else
                pictureBox5.Top += speed;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(ok4==0)
            {
                if (e.KeyCode == Keys.Left)
                    if (car.Left > 1)
                        car.Left += -6;
                if (e.KeyCode == Keys.Right)
                    if (car.Right < 510)
                        car.Left += 6;
                if (e.KeyCode == Keys.Up)
                    if (gamespeed < 35)
                        gamespeed++;
                if (e.KeyCode == Keys.Down)
                    if (gamespeed > 0)
                        gamespeed--;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
