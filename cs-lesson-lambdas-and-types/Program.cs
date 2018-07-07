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

        static void Main(string[] args)
        {

            // () => Console.WriteLine(" yo ");
            // (alpha) => alpha + _beta
            // (a,b,c) => a + b + c
            // (int x, string y) => Console.WriteLine (y + x)
            // (ref int x, int y) => x = y + 5
            /*
            () =>
            {
                Console.WriteLine("Yo!");
                Console.WriteLine("Waddup");
                Console.Beep();
                //return 42;
            }
            */
            // a => !a 
        }
    }

    // syntax visualizer
    // https://github.com/dotnet/roslyn/wiki/Syntax-Visualizer

    // syntax tree
    // https://github.com/dotnet/csharplang/blob/7f39331672cf8edbda8867de004138e0f711c877/spec/expressions.md#anonymous-function-expressions

}
