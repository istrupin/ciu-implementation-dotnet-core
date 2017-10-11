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

        public int ValueAt(int v)
        {
            int i = 0;
            var cursor = this;
            while (i != v)
            {
                cursor = cursor.Next;
                i++;
            }
            return cursor.Value.GetValueOrDefault();
        }

        public Node Front() => this.head;

        public Node Back()
        {
            var cursor = this;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            return cursor;
        }

        public void PushFront(int v)
        {
            head = this;
            var newNode = new Node(v);
            newNode.Next = head;
            head = newNode;
        }

        public int? PopFront()
        {
            this.head = this.Next == null ? null : this.Next;
            var retVal = this.Value;
            this.Value = null;
            return retVal;
        }

        public int? PopBack() 
        {
            var cursor = this;
            var behind = this;
            while (cursor.Next != null)
            {
                behind = cursor;
                cursor = cursor.Next;
            }
            behind.Next = null;
            return cursor.Value;
        }

        public void Insert(int index, int value)
        {
            if (index == 0)
            {
                PushFront(value);
            }
            else
            {
                var cursor = this;
                var behind = this;
                var newNode = new Node(value);
                for (int i = 0; i < index; i++)
                {
                    behind = cursor;
                    cursor = cursor.Next;
                }
                behind.Next = newNode;
                newNode.Next = cursor;
            }
        }
    }
}