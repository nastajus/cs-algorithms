using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_async_tasks
{
    /// <summary>
    /// Purpose is following along with Microsoft's sample code:
    /// https://msdn.microsoft.com/en-us/library/system.threading.tasks.task(v=vs.110).aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                //just loop.
                int ctr = 0;
                for (ctr=0; ctr<=1000000000; ctr++) { }
                Console.WriteLine($"finished {ctr} loop iterations");
            });
            t.Wait();
            Console.ReadKey();
        }
    }

}
