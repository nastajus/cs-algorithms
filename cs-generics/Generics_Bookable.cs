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
    // "marker interfaces"
    //  answer: no if compile-time id, yes if run-time id.
    //  quotes from Microsoft: https://stackoverflow.com/questions/7552677/are-empty-interfaces-code-smell
    
    // so my question now is
    //   is there a way to pass in any type without requiring it to implement my interface? 
    //   why do i care?
    //      1) i find implementing a hierachy messy to read. it increases difficulty of reading, for the gain of increased compiler-time writing ease.
    //      2) part of me wants to ENTIRELY AVOID any kind of "code smell"... 
    //   it doesn't matter.
    //   do it.
    //   i choose "the potentially smelly way" JUST to *climb to the top of the mountain of experience" ... just so I can read my peers code at work... 

    interface IBookable
    {

    }

    class YogaRoom : IBookable
    {
        public string RoomName;
    }
}
