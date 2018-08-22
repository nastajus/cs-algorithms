using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lambdas
{
    class Program
    {

        static void Main(string[] args)
        {
            //expression lambdas
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            int oddIndex = elements.FindIndex(x % 2 != 0);
            
            //commentary:
            // predicate: a function that returns a boolean
            // next try : so I wanna try passing in an equivalent anonymous function.

            
            Console.WriteLine(oddIndex);
            Console.ReadKey();

            //statement lambdas
            //...





        }
    }
}
