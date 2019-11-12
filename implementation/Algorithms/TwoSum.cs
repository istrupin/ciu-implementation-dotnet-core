using System;
using System.Collections.Generic;

namespace implementation.Algorithms
{
    public static class TwoSum
    {
        public static int[] SumNaive(int[] nums, int target) 
        {
            // Given an array of integers, return indices of the two numbers such that they add up to a specific target.
            // You may assume that each input would have exactly one solution, and you may not use the same element twice.
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];
                    if (sum == target)
                    {
                        return new []{i,j};
                    }
                }
            }
            throw new Exception("Unable to find matching numbers");
        }

        public static int[] SumFaster(int[] nums, int target) 
        {
            var dict = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                var complement = target - value;
                if (dict.TryGetValue(complement, out int result))
                {
                    return new[]{i, result};
                }
                dict[value] = i;
            }
            throw new Exception("Unable to find numbers");
        }
    }
}