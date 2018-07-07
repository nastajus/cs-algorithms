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

            //() => { ; }

            int _beta = 2;
            (alpha) => { alpha + _beta; };
            //COMPILER ERROR: Only assignment, call, increment, decrement, and new object expressions can be used as a statement
        }
    }
}
