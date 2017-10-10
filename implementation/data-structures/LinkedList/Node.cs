using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class Node
    {
        public int? Value { get; set; }
        public Node Next { get; set; }
        private Node head;
        public Node(int nodeValue)
        {
            this.Value = nodeValue;
        }
        public Node()
        {
            
        }
        public void PushBack(int value) 
        {
            head = this;
            var cursor = this;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            cursor.Next = new Node(value);
        }

        public int Size()
        {
            var cursor = this;
            int i = 1;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
                i++;
            }
            return i;
        }

        public bool Empty()
        {
            return this.Value == null;
        }
    }
}