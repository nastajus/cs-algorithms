using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{

    // compiler doesn't have any idea what "T" is about... but i can create an object instance that concretizes with an existing type...
    public class MyGenericClass<T>
    {
        public T MyNumber { get; set; }
    }

    class Generics_Angel
    {
        public static void Init()
        {
            var c = new MyGenericClass<int>();
            // accessible : c.MyNumber;
        }
    }
}
