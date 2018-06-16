using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics
    {
        static void Main(string[] args)
        {
        }
    }

    interface IFlyable <TCargo>
    {
        bool CanFly();
        TCargo GetCargo(); //take out.
    }

    //class Delorian
    //class Delorian : IFlyable
    //class Delorian : IFlyable<>
    //class Delorian : IFlyable<People> { }
    /*
    class Delorian : IFlyable<>
    {
        public bool CanFly()
        {
            throw new NotImplementedException();
        }

        public TCargo GetCargo()
        {
            throw new NotImplementedException();
        }
    }
    */
    
    class Delorian : IFlyable<TPerson>
    {
        public bool CanFly()
        {
            throw new NotImplementedException();
        }

        public TPerson GetCargo()
        {
            throw new NotImplementedException();
        }
    }

    //Error: Cannot resolve symbol TPerson
    //T is just a placeholder. You need to supply an actual type somewhere for T.
    //E.g. if you have List<T>, you could make a List<int> or List<string> 
    //Concretization


}
