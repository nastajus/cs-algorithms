using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lambdas
{
    class Program
    {
        //follow along: https://www.dotnetperls.com/lambda

        static void Main(string[] args)
        {
            Func<int, int> func1 = x => x + 1;



            Console.ReadKey();
        }
    }
}
