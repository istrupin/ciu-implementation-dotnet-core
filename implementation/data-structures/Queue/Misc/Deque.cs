using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class Deque
    {
        //rear.....front
        private int[] d;
        public Deque()
        {
            d = new int[0];
        }

        public int GetLength() => d.Length;
        public bool CheckEmpty() => d.Length == 0;
        
        public void AddRear(int item)
        {
            var oldArr = d;
            d = new int[oldArr.Length + 1];

            d[0] = item;

            for (int i = 1; i < d.Length; i++)
            {
                d[i] = oldArr[i-1];
            }
        }

        public int PopRear()
        {
            var oldArr = d;
            var itm = d[0];
            d = new int[oldArr.Length -1];
            for (int i = 1; i < d.Length; i++)
            {
                d[i] = oldArr[i-1];
            }
            return itm;
        }

        public void AddFront(int item)
        {
            var oldArr = d;
            d = new int[oldArr.Length + 1];
            for (int i = 0; i < oldArr.Length; i++)
            {
                d[i] = oldArr[i];
            }
            d[d.Length - 1] = item; 
        }

        public int PopFront()
        {
            var itm = d[d.Length-1];
            var oldArr = d;
            d = new int[oldArr.Length -1];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = oldArr[i];
            }

            return itm;
        }
    }
}