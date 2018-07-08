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
    /// TrafficLight frequency will be designed to be slightly adaptable based on vehicle accumulation.
    /// VehicleTrafficGenerator will randomly spawn a periodic amount of cars that stop at the traffic lights
    /// Only once the above is complete do I allow myself to expand into A) graphical representation or B) a connected city block network
    /// </summary>
    class Program
    {
        public static int SystemSpeedFactor = 15;

        static void Main(string[] args)
        {
            TrafficLight light = new TrafficLight(ON.RedMaxAll, ON.AmberMax, ON.Green, SystemSpeedFactor);

            RoadwayAcceptor roadway = new RoadwayAcceptor();

            VehicleTrafficGenerator vg = new VehicleTrafficGenerator(roadway, SystemSpeedFactor);

            //i'm questioning if this is the "right" place... especially now that I am considering burying it in a layer of abstraction...

            //in fact... i'd like to bury it... i don't wanna think about events at this top level... i don't think i should have to... except one concern is coupling.
            light.LightChanged += vg.OnLightChanged;

            Console.ReadKey();
        }
    }


    /// <summary>
    /// this class refers to the system of equipment necessary for a single roadway to operate, including TrafficLight, Camera, and TimingAdjusterAI.
    /// Not to be confused with a city-centralized controller, and not even 2-4 roadways for a complete intersection! 
    /// </summary>
    class TrafficLightAssembly
    {
        TrafficLightAssembly(int systemSpeedFactor, RoadwayAcceptor roadwayWatching)
        {
            TrafficLight tl = new TrafficLight(ON.RedMaxAll, ON.AmberMax, ON.Green, systemSpeedFactor);

            TrafficCamera tc = new TrafficCamera(roadwayWatching);
        }
    }

    /// <summary>
    /// detects cars in oncoming Roadway it faces (for now stay with lane1 hardcoding)
    /// </summary>
    internal class TrafficCamera
    {
        private RoadwayAcceptor _roadwayWatching;

        public TrafficCamera(RoadwayAcceptor roadwayWatching)
        {
            _roadwayWatching = roadwayWatching;
        }

        //can i modify Enqeue to emit an event when something happens? ehh...
        //i'd rather just do it from the vehicle... right?
        //what's the appropriate semantics here.... 
        //ultimately this entire program is all just a model that is of lesser accuracy than reality
    }

    /// <summary>
    /// this class represents current state & control of traffic lights as they move through phases like green, amber, red.
    /// </summary>
    class TrafficLight
    {
        //i *think* this is called __Handler by convention... tbd
        public delegate void LightChangedToHandler(ConsoleColor cc);
        public event LightChangedToHandler LightChanged;



        private const double _pulse = 1000;
        private Timer _aTimer = new Timer();

        private int _secondsElapsedInCycle = 0;

        private readonly int _durationRedJustThis;
        private readonly int _durationRedAll;
        private readonly int _durationAmber;
        private readonly int _durationGreen;


        public TrafficLight(int durationRedAll, int durationAmber, int durationGreen, int systemSpeedFactor = 1)
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
                LightChanged?.Invoke(Light);
            }
        }
    }


    //yagni / kis --> do simplest implementation first: all vehicles are 1 size and all listen directly to lights only 

    /// <summary>
    /// represents the endless stream of vehicles in an metropolitan urban area.
    /// </summary>
    class VehicleTrafficGenerator
    {
        private Timer _vgTimer = new Timer();
        private Random _vgRandom = new Random();
        private RoadwayAcceptor _ra;

        // seems strange to instantiate a variable but not perform any dot operations on it... yet i definitely want this constructor to run and continue to exist in-memory holding state. heh.
        private VehicleGenerator _vg;

        public VehicleTrafficGenerator(RoadwayAcceptor ra, int systemSpeedFactor = 1)
        {
            _vgTimer.Interval = 1000 / systemSpeedFactor;

            _vg = new VehicleGenerator();

            _ra = ra;

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
            int numV = _vgRandom.Next(0, 3);
            while (numV-- > 0)
            {
                _ra.Accept(VehicleGenerator.Create());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" - drove up: {_ra.RoadwayVehicles.Last()}");

            }
        }
    }

    /// <summary>
    /// probably can rename to just Roadway... 
    /// </summary>
    class RoadwayAcceptor
    {
        private Queue<Vehicle> _lane1 = new Queue<Vehicle>();
        private Queue<Vehicle> _lane2 = new Queue<Vehicle>();

        //would this make sense as an event instead? seems pointlessly over-complicated..
        public void Accept(Vehicle v)
        {
            // kis ... for now send all vehicles to lane1 only... no additional abstraction allowed...
            _lane1.Enqueue(v);
        }

        public IEnumerable<Vehicle> RoadwayVehicles { get {return _lane1; } }

    }

    /// <summary>
    /// this is coupled to the raw data loaded from the csv for vehicle types. 
    /// serves two main purposes:
    ///     1) abstracts away need to think about loading file,
    ///     2) Creating vehicle instances 
    /// </summary>
    class VehicleGenerator
    {
        private static List<VehicleClassification> _possibleVehicles;
        private static Random _randomVehicleClassification = new Random();
        private static Random _randomExample = new Random();

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
            }
        }

        internal class VehicleClassification
        {
            public string American;
            public string British;
            public string Australian;
            public string Examples;
        }


        public static Vehicle Create()
        {
            //int num = _possibleVehicles ?? _possibleVehicles.Count;
            //int? num = _possibleVehicles?.Count;
            if (_possibleVehicles == null || _possibleVehicles.Count <= 0)
            {
                throw new Exception("no data to create cars with.");
            }

            
            var whichNum = _randomVehicleClassification.Next(_possibleVehicles.Count);
            var whichVehicle = _possibleVehicles[whichNum];
            var examples = whichVehicle.Examples.Split(new[] {","}, StringSplitOptions.None).ToList();
            
            var exampleNum = _randomExample.Next(examples.Count);
            var example = examples[exampleNum];

            Vehicle v = new Vehicle(whichVehicle.American, example);
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
