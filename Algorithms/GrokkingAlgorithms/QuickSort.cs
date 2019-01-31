using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms
{
    public class QuickSort
    {
        public static List<int> QuickSortMethod(List<int> array)
        {
            List<int> result = new List<int>();
            if(array.Count < 2)
            {
                result = array.OfType<int>().ToList();
                return result;
            }
            else
            {
                int pivot = array[0]; // Recursive Array
                List<int> less = new List<int>(array.Count);
                List<int> greater = new List<int>(array.Count);

                int counter = 0;
                for (int i=1; i < array.Count; i++)
                {
                    if(array[i] <= pivot)
                    {
                        less.Add(array[i]);
                        counter++;
                    }
                }

                counter = 0;
                for (int i = 1; i < array.Count; i++)
                {
                    if(array[i] > pivot)
                    {
                        greater.Add(array[i]);
                        counter++;
                    }
                }
                result.AddRange(less);
                result.Add(pivot);
                result.AddRange(greater);
                if (less.Count > 0)
                {
                    result = QuickSortMethod(result);
                }
                return result;
            }
        }
    }
}
