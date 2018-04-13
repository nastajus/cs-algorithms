using System;
using static System.Console;
//using System.Windows.Forms;
//using System.Windows.Forms.dll;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //BubbleSort(new int[] { 2, 1 });
            BubbleSort(new int[] { 3, 2, 1 });
           // BubbleSort(new int[] { 4, 3, 2, 1 });
           // BubbleSort(new int[] { 7, 6, 5, 4, 3, 2, 1 });
            //BubbleSort({ 4, 3, 2, 1 });   //invalid [{..} not an expression, expression expected inside brackets]
           // BubbleSort(new int[3]); //valid 
           // BubbleSort(new int[0]);
            ReadKey();
        }

        static int[] BubbleSort(int[] array)
        {
            if (array.Length <= 1) return array;

            //int[] sortedArray = new int[array.Length];

            //suppose 3 items passed in, new int[] { 3, 2, 1 }

            System.Diagnostics.Debug.WriteLine("Original: " + Utils.PrintArray(array));
            //for (int i = 0; i < 2; i++)
            for (int i = 0; i < array.Length - 1; i++)  //minus one here because below we look-ahead by one.
            {
                //for (int k = 0;    k < 2,1,0; k++)
                for (int k = 0; k < i ; k++) 
                {
                    var leftIdx = k;
                    var rightIdx = k + 1;

                    if (array[leftIdx] > array[rightIdx])
                    {
                        //swap
                        var tempValue = array[rightIdx];
                        array[rightIdx] = array[leftIdx];     //by copy, preserved
                        array[leftIdx] = tempValue;             //by copy, preserved
                    }
                    System.Diagnostics.Debug.Write("[" + i + "," + k + "] " + Utils.PrintArray(array));
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("Sorted: " + Utils.PrintArray(array));
            System.Diagnostics.Debug.WriteLine("======");

            return array;
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
