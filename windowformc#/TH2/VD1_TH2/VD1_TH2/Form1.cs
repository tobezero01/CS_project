using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VD1_TH2.StaticData;


namespace VD1_TH2
{
   
    public partial class Form1 : Form
    {
        List<NguoiGui> listNguoiGuis = new List<NguoiGui>();       

        public Form1()
        {
            InitializeComponent();
        }

      
      
        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSoTienGui.Text = "";
            dtpNgayGui.Text = "";
            cbThoiGianGui.Text = "";
            cbThoiGianGui.SelectedIndex = -1;
            rdoThuong.Checked = false;
            rdoPhatLoc.Checked = false;

        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddComboBox()
        {
            cbThoiGianGui.Items.Add("1");
            cbThoiGianGui.Items.Add("3");
            cbThoiGianGui.Items.Add("6");
            cbThoiGianGui.Items.Add("12");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            this.KeyPreview = true;

        }

        private void txtSoTienGui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if (txtMaKH.TextLength < 6)
            {
                MessageBox.Show("Nhập lại vì mã < 6");
                kt = 0;
            }
            if (txtDiaChi.TextLength == 0 || txtTenKH.TextLength == 0)
            {
                MessageBox.Show("Nhập lại vì tên hoặc địa chỉ rỗng");
                kt = 0;
            }

            double tienlai = 0;
            if (kt == 1)
            {
                if (rdoThuong.Checked == true)
                {
                    if (cbThoiGianGui.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.06;

                    }
                    if (cbThoiGianGui.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.07;

                    }
                    if (cbThoiGianGui.SelectedItem == "6")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.08;

                    }
                    if (cbThoiGianGui.SelectedItem == "12")
                    {
                        tienlai = Convert.ToDouble(txtSoTienGui.Text) * 0.09;
                    }
                }
                else if (rdoPhatLoc.Checked == true)
                {
                    if (cbThoiGianGui.SelectedItem == "1")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.07;

                    }
                    if (cbThoiGianGui.SelectedItem == "3")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.08;

                    }
                    if (cbThoiGianGui.SelectedItem == "6")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.09;

                    }
                    if (cbThoiGianGui.SelectedItem == "12")
                    {
                        tienlai = Convert.ToInt32(txtSoTienGui.Text) * 0.1;

                    }
                }
                lstDanhSach.Items.Add(txtMaKH.Text + " | " + txtTenKH.Text + " | " +
                    txtDiaChi.Text
                    + " | " + dtpNgayGui.Text + " | " + txtSoTienGui.Text + " | "
                    + cbThoiGianGui.Text + " tháng | " + tienlai);

                StaticData._NguoiGui.Add(new NguoiGui(Convert.ToInt32(txtMaKH.Text), txtTenKH.Text, txtDiaChi.Text, Convert.ToInt32(txtSoTienGui.Text),
                    dtpNgayGui.Text, cbThoiGianGui.Text, tienlai
                  ));

                listNguoiGuis.Add(new NguoiGui(Convert.ToInt32(txtMaKH.Text), txtTenKH.Text, txtDiaChi.Text, Convert.ToInt32(txtSoTienGui.Text),
                    dtpNgayGui.Text, cbThoiGianGui.Text, tienlai
                  ));

                StaticData._NguoiGui = listNguoiGuis;

            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
