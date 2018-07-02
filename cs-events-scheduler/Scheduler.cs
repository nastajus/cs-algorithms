using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_events_scheduler
{
    class Scheduler
    {
        static void Main(string[] args)
        {
            Run();

            //reconcile inconsistent mocking ... eh whatever
            YogaStudios.Mock();
        }

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

        Scheduler()
        {
            Mock.Run(this);
            ShowRegisteredUsers();

        }

        readonly List<User> _registeredUsers = new List<User>();
        public IEnumerable<User> RegisteredUsers => _registeredUsers;

        public Bookable<T> RegisterBookable;

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

        class Bookable<T>
        {

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


        class Babysittable { }



        class YogaStudios
        {
            public static void Mock()
            {
                var rooms = new { venue = StudioNames.BayDundas, rooms = new { DundasRoomNames.Earth, DundasRoomNames.Fire } };
            }

            public enum StudioNames
            {
                BayDundas,
                RichmondSpadina,
                YongeEglinton,
                Vaughan,
                RichmondHill,
            }

            public enum DundasRoomNames
            {
                Fire,
                Wind,
                Water,
                Earth
            }

            public class YogaRoom
            {
                public string StudioName;
                public int NumInstructorsBookable;

            }
        }

        class Mock
        {

            public static void Run(Scheduler scheduler)
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
}
