using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class StringCompression
    {
        public static string Compress(string uncompressedString)
        {
            //string output = "";
            Dictionary<char, int> compDictionary = new Dictionary<char, int>();
            foreach (var element in uncompressedString)
            {
                if (compDictionary.TryGetValue(element, out int value))
                {
                    compDictionary[element]++;
                }
                else
                {
                    compDictionary.Add(element, 1);
                }
            }

            return String.Join("",compDictionary.Select(q => $"{q.Key}{q.Value}"));
        }

        public static string Compress2(string uncompressedString)
        {
            string output = "";
            int length = uncompressedString.Length;
            int i = 1;
            int c = 1;
            
            while (i < length)
            {
                if(uncompressedString[i] == uncompressedString[i-1])
                    c++;
                else
                {
                    output = output+uncompressedString[i-1] + c;
                    c = 1;
                }
                i++;
            }
            output = output+uncompressedString[i-1] + c;
            return output;
        }
    }
}