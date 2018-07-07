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

            //valid since is an expression on the right side, which can be returned.
            (a, b, c) => a + b + c



        }
    }
}
