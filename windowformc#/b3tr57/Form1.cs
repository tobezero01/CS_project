using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace b3tr57
{
    public partial class Form1 : Form
    {
        private int n;
        private int[] a;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập n");
                textBox1.Focus(); //Đặt con trỏ vào txtN
                return;
            }
            n = Convert.ToInt16(textBox1.Text);
            a = new int[n];

            label2.Text = "Dãy số: ";
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(100);

                label2.Text = label2.Text + a[i].ToString() + "   ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            n = 0;
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int S = 0;
            for (int i = 0; i < n; i++)
            {
                S += a[i];
            }
            label3.Text = "Tong cua day so la " + S.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Array.Sort(a);
            label4.Text = "Day khi sap xep la ";
            for (int i = n - 1; i >= 0; i--)
            {
                label4.Text = label4.Text + a[i].ToString() + "  ";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Ok ?","notive", MessageBoxButtons.YesNo)  == DialogResult.Yes) { this.Close(); }        
        }
    }

}
