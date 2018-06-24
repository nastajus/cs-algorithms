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

            boxOfKittens.Add(new Kitten { Name = "Simba" });
            boxOfKittens.Add(new Kitten { Name = "Smokey" });
            boxOfKittens.Add(new Kitten { Name = "Max" });
            boxOfKittens.Add(new Kitten { Name = "Luna" });
            boxOfKittens.Add(new Kitten { Name = "Coco" });
            boxOfKittens.Add(new Kitten { Name = "Tigger" });

            Kitten unwrapped;
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
            unwrapped = boxOfKittens.Unwrap();
        }
    }


    class Box<TKitten>
    {
        private List<TKitten> _list = new List<TKitten>();

        public void Add(TKitten tkitten)
        {
            _list.Add(tkitten);
        }

        public TKitten Unwrap()
        {
            if (_list.Any())
            {
                var unwrapped = _list.Last();
                _list.Remove(unwrapped);
                return unwrapped;
            }
            return default(TKitten);
        }
    }

    class Kitten { public string Name { get; set; }}

}
