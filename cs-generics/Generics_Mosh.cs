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

                // we want to assume that both (a) and (b) both implement the IComparable interface
                // How Would I have Discovered This Without YouTube / Instruction ?
                //  I would've *needed* to be taught.
                // I **cannot** lookup operators like < or > , they are not defined in any C#-readable syntax... it is in the compiler itself

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
