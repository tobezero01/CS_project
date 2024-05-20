
using System;
namespace events
{

    public delegate void eventInput(int x);
    class delieunhap : EventArgs
    {
        public int data { set; get; }
        public delieunhap(int x)
        {
            data = x;
        }
    }
    class UserInput
    {   
        //public event eventInput sknhapso;

        public event EventHandler Sknhapso;// deligate void kieu(object ? sender, EventArgs args)
        public void input()
        {
            do
            {               
                int i = Convert.ToInt32(Console.ReadLine());
                Sknhapso?.Invoke(this,new delieunhap(i) );
            } while (true);
            
        }
    }

    class TinhCan{
        public void sub(UserInput input) {
            input.Sknhapso += can;
        }
        public void can(object sender, EventArgs e) {
            delieunhap  delieun = (delieunhap)e;
            int i = delieun.data; 
            Console.WriteLine($"can bac 2 cua i la  {Math.Sqrt(i)}");
        }
    }
    class binhPhuong{
        public void sub(UserInput input) {
            input.Sknhapso += binhphuong;
        }
        public void binhphuong(object sender, EventArgs e) {
            delieunhap delieun = (delieunhap)e;
            int i = delieun.data;
            Console.WriteLine($"binh phuong cua i la  {i*i}");
        }
    }
    class Program
    {
        /*publiser => class - phat su kien
         * subrider => class - nhan su kien
         */

        
        static void Main(string[] args)
        {
            UserInput u = new UserInput();

            u.Sknhapso += (sender , e) =>
            {
                delieunhap dulieun = (delieunhap)e;
                Console.WriteLine("ban vua nhap so " + dulieun.data);
            };
            TinhCan t = new TinhCan();
            binhPhuong b = new binhPhuong();
            b.sub(u);
            t.sub(u);
            u.input();
        }
    }
}