using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ON = cs_events_vehicles.OntarioStandards;
using CsvHelper;
using CsvHelper.Configuration;

namespace cs_events_vehicles
{
    /// <summary>
    /// This will begin as a complete and an extremely simplified dual event system
    /// TrafficLights frequency will be designed to be slightly adaptable based on vehicle accumulation.
    /// VehicleTrafficGenerator will randomly spawn a periodic amount of cars that stop at the traffic lights
    /// Only once the above is complete do I allow myself to expand into A) graphical representation or B) a connected city block network
    /// </summary>
    class Program
    {
        public static int SystemSpeedFactor = 15;

        static void Main(string[] args)
        {
            TrafficLights lights = new TrafficLights(ON.RedMaxAll, ON.AmberMax, ON.Green, SystemSpeedFactor);

            VehicleTrafficGenerator vg = new VehicleTrafficGenerator(SystemSpeedFactor);

            lights.LightChanged += vg.OnLightChanged;

            Console.ReadKey();
        }
    }


    class TrafficLights
    {

        private const double _pulse = 1000;
        private Timer _aTimer = new Timer();

        private int _secondsElapsedInCycle = 0;

        private readonly int _durationRedJustThis;
        private readonly int _durationRedAll;
        private readonly int _durationAmber;
        private readonly int _durationGreen;


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

            Init();
        }

        public void Init()
        {
            //begin normal operations, on assumption it is the solitary light in existance. 
            Console.WriteLine("lights started");

            _aTimer.Enabled = true;
            /* Light = */ SetNextLightColor();

            //feels like pointless duplication... should be able to rewrite this somehow...
            Console.ForegroundColor = Light;
            Console.WriteLine($"current light color is ... {Light}");

        }

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


        /// <summary>
        /// begins as if was in durationGreen state initially
        /// 
        /// this method is += subscribed to the Timer's published ⚡ Elapsed event
        /// (internally in the same class scope that Timer is declared)
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

                // I wanna publish or emit or raise an event here... hmm...
                // so how about ... this! 
                LightChanged?.Invoke(Light);   //now... by itself... this isn't gonna trigger anything at this time... since I have subscribed to the LightChanged event yet.
            }
        }

        //i *think* this is called __Handler by convention... tbd
        public delegate void LightChangedToHandler(ConsoleColor cc);

        public event LightChangedToHandler LightChanged;


        // naming conventions:
        // https://stackoverflow.com/questions/724085/events-naming-convention-and-style


        // search for "convention"
        // https://www.codeproject.com/Articles/20550/C-Event-Implementation-Fundamentals-Best-Practices

    }


    //yagni / kis --> do simplest implementation first: all vehicles are 1 size and all listen directly to lights only 
    class VehicleTrafficGenerator
    {
        Timer _vgTimer = new Timer();
        Random _vgRandom = new Random();

        // kis ... for now bake road directly into VG class... no additional abstraction allowed...
        List<Vehicle> _lane1 = new List<Vehicle>();
        List<Vehicle> _lane2 = new List<Vehicle>();

        private VehicleGenerator _vg;

        public VehicleTrafficGenerator(int systemSpeedFactor = 1)
        {
            _vgTimer.Interval = 1000 / systemSpeedFactor;

            _vg = new VehicleGenerator();

            Init();
        }


        void Init()
        {


            //begins generating cars
            _vgTimer.Enabled = true;



        }
        

        public void OnLightChanged(ConsoleColor cc)
        {
            //Console.WriteLine("vehicles can move...");

            //for now... no limit the number of vehicles spawned...
            //SpawnVehicles();
            int numV = _vgRandom.Next(0, 2);
            while (numV-- > 0)
            {
                _lane1.Add(VehicleGenerator.Create());

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" - drove up: {_lane1.Last()}");

            }

        }
    }

    class VehicleGenerator
    {
        private static List<VehicleClassification> _possibleVehicles;

        public VehicleGenerator()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"data", $"vehicle classification systems worldwide.csv");
            _possibleVehicles = LoadCSV(path);

        }

        private List<VehicleClassification> LoadCSV(string path)
        {
            CsvReader csv = new CsvReader(new StreamReader(path));
            csv.Configuration.RegisterClassMap<ClassificationCSVMap>();
            csv.Configuration.Delimiter = ",";
            //csv.Configuration.HeaderValidated = null;
            //csv.Configuration.MissingFieldFound = null;
            List<VehicleClassification> vcs = csv.GetRecords<VehicleClassification>().ToList();
            return vcs;
        }

        internal class ClassificationCSVMap : ClassMap<VehicleClassification>
        {
            public ClassificationCSVMap()
            {
                Map(m => m.American).Name("Market segment (American English)");
                Map(m => m.British).Name("Market segment (British English)");
                Map(m => m.Australian).Name("Market segment (Australian English)");
                Map(m => m.Examples).Name("Examples");
                //Map(m => m.Examples).Name("Examples").ConvertUsing();
            }
        }

        internal class VehicleClassification
        {
            public string American;
            public string British;
            public string Australian;
            public string Examples;
            //public List<string> Examples = new List<string>();
        }

        public static Vehicle Create()
        {
            //int num = _possibleVehicles ?? _possibleVehicles.Count;
            //int? num = _possibleVehicles?.Count;
            if (_possibleVehicles == null || _possibleVehicles.Count <= 0)
            {
                throw new Exception("need data to spawn cars, problem getting data loaded.");
            }

            Random randomVehicleClassification = new Random();
            var whichNum = randomVehicleClassification.Next(_possibleVehicles.Count);
            var whichVehicle = _possibleVehicles[whichNum];


            var examples = whichVehicle.Examples.Split(new[] { "," }, StringSplitOptions.None).ToList();

            Random randomExample = new Random();
            var exampleNum = randomExample.Next(examples.Count);

            Vehicle v = new Vehicle(whichVehicle.American, examples[exampleNum]);
            
            return v;
        }

    }

    class Vehicle
    {
        public Vehicle(string marketSegment, string example)
        {
            MarketSegment = marketSegment;
            Example = example;
        }
        public string MarketSegment { get; private set; }
        public string Example { get; private set; }

        public override string ToString()
        {
            return Example;
        }
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
