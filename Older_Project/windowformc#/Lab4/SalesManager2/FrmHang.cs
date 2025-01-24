using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManager2
{
    public partial class FrmHang : Form
    {
        FrmDangNhap frmDangNhap = new FrmDangNhap();

        public static string userName = "";

        Classes.DatabaseProcess db = new Classes.DatabaseProcess();

        OpenFileDialog openFileDialog = new OpenFileDialog();
        public FrmHang()
        {
            InitializeComponent();
        }

        private void FrmHang_Load(object sender, EventArgs e)
        {
            frmDangNhap.ShowDialog();
            lblUsername.Text = "Xin chào " + userName;

            dgvProducts.DataSource = db.DataReader("Select * from tblHang");
            dgvProducts.Columns[0].HeaderText = "Mã hàng";
            dgvProducts.Columns[1].HeaderText = "Tên hàng";
            dgvProducts.Columns[2].HeaderText = "Chất liệu";
            dgvProducts.Columns[3].HeaderText = "Số lượng";
            dgvProducts.Columns[4].HeaderText = "Giá bán";
            dgvProducts.Columns[5].HeaderText = "Giá nhập";
            dgvProducts.Columns[6].HeaderText = "Ảnh";
            dgvProducts.Columns[7].HeaderText = "Ghi chú";
            ShowDetail(false);
        }

        public void ShowDetail(bool b)
        {
            
        }

        public void DeleteDetail()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            cbMaterial.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtImportPrice.Text = "";
            txtExportPrice.Text = "";
            pBShowImage.ImageLocation = null;
            rTBNote.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "THÔNG BÁO!"
                , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmDangNhap.Visible = true;
                frmDangNhap.DeleteDetail();
                this.Visible = false;
            }
        }
        
        // Kiểm tra số nguyên
        private bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra bỏ trống textbox 
            if (txtProductID.Text.Trim().Equals("")
                || txtProductName.Text.Trim().Equals("")
                || cbMaterial.SelectedIndex == -1
                || txtQuantity.Text.Trim().Equals("")
                || txtImportPrice.Text.Trim().Equals("")
                || txtExportPrice.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "LỖI!", MessageBoxButtons.OK);
                return;
            }

            // Kiểm tra số nguyên cho textbox
            if (!IsNumeric(txtQuantity.Text.Trim().ToString())
                || !IsNumeric(txtImportPrice.Text.Trim().ToString())
                || !IsNumeric(txtExportPrice.Text.Trim().ToString()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "LỖI!", MessageBoxButtons.OK);
                return;
            }

            // Insert
            string sql;
            if (txtProductID.Text.Trim() == "")
            {
                errProvider.SetError(txtProductID, "Bạn không để trống mã sản phẩm trường này!");
                return;
            }
            else
            {
                //Kiểm  tra  xem  mã  sản  phẩm  đã  tồn  tại  chưa  đẻ  tránh việc  insert  mới  bị  lỗi  
                sql = "Select * From tblHang Where MaHang ='" + txtProductID.Text + "'";
                DataTable dtSP = db.DataReader(sql);
                if (dtSP.Rows.Count > 0)
                {
                    errProvider.SetError(txtProductID, "Mã sản phẩm trùng trong cơ sở dữ liệu");
                    return;
                }
                errProvider.Clear();
            }

            string dirImage = Path.GetFileName(openFileDialog.FileName);

            sql = "Insert into tblHang values('" + txtProductID.Text.Trim() + "',"
                + "N'" + txtProductName.Text.Trim() + "',"
                + "N'" + cbMaterial.SelectedItem + "',"
                + "'" + txtQuantity.Text.Trim() + "',"
                + "'" + txtImportPrice.Text.Trim() + "',"
                + "'" + txtExportPrice.Text.Trim() + "',"
                + "'" + dirImage + "',"
                + "N'" + rTBNote.Text + "')";

            Console.WriteLine(sql);

            db.DataChange(sql);

            dgvProducts.DataSource = db.DataReader("Select *from tblHang");

            DeleteDetail();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //StreamReader readImage = new StreamReader(openFileDialog.FileName);
                pBShowImage.ImageLocation = openFileDialog.FileName;
                pBShowImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string dirImage = Path.GetFileName(pBShowImage.ImageLocation);

            string sql = "Update tblHang SET ";
            sql += "TenHang = N'" + txtProductName.Text + "',";
            sql += "ChatLieu = '" + cbMaterial.SelectedItem + "',";
            sql += "SoLuong = '" + txtQuantity.Text + "',";
            sql += "DonGiaNhap = N'" + txtImportPrice.Text + "',";
            sql += "DonGiaBan = '" + txtExportPrice.Text + "',";
            sql += "Anh = N'" + dirImage + "',";
            sql += "GhiChu = N'" + rTBNote.Text + "' ";
            sql += "Where MaHang = N'" + txtProductID.Text + "'";

            db.DataChange(sql);
            dgvProducts.DataSource = db.DataReader("select *from tblHang");

            DeleteDetail();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hiển thị nút sửa
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            // Bắt lỗi khi người sử dụng kích linh tinh trên datagrid
            try
            {
                txtProductID.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtProductName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                cbMaterial.SelectedItem = dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQuantity.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtImportPrice.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtExportPrice.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
                pBShowImage.ImageLocation = Application.StartupPath + "\\Images\\"
                    + dgvProducts.CurrentRow.Cells[6].Value.ToString();
                pBShowImage.SizeMode = PictureBoxSizeMode.StretchImage;
                rTBNote.Text = dgvProducts.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "Delete From tblHang Where MaHang =N'" + 
                txtProductID.Text + "'";
            db.DataChange(sql);
            dgvProducts.DataSource = db.DataReader("select *from tblHang");
            DeleteDetail();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
