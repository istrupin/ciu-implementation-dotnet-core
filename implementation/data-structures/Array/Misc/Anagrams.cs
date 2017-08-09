using System.Collections.Generic;


namespace Implementation.DataStructures.ArraySequence.Misc{

    public static class Anagrams {

        public static bool IsAnagram(string s1, string s2)
        {
            var hashOne = new Dictionary<string, int>();
            var hashTwo = new Dictionary<string, int>();

            foreach (var element in s1)
            {
                if (element != " ".ToCharArray()[0])
                {
                    hashOne[element.ToString().ToUpper()] = (hashOne.ContainsKey(element.ToString().ToUpper())) 
                        ? hashOne[element.ToString().ToUpper()] += 1 
                        : hashOne[element.ToString().ToUpper()] = 1;
                }
            }

            foreach (var element in s2)
            {
                if (element != " ".ToCharArray()[0])
                {
                    hashTwo[element.ToString().ToUpper()] = hashTwo.ContainsKey(element.ToString().ToUpper()) 
                        ? hashTwo[element.ToString().ToUpper()] += 1 
                        : hashTwo[element.ToString().ToUpper()] = 1;
                }
            }
            return AreEqual(hashOne, hashTwo);	
        }

        private static bool AreEqual(Dictionary<string, int> left, Dictionary<string, int> right)
        {
            if (left.Count != right.Count) return false;
            bool equal = true;
            foreach (var element in left)
            {
                if (element.Value != right[element.Key])
                {
                    equal = false;
                    break;
                }
            }
            return equal;
        }
    }
}