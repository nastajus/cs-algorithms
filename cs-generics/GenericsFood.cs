using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
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

    interface IEdible<TEdible>
    {

    }

    interface ICreature<TEdible>
    {
        void Eats(TEdible edible);      //probably or possibly a bad usage of TEdible??
                                        //decidedly. doesn't follow principles in {cs_generics} 
    }

    /*
    class Edible { }
    class Waste { }
    class Person { }
    class Animal { }
    */

    //class Person : ICreature<>

}
