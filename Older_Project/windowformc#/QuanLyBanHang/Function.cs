using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Data;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class Function
    {
        public void FillComBox(ComboBox cb,DataTable dt, string display, string value)
        {
            cb.DataSource = dt;
            cb.DisplayMember = display;
            cb.ValueMember = value;
        }
    }
}
