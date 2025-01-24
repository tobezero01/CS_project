using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmKhach : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public frmKhach()
        {
            InitializeComponent();
        }

        private void frmKhach_Load(object sender, EventArgs e)
        {
            DataTable dtKhachHang = dtBase.DocBang("select * from tblKhach");
            dgvKhach.DataSource = dtKhachHang;
            //Định dạng dataGrid
            dgvKhach.Columns[0].HeaderText = "Mã Khách";
            dgvKhach.Columns[1].HeaderText = "Tên khách";
            dgvKhach.Columns[2].HeaderText = "Địa chỉ";
            dgvKhach.Columns[3].HeaderText = "Diện thoại";
            dgvKhach.Columns[0].Width = 120;
            dgvKhach.Columns[1].Width = 180;
            dgvKhach.Columns[2].Width = 250;
            dgvKhach.Columns[3].Width = 120;

            dgvKhach.Columns[0].DataPropertyName = "MaKhach";
            dgvKhach.Columns[1].DataPropertyName = "TenKhach";
            dgvKhach.Columns[2].DataPropertyName = "DiaChi";
            dgvKhach.Columns[3].DataPropertyName = "DienThoai";

            dgvKhach.BackgroundColor = Color.LightBlue;
            dtKhachHang.Dispose();//Giải phóng bộ nhớ cho DataTable

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThemMoi.Enabled = true;
        }

        private void dgvKhach_Click(object sender, EventArgs e)
        {
            txtMaKhach.Text = dgvKhach.CurrentRow.Cells[0].Value.ToString();
            txtTenKhach.Text = dgvKhach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhach.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKhach.CurrentRow.Cells[3].Value.ToString();

            txtMaKhach.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = true;
            btnThemMoi.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
        }
    }
}
