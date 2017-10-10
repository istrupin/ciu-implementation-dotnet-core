using Xunit;
using Implementation.DataStructures;


namespace implementation_test
{
    public class SllNode_should
    {
        private Node node;
        public SllNode_should()
        {
            node = new Node(1);
        }
        [Fact]
        public void CorrectlyConstruct()
        {
            Assert.Equal(1, node.Value);
            Assert.Null(node.Next);
        }
        [Fact]
        public void PushBackItems()
        {
            node.PushBack(2);
            Assert.NotNull(node.Next);
            Assert.Equal(2, node.Next.Value);
        }

        [Fact]
        public void ReturnSize()
        {
            Assert.Equal(1, node.Size());
            node.PushBack(2);
            Assert.Equal(2, node.Size());
        }

        [Fact]
        public void ReturnEmpty()
        {
            Assert.False(node.Empty());
            var emptyNode = new Node();
            Assert.True(emptyNode.Empty());
        }
    }
}