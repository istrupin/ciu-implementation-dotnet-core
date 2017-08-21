using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class QueueUsingTwoStacks
    {
        private readonly Stack<int> _stack1;
        private readonly Stack<int> _stack2;

        public QueueUsingTwoStacks()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        private void Reset()
        {
            while (_stack2.Count != 0)
            {
                _stack1.Push(_stack2.Pop());
            }
        }
        public void Enqueue(int item)
        {
            Reset();
            _stack1.Push(item);
        }

        public int GetLength() => _stack1.Count;
            
        public int Dequeue()
        {
            while(_stack1.Count != 0)
            {
                _stack2.Push(_stack1.Pop());
            }
            var itm = _stack2.Pop();
            Reset();
            return itm;
        }
    }
}