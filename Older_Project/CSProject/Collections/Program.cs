using System;
using System.Collections.Generic;
namespace Collections

{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.AddRange(new int[] {2,3,4,5,6});
            list1.Insert(0, 0);
            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }
            list1.RemoveAt(2);

            Console.WriteLine("------------------"); 
            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine(list1[2]);

            Console.WriteLine("------------------");

            var m = list1.FindAll(
                (e) =>
                {
                    return e % 2 == 0;
                });
            Console.WriteLine(m);
            
        }
    }
}