using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Mosh
    {
        public static void Init()
        {
            Max(1, 2);
        }

        public static T Max<T>(T a, T b)
        {
            //A constant value is expected 
            if (typeof(T) is typeof(int))
            {
                return (a > b) ? a : b;
            }

            return default(T);
        }

    }
}
