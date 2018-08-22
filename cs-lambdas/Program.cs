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

        // wisdom:
        // Many developers regard lambda expressions as a complete improvement over (and replacement for) the delegate syntax.


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


            #region copy_Pasta

            //COPY-PASTA:


            // Use delegate method expression.
            Func<int, int> func7 = delegate (int x) { return x + 1; };
            
            // Use delegate expression with no parameter list.
            Func<int> func8 = delegate { return 1 + 1; };

            Console.WriteLine(func1.Invoke(1));
            Console.WriteLine(func2.Invoke(1));
            Console.WriteLine(func3.Invoke(1));
            Console.WriteLine(func5.Invoke(2, 2));
            func6.Invoke();
            Console.WriteLine(func7.Invoke(1));
            Console.WriteLine(func8.Invoke());

            #endregion


            Console.ReadKey();
        }

        delegate void Actionn();
        delegate TResult Actionn<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

        //conclusion:
        // ~everything~ is a delegate type! 
        // suffice to say:
        // either `Func<a, b> myVariableV` or `Action myVariableW` are necessary types to assign lambdas to variables.




    }
}
