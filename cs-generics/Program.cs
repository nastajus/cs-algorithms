using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Box { }
        public class Kittens { }

        //public void Unwrap (Box<Kittens> boxOfKittens) { }  //Error: The non-generic type 'Box' cannot be used with type arguments.

        //public T Unwrap (Box<T> boxThings) { return new T(); } //Error: The non-generic type 'Box' cannot be used with type arguments.   //Error: The type or namespace 'T' cannot be found.

        //public T Unwrap(Box<T> boxOfKittens) as T { }

    }
}
