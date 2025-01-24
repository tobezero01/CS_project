using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManager2
{
    public partial class FrmDangNhap : Form
    {
        Classes.DatabaseProcess db = new Classes.DatabaseProcess();
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        public void DeleteDetail()
        {
            txtUsername.Text = "";
            txtUsername.Focus();
            txtPassword.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy bỏ không?", "THÔNG BÁO!"
                , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Equals("") || txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!"
                    , "LỖI!", MessageBoxButtons.OK);
            }
            else
            {
                string sql = "Select passWord from tblUser where userName = '"
                    + txtUsername.Text.Trim().ToString() + "'";
                SqlDataReader dtReader = db.dataReader(sql);
                string password = "";
                if (dtReader.Read())
                {
                    password = dtReader["passWord"].ToString();
                }
                if (password.Equals(txtPassword.Text))
                {
                    FrmHang.userName = txtUsername.Text;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác. "
                        + "Vui lòng nhập lại!", "LỖI!", MessageBoxButtons.OK);
                }
            }
        }
    }
}
