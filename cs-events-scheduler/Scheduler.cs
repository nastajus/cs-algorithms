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
            public string Phone { get; }

            //todo: fix leaky abstraction
            public string Email { get; set; } //should any class be allowed  to set email???

            public User(string name, string phone)
            {
                Name = name;
                Phone = phone;
            }
        }

        class Mock
        {
            //todo: ponder when do i ever want a private constructor...
            public Mock()
            {
                //compiler error: an object reference is required for the non-static field, method, property 'Scheduler.registeredUsers'
                //is this a good idea to convert to static??? welll... if i do ... then the scheduler may as well be static too... then... this begs the question, would i ever want 2+ concurrent scheduler instances? i suppose , sure... why not... no reason to limit that...
                registeredUsers.Add(new User(GetRandomName(), "111-111-1111"));
                registeredUsers.Add(new User(GetRandomName(), "222-222-2222"));
                registeredUsers.Add(new User(GetRandomName(), "234"));
            }

            private string GetRandomName()
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
