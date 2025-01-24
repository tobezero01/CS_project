using System.Data;
using Internal;
using System;
namespace MaTran
{
    class maTran {
        private int n;
        private int m;
        int [,] a;

        public maTran(){}
        public maTran(int n, int m) {
            this.n = n;
            this.m = m;
            a = new int[n,m];
        }
    }
    public void Nhap() {
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < m; j++) {
                a[i][j] = new int();
                a[i][j] = Convert.ToInt16(Console.Read());
            }
        }
    }

    public void In() {
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < m; j++) {
                Console.write(a[i,j] + " ");
            }
        }Console.WriteLine();
    }
    /// <summary>
    /// tinh hieu hai ma tran
    /// </summary>
    /// <param name="q"></param>
    /// <param name="p"></param> <summary>
    /// 
    /// </summary>
    /// <param name="q"></param>
    /// <param name="p"></param>
    public void Tong(maTran q, maTran p, maTran t) {
        maTran t = new maTran();
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < m; j++) {
                t[i][j] = p[i][j] + q[i][j];
            }
        }
        t.In();
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            maTran p = new maTran();
            maTran q = new maTran();
            p.Nhap(); q.Nhap();
            
        }
    }
}