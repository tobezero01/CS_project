using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int m, s;
            m = Convert.ToInt32(textBox1.Text);
            s = Convert.ToInt32(textBox2.Text);
            if(s > 0 && s<=59) { s = s - 1; }
            else
            {
                if(m > 0 && s==0) { s = 59; m = m - 1; }
                if(s==0 && m==0)
                {
                    timer1.Stop();
                    MessageBox.Show("kmksmfmsad");
                }
            }
            textBox1.Text = m.ToString();
            textBox2.Text = s.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()== "" || textBox2.Text.Trim()=="")  { MessageBox.Show("");  }
            else
            {
                timer1.Start();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Are you Ok ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }
    }
}
