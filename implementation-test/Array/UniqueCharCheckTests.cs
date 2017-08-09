using Xunit;
using Implementation.DataStructures.ArraySequence.Misc;

namespace implementation_test
{
    public class UniqueCharCheck_Should
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("abA")]
        [InlineData("")]
        
        
        public void ReturnTrueIfStringComprisedOfUniqueChars(string input)
        {
            var result = UniqueCharCheck.CheckUnique(input);
            Assert.True(result, $"{input} is not comprised of unique characters");
        }

        [Theory]
        [InlineData("aba")]
        [InlineData("aaa")]
        
        public void ReturnFalseIfStringHasRepeatedChars(string input)
        {
            var result = UniqueCharCheck.CheckUnique(input);
            Assert.False(result, $"{input} has no repeated characters");
        }
    }
}