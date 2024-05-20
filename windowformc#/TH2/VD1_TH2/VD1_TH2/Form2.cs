using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VD1_TH2
{
    public partial class Form2 : Form
    {
        List<NguoiGui> listNguoiGuis = new List<NguoiGui>();
        public Form2()
        {
            InitializeComponent();
            listNguoiGuis = StaticData._NguoiGui;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int timthay = 0;
            foreach (NguoiGui i in listNguoiGuis)
            {
                if (i.MaKH1 == Convert.ToInt32(tbTimKiem.Text))
                {
                    timthay = 1;
                    lbThongTinTimKiem.Text = "Khách hàng " + i.TenKH1 + " phải trả "
                        + i.Tien1 + " nghìn đồng ";

                }
            }

            if (timthay == 0)
            {
                lbThongTinTimKiem.Text = " Khách hàng " + tbTimKiem.Text + " không có trong danh sách";

            }

        }

        private void lbThongTinTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
