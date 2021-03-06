﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_events_scheduler
{

    class Program
    {
        public static void Main(string[] args)
        {
            //reconcile inconsistent mocking ... eh whatever
            YogaStudios.Mock();

            Scheduler<IBookable> scheduler = new Scheduler<IBookable>();
            //scheduler.RegisterBookableLocation(new YogaTreeRoomBookable());



            Console.ReadKey();


        }
    }

    class Scheduler<T>
    {
        /// <summary>
        /// i had a reason for this static Run() method originally... it's being forgotten... 
        /// </summary>
        static void Run()
        {
            //load up a list of existing schedules
            // listen for incoming `events` requests
            //  reply back with possibilities
            //   allow booking to different agencies, like Yoga teachers or Babysitters
            //    NOT use protobufs, nor GRPC. 
            //     these are to-be-run as native C# projects, to emphasize purely `events`


            /*
             * - some kind of while loop
             * - some kind of event queuing
             * - some kind of event removing or executing here.
             */
        }

        public Scheduler()
        {
            Mock.Run(this);
            ShowRegisteredUsers();

        }

        private List<User> _registeredUsers = new List<User>();
        public IEnumerable<User> RegisteredUsers => _registeredUsers;

        /// <summary>
        /// todo: is intended to be the idempotent collection of venues *physically exist*, without consideration of *time availability*
        /// however then why use this AND resource Occupancy... 
        /// my mind wishes both... but i haven't determined the implementation that completely justifies both yet...
        /// </summary>
        private List<T> _bookingsLocations = new List<T>();


        //todo: decide data structure, if I want 1 or Many schedulers running, for 2 types of bookings...
        // oh, it must be 1 singular system. otherwise i'd lose the point of trying to have multiple events coming in... okay... okay! ... ManaObject! or ... something! 
        Dictionary<string, object> _resourceOccupancy = new Dictionary<string, object>();


        void ShowRegisteredUsers()
        {
            foreach (User user in RegisteredUsers)
            {
                Console.WriteLine(user);
            }
            //todo: ponder the value of using IEnumerable syntax here... oh... none.
            //my rule will be: use shorter code unless more verbosity solves another problem.
        }

        // Register█████blah is what is seen externally in my API designed for another developer to consume. for better or worse
        public bool RegisterBookableLocation(T bookable)
        {
            _bookingsLocations.Add(bookable);
            return true;
        }




        class Timeblock
        {
            User who;
        }


        //todo: resolve question of what does `public` mean for an inner class?
        public class User
        {
            public string Name { get; }
            public string Phone { get; }

            //todo: fix leaky abstraction
            public string Email { get; set; } //should any class be allowed  to set email???

            public User(string name, string phone)
            {
                Name = name;
                Phone = phone;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Phone: {Phone}";
            }
        }



        class Mock
        {

            public static void Run(Scheduler<T> scheduler)
            {
                scheduler._registeredUsers.Add(new User(GetRandomNameUser(), "111-111-1111"));
                scheduler._registeredUsers.Add(new User(GetRandomNameUser(), "222-222-2222"));
                scheduler._registeredUsers.Add(new User(GetRandomNameUser(), "234"));
            }

            //todo: do generically from a single Mocking location... at least the type names...
            public static string GetRandomName(Type type)
            {
                //todo: make this work
                //return ((type) new Random().Next(Enum.GetNames(typeof(type)).Length)).ToString();
                return null;
            }

            public static string GetRandomNameUser()
            {
                return ((RandomUserNames)new Random().Next(Enum.GetNames(typeof(RandomUserNames)).Length)).ToString();
            }

        }

        enum RandomUserNames
        {
            Martin      ,
            Alesia      ,
            Farrah      ,
            Quintin     ,
            Jeri        ,
            Clorinda    ,
            Bobette     ,
            Nana        ,
            Paulene     ,
            Lavone      ,
            Melania     ,
            Breana      ,
            Clifton     ,
            Dani        ,
            Margarette  ,
            Orval       ,
            Lyndia      ,
            Elmo        ,
            Teri        ,
            Eula        
        }
    }


    public class YogaStudios
    {
        public static void Mock()
        {
            // data structure design 1 : anonymous object
            // -----------------------
            // debating about choosing between anonymous object & nested dictionary, and converting between with reflection, or anything else?

            // reasoning:
            // ---------
            // eventually abandoned due to not wanting to explore using reflection to put into dictionaries... 
            // that i should explore manually populating dictionaries myself before worrying about automatic dictionary creation...
            var bookablesAnon = new { venue = StudioNames.BayDundas, rooms = new { BayDundas.BayDundasRoomNames.Earth, BayDundas.BayDundasRoomNames.Fire } };


            // data structure design 2 : dictionary of strings nesting list of strings... why? oh. see above.
            // -----------------------
            Dictionary<string, List<string>> bookablesDict = new Dictionary<string, List<string>>();



            #region defines dictionary of strings with nesting list of strings

            List<string> listDundasRooms = new List<string>();
            listDundasRooms.Add(BayDundas.BayDundasRoomNames.Earth.ToString());
            listDundasRooms.Add(BayDundas.BayDundasRoomNames.Fire.ToString());
            listDundasRooms.Add(BayDundas.BayDundasRoomNames.Wind.ToString());
            listDundasRooms.Add(BayDundas.BayDundasRoomNames.Water.ToString());

            bookablesDict.Add(StudioNames.BayDundas.ToString(), listDundasRooms);

            bookablesDict.TryGetValue(StudioNames.BayDundas.ToString(), out var value);
            value?.Add(BayDundas.BayDundasRoomNames.Wind.ToString());
            value?.Add(BayDundas.BayDundasRoomNames.Water.ToString());

            //verify contents of dictionary..
            foreach (KeyValuePair<string, List<string>> entry in bookablesDict)
            {
                foreach (string innerEntry in entry.Value)
                {
                    //this is ugly to read {entry} as fully qualified... yuck.
                    Console.WriteLine($"bookablesDict[\"{entry}\"][\"{innerEntry}\"] ... eh might work\n");
                }
            }

            #endregion


            // data structure design 3 : hash set of types
            // -----------------------
            //i want some kind of TUPLE to go here.... maybe a class instance is best?? what if i used class instances instead???
            
            // reason:
            // -------
            // ultimately arrived at conclusion that I wanted some kind of compile-time safety to prevent any invalid data going in...
            HashSet<YogaTreeRoomBookable> bookableHash = new HashSet<YogaTreeRoomBookable>();


            #region defines hash set of typed-everything

            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.BayDundas, new BayDundas("Fire")));
            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.BayDundas, new BayDundas("Earth")));
            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.BayDundas, new BayDundas("Water")));
            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.BayDundas, new BayDundas("Wind")));

            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.RichmondSpadina, new RichmondSpadina("One")));
            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.RichmondSpadina, new RichmondSpadina("Two")));
            bookableHash.Add(new YogaTreeRoomBookable(StudioNames.RichmondSpadina, new RichmondSpadina("Three")));

            //todo: move this to a separate unit test, see if i can capture the exception... i bet yes.
            //bookableHash.Add(new YogaTreeRoomBookable(StudioNames.RichmondSpadina, new RichmondSpadina("Four")));

            //verify contents of hash set
            foreach (YogaTreeRoomBookable yoroom in bookableHash)
            {
                Console.WriteLine(yoroom);
            }

            //bookablesDict.Add(StudioNames.BayDundas.ToString(), );

            #endregion 


        }

        public enum StudioNames
        {
            BayDundas,
            RichmondSpadina,
            YongeEglinton,
            Vaughan,
            RichmondHill,
        }






    }


    //i wanted to use Room or something as some kind of generalized way to force either  BayDundasRoomNames  or  RichmondSpadinaRoomNames to be supplied
    //WHAT I REALLY want is that ONLY BayDundas has Fire Earth Water Wind, and that ONLY SpadinaRichomd has One Two Three... 
    //so for all my fancy machinantions with enums and classes and overridding ToString and using property's private settings and throwing exceptions... none of this helps...
    // the only solution is to promote EVERYTHING to the class level...
    public interface IYogaTreeRoom
    {
        string RoomName { get; }
    }

    public abstract class YogaTreeRoom : IYogaTreeRoom
    {
        protected YogaTreeRoom() { } //this is upsetting, why do i need this, i don't want it to exist, i want it locked and inaccessible.
        protected YogaTreeRoom(string roomName)
        {
            RoomName = roomName;
        }

        private string _roomName;
        public string RoomName
        {
            get
            {
                return _roomName;
            }

            //only allowed via the constructor
            private set
            {
                if (Enum.IsDefined(typeof(BayDundas.BayDundasRoomNames), value) || Enum.IsDefined(typeof(RichmondSpadina.RichmondSpadinaRoomNames), value))
                {
                    _roomName = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("yo, please use one of the standard Yoga Studios names in the enums, pal");
                }
            }
        }

        public override string ToString()
        {
            return _roomName;
        }

    }

    public class BayDundas : YogaTreeRoom
    {
        // "constructor initializer" 
        // you get to specify which constructor in the base class should be invoked before the constructor of the derived class
        public BayDundas(string roomName) : base (roomName)
        {
            //base(roomName);

            //rely entirely on parent...
        }

        public enum BayDundasRoomNames
        {
            Fire,
            Wind,
            Water,
            Earth
        }
    }

    public class RichmondSpadina : YogaTreeRoom
    {
        public RichmondSpadina(string roomName) : base(roomName)
        {
            //rely entirely on parent...
        }

        public enum RichmondSpadinaRoomNames
        {
            One,
            Two,
            Three
        }
    }


    public class YogaTreeRoomBookable : IBookable
    {

        public YogaStudios.StudioNames StudioName; // { get; }
        public YogaTreeRoom RoomName { get; } // private set; } // todo: DO I NEED? TO TEST...
        public int NumInstructorsBookable;

        //COMPILER ERROR: base class YogaTreeRoom doesn't contain a parameterless constructor
        public YogaTreeRoomBookable(YogaStudios.StudioNames studioName, YogaTreeRoom roomName, int numInstructorsBookable = 1)
        {
            StudioName = studioName;
            RoomName = roomName;
            NumInstructorsBookable = numInstructorsBookable;
        }

        public override string ToString()
        {
            return $"{StudioName} . {RoomName} allows {NumInstructorsBookable} 1 instructor";
        }
    }


    class BabysittingHome : IBookable { }






    // "Marker interface"
    public interface IBookable { }




    //class Util
    //{
    //    void ConvertAnonymousObjectToNestedDictionary(object anonymousObject)
    //    {
    //
    //    }
    //}

}
