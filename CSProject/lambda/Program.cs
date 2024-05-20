using System;
namespace lambda
{
    internal class Program
    {   // lambda = anonymos function
        static void Main(string[] args)
        {
            //Action<string> thongbao;
            //thongbao = (string s) => Console.WriteLine(s);
            //thongbao?.Invoke("xin chao");

            //Action thongbao;
            //thongbao = {} => Console.WriteLine("cinvhao");

            //Action<string,string> thongbao;
            //thongbao = (string s, string k) =>
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(s + k);
            //    Console.ResetColor();
            //};
            //thongbao?.Invoke("xin chao"," duc");

            //Func<int, int, int> tinhtoan;
            //tinhtoan = (int a, int b) =>
            //{
            //    int kq = a + b;
            //    return kq;
            //};
            //Console.WriteLine(tinhtoan(3,5));

            int[] mang = { 3,4,2,44,4,3,5,6,7};
            //var kq = mang.Select((int x) =>
            //{
            //    return Math.Sqrt(x);
            //}
            //);
            //foreach(int x in mang)
            //{
            //    Console.WriteLine(x);
            //}

            //mang.ToList().ForEach(
            //    (int x) =>
            //    {
            //        if(x %2 == 0)
            //        {
            //            Console.WriteLine(x);
            //        }
            //    });

            var kq = mang.Where(
                x =>
                {
                    return x % 4 == 0;
                }
                );
            foreach(var x in kq)
            {
                Console.WriteLine(x);
            }
        }
    }
}