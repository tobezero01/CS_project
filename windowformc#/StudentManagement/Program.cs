using System.Collections.Specialized;

namespace StudentManagement
{
    public class SManagement
    {
        String name { get; set; }
        String date { get; set; }
        public double dbG { get; set; }
        public double codeG { get; set; }
        public double webG { get; set; }


        public SManagement() { }
        public SManagement(string name, string date, double codeTG, double dbG, double webG)
        {
            this.name = name;
            this.date = date;
            this.codeG = codeG;
            this.dbG = dbG;
            this.webG = webG;
        }

        public void input()
        {
            Console.Write("name : ");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("date : ");
            date = Convert.ToString(Console.ReadLine());
            Console.Write("Grade : ");
            codeG = Convert.ToDouble(Console.ReadLine());
            dbG = Convert.ToDouble(Console.ReadLine());
            webG = Convert.ToDouble(Console.ReadLine());
        }
        public double diemTB()
        {
            return (webG + dbG + codeG) / 3;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine()); int cnt1 = 0, cnt2 = 0;
            double[] b = new double[n];
            SManagement []a = new SManagement[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = new SManagement();
                a[i].input();
                b[i] = a[i].diemTB();
                if (b[i] >= 8 && a[i].dbG >= 5 && a[i].codeG >= 5 && a[i].webG >= 5) cnt1++;
                else if (b[i] < 8 && a[i].dbG >= 5 && a[i].codeG >= 5 && a[i].webG >= 5) cnt2++;
            }
            Console.WriteLine($@"So sinh vien am khoa luan la : {cnt1} va so sinh vien lam chuyen de la {cnt2}" );
        }
  
    }
}