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
            Show();

        }

        //resharper tip: field can be made `readonly`
        readonly List<User> _registeredUsers = new List<User>();
        private IEnumerable<User> RegisteredUsers => _registeredUsers;

        void Show()
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

            public override string ToString()
            {
                return $"Name: {Name}, Phone: {Phone}";
            }
        }

        class Mock
        {

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
