using System;
using System.Collections.Generic;

namespace cs_loops
{
    class Program
    {
        static void Main(string[] args)
        {

            IteratingAndPrintingAnArrayOrCollection();
            Console.ReadLine();

        }

        static void IteratingAndPrintingAnArrayOrCollection()
        {
            int[] arr = new[] { 1, 5, 3, 4, 2 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();


            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            List<int> list = new List<int>(arr);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Dictionary<int, string> map = new Dictionary<int, string>
            {
                {1, "un"}
            };
            map.Add(4, "quatre");
            map.Add(2, "deux");

            foreach (var item in map)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            foreach (KeyValuePair<int, string> entry in map)
            {
                Console.Write(entry);
            }
            Console.WriteLine();


            foreach (var item in map)
            {
                Console.Write("Key: " + item.Key + " ");
                Console.Write("Value: " + item.Value + "   ");
            }
            Console.WriteLine();


        }
    }
}
