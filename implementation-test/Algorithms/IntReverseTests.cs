using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using System;

namespace implementation_test.Algorithms
{
    public class IntReverseTests
    {

        [Theory]
        // [InlineData(123, 321)]
        // [InlineData(1, 1)]
        // [InlineData(111, 111)]
        // [InlineData(2147483647, 1)]
        [InlineData(-2147483412, -2143847412)]
        // [InlineData(1534236469, 1)]


        
        // [InlineData(1111111113, 1)]
        // [InlineData(-123, 321)]

        public void SorterCanSortNaive(int x,int res )
        {
            var output = 0;

            var digits = x.ToString().ToCharArray();

            var stack = new Stack<int>();
            int multiplier = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '-')
                {
                    stack.Push((int)Char.GetNumericValue(digits[i]));
                }
                else
                {
                    multiplier = -1;
                }
            }

            int popped;
            var sb = new StringBuilder();
            var overflow = false;
            while (stack.TryPop(out popped))
            {
                var intVal = Convert.ToInt32(sb.ToString() == string.Empty ? "0" : sb.ToString()) * multiplier;
                if ((intVal ) > (int.MaxValue/10) || (intVal) < (int.MinValue/10))
                   {
                       overflow = true;
                       break;
                   }
                sb.Append(popped);

            }
            if(overflow){
                Assert.True(false);
            }
            else
            {
                output = Convert.ToInt32(sb.ToString()) * multiplier;
                output.Should().Be(res);
            }

            
        }



    }
}