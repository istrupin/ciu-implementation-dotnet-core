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
    }
}
