using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm2 = new Form3();
            frm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            slider frm3 = new slider();
            frm3.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
