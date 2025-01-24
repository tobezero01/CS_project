
using System;
namespace ConsoleApp2
{
    public delegate void showlog(string mes);

    
    internal class Program {
        static void infor(string d) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(d);
        Console.ResetColor();

        }
        static void tinhtong(int a, int b, showlog log)
        {
            int kq = a + b;
            log?.Invoke($"tong la : {kq}");
        }
        //public int tong (int a, int b) =>  a + b;
        //public int hieu(int a, int b) => a - b;
        static void Main(string[] args)
        {
            //showlog log = null;
            ////log = infor;


            //log("cxin chao");
            //log?.Invoke("cxin chao adsfjnsdf"); 


            //action vs func
            //Action action;  // = delegate void kocothamso
            //Action<string, int> action1;
            //Action<string> action2;

            //action2 = infor;
            //action2?.Invoke("fsdfsdfsd");


            //Func<int, int, int> tinhtoan;    // deligate int kieu(int a, int b)
            //int a = 10; int b = 7;
            //Console.WriteLine("{tinhtoan(a, b)}");
            tinhtong(4, 5, infor);
            
        }   
    }
}