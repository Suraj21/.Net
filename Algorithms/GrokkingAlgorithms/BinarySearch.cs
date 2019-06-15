using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms
{
    static class BinarySearch
    {
        /// <summary>
        /// Binary Search Method,
        /// Takes O(log n) logarithmic time to compute as compared to the O(n) Linear Time fo simple search
        /// Big O notation tells you how fast an algorithm is.
        /// Big O doesn’t tell you the speed in seconds.Big O notation lets you compare the number of operations.
        /// It tells you how fast the algorithm grows.
        /// BINARY SEARCH TO WORK MAKE SURE THE ARRAY IS SORTED FIRST
        /// </summary>
        /// <param name="object_List"></param>
        /// <param name="search_Item"></param>
        /// <returns></returns>
        public static object Binary_Search(List<int> object_List, int search_Item)
        {
            int? low = 0; // Low and high keep track of which part of the list you will search in.
            int? high = object_List.Count - 1;
            int? mid = null;

            while (low <= high)
            {
                mid = (low + high) / 2; // Get the mid index
                int guess = object_List[Convert.ToInt32(mid)]; // Get the middle Element
                if (guess == search_Item)
                    return ++mid;
                else if (guess > search_Item) // The guess was too high
                    high = mid - 1;
                else        // The guess was too low
                    low = mid + 1;
            }
            return null;
        }
    }
}
