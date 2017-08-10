using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class MissingElement
    {
        public static int FindMissing(int[] left, int[] right)
        {
            var d1 = new Dictionary<int, int>();
            var d2 = new Dictionary<int, int>();

            foreach (var element in left)
            {
                d1[element] = (d1.ContainsKey(element)) ? d1[element] + 1 : 1;
            }

            foreach (var element in right)
            {
                d2[element] = (d2.ContainsKey(element)) ? d2[element] + 1  : 1;
            }
            
            foreach (var kvp in d1)
            {
                if ((!d2.ContainsKey(kvp.Key)) || kvp.Value != d2[kvp.Key])
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
}