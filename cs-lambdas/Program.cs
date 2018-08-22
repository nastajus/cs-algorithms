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

        //DEFINITIONS:

        // expression vs statement:
        // Expression: Something which evaluates to a value. Example: 1+2/x
        // Statement:  A line of code which does something.  Example: GOTO 100

        // lambda: 
        // Lambda comes from the Lambda Calculus and refers to anonymous functions in programming.
        // ~= shorthand for FUNCTION.

        static void Main(string[] args)
        {

            //lambda with expression body
            Func<int, int> func1 = x => x + 1;

            //lambda with statement body
            Func<int, int> func2 = x => { return x + 1; };

            //lambda with formal parameters + with experssion body
            Func<int, int> func3 = (int x) => x + 1;

            //lambda multiple parameters
            Func<int, int, int> func5 = (x, y) => x * y;

            // lambda no parameters
            Action func6 = () => Console.WriteLine();


            


            Console.ReadKey();
        }

        delegate void Action();
        delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

        //conclusion:
        // ~everything~ is a delegate type! 
        // suffice to say:
        // either `Func<a, b> myVariableV` or `Action myVariableW` are necessary types to assign lambdas to variables.




    }
}
