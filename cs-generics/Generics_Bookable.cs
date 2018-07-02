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

        //this might be the core cause of my faults here... now... maybe...

        //RESHARPER WARNING: Type paramater 'T' has the same name as the type parameter from outer type 'Scheduler<T>'
        public void Add(T t)
        {
            //COMPILER ERROR: Cannot convert from 'T [C:\...Generics_Bookable.cs(26)]' to 'T [C:\...Generics_Bookable.cs(22)]'
            bookable.Add(t);
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
