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
            //Run takes Action type, Actions accept lambdas, lambdas are consice functions nay expressions
            Task t = Task.Run(() => { });
            t.Wait();
        }
    }

}
