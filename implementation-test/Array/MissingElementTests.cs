using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class MissingElement_Should
    {
        [Theory]
        [InlineData(new [] { 1, 3, 5, 4 }, new [] {3,1,5}, 4)]
        [InlineData(new [] { 1, 3, 3, 4 }, new [] {3,4,3}, 1)]
        [InlineData(new [] { 1, 3, 5, 5 }, new [] {3,1,5}, 5)]
        public void ReturnElementMissingFromSecondArray(int[] left, int[] right, int expectedOutput)
        {
            var result = MissingElement.FindMissing(left, right);
            Assert.Equal(expectedOutput, result);
        }
    }
}