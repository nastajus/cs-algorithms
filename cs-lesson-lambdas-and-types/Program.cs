using System;
using System.Collections.Generic;
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

            //depending on syntactics used... this occurs... 
            //COMPILER ERROR: Only assignment, call, increment, decrement, and new object expressions can be used as a statement

            //() => { ; }

            // lambdas are ... expressions or blocks perhaps....
            //does it even make sense to use alone like this anywhere ??? 
            //  do i *need* to assign lambdas to a variable ??? 

            () => Console.WriteLine("hi");

            int _beta = 2;
            (alpha) => alpha + _beta;

            (a, b, c) => a + b + c 

            (string x, int y) => { y + x };

            (ref string x, int y) => { x + y } //um wait no.. not assignment...

            () => { }


        }
    }
}
