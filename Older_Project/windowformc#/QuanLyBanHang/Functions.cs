using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace QuanLyBanHang
{
    public class Functions
    {
        ProcessDataBase dataBase = new ProcessDataBase();
        public string SinhMaTuDong(string TenBang, string MaBatDau, string TruongMa)
        {
            int id = 0;
            bool dung = false;
            string ma = "";
            DataTable dm = new DataTable();
            while (dung == false)
            {
                dm = dataBase.DocBang("Select * from "+TenBang+" where "+TruongMa+"='"+MaBatDau +
                    id.ToString() + "'");
                if (dm.Rows.Count == 0)
                {
                    dung = true;
                }
                else
                {
                    id++;
                    dung = false;
                }
            }
            ma = MaBatDau + id.ToString();
            return ma;
        }
    }
}
