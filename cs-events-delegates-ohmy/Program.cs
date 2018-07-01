using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_events_delegates_ohmy
{
    class Person
    {
        delegate void VisitsGym(int val);

        private event VisitsGym GymActionHandler;

        public void MakesResolution()
        {
            GymActionHandler += LiftDumbbells;
            GymActionHandler += RunsElliptical;
        }

        void LiftDumbbells(int weight)
        {
            Console.WriteLine("Grunt like a bro");
        }

        void RunsElliptical(int minutes)
        {
            Console.WriteLine($"ran like a boss for {minutes} m");
        }

        public void FeelsFat()
        {
            GymActionHandler?.Invoke(3);
        }

    }

    class Life
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.MakesResolution();
            p.FeelsFat();
        }

    }
}
