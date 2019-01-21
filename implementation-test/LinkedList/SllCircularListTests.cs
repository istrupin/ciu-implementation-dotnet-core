using Xunit;
using Implementation.DataStructures;
using System.Linq;

namespace implementation_test
{
    public class SllCircleCheck_should
    {
        private Sll circularList;
        private Sll nonCircularList;
        public SllCircleCheck_should()
        {
            nonCircularList = new Sll(1);
            nonCircularList.PushBack(2);

            var nodeA = new Node(1);
            var nodeB = new Node(2);
            var nodeC = new Node(3);
            nodeA.Next = nodeB;
            nodeB.Next = nodeC;
            nodeC.Next = nodeA;

            circularList = new Sll(nodeA);
        }
        

        [Fact]
        public void NonCircularListShouldReturnFalse()
        {
            Assert.False(nonCircularList.IsCircular());
        }

        [Fact]
        public void CircularListShouldReturnTrue()
        {
            Assert.True(circularList.IsCircular());
        }
    }
}