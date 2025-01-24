using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManager
{
    public partial class Form1 : Form
    {
        //Khai báo và khởi tạo biến toàn cục trong class frmMatHang sử dụng class DataBaseProcess
        Classes.DataBaseProcess dtbase = new Classes.DataBaseProcess();

        //Phương thức ẩn hiện các control trong groupBox Chi tiết
        private void ShowDetail(bool hien)
        {
            txtProductID.Enabled = hien;
            txtProductName.Enabled = hien;
            dtpProduceDate.Enabled = hien;
            dtpExpirationDate.Enabled = hien;
            txtProductUnit.Enabled = hien;
            txtProductPrice.Enabled = hien;
            txtProductNote.Enabled = hien;
            //Ẩn hiện 2 nút Lưu và Hủy
            btnSave.Enabled = hien;
            btnCancel.Enabled = hien;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load dữ liệu lên DataGridView
            dgvProducts.DataSource = dtbase.DataReader("Select * from tblMatHang");
            //Ẩn nút Sửa,xóa      
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            //Ẩn groupBox chi tiết
            ShowDetail(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Cập nhật trên nhãn tiêu đề
            lblTitle.Text = "TÌM KIẾM MẶT HÀNG";
            //Cấm nút Sửa và Xóa
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            //Viet cau lenh SQL cho tim kiem 
            string sql = "SELECT * FROM tblMatHang where MaSP is not null ";
            //Tim theo MaSP khac rong
            if (txtSearchProductID.Text.Trim() != "")
            {
                sql += " and MaSP like '%" + txtSearchProductID.Text + "%'";
            }
            //kiem tra TenSP 
            if (txtSearchProductName.Text.Trim() != "")
            {
                sql += " AND TenSP like N'%" + txtSearchProductName.Text + "%'";
            }
            //Load dữ liệu tìm được lên dataGridView
            dgvProducts.DataSource = dtbase.DataReader(sql);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị nút sửa
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;

            // Bắt lỗi khi người sử dụng kích linh tinh trên datagrid
            try
            {
                txtProductID.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtProductName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                dtpProduceDate.Value = (DateTime)dgvProducts.CurrentRow.Cells[2].Value;
                dtpExpirationDate.Value = (DateTime)dgvProducts.CurrentRow.Cells[3].Value;
                txtProductUnit.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtProductPrice.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtProductNote.Text = dgvProducts.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void DeleteDetail()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            dtpProduceDate.Value = DateTime.Today;
            dtpExpirationDate.Value = DateTime.Today;
            txtProductUnit.Text = "";
            txtProductPrice.Text = "";
            txtProductNote.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "THÊM MẶT HÀNG";
            // Xóa trang GroupBox chi tiết sản phẩm
            DeleteDetail();
            // Cấm nút xóa sửa
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            // Hiện GroupBox chi tiết
            ShowDetail(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Cập nhật tiêu đề
            lblTitle.Text = "CẬP NHẬT MẶ HÀNG";
            //Ẩn hai nút Thêm và Xóa
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            //Hiện gropbox chi tiết
            ShowDetail(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Bật Message Box cảnh báo người sử dụng
            if (MessageBox.Show("Bạn  có  chắc  chắn  xóa  mã  mặt  hàng  " + txtProductID.Text
                + " không ? Nếu  có  ấn  nút  Lưu, không  thì  ấn  nút  Hủy"
                , "Xóa  sản  phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblTitle.Text = "XÓA MẶT HÀNG";
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                //Hiện gropbox chi tiết
                ShowDetail(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";

            //Chúng ta sử dụng control ErrorProvider để hiển thị lỗi
            //Kiểm tra tên sản phầm có bị để trống không
            if (txtProductName.Text.Trim() == "")
            {
                errDetail.SetError(txtProductName, "Bạn không để trống tên sản phẩm!");
                return;
            }
            else
            {
                errDetail.Clear();
            }

            //Kiểm  tra  ngày  sản  xuất,  lỗi  nếu  người  sử  dụng  nhập  vào  ngày  sản  xuất  lớn  hơn ngày hiện tại
            if (dtpProduceDate.Value > DateTime.Now)
            {
                errDetail.SetError(dtpProduceDate, "Ngày sản xuất không hợp lệ!");
                return;
            }
            else
            {
                errDetail.Clear();
            }

            //Kiểm tra ngày hết hạn xem có lớn hơn ngày sản xuất không
            if (dtpExpirationDate.Value < dtpProduceDate.Value)
            {
                errDetail.SetError(dtpExpirationDate, "Ngay  hết  hạn  nhỏ  hơn  ngày  sản  xuất!");
                return;
            }
            else
            {
                errDetail.Clear();
            }

            //Kiểm  tra   đơn vị  xem có  để trống  không  
            if (txtProductUnit.Text.Trim() == "")
            {
                errDetail.SetError(txtProductUnit, "Bạn  không  để  trống  đơn  vi!");
                return;
            }
            else
            {
                errDetail.Clear();
            }

            //Kiểm  tra  đơn  giá  
            if (txtProductPrice.Text.Trim() == "")
            {
                errDetail.SetError(txtProductPrice, "Bạn  không  để  trống  đơn  giá!");
                return;
            }
            else
            {
                errDetail.Clear();
            }

            //Nếu  nút Thêm  enable  thì  thực  hiện thêm  mới  
            //Dùng  ký  tự  N'  trước mỗi giá  trị kiểu  text để  insert giá  trị có  dấu tiếng  việt vào  CSDL được  đúng 
            if (btnAdd.Enabled == true)
            {
                //Kiểm  tra  xem  ô  nhập  MaSP  có  bị  trống  không  if
                if (txtProductID.Text.Trim() == "")
                {
                    errDetail.SetError(txtProductID, "Bạn không để trống mã sản phẩm trường này!");
                    return;
                }
                else
                {   
                    //Kiểm  tra  xem  mã  sản  phẩm  đã  tồn  tại  chưa  đẻ  tránh việc  insert  mới  bị  lỗi  
                    sql = "Select * From tblMatHang Where MaSP ='" + txtProductID.Text + "'";
                    DataTable dtSP = dtbase.DataReader(sql);
                    if (dtSP.Rows.Count > 0)
                    {
                        errDetail.SetError(txtProductID, "Mã sản phẩm trùng trong cơ sở dữ liệu");
                        return;
                    }
                    errDetail.Clear();
                }
                //Insert vao CSDL
                sql = "INSERT  INTO  tblMatHang(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES(";
                sql += "N'" + txtProductID.Text + "',N'" + txtProductName.Text + "','" + dtpProduceDate.Value.Date + "','" +
                    dtpExpirationDate.Value.Date + "',N'" + txtProductUnit.Text + "',N'" + txtProductPrice.Text + "',N'" + txtProductNote.Text + "')";
                //sql = "INSERT  INTO  tblMatHang(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES\r\n('3','Lavie','2023-10-01','2023-10-31','10',10000,'Thêm Lavie')";
            }
            //dtbase.DataChange(sql);
            Console.WriteLine(sql);

            //Nếu nút Sửa enable thì thực hiện cập nhật dữ liệu
            if (btnUpdate.Enabled == true)
            {
                sql = "Update tblMatHang SET ";
                sql += "TenSP = N'" + txtProductName.Text + "',";
                sql += "NgaySX = '" + dtpProduceDate.Value.Date + "',";
                sql += "NgayHH = '" + dtpExpirationDate.Value.Date + "',";
                sql += "DonVi = N'" + txtProductUnit.Text + "',";
                sql += "DonGia = '" + txtProductPrice.Text + "',";
                sql += "GhiChu = N'" + txtProductNote.Text + "' ";
                sql += "Where MaSP = N'" + txtProductID.Text + "'";
            }

            //Nếu nút Xóa enable thì thực hiện xóa dữ liệu
            if (btnDelete.Enabled == true)
            {
                sql = "Delete From tblMatHang Where MaSP =N'" + txtProductID.Text + "'";
            }
            Console.WriteLine(sql);
            dtbase.DataChange(sql);

            //Cap nhat lai DataGrid
            sql = "Select * from tblMatHang";
            dgvProducts.DataSource = dtbase.DataReader(sql);

            //Ẩn hiện các nút phù hợp chức năng
            ShowDetail(false);
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Thiết lập lại các nút như ban đầu
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            //xoa trang chi tiết
            DeleteDetail();
            //Cam nhap vào groupBox chi tiết
            ShowDetail(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
