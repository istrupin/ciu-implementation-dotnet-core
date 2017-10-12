using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class Sll
    {
        public Node head;
        public Sll(int nodeValue)
        {
            this.head = new Node(nodeValue);
        }
        public Sll()
        {
            
        }
        public void PushBack(int value) 
        {
            var cursor = head;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            cursor.Next = new Node(value);
        }

        public int Size()
        {
            var cursor = head;
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
            return head.Value == null;
        }

        public int ValueAt(int v)
        {
            int i = 0;
            var cursor = head;
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
            var cursor = head;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            return cursor;
        }

        public void PushFront(int v)
        {
            var newNode = new Node(v);
            newNode.Next = head;
            head = newNode;
        }

        public int? PopFront()
        {
            var retVal = this.head.Value;
            this.head = this.head.Next == null ? null : this.head.Next;
            return retVal;
        }

        public int? PopBack() 
        {
            var cursor = this.head;
            var behind = this.head;
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
                var cursor = this.head;
                var behind = this.head;
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

        public void Erase(int index)
        {
            if (index == 0)
            {
                PopFront();
            }
            var cursor = this.head;
            var behind = this.head;
            for (int i = 0; i < index; i++)
            {
                behind = cursor;
                cursor = cursor.Next;
            }
            behind.Next = cursor.Next;
        }

        public int ValueNFromEnd(int n)
        {
            this.Reverse();
            return ValueAt(n);
        }

        public void Reverse() 
        {
            Stack<int?> stk = new Stack<int?>();
            var cursor = this.head;
            while (cursor != null)
            {
                stk.Push(cursor.Value);
                cursor = cursor.Next;
            }
            var newHead = new Node(stk.Pop().Value);
            cursor = newHead;
            head = newHead;
            while (stk.Count > 0)
            {
                cursor.Next = new Node(stk.Pop().Value);
                cursor = cursor.Next;
            }
        }

        public void RemoveValue(int v)
        {
            var cursor = head;
            var behind = head;
            while (cursor.Value != v)
            {
                behind = cursor;
                cursor = cursor.Next;
            }
            behind.Next = cursor.Next;
        }
    }
}