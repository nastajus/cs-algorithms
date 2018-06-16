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

    //interface IEdible { }
    //interface ICreature { }

    // ask myself, when making an interface (like List<T>), think what actions I want interacting (like Add(T) and T Get(i)).
    interface IEdible<TEdible>
    {
        //void GetsEaten(TEdible edible);
        //TEdible GiveTo(TPerson person);
        //TEdible Cooked(TRawEdible);
        //TEdible Ripens(TGrowable growable);
        TEdible Ripens(Plant plant);

    }

    interface IGrowable
    {
        void Grow(Plant plant);
    }

    class Plant { }
    class Food { }

    //class GreenHouse<TEdible>
    class GreenHouse<IGrowable>
    {
        void GetsSunlight()
        {

        }
    }

    /*
    class Edible { }
    class Waste { }
    class Person { }
    class Animal { }
    */

    //class Person : ICreature<>

}
