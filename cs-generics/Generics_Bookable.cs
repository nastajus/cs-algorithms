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
            Scheduler<IBookable> scheduler = new Scheduler<IBookable>();

            //COMPILER ERROR: cannot convert from YogaRoom to IBookable
            scheduler.Book(new YogaRoom());



            List<T> bookables = new List<T>();
            //COMPILER ERROR: The **non-generic** list... cannot be used... with type arguments... wait a minute...
            bookables.Add<T>(new YogaRoom());
        }
    }

    class Scheduler<T>
    {
        public List<T> bookable = new List<T>();

        public void Book(T t)
        {
            bookable.Add(t);
        }
    }

    //empty interface ... is this a code smell? 
    interface IBookable
    {

    }

    class YogaRoom : IBookable
    {
        public string RoomName;
    }
}
