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
            aaa();
            //aaa(); alone: Because this call is not awatied,execution of the current method continues before the call is completed. Consider applying await

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
