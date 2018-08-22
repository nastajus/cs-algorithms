using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace cs_async_void
{
    /// <summary>
    /// while attempting to reserach in google "Task<void>" or "Task<T> vs Task" return types,
    /// came to low-fruit page about async void antipattern
    /// so i'm doing that here.
    /// https://theburningmonk.com/2012/10/c-beware-of-async-void-in-your-code/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            timer.Elapsed += (s,e) => OnTimerFired(s, e).SwallowException();
            timer.Interval = 1000;
            timer.Start();
            Console.Read();
        }

        static async Task OnTimerFired(object sender, ElapsedEventArgs args)
        {
            await Task.Delay(1000);

            //kill process, but now will be swallowed silently.
            throw new Exception();
        }
    }

    public static class TaskExtensions
    {
        public static void SwallowException(this Task task)
        {
            task.ContinueWith(_ => { return; });
        }
    }
}
