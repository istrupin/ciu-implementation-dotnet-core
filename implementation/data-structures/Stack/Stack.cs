using System;

namespace Implementation.DataStructures
{
    public class StackI
    {
        private int[] _stk { get; set; }
        public StackI()
        {
            _stk = new int[0];
        }

        public void Push(int item)
        {
            _stk = Resize(_stk.Length+1);
            _stk[_stk.Length-1] = item;
        }
        public int Pop()
        {
            var item = _stk[_stk.Length-1];
            _stk = Resize(_stk.Length-1);
            return item;
        }

        private int[] Resize(int newSize)
        {
            var newStk = new int[newSize];
            Array.Copy(_stk,newStk, Math.Min(_stk.Length, newStk.Length));
            return newStk;
        }
        public int GetSize() => _stk.Length; 
        public int Peek() => _stk[_stk.Length-1];
    }
}