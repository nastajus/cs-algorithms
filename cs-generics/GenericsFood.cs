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

    class Creature
    {
        //Error on private: The accessor modifier of the accessor must be more restrictive than the property CS_generic_food.Creature.Hungry
        //Error on set: The accessibility modifier of the 'Creature.Hungry.set' must be more restrictive than the property or indexer 'Creature.Hungry' 

        //bool Hungry { get; private set; }

        //private bool Hungry { get; set; }     //--> insisted on autocompleting to private... grr.



        //this above error meesage sounds like it's written backwards
        //it's saying "set" must be MORE restrictive than Hungry itself.
        //but ... well... that got me thinking... what's the restrictiveness level of Hungry?
        //oooh... Hungry is private AND set is private

        //protected bool Hungry { get; private set; } //--> valid but undesired. decidedly don't want to "set" at Creature level.

        public bool Hungry { get; protected set; } // --> yes, this

    }

    //class Bird : Creature
    //class Bird : Creature<Food>
    //class Bird<Food> : Creature

    class Bird : Creature, IEdibleConsumer<Food>
    {
        public bool CanEat()
        {
            //Hungry = false;   //--> test, good! accessible! :D 
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
