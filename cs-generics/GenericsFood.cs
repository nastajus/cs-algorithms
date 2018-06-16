using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics_food
{
    class GenericsFood
    {
        //main
    }

    interface IEdibleConsumer<TEdible>
    {
        //bool Hungry;
        //bool Hungry { get; private set; } --> decidedly don't want "Hungry" in interface then.

        bool CanEat();
        (Waste, Energy) Eat(TEdible edible);
        TEdible Regurgitate();
    }

    /// <summary>
    /// for the purposes of this exercise, "Food" will be considered "needs complete digestion still", and can reside in Rumin and Gizzard stomachs unmodified. 
    /// </summary>
    class Food { }

    //"Chewed Food" is no longer accurate for both Cows and Birds, but I still want a singular representative state for after a partial stay in one of the stomachs --> renaming to Partially Digested Food
    //class ChewedFood : Food { }

    /// <summary>
    ///  result of some special animal stomachs, but still containing nutrients.
    /// </summary>
    class PartiallyDigestedFood : Food { }

    class Waste { }
    class Energy { }

    class Creature
    {
        public bool Hungry { get; protected set; } // --> yes, this

    }


    class Stomach
    {
        private const int MIN_SATIETY = 0;
        private const int MAX_SATIETY = 100;

        // fullness is misleading now since there's multiple stomachs. --> replace with Satiety
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
        public bool CanEat()
        {
            //Hungry = false;   //--> test, good! 
            throw new NotImplementedException();
        }

        public (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            return new PartiallyDigestedFood();
        }

    }

    class Cow : Creature, IEdibleConsumer<Food>
    {
        public bool CanEat()
        {
            throw new NotImplementedException();
        }

        public (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            throw new NotImplementedException();
        }
    }

    class Person : Creature, IEdibleConsumer<Food>
    {
        public bool CanEat()
        {
            throw new NotImplementedException();
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
