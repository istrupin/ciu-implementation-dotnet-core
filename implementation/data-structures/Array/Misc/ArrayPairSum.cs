using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class ArrayPairSum
    {
        public static List<Tuple<int, int>> PairSum(int[] arr, int k)
        {
            HashSet<int> seen = new HashSet<int>();
            List<Tuple<int, int>> pairList = new List<Tuple<int, int>>();

            foreach (var element in arr)
            {
                var target = k - element;
                if (seen.Contains(target))
                {
                    pairList.Add(new Tuple<int, int>(target, element));
                }
                else
                {
                    seen.Add(element);
                }
            }
            return pairList;
        }
    }
}