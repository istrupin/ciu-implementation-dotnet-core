using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using System.Collections.Generic;

namespace implementation_test.Algorithms
{
    public class ListNodeAdderTests
    {

        [Fact]
        public void CanCreateList(){
            var values = new List<int>{1,2,3,4};
            var node = new ListNode(values);
            var resList = new List<int>();
            while (node != null)
            {
                resList.Add(node.val);
                node = node.next;
            }
            resList.Should().BeEquivalentTo(values);
        }

        [Theory]
        [InlineData(new int[] { 2,4,3 }, new int[] { 5,6,4 }, new int[] {7,0,8})]
        [InlineData(new int[] { 2,4,3 }, new int[] { 5,8,4 }, new int[] {7,2,8})]
        [InlineData(new int[] { 6,5 }, new int[] { 1,0,0,0,0,0,0,0,0,0,0,1 }, new int[] {7,5,0,0,0,0,0,0,0,0,0,1})]
        [InlineData(new int[] { 5 }, new int[] { 5 }, new int[] {1,0})]
        [InlineData(new int[] { 1 }, new int[] { 9,9 }, new int[] {0,0,1})]


        public void CanAddCorrectly(int[] l1, int[] l2, int[] expected){
            var res = ListNodeAdder.AddTwoNumbers(new ListNode(l1),new ListNode(l2));

            var resList = new List<int>();
            while (res != null)
            {
                resList.Add(res.val);
                res = res.next;
            }
            resList.Should().BeEquivalentTo(expected);

            var q = new Stack<int>();
        }


    }
}