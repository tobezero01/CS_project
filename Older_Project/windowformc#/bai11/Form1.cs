using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string book;
            book = listBox1.SelectedItem as string;
            for(i = 0; i < listBox2.Items.Count ; i++) {
                if (listBox1.Items[i].ToString() == book) {
                    MessageBox.Show("Ban muon mua " + book  );
                    break;
                }
            }
            if (i == listBox2.Items.Count ) {
                listBox2.Items.Add( book );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            try
            {
                if (MessageBox.Show("ban co muon huy ko", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox2.Items.RemoveAt(index);
                }
                
            }  catch { 

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String result = "";

        }
    }
}
