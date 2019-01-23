using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms
{
    static class BinarySearch
    {
        public static object Binary_Search(List<int> object_List, int search_Item)
        {
            int? low = 0; // Low and high keep track of which part of the list you will search in.
            int? high = object_List.Count - 1;
            int? mid = null;

            while (Convert.ToInt32(low) < Convert.ToInt32(high))
            {
                mid = (Convert.ToInt32(low) + Convert.ToInt32(high)) / 2; // Get the mid index
                int guess = object_List[Convert.ToInt32(mid)]; // Get the middle Element
                if (guess == search_Item)
                    return mid;
                if (Convert.ToInt32(guess) > Convert.ToInt32(search_Item)) // The guess was too high
                    high = mid - 1;
                else        // The guess was too low
                    low = mid + 1;
            }
            return mid;
        }
    }
}
