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

    //class Food { }

    /*
    class Food
    {
        //protein
        //carb
        //fat
        //etc.
    }
    */

    //interface IEdibleConsumer { }
    //interface ICreatureBehavior { }

    interface IEdibleConsumer<TEdible>
    {
        //bool Hungry;
        //bool Hungry { get; private set; } --> decidedly don't want "Hungry" in interface then.

        bool CanEat();
        (Waste, Energy) Eat(TEdible edible);
        TEdible Regurgitate();
    }

    //class Food : TEdible { }
    class Food { }
    class ChewedFood : Food { }

    class Waste { }
    class Energy { }

    class Creature { }

    //class Bird : Creature
    //class Bird : Creature<Food>
    //class Bird<Food> : Creature

    //Error on interface: 'Bird' does not implement interface member 'IEdibleConsumer<Food>.Eat(Food)'. 'Bird.Eat<Food>' cannot implement an interface member because it is not public
    class Bird : Creature, IEdibleConsumer<Food>
    {
        public bool CanEat()
        {
            throw new NotImplementedException();
        }

        (Waste, Energy) Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            return new ChewedFood();
            throw new NotImplementedException();
        }

        //public ChewedFood Regurgitate()
        //{
        //    throw new NotImplementedException();
        //}
    }

    class Person : IEdibleConsumer<Food>
    {
        public bool CanEat()
        {
            throw new NotImplementedException();
        }

        (Waste, Energy) IEdibleConsumer<Food>.Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public void Eat(Food edible)
        {
            throw new NotImplementedException();
        }

        public Food Regurgitate()
        {
            return null; //do nothing;
        }
    }

    /*
    class Edible { }
    class Person { }
    class Animal { }
    */

    //class Person : ICreature<>

}
