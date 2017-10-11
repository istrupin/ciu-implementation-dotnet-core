using Xunit;
using Implementation.DataStructures;
using System.Linq;

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

        [Fact]
        public void FindValueAt()
        {
            Assert.Equal(1, node.ValueAt(0));
            node.PushBack(2);
            Assert.Equal(2, node.ValueAt(1));
        }

        [Fact]
        public void PushFrontItem()
        {
            node.PushFront(2);
            Assert.Equal(2, node.Front().Value);
            Assert.Equal(1, node.Front().Next.Value);
        }

        [Fact]
        public void PopFrontLastItem()
        {
            var popped = node.PopFront();
            Assert.Equal(1, popped);
            Assert.Null(node.Value);
        }

        [Fact] 
        public void PopFrontNotLastItem()
        {
            node.PushBack(2);
            var popped = node.PopFront();
            Assert.Equal(1, popped);
            Assert.Equal(2,node.Front().Value);
        }

        [Fact]
        public void PopBackItem()
        {
            node.PushBack(2);
            var popped = node.PopBack();
            Assert.Equal(2, popped);
            Assert.Equal(1, node.Back().Value);
        }

        [Fact]
        public void FindBackItem()
        {
            Assert.Equal(1, node.Back().Value);
            node.PushBack(2);
            Assert.Equal(2, node.Back().Value);
        }

        [Fact]
        public void InsertItemInMiddle()
        {
            node.PushBack(3);
            var head = node.Front();
            head.Insert(1,2);
            var arr = new int?[]{head.Value, head.Next.Value, head.Next.Next.Value};
            Assert.True(Enumerable.SequenceEqual(arr, new int?[]{1,2,3}));
        }

        [Fact]
        public void InsertItemAtEnd()
        {
            node.PushBack(2);
            node.Insert(2,3);
            var head = node.Front();
            var arr = new int?[]{head.Value, head.Next.Value, head.Next.Next.Value};
            Assert.True(Enumerable.SequenceEqual(arr, new int?[]{1,2,3}));
        }
    }
}