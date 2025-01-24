using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;
            
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size, textBox1.Font.Style^FontStyle.Bold);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton2.Checked == true)
        //    {
        //        textBox1.Font = new Font("Verdana", 12);
        //    }
        //    else return;
        //}

        //private void radioButton3_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton3.Checked == true)
        //    {
        //        textBox1.Font = new Font("Algerian", 12);
        //    }
        //    else return;
        //}

        //private void radioButton4_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton4.Checked == true)
        //    {
        //        textBox1.Font = new Font("Tahoma", 12);
        //    }
        //    else return;
        //}

    }
}
