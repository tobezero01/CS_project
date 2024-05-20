using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            Forms.frmChatLieu frmCL = new Forms.frmChatLieu();
            frmCL.ShowDialog();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            Forms.frmNhanVien frmNV = new Forms.frmNhanVien();
            frmNV.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            Forms.frmKhach frmKH = new Forms.frmKhach();
            frmKH.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            Forms.frmHang frmH = new Forms.frmHang();
            frmH.ShowDialog();
        }

        private void mnuHDBan_Click(object sender, EventArgs e)
        {
            Forms.frmHDBan frmHDBan = new Forms.frmHDBan();
            frmHDBan.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            picAnhNen.Image = Image.FromFile("Images\\Button\\AnhNen.gif");
                       
        }

        private void mnuHang_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuNV_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}
