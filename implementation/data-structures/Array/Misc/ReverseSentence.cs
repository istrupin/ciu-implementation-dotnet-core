using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.DataStructures.ArraySequence.Misc
{
    public static class ReverseSentence
    {
        public static string Reverse(string str) 
        {
            var word = String.Empty;
            var words = new Stack<string>();
            bool space = true;

            foreach (var character in str)
            {
                if (character != ' ')
                {
                    word = word + character;
                    space = false;
                }
                else if( character == ' ' && !space)
                {
                    words.Push(word);
                    word = String.Empty;
                    space = true;
                }
                else continue;
                
            }
            if (word.Length > 0)
            {
                words.Push(word);
                word = String.Empty;
            }
            
            var totalWords = words.Count - 1;
            StringBuilder sb = new StringBuilder();
            while (words.Count > 0)
            {
                sb.Append(new string(words.Pop().ToCharArray()));
                sb.Append(words.Count > 0 ? " " : "");
            }
            return sb.ToString();
        }
    }
}