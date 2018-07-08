using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ON = cs_events_vehicles.OntarioStandards;

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
        public static int SystemSpeedFactor = 15;

        static void Main(string[] args)
        {
            TrafficLights lights = new TrafficLights(ON.RedMaxAll, ON.AmberMax, ON.Green, SystemSpeedFactor);
            Console.ReadKey();
        }
    }


    class TrafficLights
    {

        private const double _pulse = 1000;
        private Timer _aTimer = new Timer();

        public TrafficLights(int durationRedAll, int durationAmber, int durationGreen, int systemSpeedFactor = 1)
        {
            //boot up into existance, barely alive.
            Light = ConsoleColor.Gray;
            _aTimer.Interval = _pulse / systemSpeedFactor; 
            _aTimer.Elapsed += new ElapsedEventHandler(OnPulseTickEvent);


            _durationRedAll = durationRedAll;
            _durationAmber = durationAmber;
            _durationGreen = durationGreen;

            _durationRedJustThis = durationRedAll + durationAmber + durationGreen;

            Console.WriteLine("lights started");
            Init();
        }

        public void Init()
        {
            //begin normal operations, on assumption it is the solitary light in existance. 

            _aTimer.Enabled = true;
            /* Light = */ SetNextLightColor();


            //feels like pointless duplication... should be able to rewrite this somehow...
            Console.ForegroundColor = Light;
            Console.WriteLine($"current light color is ... {Light}");


        }

        private readonly int _durationRedJustThis;
        private readonly int _durationRedAll;
        private readonly int _durationAmber;
        private readonly int _durationGreen;

        public ConsoleColor Light
        {
            get;
            private set;
        }

        /// <summary>
        /// rotate through 3 different light colors in-order
        /// </summary>
        private void SetNextLightColor()
        {
            switch (Light)
            {
                case ConsoleColor.Green:
                    Light = ConsoleColor.DarkYellow;
                    break;
                case ConsoleColor.DarkYellow:
                    Light = ConsoleColor.Red;
                    break;
                case ConsoleColor.Red:
                case ConsoleColor.Gray:
                    Light = ConsoleColor.Green;
                    break;
            }
        }


        private int _secondsElapsedInCycle = 0;


        /// <summary>
        /// begins as if was in durationGreen state initially
        /// </summary>
        void OnPulseTickEvent(object source, ElapsedEventArgs e)
        {
            _secondsElapsedInCycle += 1;

            //todo: proper state machine that correctly separates four states for three colors... 
            //right now is weak design, as relies on symmetry between this function on SetNextLightColor();

            //check if light changes
            if ((Light == ConsoleColor.Green && _secondsElapsedInCycle == _durationGreen)
                || (Light == ConsoleColor.DarkYellow && _secondsElapsedInCycle == _durationAmber)
                || (Light == ConsoleColor.Red && _secondsElapsedInCycle == _durationRedAll + _durationRedJustThis))
            {
                //switch
                _secondsElapsedInCycle = 0;
                SetNextLightColor();
                Console.ForegroundColor = Light;
                Console.WriteLine($"current light color is ... {Light}");
            }




        //hmm okay i see...
        //internally within this single class...
        //I'M SUBSCRIBING to the event that raised INTERNALLY by the system whenever time passes.
        }
    }


    //yagni / kis --> do simplest implementation first: all vehicles are 1 size and all listen directly to lights only 
    class VehicleGenerator
    {

    }


    class OntarioStandards
    {

        public static readonly int RedMinAll = 2; //all directions...
        public static readonly int RedMaxAll = 4;
        public static readonly int AmberMin = 3;
        public static readonly int AmberMax = 5;
        public static readonly int Green = 24; //hardcoded assuming only four lanes...

    }

}
