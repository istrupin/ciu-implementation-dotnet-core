using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.HashTable
{
    //can be generic but we will use type int string for implementation
    public class HTable
    {
        private readonly int _size;
        private readonly LinkedList<KeyValuePair<int, string>> [] _buckets;

        public HTable(int size)
        {
            this._size = size;
            _buckets = new LinkedList<KeyValuePair<int, string>>[size];
        }

        private LinkedList<KeyValuePair<int, string>> getBucketByIndex(int index)
        {
            var bkt = _buckets[index];
            if (bkt == null)
            {
                bkt = new LinkedList<KeyValuePair<int, string>>();
                _buckets[index] = bkt;
            }
            return bkt;
        }
        private int getBucketIndex(int key)
        {
            int bucket = key.GetHashCode() % _size;
            return Math.Abs(bucket);
        }

        public void Add(int key, string value)
        {
            int bucketIndex = getBucketIndex(key);
            var bucket = getBucketByIndex(bucketIndex);

            //update if exists
            if(bucket.Count > 0)
            {
                var cursor = bucket.First;
                while (cursor != null)
                {
                    if (cursor.Value.Key == key)
                    {
                        cursor.Value = new KeyValuePair<int, string>(key, value);
                    }
                    cursor = cursor.Next;
                }
            }

            var item = new KeyValuePair<int, string>(key, value);
            bucket.AddLast(item);
        }

        public string Get(int key)
        {
            var bucketIndex = getBucketIndex(key);
            var bkt = getBucketByIndex(bucketIndex);
            var cursor = bkt.First;
            while(cursor != null)
            {
                if(cursor.Value.Key == key)
                {
                    return cursor.Value.Value;
                }
                cursor = cursor.Next;
            }
            return "does not exist";
        }
    }
}