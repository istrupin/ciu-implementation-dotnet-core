using System;
using System.Collections.Generic;
using System.Linq;

namespace implementation.Algorithms
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public ListNode(IEnumerable<int> values)
        {
            this.val = values.First();
            var enumerator = values.GetEnumerator();
            enumerator.MoveNext();
            ListNode current = this;
            while (enumerator.MoveNext())
            {
                current.next = new ListNode(enumerator.Current);
                current = current.next;
            }
        }
    }

    public static class ListNodeAdder
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var firstCursor = l1;
            var secondCursor = l2;
            int rem= 0;
            int sum = 0;
            
            sum = firstCursor.val + secondCursor.val;
            if (sum >= 10)
            {
                sum-=10;
                rem +=1;
            }
            
            firstCursor = firstCursor.next;
            secondCursor = secondCursor.next;

            var resHead = new ListNode(sum);
            var resCursor = resHead;

            while (firstCursor != null || secondCursor != null)
            {
                sum = (firstCursor?.val ?? 0) + (secondCursor?.val ?? 0) + rem;
                if (sum >= 10)
                {
                    sum -=10;
                    rem =1;
                }
                else
                {
                    if (rem > 0)
                    {
                        rem =0;
                    }
                }
                resCursor.next = new ListNode(sum);
                resCursor = resCursor.next;
                firstCursor = firstCursor?.next;
                secondCursor = secondCursor?.next;
            }
            if (rem > 0)
            {
                resCursor.next = new ListNode(rem);
            }
            return resHead;
        }

    }
}