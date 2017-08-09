using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;


namespace implementation_test
{
    public class Anagrams_should
    {
        [Theory]
        [InlineData("go go go", "gggooo")]
        [InlineData("hi man", "hi     man")]
        [InlineData("123", "31 2")]
        public void ReturnTrueIfStringsAreAnagrams(string left, string right)
        {
            var result = Anagrams.IsAnagram(left, right);
            Assert.True(result, $"{left} and {right} are not anagrams");
        }

        [Theory]        
        [InlineData("123", "1 2")]
        [InlineData("aabbcc", "aabbc")]
        public void ReturnFalseIfStringsAreNotAnagrams(string left, string right)
        {
            var result = Anagrams.IsAnagram(left, right);
            Assert.False(result, $"{left} and {right} are anagrams");
        }
    }
}