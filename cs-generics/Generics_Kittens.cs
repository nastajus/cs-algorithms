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


    class Box<TKitten>
    {
        public TKitten Unwrap()
        {
            //error: cannot implicitly convert type 'cs_generics.Kitten' to 'TKitten'
            //error: cannot implicitly convert expression type 'cs_generics.Kitten' to 'TKitten'
            return new Kitten();

        }
    }

    class Kitten { }

}
