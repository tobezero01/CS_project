using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QuanLyBanHang.Forms
{
    public partial class frmChatLieu : Form
    {
        ProcessDataBase dtBase = new ProcessDataBase();
        
        public frmChatLieu()
        {
            InitializeComponent();
        }

        private void frmChatLieu_Load(object sender, EventArgs e)
        {
           DataTable dtChatLieu=dtBase.DocBang("Select * from tblChatLieu");

            dgvChatLieu.DataSource = dtChatLieu;

            
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu");
                txtMaCL.Focus();
            }
            else
            {
                if (txtTenCL.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập tên chất liệu");
                    txtTenCL.Focus();
                }
                else
                {
                    DataTable dtChatLieu = dtBase.DocBang("Select * from tblChatLieu where MaChatLieu='"+txtMaCL.Text+"'");
                    if (dtChatLieu.Rows.Count == 0)
                    {
                        dtBase.CapNhatDuLieu("insert into tblChatLieu(MaChatLieu," +
                            "TenChatLieu) values(N'" + txtMaCL.Text + "',N'" + txtTenCL.Text + "')");
                        dgvChatLieu.DataSource = dtBase.DocBang("Select * from tblChatLieu");
                    }
                    else
                    {
                        MessageBox.Show("Mã CL này đã tồn tại. Bạn phải nhập mã khác");
                        txtMaCL.Focus();
                    }
                }
            }
           
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaCL.Enabled = true;
            btnLuu.Enabled = true;
            txtMaCL.Focus();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete tblChatLieu where MaChatLieu='"+txtMaCL.Text+"'");
                dgvChatLieu.DataSource = dtBase.DocBang("Select * from tblChatLieu");
            }
        }

        
        //Hàm xóa hết dữ liệu trong các điều khiển trên Form
        void ResetValue()
        {
            txtMaCL.Text = "";
            txtTenCL.Text = "";
        }

        private void dgvChatLieu_Click(object sender, EventArgs e)
        {
            txtMaCL.Text = dgvChatLieu.CurrentRow.Cells[0].Value.ToString();
            txtTenCL.Text = dgvChatLieu.CurrentRow.Cells[1].Value.ToString();
            txtMaCL.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenCL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu");
                txtTenCL.Focus();
            }
            else
            {
                dtBase.CapNhatDuLieu("update tblChatLieu set TenChatLieu=N'"+txtTenCL.Text +"' where MaChatLieu=N'"+txtMaCL.Text+"'");
                dgvChatLieu.DataSource = dtBase.DocBang("select * from tblChatLieu");
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }
    }
}
