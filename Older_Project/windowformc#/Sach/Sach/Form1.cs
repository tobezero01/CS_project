using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SachMoi book;
            string mS, tS, TG, qrCode;
            int SL;

            mS=txtMaS.Text;
            tS = txtTenS.Text;
            SL = int.Parse(txtSoLuong.Text);
            TG = txtTacGia.Text;
            qrCode = txtQrCode.Text;
            book = new SachMoi(mS, tS, TG, SL, qrCode);

            dgvSach.Rows.Add();
            DataGridViewRow dr = dgvSach.Rows[dgvSach.Rows.Count - 2];
            dr.Cells[0].Value = mS;
            dr.Cells[1].Value = tS;
            dr.Cells[2].Value = TG;
            dr.Cells[3].Value = SL;
            dr.Cells[4].Value = qrCode;


        }
    }
}
