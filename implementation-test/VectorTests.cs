using System;
using Xunit;
using Implementation.DataStructures;

namespace implementation_test
{
    public class Vector_Should
    {
        private readonly Vector _vector;
        public Vector_Should()
        {
            _vector = new Vector();
        }

        [Fact]
        public void PushItemsCorrectly()
        {
            _vector.Push(1);
            var result = _vector.At(0);
            Assert.True(result.Equals(1), $"{result} is not equal to 1");
            Assert.True(_vector.Capacity().Equals(2),"starting capacity is not 2");
            _vector.Push(2);
            _vector.Push(2);
            
            Assert.True(_vector.Capacity().Equals(4), $"capacity did not double correctly. Capacity: {_vector.Capacity()}");
        }

        [Fact]
        public void InsertCorrectly(){
            var oldCap = _vector.Capacity();
            _vector.Insert(0,10);
            Assert.True(_vector.At(0).Equals(10), $"insert failed at 1");
            Assert.True(_vector.Capacity().Equals(oldCap+1), "capacity did not increase");
            _vector.Insert(1,11);
            Assert.True(_vector.At(1).Equals(11), $"insert failed at 1");
            _vector.Insert(1,12);
            Assert.True(_vector.At(2).Equals(11), "failed to push right after insert");
        }
    }
}
