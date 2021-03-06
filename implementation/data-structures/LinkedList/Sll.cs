using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class Sll
    {
        public Node head;
        public Node tail;
        
        public Sll(int nodeValue)
        {
            this.head = new Node(nodeValue);
            this.tail = head;
        }

        public Sll(Node startNode)
        {
            this.head = startNode;
            this.tail = head;
        }
        public Sll()
        {
            this.head = new Node();
            tail = head;
        }
        public void PushBack(int value) 
        {
            //// Use for without tail poiter
            // var cursor = head;
            // while (cursor.Next != null)
            // {
            //     cursor = cursor.Next;
            // }
            if (head.Empty())
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
            var cursor = tail;
            cursor.Next = new Node(value);
            tail = cursor.Next;
            }
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
            tail = behind;
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
                tail = FindTail();
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
            tail = FindTail();
        }

        public int ValueNFromEnd(int n)
        {
            this.Reverse();
            return ValueAt(n);
        }

        public void Reverse() 
        {
            Stack<Node> stk = new Stack<Node>();
            var cursor = this.head;
            tail = this.head;
            while (cursor != null)
            {
                stk.Push(cursor);
                cursor = cursor.Next;
            }
            var newHead = stk.Pop();
            cursor = newHead;
            head = newHead;
            while (stk.Count > 0)
            {
                cursor.Next = stk.Pop();
                cursor = cursor.Next;
            }
        }

        public void ReverseIteratively(){
            if (this.head.Next == null)
                return;
            
            var cursor = this.head;
            Node previous = null;
            while (cursor.Next != null)
            {
                var nextNode = cursor.Next;
                cursor.Next = previous;
                previous = cursor;
                cursor = nextNode;
            }
            cursor.Next = previous;
            head = cursor;
        }
        public void ReverseRecursively(){
            this.head = RecursiveReverse(this.head);
        }
        
        private Node RecursiveReverse(Node first, Node previous = null){
            if(first == null)
                return null;
            if (first.Next == null)
            {
                //first.Next = previous;
                return first;
            }
                
            // var rest = first.Next;
            // first.Next = previous;
            // var headNode = RecursiveReverse(rest, first);
            // return headNode;


            //
            var rest = first.Next;
            first.Next = null;
            var reversedRest = RecursiveReverse(rest);
            reversedRest.Next = first;
            return rest;
            //
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
            tail = FindTail();
        }
        public Node FindTail()
        {
            var cursor = head;
            while (cursor.Next != null)
            {
                cursor = cursor.Next;
            }
            return cursor;
        }

        public bool IsCircular(){
            var fastCursor = head;
            var slowCursor = head;

            while (fastCursor != null && fastCursor.Next != null)
            {
                slowCursor = slowCursor.Next;
                fastCursor = fastCursor.Next.Next;
                if (slowCursor == fastCursor)
                {
                    return true;
                }
            }
            return false;
        }
    }
}