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
        public const int SystemSpeedMultiplicationFactor = 5;

        static void Main(string[] args)
        {

        }
    }

    //timed as 30 seconds on, 30 seconds off.
    // use city of toronto documents as a guideline for the design: 
    // https://www.toronto.ca/311/knowledgebase/kb/docs/articles/transportation-services/traffic-management-centre/urban-traffic-control-systems/traffic-signals-operation-timing.html
    //The duration of the all-red display at traffic signals in the City ranges from two to four seconds. 
    //The duration of the yellow light display at traffic signals in the City ranges from three to five seconds. ...
    // Most intersections in Toronto provide at least enough time for someone crossing at 1.0 metre/second walking speed 
    // https://en.wikipedia.org/wiki/Lane#Lane_width
    // The Interstate Highway standards for the U.S.Interstate Highway System uses a 12-foot (3.7 m) standard for lane width, while narrower lanes are used on lower classification roads.
    class TrafficLights
    {
        System.Timers.Timer _aTimer = new Timer();

        TrafficLights()
        {
            //for one particular road... 
            _aTimer.Interval = IntervalSeconds;
        }

        private const double RedMin = 2;
        private const double RedMax = 4;
        private const double AmberMin = 3;
        private const double AmberMax = 5;
        private const double Green = 24; //hardcoded assuming only four lanes...

        public double IntervalSeconds
        {
            get { return _aTimer.Interval / 1000; }
            private set
            {
                if (value < Green + AmberMin + RedMin || value > Green + AmberMax + RedMax)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _aTimer.Interval = value * 1000;
            }
        }
    }


    //yagni / kis --> do simplest implementation first: all vehicles are 1 size and all listen directly to lights only 
    class VehicleGenerator
    {

    }
}
