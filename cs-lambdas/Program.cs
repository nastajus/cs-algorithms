using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lambdas
{
    class Program
    {
        // follow along: https://www.dotnetperls.com/lambda

        // expression vs statement:
        // Expression: Something which evaluates to a value. Example: 1+2/x
        // Statement:  A line of code which does something.  Example: GOTO 100

        static void Main(string[] args)
        {

            //expression body
            Func<int, int> func1 = x => x + 1;

            //statement body
            Func<int, int> func2 = x => { return x + 1; };

            //formal parameters + experssion body
            Func<int, int> func3 = (int x) => x + 1;



            Console.ReadKey();
        }
    }
}
