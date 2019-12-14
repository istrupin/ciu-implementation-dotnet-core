using System.Collections.Generic;
using System.Text;

namespace implementation.Algorithms
{
    public static class ParenFinder
    {
        public static List<string> ShowParens(int pairs)
        {
            var sets = new List<string>();
            ParenHelper(sets, new StringBuilder(), pairs, pairs, 0);
            return sets;
        }

        public static void ParenHelper(List<string> validSets, StringBuilder stringBuilder, int leftUnused, int rightUnused, int openLeft)
        {
            if (rightUnused == 0)
            {
                validSets.Add(stringBuilder.ToString());
                return;
            }
            else
            {
                if (leftUnused > 0)
                {
                    ParenHelper(validSets, stringBuilder.Append('('), leftUnused - 1, rightUnused, openLeft + 1);
                }
                if (openLeft > 0)
                {
                    ParenHelper(validSets, stringBuilder.Append(')'), leftUnused, rightUnused - 1, openLeft - 1);
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

        }
    }
}