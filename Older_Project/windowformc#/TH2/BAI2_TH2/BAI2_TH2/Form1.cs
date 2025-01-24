using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BAI2_TH2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }

        private void AddComboBox()
        {
            cbDoUong.Items.Add("Coca cola");
            cbDoUong.Items.Add("Pepsi");
            cbDoUong.Items.Add("Seven up");
            cbSoLuong.Items.Add("1");
            for (int i = 1;i<= 10; i++)
            {
                cbSoLuong.Items.Add(i.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            this.KeyPreview = true;

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            rdoCaNgay.Checked = false;
            rdoNuaNgay.Checked = false;
            txtGiaDT.Text = "";
            cbDoUong.Text = string.Empty;
            cbSoLuong.Text = string.Empty;
            txtTienDU.Text = string.Empty;
        }

        private void rdoCaNgay_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaDT.Text = "200";
        }

        private void rdoNuaNgay_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaDT.Text = "100";
        }

        private void cbDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhTien();
        }

        private void cbSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinhTien();
        }

        private void tinhTien()
        {
            if(cbDoUong.SelectedIndex != -1 && cbSoLuong.SelectedIndex !=-1) 
            {
                double price = 0.0;
                if(cbDoUong.SelectedItem.Equals("Coca cola")) { price = 0.5; }
                if (cbDoUong.SelectedItem.Equals("Pepsi")) { price = 0.8; }
                if (cbDoUong.SelectedItem.Equals("Seven up")) { price = 1.0; }
                txtTienDU.Text = (price * Convert.ToDouble(cbSoLuong.SelectedItem)).ToString();
            }
        }

        private void txtThemDS_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if(txtHoTen.Text =="" || cbDoUong.Text == "" || cbSoLuong.Text =="" )
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin");
                kt = 0;
            }
            if(kt == 1)
            {
                string Item;
                if(rdoCaNgay.Checked) { Item = "Cả ngày"; }
                else { Item = "Nửa ngày"; }
                lbKhachHang.Items.Add( "Họ tên " + txtHoTen.Text + " | " + Item + " | " + txtGiaDT.Text 
                                       + "$" + " | Đồ uống " + txtTienDU.Text + " | " + " Tổng " +
                                       (Convert.ToDouble(txtGiaDT.Text) + Convert.ToDouble(txtTienDU.Text)).ToString()); 
            }
        }
    }
}
