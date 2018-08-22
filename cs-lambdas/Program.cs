using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lambdas
{
    class Program
    {

        //mine
        delegate bool Pred(int val);

        //ms's 
        delegate bool Predicate<in T>(T obj);

        static void Main(string[] args)
        {
            //anonymous method
            Pred odd = delegate(int val) { return val % 2 != 0; };

            //expression lambdas
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            int oddIndex = elements.FindIndex(odd);
            
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
