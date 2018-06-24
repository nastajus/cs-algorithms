using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Kittens
    {
        public static void Init(string[] args)
        {
            Box<Kitten> boxOfKittens = new Box<Kitten>();
            boxOfKittens.Unwrap();
        }
    }

    //useless
    class Box<TKitten>
    {
        public Kitten Unwrap()
        {
            return new Kitten();
        }
    }

    class Kitten { }

}
