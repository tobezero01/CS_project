namespace MangHaiChieu
{
    class toaDo
    {
        private double x { get; set; }
        private double y { get; set; }

        public toaDo ()
        {
            x = 0; y = 0;
        }

        public toaDo(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Nhap()
        {
            Console.Write("nhap thoa do (x,y) = ");
            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());
        }

        public void In()
        {
            Console.Write($@" thoa do (x,y) = {x}/{y}");
        }

        public double KhoangCach(toaDo a, toaDo b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x,2) + Math.Pow(a.y - b.y,2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            toaDo a = new toaDo();
            toaDo b = new toaDo();
            a.Nhap();b.Nhap();
            toaDo c = new toaDo();
            Console.WriteLine($@" khoang cach 2 diem la {c.KhoangCach(a,b)}");
        }
    }
}