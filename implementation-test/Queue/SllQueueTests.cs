using Xunit;
using Implementation.DataStructures;


namespace implementation_test
{
    public class SllQueue_should
    {
        private SllQueue q;
        public SllQueue_should()
        {
            q = new SllQueue();
        }

        [Fact]
        public void EnqueueItems()
        {
            q.Enqueue(1);
            Assert.Equal(1, q.GetLength());
        }
        [Fact]
        public void DequeueItems()
        {
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Assert.Equal(1, q.Dequeue());
            Assert.Equal(2, q.Dequeue());
        }
    }
}