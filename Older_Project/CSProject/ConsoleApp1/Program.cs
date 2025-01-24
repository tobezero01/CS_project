using System.Data.SqlTypes;

namespace ConsoleApp1
{
    internal class Program
    {
        // static void swap(ref int a,ref int b) {
        //     int c = a;a = b; b = c;
        // }
        // static void swap(ref float a,ref float b) {
        //     float c = a;a = b; b = c;
        // }
        // static void swap<T>(ref T a,ref T b) {
        //     T c = a;a = b; b = c;
        // }
        class sinhvien {
            public string name {get;set;}
            public int namsinh {get;set;}
            public string noisinh {get;set;}
        }
        static void Main(string[] args)
        {
            // string a = "45";
            // string b= "4";
            // //int a = 5; int b = 45;
            // swap(ref a,ref b);
            // Console.WriteLine($@"a = {a} , b = {b}");
            // product<int> sp2 = new product<int>();  
            // product<int> sp1 = new product<int>();

            // sp1.setId(123);ot
            // sp1.print();
            

            // kiểu vô danh
            List<sinhvien> cacsinhvien = new List<sinhvien>(){
                new sinhvien() {name = "duc", namsinh = 2040, noisinh = "hd"},
                new sinhvien() {name = "duc2", namsinh = 2000, noisinh = "hd"},
                new sinhvien() {name = "duc3", namsinh = 2000, noisinh = "hd"},
                new sinhvien() {name = "duc1", namsinh = 2003, noisinh = "hd"}
            };
            var kq = from sv in cacsinhvien where sv.namsinh <= 2000
                        select new  {
                            ten = sv.name,
                            ns = sv.namsinh
                        };
            foreach(var sv in kq) {
                Console.WriteLine(sv.ten + sv.ns);
            }


            // kieu du lieu dong
            dynamic tenbienl;
            var tenbien2 = 123;
        } 
    }
}