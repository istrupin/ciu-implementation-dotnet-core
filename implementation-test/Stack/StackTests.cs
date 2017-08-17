using Xunit;
using Implementation.DataStructures;


namespace implementation_test
{
    public class Stack_should
    {
        private Stack _stack;
        public Stack_should()
        {
            _stack = new Stack();
        }
        [Fact]
        public void PushItemsCorrectly()
        {
            //When
            _stack.Push(1);
            //Then
            Assert.Equal(1, _stack.GetSize());
        }
        [Fact]
        public void PopItemsCorrectly()
        {
            _stack.Push(1);
            _stack.Push(2);
            var result = _stack.Pop();
            Assert.Equal(2, result);
            Assert.Equal(1, _stack.GetSize());
        }

        [Fact]
        public void ShouldPeekCorrectly()
        {
            _stack.Push(1);
            _stack.Push(2);
            var result = _stack.Peek();

            Assert.Equal(2, result);
            Assert.Equal(2, _stack.GetSize());
        }
    }
}