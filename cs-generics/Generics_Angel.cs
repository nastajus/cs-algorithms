using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{

    public class MyGenericClass
    {
        public int MyNumber { get; set; }
    }

    class Generics_Angel
    {
        public static void Init()
        {
            var c = new MyGenericClass();
            // accessible : c.MyNumber;
        }
    }
}
