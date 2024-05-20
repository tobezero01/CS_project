using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TH3_B2
{
    public partial class Form2 : Form
    {
        Form1 f1= new Form1 ();

        public Form2()
        {
        }

        public Form2(BaiTapDienTu baitap)
        {
            InitializeComponent();
            f1.bt = baitap;
            richTextBox1.Text = f1.bt.Debai;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diem = 0;
            if (textBox1.Text.Equals(f1.bt.Dapantungcau[0]))
            {
                textBox1.BackColor = Color.Green;
                diem++;
            }
            if (textBox2.Text.Equals(f1.bt.Dapantungcau[1]))
            {
                textBox2.BackColor = Color.Green;
                diem++;
            }
            if (textBox3.Text.Equals(f1.bt.Dapantungcau[2]))
            {
                textBox3.BackColor = Color.Green;
                diem++;
            }
            if (textBox4.Text.Equals(f1.bt.Dapantungcau[3]))
            {
                textBox4.BackColor = Color.Green;
                diem++;            
            }
            if (textBox5.Text.Equals(f1.bt.Dapantungcau[4]))
            {
                textBox5.BackColor = Color.Green;
                diem++;
            }
            if (textBox6.Text.Equals(f1.bt.Dapantungcau[5]))
            {
                textBox6.BackColor = Color.Green;
                diem++;
            }
            if (textBox7.Text.Equals(f1.bt.Dapantungcau[6]))
            {
                textBox7.BackColor = Color.Green;
                diem++;
            }
            if (textBox8.Text.Equals(f1.bt.Dapantungcau[7]))
            {
                textBox8.BackColor = Color.Green;
                diem++;
            }
            if (textBox9.Text.Equals(f1.bt.Dapantungcau[8]))
            {
                textBox9.BackColor = Color.Green;
                diem++;
            }
            if (textBox10.Text.Equals(f1.bt.Dapantungcau[9]))
            {
                textBox10.BackColor = Color.Green;
                diem++;
            }

            MessageBox.Show("Diem cua ban la : " + diem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = (f1.bt.Dapan);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox1.BackColor = default;
            textBox2.Text = ""; textBox2.BackColor = default;
            textBox3.Text = ""; textBox3.BackColor = default;
            textBox4.Text = ""; textBox4.BackColor = default;
            textBox5.Text = ""; textBox5.BackColor = default;
            textBox6.Text = ""; textBox6.BackColor = default;
            textBox7.Text = ""; textBox7.BackColor = default;
            textBox8.Text = ""; textBox8.BackColor = default;
            textBox9.Text = ""; textBox9.BackColor = default;
            textBox10.Text = ""; textBox10.BackColor = default;
            richTextBox1.Text = f1.bt.Debai;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }
    }
}
