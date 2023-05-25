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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                StreamWriter w = new StreamWriter("Utilizatori.txt", true);
                w.WriteLine(textBox1.Text + "^" + textBox2.Text);
                w.Close();
                StreamWriter q = new StreamWriter("Clasament.txt", true);
                q.WriteLine(textBox1.Text + "^" + textBox2.Text + ":");
                q.Close();
                Close();
            }
            else
                MessageBox.Show("Eror");
        }
    }
}
