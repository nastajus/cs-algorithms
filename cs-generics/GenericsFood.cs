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

    class Bird : Creature, IEdibleConsumer<Food>
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
            return new ChewedFood();
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

    /*
    class Edible { }
    class Person { }
    class Animal { }
    */

    //class Person : ICreature<>

}
