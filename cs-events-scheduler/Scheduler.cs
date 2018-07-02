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
            //compiler error: an object reference is required for the non-static field, method, or property 'Scheduler.Show()'
            //compiler error: cannot access non-static method 'Show' in static context
            
            //todo: resolve the decision pathway i took that made me put this here. oh.
            // i wanted Run() and Show() but didn't want to care about static/not at that moment.
            // still don't want to care....... well, do it.
            // 
            Show(this);
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
        }

        //todo: ponder if this is a good design. no? Should it be IEnumerable instead? 
        //well, it's fine as a list internally. why?
        // internal to this Scheduler class, i can wreak havoc on this poor list.
        // but externally i should only provide an IEnumerable, which, btw, is totally convertable back to a list.
        // the point is... this Scheduler should have complete control... nobody should be able to modify the list state externally.
        List<User> _registeredUsers = new List<User>();
        private IEnumerable<User> RegisteredUsers
        {
            get { return _registeredUsers; }
            //set { }
        }

        static void Show(Scheduler scheduler)
        {
            foreach (User user in scheduler.RegisteredUsers)
            {
                Console.WriteLine(user);
            }
        }


    class Timeblock
        {
            User who;
        }

        class User
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

            //compiler error:  Override method 'string cs_events_scheduler.Scheduler.User.ToString()' cannot change access rights
            //resoultion:  go to definition, resharper takes to decompiled assembly, see `public`, an important semantic difference in signature, match it. (also saw `virtual` as expected).
            public override string ToString()
            {
                return $"Name: {Name}, Phone: {Phone}";
            }
        }

        class Mock
        {
            //todo: ponder deeper questions of whether this is a good design long-term though.
            // since this Mock class is intended to be highly coupled to the Scheduler,
            // i see no downfall of this design.
            // let Mock be static, let it accept a Scheduler parameter, let it have copious instance references from that Scheduler, let this Mock class reside as an inner class inside Scheduler.

            public static void Run(Scheduler scheduler)
            {
                scheduler._registeredUsers.Add(new User(GetRandomName(), "111-111-1111"));
                scheduler._registeredUsers.Add(new User(GetRandomName(), "222-222-2222"));
                scheduler._registeredUsers.Add(new User(GetRandomName(), "234"));
            }

            private static string GetRandomName()
            {
                return ((RandomNames) new Random().Next(Enum.GetNames(typeof(RandomNames)).Length)).ToString();
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
