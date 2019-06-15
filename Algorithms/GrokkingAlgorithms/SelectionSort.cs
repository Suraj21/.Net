using System;
using System.Collections.Generic;
using System.Text;

namespace GrokkingAlgorithms
{
    public class SelectionSort
    {
        public static int Find_Smallest_Element(int[] arrayObject)
        {
            int smallest = arrayObject[0];
            int smallest_index = 0;
            for (int i = 1; i < arrayObject.Length; i++)
            {
                if (arrayObject[i] < smallest)
                {
                    smallest = arrayObject[i];
                    smallest_index = i;
                }
            }

            return smallest;
        }

        /// <summary>
        /// Method to sort the array objects using selection sort algorithm
        /// </summary>
        /// <param name="objArray"></param>
        /// <returns></returns>
        public static int[] Selection_Sort(int[] objArray)
        {
            int temp, smallest = 0;

            for (int i = 0; i < objArray.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < objArray.Length; j++)
                {
                    if (objArray[j] < objArray[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = objArray[smallest];
                objArray[smallest] = objArray[i];
                objArray[i] = temp;
            }

            return objArray;
        }
    }
}
