using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class LargetsContinuousSum_Should
    {
        [Theory]
        [InlineData(new [] { 0, -4, -5, -1, -2, 2, -10 }, 2)]
        [InlineData(new [] { 1 }, 1)]
        [InlineData(new [] { 1, 2, -1, 3, 4, -1 }, 9)]
        [InlineData(new [] { 1, 2, -1, 3, 4, 10, 10, -10, -1 }, 29)]
        [InlineData(new [] { -1, 1 }, 1)]
        [InlineData(new [] { -10, -1 }, -1)]
        public void FindLargestContinousSumUsingNestedLoopAlgo(int[] arr, int expectedOut)
        {
            var result = LargestContinuousSum.LongestContSum(arr);
            Assert.Equal(result,expectedOut);
        }
        [Theory]
        [InlineData(new [] { 0, -4, -5, -1, -2, 2, -10 }, 2)]
        [InlineData(new [] { 1 }, 1)]
        [InlineData(new [] { 1, 2, -1, 3, 4, -1 }, 9)]
        [InlineData(new [] { 1, 2, -1, 3, 4, 10, 10, -10, -1 }, 29)]
        [InlineData(new [] { -1, 1 }, 1)]
        [InlineData(new [] { -10, -1 }, -1)]
        public void FindLargestContinousSumUsingNotNestedAlgo(int[] arr, int expectedOut)
        {
            var result = LargestContinuousSum.LargestContSumBetter(arr);
            Assert.Equal(result,expectedOut);
        }
    }
}