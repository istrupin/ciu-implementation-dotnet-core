using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class Vector
    {
        public Vector()
        {
            _initialArr = new int?[2];
            _capacity = 2;
        }

        private int?[] _initialArr;
        private int _lastIndex;
        private int _capacity;

        public int Capacity() => _capacity;

        public int Size() => _lastIndex;

        public bool IsEmpty() => _lastIndex > 0 ? false : true;

        public int At(int ind) => _initialArr[ind].Value;

        public void Push(int item)
        {
            if (_capacity > _lastIndex)
            {
                //add to existing
                _initialArr[_lastIndex] = item;
                _lastIndex++;
            }
            else
            {
                //double size
                Resize(_capacity*2);
                Push(item);
            }
        }

        //refactor so that this doesnt always add 1 capacity
        public void Insert(int index, int item)
        {
            if (_capacity < _lastIndex+1)
            {
                Resize(_capacity*2);
            }
            var oldArr = _initialArr;
            var oli = _lastIndex;
            
            _initialArr = new int?[_capacity];
            _lastIndex = 0;

            for (int i = 0; i < oli; i++)
            {
                if (i != index)
                {
                    this.Push(oldArr[i].Value);
                }
                else
                {
                    this.Push(item);
                    this.Push(oldArr[i].Value);
                }
            }
        }

        public int Pop()
        {
            var retVal = _initialArr[_lastIndex - 1];
            _initialArr[_lastIndex - 1] = null;
            _lastIndex--;

            if (_lastIndex <= (_capacity/4))
            {
                Resize(_capacity/2);
            }

            return retVal.Value;
        }

        public void Prepend(int item) => this.Insert(0, item);

        public void Delete(int index)
        {
            var oldArr = _initialArr;
            var oldLength = Size();
            _capacity--;
            _lastIndex = 0;
            _initialArr = new int?[_capacity];
            for (int i = 0; i < oldLength; i++)
            {
                if (i != index)
                {
                    this.Push(oldArr[i].Value);
                }
            }
        }

		public void Remove(int item)
		{
            var newLength = 0;
            for (int i = 0; i < _lastIndex; i++)
            {
                if (_initialArr[i] != item)
                {
                    newLength++;
                }
            }
            var newArr = new int?[newLength];
            int addIdx = 0;
            int newLastIndex = 0;
            for (int i = 0; i < _lastIndex; i++)
            {
                if (_initialArr[i] != item)
                {
                    newArr[addIdx] = _initialArr[i];
                    newLastIndex++;
                    addIdx++;
                }
            }
            _initialArr = newArr;
            _lastIndex = newLastIndex;
		}

        public int Find(int item)
        {
            for (int i = 0; i < _initialArr.Length; i++)
            {
                if (_initialArr[i] == item )
                {
                    return i;
                }
            }
            return -1;
        }

        private void Resize(int newCapacity)
        {
            var newArr = new int? [newCapacity];
            _capacity = newCapacity;
            int newLastIndex = 0;
            for (int i = 0; i < _lastIndex; i++)
            {
                newArr[i] = _initialArr[i];
                newLastIndex++;
            }
            _initialArr = newArr;
            _lastIndex = newLastIndex;
        }
    }
}
