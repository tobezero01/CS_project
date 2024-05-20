using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanHang.Forms
{
    public partial class frmHDBan : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        Functions ft = new Functions();
        Function ftt = new Function();
        public frmHDBan()
        {
            InitializeComponent();
        }

        private void cboMaNV_Click(object sender, EventArgs e)
        {
            DataTable dtNV= dtBase.DocBang("Select MaNhanVien,tenNhanVien from tblNhanVien");
            cboMaNV.DataSource = dtNV;
            cboMaNV.DisplayMember = "MaNhanVien";
            cboMaNV.ValueMember = "MaNhanVien";
        }

        private void cboMaNV_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNV = dtBase.DocBang("Select MaNhanVien,TenNhanVien from tblNhanVien"+
                    " where MaNhanVien='"+cboMaNV.SelectedValue.ToString()+"'");
                if (dtNV.Rows.Count > 0)
                    txtTenNV.Text = dtNV.Rows[0]["TenNhanVien"].ToString();
            }
            catch
            {

            }
        }
        private void cboMaKhach_Click(object sender, EventArgs e)
        {
            ftt.FillComBox(cboMaKhach , dtBase.DocBang("Select * from tblKhach"), "MaKhach", "MaKhach");
        }

        private void cboMaKhach_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtKhach = dtBase.DocBang("Select * from tblKhach where MaKhach='" +
                    cboMaKhach.SelectedValue.ToString() + "'");
                if (dtKhach.Rows.Count > 0)
                {
                    txtTenKH.Text = dtKhach.Rows[0]["TenKhach"].ToString();
                    txtDiaChi.Text = dtKhach.Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = dtKhach.Rows[0]["SoDienThoai"].ToString();
                }
            }
            catch
            {

            }
        }
        private void cboMaHang_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtHang = dtBase.DocBang("Select * from tblHang where MaHang='" + 
                    cboMaHang.SelectedValue.ToString() + "'");
                if (dtHang.Rows.Count > 0)
                {
                    txtTenHang.Text = dtHang.Rows[0]["TenHang"].ToString();
                    txtDonGia.Text = dtHang.Rows[0]["DonGiaBan"].ToString();

                }
            }
            catch
            {

            }
        }

        private void cboMaHang_Click(object sender, EventArgs e)
        {
            ftt.FillComBox(cboMaHang, dtBase.DocBang("Select * from tblHang"), "MaHang", "MaHang");
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double DonGia, GiamGia, soluong;
                if (txtGiamGia.Text == "")
                    GiamGia = 0;
                else
                    GiamGia = Convert.ToDouble(txtGiamGia.Text);
                soluong = Convert.ToDouble(txtSoLuong.Text);
                DonGia = Convert.ToDouble(txtDonGia.Text);                
                txtThanhTien.Text = (soluong * DonGia - soluong *DonGia* GiamGia / 100).ToString();

            }
            catch
            {
            }
            
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            ResetValue();
            DataTable dtHD = dtBase.DocBang("Select * from tblHDBan");
            string str = "HD" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            txtMaHD.Text = ft.SinhMaTuDong("tblHDBan",str,"MaHDBan");

            btnThemHD.Enabled = false;
            btnLuu.Enabled = true;
            btnHuyHD.Enabled = false;
            btnInHD.Enabled = false;
        }

        private void frmHDBan_Load(object sender, EventArgs e)
        {
            btnThemHD.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyHD.Enabled = false;
           // btnInHD.Enabled = false;
            ResetValue();
        }
        void ResetValue()
        {
            DateTime dt = new DateTime(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day);
            txtMaHD.Text = "";
            dtpNgayBan.Text =  dt.ToShortDateString();
            cboMaNV.Text = "";
            cboMaKhach.Text = "";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            txtTongTien.Text = "0";
            lblSoTien.Text = "Bằng chữ: ";
            dgvHoaDonHang.DataSource = null;
        }
        void LayThongTin()
        {
            DataTable dtHDBan = dtBase.DocBang("Select * from tblHDBan where MaHDBan='"+txtMaHD.Text+"'");
            try
            {
                dtpNgayBan.Text = Convert.ToDateTime(dtHDBan.Rows[0]["NgayBan"].ToString()).ToShortDateString();
                cboMaNV.Text = dtHDBan.Rows[0]["MaNhanVien"].ToString();
                cboMaKhach.Text = dtHDBan.Rows[0]["MaKhach"].ToString();
                txtTongTien.Text = dtHDBan.Rows[0]["TongTien"].ToString();
                lblSoTien.Text = "Bằng chữ: ";
            }
            catch{
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            double sl, slcon, tong, tongmoi;
            DataTable dtHD = dtBase.DocBang("Select * from tblHDBan where MaHDBan='" + txtMaHD.Text + "'");
            if (dtHD.Rows.Count == 0) //TH hóa đơn chưa có lưu các thông tin chung
            {
                if (dtpNgayBan.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập ngày bán");
                    dtpNgayBan.Focus();
                }
                else
                {
                    if (cboMaNV.Text == "")
                    {
                        MessageBox.Show("Bạn phải điền thông tin về nhân viên bán");
                        cboMaNV.Focus();
                    }
                    else
                    {
                        if (cboMaKhach.Text == "")
                        {
                            MessageBox.Show("Bạn phải điền thông tin về khách hàng");
                            cboMaKhach.Focus();
                        }
                        else
                        {
                            DateTime dtNgayBan = Convert.ToDateTime(dtpNgayBan.Text.Trim());
                            dtBase.CapNhatDuLieu("INSERT INTO tblHDBan(MaHDBan,NgayBan,MaNhanVien,MaKhach,TongTien) values('" +
                                                 txtMaHD.Text + "','" + string.Format("{0:MM/dd/yyyy}", dtNgayBan) + "',N'" +
                                                cboMaNV.SelectedValue.ToString() + "',N'" +
                                                cboMaKhach.SelectedValue.ToString() + "','" +
                                                txtTongTien.Text.Trim() + "')");
                            
                        }
                    }

                }
            }
            //Lưu thông tin các mặt hàng
            if (cboMaHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã hàng");
                cboMaHang.Focus();
            }
            else
            {
                if (txtSoLuong.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số lượng");
                    txtSoLuong.Focus();
                }
                else
                {
                    if (txtGiamGia.Text == "")
                    {
                        MessageBox.Show("Bạn phải nhập giảm giá");
                    }
                    else
                    {
                        DataTable dtHang = dtBase.DocBang("Select * from tblHang where maHang='"+cboMaHang.SelectedValue.ToString()+"'");
                        if (Convert.ToDouble(dtHang.Rows[0]["SoLuong"].ToString()) < Convert.ToDouble(txtSoLuong.Text))
                        {
                            MessageBox.Show("Số lượng không đủ, chỉ còn " + dtHang.Rows[0]["SoLuong"].ToString());
                        }
                        else
                        {
                            dtBase.CapNhatDuLieu("insert into tblChiTietHDBan(MaHDBan,MaHang,SoLuong,GiamGia,ThanhTien) values ('" + txtMaHD.Text + "','" + cboMaHang.SelectedValue.ToString() + "'," + txtSoLuong.Text + ",'" + txtGiamGia.Text + "','" + txtThanhTien.Text + "')");
                            dtHD = dtBase.DocBang("Select * from tblHDBan where MaHDBan='" + txtMaHD.Text + "'");
                            txtTongTien.Text = (Convert.ToDouble(dtHD.Rows[0]["TongTien"].ToString()) + Convert.ToDouble(txtThanhTien.Text)).ToString();
                            slcon=Convert.ToDouble(dtHang.Rows[0]["SoLuong"].ToString()) - Convert.ToDouble(txtSoLuong.Text);
                            dtBase.CapNhatDuLieu("update tblHang set SoLuong="+slcon+" where MaHang ='"+cboMaHang.SelectedValue.ToString()+"'");
                            dtBase.CapNhatDuLieu("update tblHDBan set TongTien='" + txtTongTien.Text + "' where MaHDBan='" + txtMaHD.Text + "'");
                        } 
                    }
                }
            }
            dgvHoaDonHang.DataSource = dtBase.DocBang("Select tblChiTietHDBan.MaHang,TenHang,tblChiTietHDBan.SoLuong,ThanhTien from tblChiTietHDBan inner join tblHang on tblHang.MaHang=tblChiTietHDBan.MaHang where MaHDBan='"+txtMaHD .Text +"'");
            btnInHD.Enabled = true;
        }

        private void cboTimKiem_Click(object sender, EventArgs e)
        {
            cboTimKiem.DataSource = null;
            ftt.FillComBox(cboTimKiem, dtBase.DocBang("Select MaHDBan from tblHDBan"), "MaHDBan", "MaHDBan");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtHD = dtBase.DocBang("select * from tblHDBan where MaHDBan='"+cboTimKiem.SelectedValue.ToString()+"'");
            if(dtHD.Rows.Count>0)
            {

                txtMaHD.Text = dtHD.Rows[0]["MaHDBan"].ToString();
                cboMaNV.Text  = dtHD.Rows[0]["MaNhanVien"].ToString();
                cboMaHang.Text = dtHD.Rows[0]["MaKhach"].ToString();
                txtTongTien.Text = dtHD.Rows[0]["TongTien"].ToString();
                dgvHoaDonHang.DataSource = dtBase.DocBang("Select tblChiTietHDBan.MaHang,TenHang,tblChiTietHDBan.SoLuong,ThanhTien from tblChiTietHDBan inner join tblHang on tblHang.MaHang=tblChiTietHDBan.MaHang where MaHDBan='" + txtMaHD.Text + "'");
            }
            
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1]; //Đưa con trỏ vào ô A1
            //Đưa dữ liệu vào file Excel
            tenTruong.Range["A1:D1"].MergeCells = true;
            tenTruong.Range["A1"].Value = "CỬA HÀNG BÁN ĐỐ LƯU NIỆM BÌNH AN";
            tenTruong.Range["A2"].Value = "Địa chỉ: 37B-TT Đông Anh - Hà Nội";
            tenTruong.Range["A3"].Value = "Điện thoại: 0966047698";
            tenTruong.Range["c5:f5"].MergeCells  =true ;
            tenTruong.Range["C5:F5"].Font.Size = 18;
            tenTruong.Range["C5:F5"].Font.Color  = System.Drawing.Color.Red ;
            tenTruong.Range["C5"].Value = "HÓA ĐƠN BÁN";
            tenTruong.Range["A7"].Value  = "Mã HĐ: " + txtMaHD.Text ;
            tenTruong.Range["A8"].Value = "Khách hàng: " + cboMaKhach.SelectedValue.ToString() + "-" + txtTenKH.Text;
            tenTruong.Range["A9"].Value = "Số ĐT Khách: " + txtDienThoai.Text ;
            tenTruong.Range["A10"].Value = "STT ";
            tenTruong.Range["B10"].Value = "Mã Hàng ";
            tenTruong.Range["C10"].Value = "Tên hàng ";
            tenTruong.Range["D10"].Value = "Số lượng ";
            tenTruong.Range["E10"].Value = "Thành tiền ";
            int hang = 10;

            DataTable tblChiTiet = dtBase.DocBang("Select tblChiTietHDBan.MaHang,TenHang,tblChiTietHDBan.SoLuong,ThanhTien from tblChiTietHDBan inner join tblHang on tblHang.MaHang=tblChiTietHDBan.MaHang where MaHDBan='" + txtMaHD.Text + "'");
            for (int i = 0; i < tblChiTiet.Rows.Count;i++ )
            {
                hang ++;                
                tenTruong.Range["A" + hang.ToString()].Value = (i+1).ToString();
                tenTruong.Range["B" + hang.ToString()].Value = tblChiTiet.Rows[i]["MaHang"];
                tenTruong.Range["C" + hang.ToString()].Value = tblChiTiet.Rows[i]["TenHang"];
                tenTruong.Range["D" + hang.ToString()].Value = tblChiTiet.Rows[i]["SoLuong"];
                tenTruong.Range["E" + hang.ToString()].Value = tblChiTiet.Rows[i]["ThanhTien"];

            }
            tenTruong.Range["D" + (hang + 1).ToString()].Value = "Tổng tiền: "+ txtTongTien.Text ;
            tenTruong.Range["C" + (hang+2).ToString()].Value = "Nhân viên bán: " + txtTenNV.Text ;

                exSheet.Name = "HoaDonBan";
            exBook.Activate();
            if(file.ShowDialog()==DialogResult.OK)
                exBook.SaveAs(file.FileName.ToString());
            exApp.Quit();                        
        }

        private void btnHang_Click(object sender, EventArgs e)
        {
            frmHang frmHang = new frmHang();
            frmHang.ShowDialog();
        }
    }
}
