namespace MangMotChieu
{
    class daySo
    {
        private int n;
        int []a;

        public daySo() { }
        public daySo(int x)
        {
            n = x;
            a = new int[n];
        }
        public void Nhap()
        {
            Console.Write("Nhap day so ");
            for (int i = 0; i < n; i++)
            {
                a[i] = new int();
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void In()
        {
            Console.WriteLine("day so la : ");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
        }

        public void sapXep(int thutu)
        {
           

            switch (thutu)
            {
                case 0: Array.Sort(a);In(); break;
                case 1: Array.Sort(a); Array.Reverse(a);In(); break;
            }
        }
        public int timkiem(int m)
        {
            for (int i = 0; i < n; i++)
            {
                if (a[i] == m) return i;
            }
            return -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());int m, thutu;
            daySo d = new daySo(n);
            d.Nhap();
            d.In();
            Console.Write("sap xap :");
            do
            {
                Console.Write("nhap thu tu : ");
                thutu = Convert.ToInt32(Console.ReadLine());
            } while (thutu != 0 && thutu != 1);
            d.sapXep(thutu);
            Console.Write("tim kiem : ");
            m = Convert.ToInt32(Console.ReadLine());
            if(d.timkiem(m) == -1)
            {
                Console.Write("khong tim thay m");
            }
            Console.Write($@"vi tri cua {m} la {d.timkiem(m)}");
        }
    }
}