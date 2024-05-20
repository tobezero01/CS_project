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
    public partial class frmHang : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        Function ft = new Function();
        string strAnh = "";
        bool themmoi = false;
        public frmHang()
        {
            InitializeComponent();
                      
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            dlgAnh.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif) |*.gif|All files(*.*)|*.*";
            dlgAnh.InitialDirectory = "E:\\Chong\\WebBanHoa\\Images\\AnhHoa";
            dlgAnh.FilterIndex = 3; // Quy định lọc mặc định là bộ lọc thứ 1
            dlgAnh.Title = "Chọn ảnh để hiển thị";
            if (dlgAnh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgAnh.FileName);
                string[] str=dlgAnh.FileName.Split('\\');
                strAnh=str[str.Length -1].ToString();

            }
            //Lấy tên, đường dẫn ảnh khi người dùng chọn trong hộp hội thoại OpenDialog. 
            //Sau đó gán cho thuộc tính Image của PictureBox
            else
                MessageBox.Show("You clicked Cancel", "Open Dialog",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            DataTable dtHang = dtBase.DocBang("select * from tblHang");
           
            dgvHang.DataSource = dtHang;
            //Định dạng dataGrid
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Mã CL";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Giá nhập";
            dgvHang.Columns[5].HeaderText = "Giá bán";
            dgvHang.Columns[6].HeaderText = "File ảnh";
            dgvHang.Columns[7].HeaderText = "Ghi chú";
            dgvHang.Columns[0].Width = 150;
            dgvHang.Columns[1].Width = 250;
            dgvHang.Columns[2].Width = 150;
            dgvHang.Columns[3].Width = 150;
            dgvHang.Columns[4].Width = 150;
            dgvHang.Columns[5].Width = 150;
            dgvHang.Columns[6].Width = 150;
            dgvHang.Columns[7].Width = 250;
            dgvHang.BackgroundColor = Color.LightBlue;
            dtHang.Dispose();//Giải phóng bộ nhớ cho DataTable
            
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThemMoi.Enabled = true;
        }

        private void dgvHang_Click(object sender, EventArgs e)
        {
            DataTable dtChatLieu = dtBase.DocBang("Select * from tblChatLieu");
            ft.FillComBox(cboChatLieu, dtChatLieu, "TenChatLieu", "MaChatLieu");
            txtMaHang.Text = dgvHang.CurrentRow.Cells[0].Value.ToString ();
            txtTenHang .Text = dgvHang.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dgvHang.CurrentRow.Cells[3].Value.ToString();
            cboChatLieu.SelectedValue = dgvHang.CurrentRow.Cells[2].Value.ToString();
            txtDonGiaBan.Text = dgvHang.CurrentRow.Cells[5].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells[4].Value.ToString();
            txtGhiChu.Text = dgvHang.CurrentRow.Cells[7].Value.ToString();
            picAnh.Image = Image.FromFile("Images\\Hang\\" + dgvHang.CurrentRow.Cells[6].Value.ToString());
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                DataTable dtHang = dtBase.DocBang("Select * from tblHang where MaHang='"+txtMaHang.Text +"'");
                if (dtHang.Rows.Count == 0)
                {
                    string strInsert = "Insert into tblHang(MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu) values('" + txtMaHang.Text + "',N'" + txtTenHang.Text + "','" + cboChatLieu.SelectedValue + "'," + Convert.ToInt16(txtSoLuong.Text) + "," + float.Parse(txtDonGiaNhap.Text) + "," + float.Parse(txtDonGiaBan.Text) + ",'" + strAnh + "',N'" + txtGhiChu.Text + "')";
                    dtBase.CapNhatDuLieu(strInsert);
                    dgvHang.DataSource= dtBase.DocBang("Select * From tblHang");
                }
                else
                {
                    MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác");
                    txtMaHang.Focus();
                }
            }
            else
            {
                string sqlUpdate = "update tblHang set TenHang=N'"+txtTenHang.Text +"',MaChatLieu='"+cboChatLieu.SelectedValue +"',SoLuong="+Convert.ToInt16(txtSoLuong.Text)+" ,DonGiaNhap="+float.Parse(txtDonGiaNhap.Text)+",DonGiaBan="+float.Parse(txtDonGiaBan.Text)+",Anh='"+strAnh +"',GhiChu=N'"+txtGhiChu.Text+"' where MaHang='"+txtMaHang.Text+"'";
                dtBase.CapNhatDuLieu(sqlUpdate);
                dgvHang.DataSource = dtBase.DocBang("Select * from tblHang");

            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            themmoi = true;
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGiaBan.Text = "";
            txtMaHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mặt hàng để sửa");
            }
            else
            {
                themmoi = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mặt hàng để xóa");
            }
            else
            {
                if (MessageBox.Show("Ban có muốn xóa không?", "Xóa mặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtBase.CapNhatDuLieu("Delete tblHang where MaHang='"+txtMaHang.Text +"'");
                    dgvHang.DataSource = dtBase.DocBang("select * from tblHang");
                }
            }
        }

        private void btnChatLieu_Click(object sender, EventArgs e)
        {
            frmChatLieu ftCl = new frmChatLieu();
            ftCl.ShowDialog();
        }

        private void cboChatLieu_Click(object sender, EventArgs e)
        {
            DataTable dtChatLieu = dtBase.DocBang("select * from tblChatLieu");
           ft.FillComBox(cboChatLieu, dtChatLieu, "TenChatLieu", "MaChatLieu");
          
        }

        

        
    }
}
