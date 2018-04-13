using System;
using static System.Console;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort(new int[] { 2, 1 });
            BubbleSort(new int[] { 4, 3, 2, 1 });
            //BubbleSort({ 4, 3, 2, 1 });   //invalid [{..} not an expression, expression expected inside brackets]
            BubbleSort(new int[3]); //valid 
            BubbleSort(new int[0]);
            ReadKey();
        }

        static int[] BubbleSort(int[] array)
        {
            if (array.Length <= 1) return array;

            int[] sortedArray = new int[array.Length];

            //suppose 2 items passed in, new int[] { 2, 1 }

            for (int i = 0; i < array.Length - 1; i++)  //minus one here because below we look-ahead by one.
            //              ^^^^^^^^^^^^^^^^
            //              while "i" is less than ... is true, we execute the loop
            {
                var left = array[i];
                var right = array[i + 1];

                if (left > right)
                {
                    //swap (by reference?)
                    var temp = right;
                    right = left;   //by copy, lost
                    left = temp;    //by copy, lost
                }
            }
            WriteLine("Sorted: " + Utils.PrintArray(sortedArray));

            return sortedArray;
        }

        static void SelectionSort()
        {

        }

//        static void TimeComplexityCounter()
//        {
//            
//        }
    }

    class Utils
    {
        public static string PrintArray(int[] array)
        {
            string result = "";
            foreach (var item in array)
            {
                result += item + " ";
            }
            return result;
        }
    }
}
