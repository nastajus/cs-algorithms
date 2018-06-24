using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Pet_Walker
    {
        public static void Init(string[] args)
        {
            PetWalker pw = new PetWalker();

            Dog lassie = new Dog {Name = "Lassie", FurColor = "Golden", Attitude = "Heroic" };

            pw.Walk(lassie);

            Goose carl = new Goose{Name = "Carl", Attitude = "Asshole", FeatherColor = "Snow White" };

            pw.Walk(carl);

        }
    }

    abstract class Pet
    {
        public abstract void Walk();
        public string Name;
        public string Attitude;
        public string Color { get; protected set; }
    }

    class Dog : Pet
    {
        public string FurColor { get => Color; set => Color = value; }

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
        public string FeatherColor { get => Color; set => Color = value; }

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
        public void Walk(Pet pet)
        {
            pet.Walk();
        }
    }
}
