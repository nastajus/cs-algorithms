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

        class YogaRoom
        {
            public string StudioName;

            enum StudioNames
            {
                BayDundas        ,
                RichmondSpadina  ,
                YongeEglinton    ,
                Vaughan          ,
                RichmondHill     ,
            }
        }

        class Mock
        {

            public static void Run(Scheduler scheduler)
            {
                scheduler._registeredUsers.Add(new User(GetRandomName(typeof(RandomNames)), "111-111-1111"));
                scheduler._registeredUsers.Add(new User(GetRandomName(typeof(RandomNames)), "222-222-2222"));
                scheduler._registeredUsers.Add(new User(GetRandomName(typeof(RandomNames)), "234"));
            }

            public static string GetRandomName(Type type)
            {
                //todo: analyze & internalize why this is wrong. again.
                // Symbol `Type` is a *type*  --> possibly called a "type variable"
                // Symbol `type` is a *variable*. --> possibly called a "value variable"???
                // typeof accepts TYPE VARIABLE... not a "VALUE VARIABLE"...
                return ((type) new Random().Next(Enum.GetNames(typeof(type)).Length)).ToString();
            }
        }

        enum RandomNames
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
