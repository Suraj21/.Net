using System;
using System.Collections.Generic;

namespace GrokkingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Algorithm");
            List<int> no_List = new List<int> { 1, 2, 4, 5, 6, 8, 9, 11, 13 };
            object result = BinarySearch.Binary_Search(no_List, 5);
            Console.WriteLine("Binary Search Result: " + result);

            no_List = new List<int> { 5, 4, 3, 6 };

            Console.WriteLine("no_List being passed to Sort result:");
            foreach (var item in no_List)
            {
                Console.WriteLine(item);
            }

            int[] selectionSortResult = SelectionSort.Selection_Sort(no_List.ToArray());

            Console.WriteLine("Selection Sort Result: \n");
            for (int i = 0; i < selectionSortResult.Length; i++)
            {
                Console.WriteLine(selectionSortResult[i]);
            }

            List<int> quickSortResult = QuickSort.QuickSortMethod(no_List);
            Console.WriteLine("Quick Sort Result: \n");
            foreach (var item in quickSortResult)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
