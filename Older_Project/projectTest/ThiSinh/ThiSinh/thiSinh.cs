using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ThiSinh
{
    class thiSinh
    {

        string sbd { get; set; }
        string ht { get; set; }
        private int mon1 { get; set; }
        private int mon2 { get; set; }
        private int mon3 { get; set; }

        public thiSinh() { }
        public thiSinh(string sbd, string ht, int mon1,int mon2, int mon3) 
        {
            this.sbd = sbd;
            this.ht = ht;
            this.mon1 = mon1;
            this.mon2 = mon2;
            this.mon3 = mon3;
        }
        public void input()
        {
            Console.WriteLine("so bao danh : ");
            sbd = Convert.ToString(Console.ReadLine());
            Console.WriteLine("ho va ten : ");
            ht = Convert.ToString(Console.ReadLine());
            Console.WriteLine("diem: ");
            mon1 = Convert.ToInt32(Console.ReadLine());
            mon2 = Convert.ToInt32(Console.ReadLine());
            mon3 = Convert.ToInt32(Console.ReadLine());
        }

        public void output()
        {
            Console.WriteLine($@"{sbd}  {ht}  {mon1}  {mon2}  {mon3}");
        }
        public int tinhTong()
        {
            return mon1 + mon2 + mon3;
        }
      
    }
    class tuyenSinh : thiSinh
    {
        private int khuVuc { get; set;}

        public tuyenSinh() : base() { }
        public tuyenSinh(string sbd, string ht, int mon1, int mon2 , int mon3, int khuVuc ) : base(sbd,ht,mon1,mon2,mon3) 
        {
            this.khuVuc = khuVuc;
        }
        public void input() 
        {
            base.input();
            Console.WriteLine("khu vuc : ");
            khuVuc =Convert.ToInt32(Console.Read());           
        }
        public void output()
        {
            base.output();
            Console.WriteLine($@"{khuVuc}");
        }

        public int tinhTong()
        {
            if (khuVuc == 1) return base.tinhTong() + 0;
            if (khuVuc == 2) return base.tinhTong() + 1;
            else return base.tinhTong() + 2;
        }
    }
}
