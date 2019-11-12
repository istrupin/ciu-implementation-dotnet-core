using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;


namespace implementation_test.Algorithms
{
    public class TwoSumTests
    {

        [Theory]
        [InlineData(new int[] { 2,7,11,15 }, 9, new int[] { 0,1 })]
        [InlineData(new int[] { 3,2,4 }, 6, new int[] { 1,2 })]
        public void TwoSumCanFindIndexesNaively(int[] numbers, int target, int[] expectedResult){
            var res = TwoSum.SumNaive(numbers, target);
            res.Should().Equal(expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 2,7,11,15 }, 9, new int[] { 0,1 })]
        [InlineData(new int[] { 3,2,4 }, 6, new int[] { 1,2 })]
        [InlineData(new int[] { 3,3 }, 6, new int[] { 0,1 })]
        [InlineData(new int[] { 3,3,3 }, 6, new int[] { 0,1 })]

        public void TwoSumCanFindIndexesFaster(int[] numbers, int target, int[] expectedResult){
            var res = TwoSum.SumFaster(numbers, target);
            res.Should().BeEquivalentTo(expectedResult);
        }

    }
}