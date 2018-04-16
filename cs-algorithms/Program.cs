using System;
using static System.Console;

namespace cs_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            //SelectionSort(new int[] {3,2,1});
            SelectionSort(new int[] { 4, 3, 2, 1 });
            ReadKey();

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
                for (int k = 0; k < array.Length - 1 ; k++)
                {
                    if (array[k] > array[k + 1])
                    {
                        //swap
                        var tempValue = array[k + 1];
                        array[k + 1] = array[k];
                        array[k] = tempValue;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Sorted: " + Utils.PrintArray(array));

            return array;
        }

        //double-looping structure, is taken as basic premise for sorting,
        //as one pass can only conceivably operate upon one of n elements,
        //hence needing n passes over n elements.
        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //assign smallest known index position starting at left-most array entry (gotta start somewhere)
                int smallestIdx = i;

                //as examination proceeds linearly, only "new smallest" entires need be examined.
                //hence, iteration of j can "jump ahead" to latest "<i'th> value".
                //+1 needed here to prevent re-examining same smallest index, just assigned above
                for (int j = i + 1; j < array.Length; j++)
                {
                    //find smallest index 
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

                    System.Diagnostics.Debug.WriteLine("swap result *i=" + i + "* : " + Utils.PrintArray(array));
                    System.Diagnostics.Debug.WriteLine("swapped at *i=" + i + "* and ^smallestIdx:" + smallestIdx + "^.");
                }

                System.Diagnostics.Debug.WriteLine("smallestIdx is: " + smallestIdx);
            }
            System.Diagnostics.Debug.WriteLine("sorted: " + Utils.PrintArray(array));
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
