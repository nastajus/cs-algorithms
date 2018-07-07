using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace cs_events_timer
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class TimerNetworkLaggerFaker
    {
        TimerNetworkLaggerFaker()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += OnTimedEvent;
        }

        //oh, i accept this signature as necessary to conform matching the publisher's event ... besides...
        //... just think like... i can discard these paramaters... as unimportant for consideration...
        // ... ... because ... I just need to understand the convention of matching signature... and "On.." methods...
        private void OnTimedEvent(object sender, ElapsedEventArgs e) 
        {
            throw new NotImplementedException();
        }
    }

}
