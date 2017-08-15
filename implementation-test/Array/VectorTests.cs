using System;
using Xunit;
using Implementation.DataStructures;

namespace implementation_test
{
    public class Vector_Should
    {
        private Vector _vector;
        public Vector_Should()
        {
            _vector = new Vector();
        }

        private void InitializeVector(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _vector.Push(i+1);
            }
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
        public void CalculateSize()
        {
            InitializeVector(9);
            Assert.Equal(9, _vector.Size());
        }
        [Fact]
        public void CalculateCapacity()
        {
            InitializeVector(9);
            Assert.Equal(16, _vector.Capacity());
        }
        [Fact]
        public void InsertItems()
        {
            InitializeVector(9);
            _vector.Insert(4,15);
            //{1, 2, 3, 4, 15...}
            Assert.Equal(15, _vector.At(4));
            // Assert.Equal(5, _vector.At(5));
            // Assert.Equal(9, _vector.At(9));
        }
        [Fact]
        public void PrependItem()
        {
            InitializeVector(9);
            _vector.Prepend(17);
            Assert.Equal(17, _vector.At(0));
            Assert.Equal(1, _vector.At(1));
            Assert.Equal(9, _vector.At(9));
        }

        [Fact]
        public void PopItems()
        {
            InitializeVector(1);
            var result = _vector.Pop();
            Assert.Equal(1,result);
            Assert.True(_vector.IsEmpty());
        }
        [Fact]
        public void ResizeOnPop()
        {
            //Given
            InitializeVector(8);
            //When
            for (int i = 0; i < 6; i++)
            {
                _vector.Pop();
            }
            //Then
            Assert.Equal(4, _vector.Capacity());
        }
        [Fact]
        public void DeleteItem()
        {
            InitializeVector(5);
            _vector.Delete(1);
            Assert.Equal(1, _vector.At(0));
            Assert.Equal(3, _vector.At(1));
            Assert.Equal(5, _vector.At(3));
        }
        [Fact]
        public void RemoveSingleItem()
        {
            InitializeVector(5);
            _vector.Remove(3);
            Assert.Equal(4, _vector.Size());
            Assert.Equal(4, _vector.At(2));
        }
        [Fact]
        public void RemoveMultipleItems()
        {
            InitializeVector(3);
            _vector.Push(2);
            _vector.Push(2);
            _vector.Push(3);
            //{1,2,3,2,2,3}
            _vector.Remove(2);
            //{1,3,3}
            Assert.Equal(3,_vector.At(1));
            Assert.Equal(3, _vector.Size());
            _vector.Remove(3);
            //{1}
            Assert.Equal(1,_vector.Size());
            Assert.Equal(1,_vector.At(0));
        }

        [Fact]
        public void FindItemThatExists()
        {
            //Given
            InitializeVector(5);
            //When
            int result = _vector.Find(2);
            //Then
            Assert.Equal(1, result);
        }

        [Fact]
            public void FindItemThatDoesNotExist()
            {
            //Given
            InitializeVector(5);
            //When
            int result = _vector.Find(6);
            //Then
            Assert.Equal(-1, result);
        }
    }
}

