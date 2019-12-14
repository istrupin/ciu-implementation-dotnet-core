using System;
using System.Collections.Generic;
using System.Text;

namespace implementation.Algorithms
{
    public class IntReverser
    {
        public int Reverse(int x)
        {
            var limit = int.MaxValue / 10;

            var digits = x.ToString().ToCharArray();

            var stack = new Stack<int>();
            
            int multiplier = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '-')
                {
                    stack.Push(Math.Abs((int)Char.GetNumericValue(digits[i])));
                }
                else
                {
                    multiplier = -1;
                }
            }

            int popped;
            var sb = new StringBuilder();
            while (stack.TryPop(out popped))
            {

                var intVal = Convert.ToInt32(sb.ToString() == string.Empty ? "0" : sb.ToString()) * multiplier;
                if ((intVal) > (int.MaxValue / 10) || (intVal) < (int.MinValue / 10) ||(intVal == int.MaxValue && (popped > 7 || popped < -8)))
                    return 0;
                sb.Append(popped);
            }

            return Math.Abs(Convert.ToInt32(sb.ToString())) * multiplier;
        }
    }
}