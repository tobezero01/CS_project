using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.util
{
    public class gcd
    {
        public static int gcdCal(int a, int b) {
            if(b == 0) return a;
            return gcdCal(b, a%b);
        }
    }

}