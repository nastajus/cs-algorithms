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
            //the given expression is never of the provided ("int") type.
            //the given expression is never of the provided type.
            if (typeof(T) is int)
            {
                return (a > b) ? a : b;
            }

            return default(T);
        }

    }
}
