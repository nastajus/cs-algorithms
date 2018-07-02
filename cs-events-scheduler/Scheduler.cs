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
            Mock();
        }

        static void Run()
        {
            //load up a list of existing schedules
            // listen for incoming `events` requests
            //  reply back with possibilities
            //   allow booking to different agencies, like Yoga teachers or Babysitters
            //    NOT use protobufs, nor GRPC. 
            //     these are to-be-run as native C# projects, to emphasize purely `events`

        }

        List<User> registeredUsers = new List<User>();

        class Timeblock
        {
            User who;
        }

        class User
        {
            public string Name { get; }
            public string Phone;

            public User(string name)
            {
                Name = name;
            }
        }

        class Mock
        {
            
        }
    }
}
