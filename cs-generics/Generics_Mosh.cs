using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Mosh
    {
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        //  ^^^^^^^^^^^^^^^^^^^^^^^
        //  statement
        //         ^^^^^^^
        //         expression
        //                  ^ 
        //                  expression
        //                      ^
        //                      expression
            // operators? 
            //      a : b 
            //      which parts are really which types of syntactic scenarios? 
            // eh. w/e.
        }
    }
}
