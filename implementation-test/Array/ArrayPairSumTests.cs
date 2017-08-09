using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class ArrayPairSum_should
    {
        [Theory]
        [InlineData(new [] { 1, 3, 2, 2 }, 4, 2)]
        [InlineData(new [] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 13, 14, 11, 13, -1  }, 10, 6)]
        [InlineData(new [] {1,2,3,1}, 3, 1)]
        
        public void OutputQuantityOfUniquePairsThatEqualK(int[] arr, int k, int count)
        {
            var result = ArrayPairSum.PairSum(arr, k);
            Assert.True(result.Count == count, $"Count of unique pairs summing to {k} is not {count}");
        }
    }
}