using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_events_delegates_ohmy;

namespace cs_lesson_leaky_abstraction_defence
{
    class Car
    {
        private readonly List<Person> _passengers = new List<Person>();

        public List<Person> Passengers
        {
            get { return _passengers; }
            //set's absense defends against leaky abstraction
        }

        public Person Driver { get; set; }

        public int NumOccupants
        {
            get
            {
                //int val = (Passengers != null) ? Passengers.Count : 0;
                int val = Passengers.Count;
                int v = (Driver != null) ? 1 : 0;
                return val + v;
            }
        }

        // defends against leaky abstraction
        public IEnumerable<Person> Boys
        {
            get { return Passengers.Where(p => p.Gender == Person.Genders.MALE); }
        }
        public IEnumerable<Person> Girls
        {
            get { return Passengers.Where(p => p.Gender == Person.Genders.FEMALE); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Driver = new Person();
            //car.Passengers.Add(new Person());
            //car.Passengers.Add(new Person());
            //car.Passengers.Add(new Person());
            Console.WriteLine(car.NumOccupants);
            Console.ReadKey();


            foreach (var passenger in car.Passengers)
            {
                passenger.FeelsFat();
            }

            //this is impossible deliberately now
            //since the *original* list reference isn't returned. 
            car.Passengers = null;
            car.Boys.RemoveAt(1);

        }

    }
}
