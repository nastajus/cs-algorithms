using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{

    class Generics_Bookable
    {
        public static void Init()
        {
            Scheduler<Bookable> scheduler = new Scheduler<Bookable>();

            List<T> bookables = new List<T>();
            //COMPILER ERROR: The **non-generic** list... cannot be used... with type arguments... wait a minute...
            bookables.Add<T>(new YogaRoom());
        }
    }

    class Scheduler<T>
    {
        public List<T> bookable = new List<T>();

        public void Add<T>()
        {

        }
    }

    class Bookable
    {

    }

    class YogaRoom
    {
        public string RoomName;
    }
}
