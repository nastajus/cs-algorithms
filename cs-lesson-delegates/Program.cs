using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs_lesson_types
{
    class Program
    {

        static DogHandler pendingAction = null;


        static void Main(string[] args)
        {

            var thread = new Thread(SeparateThread);

            Action a1 = SeparateThread;

            Action a2 = delegate { Console.WriteLine("Waddup"); };

            // WILL NOT WORK:
            // var a3 = delegate { Console.WriteLine("Waddup"); };

            // Default is also target-typed.
            int x = default;



            a.GetType();

            Action<Animal> d = Pet;

            d.GetType();

            Action<Dog> a5 = d;

            a5.GetType();
            thread.Start();

            Dog fido = new Dog();

            //read right-to-left:  instance of dog which is a class being assigned to a variable of animal which is a class type
            Animal a = fido;

            //read right-to-left:  instance of a method which is a delegate being assigned to a variable of dog handler which is a delegate type 
            DogHandler petter = Pet;
            //var threader = SeparateThread;

            while (false)
            {
                // Update UI
                Thread.Sleep(10);
                Console.WriteLine("Updated UI!");
            }


            Func<Animal, Animal> evolve = Mutate;

            var TMNF = evolve(fido);

            Func<Animal, Chemical, Animal> mutateWithChemical = Mutate;

            {
                var ImTiredOfComingUpWithVariableNames = "yooooo";
                Console.WriteLine(ImTiredOfComingUpWithVariableNames);
            }


            bool TryShop(DogHandler job, int money)
            {
                if (money % 2 == 0)
                {
                    job(fido);
                    return true;
                }
                return false;
            }

            //
            DogHandler wrapDog = (dog) =>
            {
                Console.WriteLine("Doggo " + dog + " is being wrapped. Obviously not as cool as " + TMNF);
            };

            TryShop(wrapDog, 1000);

            pendingAction = wrapDog;

        }

        //target-typed in Java not C#.
        //Dictionary<Dog, List<Animal>> friends = new Dictionary<>();

        //target-typed C#
        //int foo = default; //goes to 0 instead of say null.

        static void SeparateThread()
        {
            Console.WriteLine("Yo!");
        }


        //example of method group: Pet
        static void Pet(Animal a)
        {

        }

        static void Pet(Animal a, int numPets)
        {

        }

        public static Animal Mutate(Animal animal, Chemical chemical) { return null; }

        public static Animal Mutate(Animal animal) { return null; }

    }

    //delegate type definition:
    public delegate void DogHandler(Dog theDog);

    public class Chemical
    {
    }

    // class type definition 
    public class Animal { }
    public class Dog : Animal { }

}
