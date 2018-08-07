using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_async
{
    /// <summary>
    /// Base purpose was to focus on simply showing what happens when calling async methods from normies.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var a = Aaa();
            //aaa() assigned: interesting, the warning disappeared. 

            Console.WriteLine(a);
            //output: System.Threading.Tasks.Task`1[System.Boolean]

            Console.ReadKey();
        }

        static async Task<bool> Aaa()
        {
            return await Bbb();
        }

        static async Task<bool> Bbb()
        //warning: this async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread
        {
            return false;
        }
    }
}
