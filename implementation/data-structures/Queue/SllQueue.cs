using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class SllQueue
    {
        private Sll _list;
        
        public SllQueue()
        {
            _list = new Sll();
        }

        public void Enqueue(int intoToEnqueue)
        {
            _list.PushBack(intoToEnqueue);
        }

        public int Dequeue()
        {
            return _list.PopFront().Value;
        }

        public bool Empty()
        {
            return _list.Empty();
        }
        public bool Full() 
        {
            return !_list.Empty();
        }

        public int GetLength()
        {
            return _list.Size();
        }
    }
}