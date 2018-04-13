using System;
using static System.Console;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort(new int[] { 2, 1 });
            BubbleSort(new int[] { 3, 2, 1 });
            BubbleSort(new int[] { 4, 3, 2, 1 });
            BubbleSort(new int[] { 7, 6, 5, 4, 3, 2, 1 });
            //BubbleSort({ 4, 3, 2, 1 });   //invalid [{..} not an expression, expression expected inside brackets]
           // BubbleSort(new int[3]); //valid 
           // BubbleSort(new int[0]);
            ReadKey();
        }

        static int[] BubbleSort(int[] array)
        {
            if (array.Length <= 1) return array;

            for (int i = 0; i < array.Length; i++)  
            {
                for (int k = 0; k < array.Length - 1 ; k++) //minus one here because below we look-ahead by one.
                {
                    var leftIdx = k;
                    var rightIdx = k + 1; //look-ahead by one.

                    if (array[leftIdx] > array[rightIdx])
                    {
                        //swap
                        var tempValue = array[rightIdx];
                        array[rightIdx] = array[leftIdx];
                        array[leftIdx] = tempValue;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Sorted: " + Utils.PrintArray(array));

            return array;
        }

        static void SelectionSort()
        {

        }

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
