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

    //"marker inteface"
    interface IBookable { }

    class YogaRoom : IBookable
    {
        public string RoomName;
    }
}
