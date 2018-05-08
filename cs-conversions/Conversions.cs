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
    }

    class HumanDailyNeeds
    {
        private int foodCalories = 2000;
        private int sleepHours = 8; 


    }
}
