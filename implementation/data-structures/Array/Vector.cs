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

        public int?[] _initialArr;
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
                var newArr = new int?[_capacity * 2];
                Array.Copy(_initialArr, newArr, _capacity);
                _initialArr = newArr;
                _capacity *= 2;
                Push(item);
            }
        }

        //refactor so that this doesnt always add 1 capacity
        public void Insert(int index, int item)
        {
            var oldArr = _initialArr;
            _initialArr = new int?[_capacity + 1];
            var oli = _lastIndex;
            _lastIndex = 0;
            _capacity++;
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
			var indexesToDelete = new HashSet<int>();
			for(int i = 0; i <= _lastIndex; i++)
			{
				if(_initialArr[i] == item)
				{
					this.Delete(i);
					Remove(item);
				}
			}

		}

    }
}
