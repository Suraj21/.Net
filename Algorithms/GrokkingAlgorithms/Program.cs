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
        }
    }
}
