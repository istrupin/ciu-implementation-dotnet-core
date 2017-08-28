using Xunit;
using Implementation.DataStructures;


namespace implementation_test
{
    public class Deque_should
    {
        //rear....front
        private Deque deq;
        public Deque_should()
        {
            deq = new Deque();
        }

        [Fact]
        public void AddRearItems()
        {
            deq.AddRear(1);
            Assert.Equal(1, deq.GetLength());
        }
        [Fact]
        public void AddFrontItems()
        {
            deq.AddFront(1);
            Assert.Equal(1, deq.GetLength());
        }
        [Fact]
        public void CheckEmpty()
        {
            Assert.Equal(true, deq.CheckEmpty());
        }
        [Fact]
        public void RemoveRear()
        {
            deq.AddFront(1);
            deq.AddRear(2);
            var result = deq.PopRear();
            Assert.Equal(2, result);
        }
        [Fact]
        public void RemoveFront()
        {
            deq.AddFront(1);
            deq.AddFront(2);
            deq.AddRear(3);
            var result = deq.PopFront();
            Assert.Equal(2, result);
        }
    }
}