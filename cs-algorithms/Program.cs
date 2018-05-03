using System;
//using static System.Console;
using static System.Diagnostics.Debug;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args) 
        {

            WriteLine("test");
            //SelectionSort(new int[] {3,2,1});
            SelectionSort(new int[] { 4, 3, 2, 1 });
            //SelectionSort(new int[] { 14, 5, 3, 12, 11, 1, 2 });
            

            BubbleSort(new int[] { 2, 1 });
            BubbleSort(new int[] { 3, 2, 1 });
            BubbleSort(new int[] { 4, 3, 2, 1 });
            BubbleSort(new int[] { 7, 6, 5, 4, 3, 2, 1 });
            //BubbleSort({ 4, 3, 2, 1 });   //invalid [{..} not an expression, expression expected inside brackets]
           // BubbleSort(new int[3]); //valid 
           // BubbleSort(new int[0]);
        }

        static int[] BubbleSort(int[] array)
        {
            if (array.Length <= 1) return array;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 ; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        //swap
                        var tempValue = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tempValue;
                    }
                }
            }
            WriteLine("Sorted: " + Utils.PrintArray(array));


            return array;
        }

        static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int smallestIdx = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallestIdx])
                    {
                        smallestIdx = j;
                    }
                }

                //swap
                if (smallestIdx != i)
                {
                    int tempVal = array[smallestIdx];
                    array[smallestIdx] = array[i];
                    array[i] = tempVal;
                }
            }
            WriteLine("sorted: " + Utils.PrintArray(array));
            return array;
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
