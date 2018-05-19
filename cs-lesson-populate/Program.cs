using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cs_lesson_populate
{
    class Program
    {
        static void Main(string[] args)
        {
            int foo = 3;
            var x = 5;
            var str =
@"name:dante
age:26
website:http";

            Dog dog = new Doberman();
            dog.name = "fido";


            Type xxx = 1.GetType();
            Console.WriteLine(xxx);
            //"System.Int32"

            Type type1 = dog.GetType();
            Console.WriteLine(type1);

            Type type2 = typeof(Dog);
            Console.WriteLine(type2);
            //"sl_cs.Program.Dog"

            Type type3 = typeof(Dog).GetType();
            Console.WriteLine(type3);
            //"sl_cs.Program.Dog"

            Type type4 = type1.GetType();
            Console.WriteLine(type4);
            //"sl_cs.Program.Dog"

            var typeType = typeof(Type);

            var test1 = type1 == type2;
            var test2 = type2 == type3;
            var test3 = type3 == type1;


            var dante = new Person();


            var lassie = new Dog();
            SetNameOfThing(dante, "Dnate");
            SetNameOfThing(lassie, "Lassie");


            DmlPopulate(str, dante);
        }

        static void SetNameOfThing(object p, string name)
        {
            Type pType = p.GetType();
            if (pType.Name == typeof(Dog).Name || pType.Name == typeof(Person).Name)
            {
                //remember the ... doesn't have any info on the instance itself, despite ... coming from instance
                pType.GetField("name").SetValue(p, name);
            }  //System.ArgumentException: 'Field 'name' defined on type 'cs_sl.Program+Person' is not a field on the target object which is of type 'System.RuntimeType'.'


        }

        public class Person
        {
            public string name;
            public string age;
            public string website;

        }
        public class Dog
        {
            public string name;
            public string age;
        }

        public class Doberman : Dog
        {
            public void Bark()
            {
                Console.WriteLine("Woof!");
            }
        }

        static void DmlPopulate(string str, object obj)
        {
            var lines = str.Split('\n');

            var fields = new Dictionary<string, FieldInfo>();

            foreach (var fieldInfo in obj.GetType().GetFields())
            {
                fields.Add(fieldInfo.Name, fieldInfo);
            }

            foreach (var line in lines)
            {
                var pieces = line.Split(':');
                if (pieces.Length != 2) throw new ArgumentException("The parameter is not valid DML", nameof(str));
                var fieldName = pieces[0];
                if (!fields.ContainsKey(fieldName)) continue;
                var info = fields[fieldName];
                info.SetValue(obj, pieces[1]);


                //"sl_cs.Program.Person.website; Type:string, ByteAlignment:2; Flags:Instace|public"
            }
        }
    }
}
