using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_coupling_cohesion
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class rottweiler : Dog
    {

    }

    class Dog : Animal
    {

    }

    class Animal : Creature
    {

    }

    class Creature
    {

    }

    class Insect : Creature
    {

    }

    class Ladybug : Insect
    {

    }

    interface IGroomable
    {
        bool Groom();
    }


}
