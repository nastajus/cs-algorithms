using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_async
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = aaa();
            //aaa() assigned: interesting, the warning disappeared. 

            Console.WriteLine(a);
            //output: System.Threading.Tasks.Task`1[System.Boolean]

            Console.ReadKey();
        }

        static async Task<bool> aaa()
        {
            return await bbb();
        }

        static async Task<bool> bbb()
        {
            return false;
        }
    }
}
