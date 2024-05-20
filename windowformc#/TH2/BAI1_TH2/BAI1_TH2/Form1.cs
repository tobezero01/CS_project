using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI1_TH2
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
            cbTenMonHoc.Items.Add("Tin học đại cương");
            cbTenMonHoc.Items.Add("Giải tích F1");
            cbTenMonHoc.Items.Add("Tiếng Anh A0");
            cbTenMonHoc.Items.Add("Triết học Mác – Lênin");
            cbTenMonHoc.Items.Add("Vật lý F1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddComboBox();
            this.KeyPreview = true;

        }

        private void cbTenMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTenMonHoc.Text == "Tin học đại cương")
            {
                tbSoTin.Text = "2";
            }
            else if(cbTenMonHoc.Text == "Giải tích F1")
            {
                tbSoTin.Text = "3";
            }
            else if (cbTenMonHoc.Text == "Tiếng Anh A0")
            {
                tbSoTin.Text = "3";
            }
            else if (cbTenMonHoc.Text == "Triết học Mác – Lênin")
            {
                tbSoTin.Text = "2";
            }
            else if (cbTenMonHoc.Text == "Vật lý F1")
            {
                tbSoTin.Text = "3";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if(tbDiem.Text == "")
            {
                MessageBox.Show("chua nhap diem");
                kt = 0;
            }
            try
            {
                int n = int.Parse(tbDiem.Text);
            }
            catch(FormatException ex) {
                MessageBox.Show("Điểm phải là số moi nhap lai : ");kt = 0;

                tbDiem.Text = "";
            }

            if(kt == 1)
            {
                listMonHoc.Items.Add(cbTenMonHoc.Text + "-" +tbSoTin.Text + "-" + tbDiem.Text);
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int kt = 1;
            if(listMonHoc.Items.Count == 0) {
                kt = 0;
                MessageBox.Show("moi nhap danh sach mon hoc");
            }
            int tongTin = 0;
            int tongdiem = 0;
            if (kt ==1) 
            {
                foreach (var i in listMonHoc.Items)
                {
                    string[] m = i.ToString().Split('-');
                    tongdiem += int.Parse(m[1]) * int.Parse(m[2]);
                    tongTin += int.Parse(m[1]);
                }
                tbTongSoDiem.Text = tongdiem.ToString();
                tbTongSoTin.Text = tongTin.ToString();
                tbDiemTB.Text = (tongdiem/tongTin).ToString();
            }
        }
    }
}
