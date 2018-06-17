using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class Pet
    {
        public abstract void Walk();
    }

    class Dog : Pet
    {
        public override void Walk()
        {
            SmellButts();
            PeeHydrants();
        }

        void SmellButts() { }
        void PeeHydrants() { }
        void BarkRandomly() { }
    }

    class Goose : Pet
    {
        public override void Walk()
        {
            BiteHumans();
            PoopEverywhere();
        }

        void BiteHumans() { }
        void PoopEverywhere() { }
    }

    class PetWalker
    {
        //polymorphism makes a lot more sense when you introduce an object that uses the hierarchy
        void Walk(Pet pet)
        {
            pet.Walk();
        }
    }
}
