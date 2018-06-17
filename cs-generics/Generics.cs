using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{

    interface IFlyable <TCargo>
    {
        bool CanFly();
        TCargo DropCargo();
        //void PickupCargo(TCargo cargo);
    }
    
    class Delorian : IFlyable<TPerson>
    {
        public bool CanFly()
        {
            throw new NotImplementedException();
        }

        public TPerson DropCargo()
        {
            throw new NotImplementedException();
        }

        //public void PickupCargo(TPerson cargo)
        //{
        //    throw new NotImplementedException();
        //}
    }

    class Bird : IFlyable<TPoop>
    {
        public bool CanFly()
        {
            throw new NotImplementedException();
        }

        public TPoop DropCargo()
        {
            throw new NotImplementedException();
        }

        //public void PickupCargo(Object o) //(TPoop poop)
        //{
        //    throw new NotImplementedException();
        //}
    }

    class TPerson { }
    class TPoop { }

}
