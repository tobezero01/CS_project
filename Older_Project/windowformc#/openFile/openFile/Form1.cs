using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace openFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "hãy chọn file";
            openFile.Filter = "All Files|*.*|JPEG Images|*.jdg|Bitmap Images|*.bmp";
            openFile.FilterIndex = 2;
            try
            {
                if (openFile.ShowDialog(this) == DialogResult.OK)
                {
                    Pic.Image = Image.FromFile(openFile.FileName);
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi kiểu dữ liệu file");
            }
        }
    }
}
