using Xunit;
using Implementation.DataStructures;


namespace implementation_test
{
    public class BalancedParenCheck_Should
    {
        BalancedParenCheck bp;
        public BalancedParenCheck_Should()
        {
            bp = new BalancedParenCheck();    
        }

        [Theory]
        [InlineData("[](){([[[]]])}")]
        [InlineData("[]")]
        public void ReturnTrueIfBalanced(string input)
        {
            var result = bp.Balanced(input);
            Assert.True(result);
        }

        [Theory]
        [InlineData("()(){]}")]
        [InlineData("[](){([[[]]])}(")]
        [InlineData("[[[]])]")]
        public void ReturnFalseIfNotBalanced(string input)
        {
            var result = bp.Balanced(input);
            Assert.False(result);
        }

    }
}