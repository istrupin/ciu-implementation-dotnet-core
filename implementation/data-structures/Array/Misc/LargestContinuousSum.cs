using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class LargestContinuousSum
    {
        public static int LongestContSum(int[] arr)
        {
            int lastMax = arr[0];
            int currMax = arr[0];
            int sum = 0;
            
            for (int i = 0; i < arr.Length; i++)
            { 
                sum = arr[i];
                currMax = sum;
                for (int j = i+1; j < arr.Length; j++)
                {
                    sum += arr[j];
                    currMax = (sum > currMax) ? sum : currMax;
                }
                lastMax = (currMax > lastMax) ? currMax : lastMax;
            }
            return lastMax;
        }
        public static int LargestContSumBetter(int[] arr) 
        {
            int max = arr[0];
            int sum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                sum = Math.Max(sum + arr[i], arr[i]);
                max = Math.Max(sum, max);
            }
            return max;
        }
    }
}