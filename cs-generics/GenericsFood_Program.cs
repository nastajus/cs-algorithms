using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics_food
{
    class GenericsFood_Program
    {

        //is this a good place???
        // well it is the "runner" or "beginning" so it "may as well hold any relevant logic... 


        //like this, a satiety index

        // Dictionary < (Person, Apple), Satiety value > 
        // Dictionary < (Bird, Apple), Satiety value >
        Dictionary<(Person, Apple), int> satietyIndexBad = new Dictionary<(Person, Apple), int>();
        Dictionary<(Creature, Food), int> satietyIndex = new Dictionary<(Creature, Food), int>();




        Bird bird = new Bird();
        Cow cow = new Cow();
        Person person = new Person();



        //main method 


        //enumberable troth of endless food will occur here, feeding each a person, bird, and cow, all at different CanEat formulas. bird will have additional penalty of feeding babies intermittetly.

        //TODO : Later I'll transform Bird into an abstraction which has two derived classes: ParentBird and BabyBird, and BabyBird will super needy with it's hunger but require low energy food so it lasts a longtime... umm shoot... umm somehow... hmm...
    }

    interface IEdibleConsumer<TEdible>
    {
        //bool Hungry;
        //bool Hungry { get; private set; } --> decidedly don't want "Hungry" in interface then.

        bool CanEat();
        (Waste, Energy) Eat(TEdible edible);
        TEdible Regurgitate();
        Energy Digest(TEdible edible);
    }

    /// <summary>
    /// for the purposes of this exercise, "Food" will be considered "needs complete digestion still", and can reside in Rumin and Gizzard stomachs unmodified. 
    /// </summary>
    class Food { }

    /// <summary>
    ///  result of some special animal stomachs, but still containing nutrients.
    /// </summary>
    class PartiallyDigestedFood : Food { }


    class Apple : Food { }


    class Waste { }
    class Energy { }

    class Creature
    {
        //property
        public bool Hungry { get; protected set; } // --> yes, this

        //field
        public Stomach Stomach;
    }


    // is it good practice to couple differing semantic values like this? eh. why not.
    // i'm directly coupling Satiety range of 0 to 100  to Hunger Level. ok.
    public enum HungerLevel
    {
        //terms true when >=
        Starving = 0,
        Hungry = 15,
        Pekish = 45,
        Full = 75,
        Bloated = 90
    };


    class Stomach
    {
        private const int MIN_SATIETY = 0;
        private const int MAX_SATIETY = 100;

        private int _satiety;
        public int Satiety
        {
            get => _satiety;
            set
            {
                if (_satiety + value > 100) _satiety = MAX_SATIETY;
                if (_satiety - value < 0) _satiety = MIN_SATIETY;
            }
        }
        
        public List<Food> Contents = new List<Food>();

    }

    /// <summary>
    /// specialized stomach for Birds which use muscles and rocks to break down food more
    /// </summary>
    class Gizzard : Stomach { }

    /// <summary>
    /// specialized stomach for Cows which store food for later chewing, before final digestion in "normal" stomach.
    /// </summary>
    class Rumin : Stomach { }


    class Bird : Creature, IEdibleConsumer<Food>
    {
        /// <summary>
        /// Bird I'm declaring as a "moderately hungry" creature that needs to eat semi-frequently.
        /// </summary>
        /// <returns></returns>
        public bool CanEat()
        {
            return Hungry = Stomach.Satiety < (int) HungerLevel.Full;
        }

        public (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            return new PartiallyDigestedFood();
        }

        public Energy Digest(Food edible)
        {
            throw new NotImplementedException();
        }
    }

    class Cow : Creature, IEdibleConsumer<Food>
    {
        /// <summary>
        /// I'm declaring that Cow's energy needs are so high that they'll always eat until bloated.
        /// </summary>
        public bool CanEat()
        {
            return Hungry = Stomach.Satiety < (int) HungerLevel.Bloated;
        }

        public (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            throw new NotImplementedException();
        }

        public Energy Digest(Food edible)
        {
            throw new NotImplementedException();
        }
    }


    class Person : Creature, IEdibleConsumer<Food>
    {
        /// <summary>
        /// A person I'm declaring as having a deep capacity to wait a long time for food.
        /// </summary>
        public bool CanEat()
        {
            return Hungry = Stomach.Satiety < (int) HungerLevel.Hungry;
        }

        public (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            return null; //do nothing;
        }
    }


}
