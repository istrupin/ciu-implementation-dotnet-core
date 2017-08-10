using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class ReverseSentence_Should
    {
        [Theory]
        [InlineData("   hello       world.    ", "world. hello")]
        public void ReverseInputtedSentenceAndRemoveSpaces(string input, string expectedOutput)
        {
            var result = ReverseSentence.Reverse(input);
            Assert.Equal(expectedOutput, result);
        }
    }
}