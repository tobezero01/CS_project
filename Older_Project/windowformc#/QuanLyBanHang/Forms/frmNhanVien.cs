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
    public partial class frmNhanVien : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        void ReSetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            mtxtNgaySinh.Text = "";
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dtNhanVien = dtBase.DocBang("select * from tblNhanVien");
            dgvNhanVien.DataSource = dtNhanVien;
            //Định dạng dataGrid
            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Tên NV";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Dịa chỉ";
            dgvNhanVien.Columns[5].HeaderText = "Diện thoại";
            dgvNhanVien.Columns[0].Width = 120;
            dgvNhanVien.Columns[1].Width = 180;
            dgvNhanVien.Columns[2].Width = 120;
            dgvNhanVien.Columns[3].Width = 120;
            dgvNhanVien.Columns[4].Width = 250;
            dgvNhanVien.Columns[5].Width = 120;

            dgvNhanVien.Columns[0].DataPropertyName = "MaNhanVien";
            dgvNhanVien.Columns[1].DataPropertyName = "TenNhanVien";
            dgvNhanVien.Columns[2].DataPropertyName = "GioiTinh";
            dgvNhanVien.Columns[3].DataPropertyName = "NgaySinh";
            dgvNhanVien.Columns[4].DataPropertyName = "DiaChi";
            dgvNhanVien.Columns[5].DataPropertyName = "DienThoai";

            dgvNhanVien.BackgroundColor = Color.LightBlue;
            dtNhanVien.Dispose();//Giải phóng bộ nhớ cho DataTable

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThemMoi.Enabled = true;
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ReSetValues();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            mtxtNgaySinh.Text =dgvNhanVien .CurrentRow .Cells [3].Value.ToString () ;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Nhập mã đã a");
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Nhập mã đã a");
                txtTenNV.Focus();
                return;
            }
            if (rdoNam.Checked==false && rdoNu.Checked==false)
            {
                MessageBox.Show("Giới tính a ơi");
                return;
            }

            DataTable dt = dtBase.DocBang("Select * from tblNhanVien Where MaNhanVien='"+txtMaNV.Text+"'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                txtMaNV.Focus();
                return;
            }
            string gioitinh = "";
            if (rdoNam.Checked == true)
            {
                gioitinh = rdoNam.Text;
            }
            else
            {
                gioitinh = rdoNu.Text;
            }
            DateTime dateNgaySinh = Convert.ToDateTime(mtxtNgaySinh.Text);


            string strInsert = "Insert into tblNhanVien(MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh) values ('" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + gioitinh + "',N'" + txtDiaChi.Text + "','" + txtDienThoai.Text + "','" + String.Format("{0:MM/dd/yyyy}", dateNgaySinh) + "')";
            dtBase.CapNhatDuLieu(strInsert);
            
            dgvNhanVien.DataSource = dtBase.DocBang("Select * From tblNhanVien");
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt16(e.KeyChar) < 48 || Convert.ToInt16(e.KeyChar) > 57) && Convert.ToInt16(e.KeyChar) != 8)
            {
                MessageBox.Show("Nhập số thôi a ơi");
                e.Handled = true;
                txtDienThoai.Focus();
            }
        }      
    }
}
