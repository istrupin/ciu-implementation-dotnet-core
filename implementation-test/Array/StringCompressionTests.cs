using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class StringCompression_should
    {
        [Theory]
        [InlineData("AAAAABBBBCCCC", "A5B4C4")]
        [InlineData("AAAABBBBCCCCCDDEEEE", "A4B4C5D2E4")]
        [InlineData("AAB", "A2B1")]
        [InlineData("AAAaaa", "A3a3")]
        [InlineData("AABBCC", "A2B2C2")]
        [InlineData("AABBCCAA", "A4B2C2")]
        public void CompressStringWithDictionary(string input, string expectedOutput)
        {
            var result = StringCompression.Compress(input);
            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("AAAAABBBBCCCC", "A5B4C4")]
        [InlineData("AAAABBBBCCCCCDDEEEE", "A4B4C5D2E4")]
        [InlineData("AAB", "A2B1")]
        [InlineData("AAAaaa", "A3a3")]
        [InlineData("AABBCC", "A2B2C2")]
        [InlineData("AABBCCAA", "A2B2C2A2")]
        public void CompressStringWithoutDictionary(string input, string expectedOutput)
        {
            var result = StringCompression.Compress2(input);
            Assert.Equal(expectedOutput, result);
        }
    }
}