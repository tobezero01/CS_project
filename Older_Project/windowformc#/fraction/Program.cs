using fraction;

namespace fraction
{

    class phanSo
    {
        private int TuSo { get; set; }
        private int MauSo { get; set; }
 
        public phanSo() {
            MauSo = 1; TuSo = 0;
        }
        /// <summary>
        /// tim uoc chung nho nhat
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int ucln(int a, int b)
        {
            if (b == 0) return a;
            return ucln(b, a % b);
        }

        /// <summary>
        
        /// boi chung nho nhat
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int bcnn(int a, int b)
        {
            return a / ucln(a, b) * b;
        }
        public phanSo(int TuSo, int MauSo)
        {
            this.TuSo = TuSo;
            this.MauSo = MauSo;
        }      
        void Nhap()
        {
            Console.Write("Nhap tu so : "); TuSo = Convert.ToInt32(Console.Read());
            Console.Write("Nhap mau so : "); MauSo = Convert.ToInt32(Console.Read());
        }
        public void Xuat()
        {
            Console.WriteLine($@" {TuSo}/{MauSo}");
        }
 

        public void rutGon()
        {
            int  g = ucln(TuSo, MauSo); TuSo /= g; MauSo /= g;
        }

        public static phanSo operator + (phanSo a, phanSo b)
        {
            
            phanSo Tong = new phanSo(1,1);
            int mc = Tong.bcnn(a.MauSo, b.MauSo);
            Tong.TuSo = mc / a.MauSo * a.TuSo + mc / b.MauSo * b.TuSo;
            Tong.MauSo= mc;

            int g = Tong.ucln(Tong.TuSo, Tong.MauSo);
            Tong.TuSo /= g;
            Tong.MauSo /= g;
            return Tong;
        }
        public static phanSo operator - (phanSo a, phanSo b)
        {

            phanSo hieu = new phanSo(1, 1);
            int mc = hieu.bcnn(a.MauSo, b.MauSo);
            hieu.TuSo = mc / a.MauSo * a.TuSo - mc / b.MauSo * b.TuSo;
            hieu.MauSo = mc;

            int g = hieu.ucln(hieu.TuSo, hieu.MauSo);
            hieu.TuSo /= g;
            hieu.MauSo /= g;
            return hieu;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            phanSo t = new phanSo();
            phanSo h = new phanSo();
            phanSo q = new phanSo(4, 5);
            phanSo p = new phanSo(3, 5);
            t = p + q; h = q - p;
            Console.Write($@" tong hai phan so la ");
            t.Xuat();
            Console.Write($@" hieu hai phan so la ");
            h.Xuat();

        }
    }
}