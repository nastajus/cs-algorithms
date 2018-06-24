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

        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static T Max<T>(T a, T b)
        {
            if (typeof(T) == typeof(int))
            {
                //right now it* thinks a is an OBJECT.
                a.      (auto-complete)
                    --> .GetHashCode
                    --> .Equals
                    --> .GetType
                    --> .ToString

                //cannot apply operator '>' to the operands of type 'T' and 'T'
                return (a > b) ? a : b;
            }

            return default(T);
        }

    }
}
