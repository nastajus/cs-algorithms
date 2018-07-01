using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_linq
{
    class Runner
    {
        static void Main(string[] args)
        {
            RatsAndMice rm = new RatsAndMice();
            rm.Run();

            //compiler error:  Member 'RatsAndMice.Run()' cannot be accessed with an instance reference; qualify it with a type name instead

                //rm is an instance
                //.Run() in `rm.Run()` is *using* an instance reference (my words)

                //qualify
                //qualify it with a type name instead
                //*use* an type name (my words)

            RatsAndMice.Run();

        }
    }
}
