using Xunit;
using Implementation.DataStructures;
using System.Linq;

namespace implementation_test
{
    public class SllNode_should
    {
        // private Node node;
        private Sll sll;
        public SllNode_should()
        {
            // node = new Node(1);
            sll = new Sll(1);
        }
        [Fact]
        public void CorrectlyConstruct()
        {
            Assert.Equal(1, sll.head.Value);
            Assert.Null(sll.head.Next);
        }
        [Fact]
        public void PushBackItems()
        {
            sll.PushBack(2);
            Assert.NotNull(sll.head.Next);
            Assert.Equal(2, sll.head.Next.Value);
        }

        [Fact]
        public void ReturnSize()
        {
            Assert.Equal(1, sll.Size());
            sll.PushBack(2);
            Assert.Equal(2, sll.Size());
        }

        [Fact]
        public void ReturnEmpty()
        {
            Assert.False(sll.Empty());
            var emptyNode = new Node();
            Assert.True(emptyNode.Empty());
        }

        [Fact]
        public void FindValueAt()
        {
            Assert.Equal(1, sll.ValueAt(0));
            sll.PushBack(2);
            Assert.Equal(2, sll.ValueAt(1));
        }

        [Fact]
        public void PushFrontItem()
        {
            sll.PushFront(2);
            Assert.Equal(2, sll.Front().Value);
            Assert.Equal(1, sll.Front().Next.Value);
        }

        [Fact]
        public void PopFrontLastItem()
        {
            var popped = sll.PopFront();
            Assert.Equal(1, popped);
            Assert.Null(sll.head);
        }

        [Fact] 
        public void PopFrontNotLastItem()
        {
            sll.PushBack(2);
            var popped = sll.PopFront();
            Assert.Equal(1, popped);
            Assert.Equal(2,sll.Front().Value);
        }

        [Fact]
        public void PopBackItem()
        {
            sll.PushBack(2);
            var popped = sll.PopBack();
            Assert.Equal(2, popped);
            Assert.Equal(1, sll.Back().Value);
        }

        [Fact]
        public void FindBackItem()
        {
            Assert.Equal(1, sll.Back().Value);
            sll.PushBack(2);
            Assert.Equal(2, sll.Back().Value);
        }

        [Fact]
        public void InsertItemInMiddle()
        {
            sll.PushBack(3);
            var head = sll.Front();
            head.Insert(1,2);
            var arr = new int?[]{head.Value, head.Next.Value, head.Next.Next.Value};
            Assert.True(Enumerable.SequenceEqual(arr, new int?[]{1,2,3}));
        }

        [Fact]
        public void InsertItemAtEnd()
        {
            sll.PushBack(2);
            sll.Insert(2,3);
            var head = sll.Front();
            var arr = new int?[]{head.Value, head.Next.Value, head.Next.Next.Value};
            Assert.True(Enumerable.SequenceEqual(arr, new int?[]{1,2,3}));
        }

        [Fact]
        public void EraseItemInMiddle()
        {
            sll.PushBack(2);
            sll.PushBack(3);
            sll.Erase(1);
            var head = sll.Front();
            var arr = new int?[] {head.Value, head.Next.Value};
            Assert.True(Enumerable.SequenceEqual(arr, new int?[]{1,3}));
        }

        [Fact]
        public void EraseItemAtEnd()
        {
            sll.PushBack(2);
            sll.Erase(1);
            Assert.Equal(1, sll.Front().Value);
            Assert.Equal(1, sll.Back().Value);
        }

        [Fact]
        public void ReturnValueNFromEnd()
        {
            sll.PushBack(2);
            sll.PushBack(3);
            int val = sll.ValueNFromEnd(1);
            Assert.Equal(2, val);
        }

        [Fact]
        public void Reverse()
        {
            sll.PushBack(2);
            sll.Reverse();
            var head = sll.Front();
            Assert.Equal(2, head.Value);
            Assert.Equal(1, head.Next.Value);
        }

        [Fact]
        public void ReverseRecursively()
        {
            sll.PushBack(2);
            sll.ReverseRecursively();
            var head = sll.Front();
            Assert.Equal(2, head.Value);
            Assert.Equal(1, head.Next.Value);
        }

        [Fact]
        public void ReverseIteratively()
        {
            sll.PushBack(2);
            sll.ReverseIteratively();
            var head = sll.Front();
            Assert.Equal(2, head.Value);
            Assert.Equal(1, head.Next.Value);
        }

        [Fact]
        public void RemoveValue()
        {
            sll.PushBack(2);
            sll.RemoveValue(2);
            Assert.Equal(1, sll.Front().Value);
            Assert.Equal(1, sll.Back().Value);
        }
    }
}