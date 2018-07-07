using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_generics_food;

namespace cs_generics
{
    class Generics_Main
    {
        public static void Main(string[] args)
        {
            Generics_Angel.Init();
            //Generics_Bookable.Init();
            Generics_Kittens.Init(args);
            Generics_Mosh.Init();
            Generics_Food.Init(args);
        }
    }
}
