using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lesson_lambdas_and_types
{
    class Program
    {
        //useful tool: syntax visualizer

        static void Main(string[] args)
        {

            // () => C.WL (" yo ");
            // (alpha) => alpha + _beta
            // (a,b,c) => a + b + c
            // (int x, string y) => C.WL (y + x)
            // (ref int x, int y) => x = y + 5
            () =>
            {
                Console.WriteLine("Yo!");
                Console.WriteLine("Waddup");
                Console.Beep();
                //return 42;
            }
            // a => !a 
        }
    }
}
