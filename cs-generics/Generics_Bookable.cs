using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{


    // smouldering dumpster fire
    // T of what?
    // T of the one damn class I don't care about? 
    // T of OMG.
    //the logic ... isn't logical... time to die

    class Generics_Bookable<T>
    {
        public static void Init()
        {
            List<T> bookables = new List<T>();
            //COMPILER ERROR: The **non-generic** list... cannot be used... with type arguments... wait a minute...
            bookables.Add<T>(new YogaRoom());
        }
    }

    class Bookable<T>
    {

    }

    class YogaRoom
    {
        public string RoomName;
    }
}
