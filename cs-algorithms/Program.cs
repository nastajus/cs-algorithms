using System;
using static System.Console;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort(new int[] { 4, 3, 2, 1 });
            //BubbleSort({ 4, 3, 2, 1 });   //invalid [{..} not an expression, expression expected inside brackets]
            BubbleSort(new int[3]); //valid 
            BubbleSort(new int[0]);
            ReadKey();
        }

        static int[] BubbleSort(int[] arr)
        {
            //for loops on List are a bit more than 2 times cheaper than foreach loops on List.
            //Looping on array is around 2 times cheaper than looping on List.

            Write(arr + " ");
            foreach (var item in arr)
            {
                Write(item + " ");
            }
            WriteLine("");

            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("");

            return new int[0];
        }

        static void SelectionSort()
        {

        }

//        static void TimeComplexityCounter()
//        {
//            
//        }
    }
}
