using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{   class product<A> {
            A id;
            public void setId(A id) {
                this.id = id;
            }
            public void print() {
                Console.WriteLine(this.id);
            }
        }
   
}