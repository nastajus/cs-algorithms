using System;
using System.Runtime.InteropServices;

namespace cs_data_structures
{
    class Program
    {
        static void Main(string[] args)
        {

            StructsVersusClassesMemoryComparision();
            Tasks();

        }

        static void Tasks()
        {

        }

        static void StructsVersusClassesMemoryComparision()
        {
            //structs
            Fooss s = new Fooss();
            s.x = new Bar(1);
            s.y = new Bar(2);
            s.z = new Bar(3);

            Fooss t = new Fooss(new Bar(1), new Bar(2), new Bar(3));
            Fooss u = new Fooss(new Bar(1), new Bar(2), new Bar(3));

            //classes
            Fooc c = new Fooc();
            c.x = new Bar(1);
            c.y = new Bar(2);
            c.z = new Bar(3);

            Fooc d = new Fooc(new Bar(1), new Bar(2), new Bar(3));
            Fooc e = new Fooc(new Bar(1), new Bar(2), new Bar(3));

            //throws exception:
            //System.ArgumentException: 'Type 'cs_data_structures.Program+Bar' cannot be marshaled as an unmanaged structure; no meaningful size or offset can be computed.'
            //Console.WriteLine( "Bar size is: " + Marshal.SizeOf(typeof(Bar)) );

            Console.ReadLine();
            Console.ReadKey();
        }


        struct Fooss
        {
            public Bar x;
            public Bar y;
            public Bar z;

            public Fooss(Bar x, Bar y, Bar z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        class Fooc
        {
            public Bar x;
            public Bar y;
            public Bar z;

            public Fooc() { }

            public Fooc(Bar x, Bar y, Bar z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        class Bar
        {
            float f;
            public Bar(float f)
            {
                this.f = f;
            }
        }
    }
}
