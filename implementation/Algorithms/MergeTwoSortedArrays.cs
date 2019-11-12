using System;
using System.Collections.Generic;
using System.Linq;

namespace implementation.Algorithms
{
    public static class SortedArrayMerger
    {
        public static int[] MergeNaive(int[] arr1, int[] arr2){
            var arr3 = new int[arr1.Length + arr2.Length];
            Array.Copy(arr1,arr3,arr1.Length);
            var nextEmpty = arr1.Length;
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr3.Length; j++)
                {
                    if (arr2[i] <= arr3[j])
                    {
                        var current = arr3[j];
                        MoveForwardByOne(arr3,j);
                        arr3[j] = arr2[i];
                        nextEmpty++;
                        break; 
                    }   
                    else if (j == nextEmpty){
                        arr3[nextEmpty] = arr2[i];
                        nextEmpty++;
                        break;
                    }
                }
            }
            return arr3;
        }

        private static void MoveForwardByOne(int[] arr, int startIndex)
        {
            for (int i = arr.Length - 1; i > startIndex; i--)
            {
                arr[i] = arr[i-1];
            }
        }
    }
}