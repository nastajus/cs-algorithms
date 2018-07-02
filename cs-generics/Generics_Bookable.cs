using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Bookable<T> where T : Bookable<T>
    {
        public static void Init()
        {
            List<T> bookables = new List<T>();
            //COMPILER ERROR: The **non-generic** list... cannot be used... with type arguments... wait a minute...
            bookables.Add<YogaRoom>(new YogaRoom());
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
