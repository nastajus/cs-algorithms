using System;
using System.Collections.Generic;
using System.Linq;

namespace cs_conversions
{
    class Conversions
    {
        static void Main(string[] args)
        {
            ConvertArrayToList();
            ConvertListToArray();
            ConvertEnumToArrayStrings();
            //ConvertStringToInt();
            Dante1();
            Console.ReadKey();
        }

        static void ConvertArrayToList()
        {
            int[] arr = { 5, 1, 3, 4, 2 };
            List<int> list = arr.ToList();
        }

        static void ConvertListToArray()
        {
            List<int> list = new List<int>(new int[] { 5, 1, 3, 4, 2 });
            int[] arr = list.ToArray();
        }
        
        enum MyEnum { Monday, Tuesday, Wendesday }
        static void ConvertEnumToArrayStrings()
        {
            //Console.WriteLine((MyEnum[])Enum.GetValues(typeof(MyEnum)));
            foreach (var value in (MyEnum[])Enum.GetValues(typeof(MyEnum)) )
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        static void ConvertStringToEnum()
        {
            // throws ArgumentNullExceptionint
            int result1 = Int32.Parse(null);

            // doesn't throw an exception, returns 0
            int result2 = Convert.ToInt32(null);

        }



        //how many instance variables in the next 4 code lines?
        private static Person p1;

        static void Dante1()
        {
            var dante = new Person("Dante", "Camaron");
            p1 = dante;

            string s1 = "aasda";
            String s2 = "aasda";


            int notBoxed1 = 1;
            int notBoxed2 = 2;
            IntBox yesBoxed = new IntBox { value = 3 };
            NotBoxedInt notBoxed4 = new NotBoxedInt { value = 4 };

            Console.WriteLine("Sup");
            IntBox yesBoxCopy = yesBoxed;

            yesBoxCopy.value = 500;

            NotBoxedInt notBoxed4Copy = notBoxed4;
            notBoxed4Copy.value = 500;
            Console.WriteLine("Dawg");


            var me = new Person("Ian", "Nastajus", "Bryan");



        }
    }

    class IntBox
    {
        public int value;
    }

    struct NotBoxedInt
    {
        public int value;
    }


    class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }

        public Person(string firstName, string lastName, string middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
    }

    class HumanDailyNeeds
    {
        private int foodCalories = 2000;
        private int sleepHours = 8; 


    }
}
