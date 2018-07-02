using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Bookable<T>
    {
        public static void Init()
        {
            List<Bookable<T>> bookables = new List<Bookable<T>>();
            //COMPILER ERROR: The **non-generic** list... cannot be used... wait a minute...
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
