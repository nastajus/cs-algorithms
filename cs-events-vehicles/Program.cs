using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace cs_events_vehicles
{
    /// <summary>
    /// This will begin as a complete and an extremely simplified dual event system
    /// TrafficLights frequency will be designed to be slightly adaptable based on vehicle accumulation.
    /// VehicleGenerator will randomly spawn a periodic amount of cars that stop at the traffic lights
    /// Only once the above is complete do I allow myself to expand into A) graphical representation or B) a connected city block network
    /// </summary>
    class Program
    {
        public static int SystemSpeedFactor = 5;

        static void Main(string[] args)
        {

        }
    }

    class TrafficLights
    {
        private const double RedMin = 2;
        private const double RedMax = 4;
        private const double AmberMin = 3;
        private const double AmberMax = 5;
        private const double Green = 24; //hardcoded assuming only four lanes...

        Timer _aTimer = new Timer();

        TrafficLights()
        {
            _aTimer.Interval = IntervalSeconds;
            _aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public double IntervalSeconds
        {
            get { return _aTimer.Interval / 1000; }

            [DefaultValue(Green + AmberMax + RedMax)] //== 33 seconds
            private set
            {
                if (value < Green + AmberMin + RedMin || value > Green + AmberMax + RedMax)
                {
                    throw new ArgumentOutOfRangeException();
                }

                //i mean... i question the design decision to create this dependency from I.S. to Program... and later from VG to Program as well... but meh
                _aTimer.Interval = value * 1000 / Program.SystemSpeedFactor; 
            }
        }

        void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //hmm okay i see...
            //internally within this single class...
            //I'M SUBSCRIBING to the event that raised INTERNALLY by the system whenever time passes.
        }
    }


    //yagni / kis --> do simplest implementation first: all vehicles are 1 size and all listen directly to lights only 
    class VehicleGenerator
    {

    }
}
