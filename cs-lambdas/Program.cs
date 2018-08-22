using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            //expression lambdas
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            int oddIndex = elements.FindIndex(x => x % 2 != 0);
            Console.WriteLine(oddIndex);

            //statement lambdas
            //...

        }
    }
}
