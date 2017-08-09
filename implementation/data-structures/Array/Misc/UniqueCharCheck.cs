using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class UniqueCharCheck
    {
        public static bool CheckUnique(string input)
        {
            var charHash = new HashSet<Char>(input.ToCharArray());
            return charHash.Count == input.Length;
        }
    }
}