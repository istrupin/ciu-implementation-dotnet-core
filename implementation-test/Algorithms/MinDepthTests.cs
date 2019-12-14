using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using System.Collections.Generic;

namespace implementation_test.Algorithms
{
    public class MinDepthTests
    {
        class TreeNode {
        int Data;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int data, TreeNode left, TreeNode right) {
        this.Data = data;
        this.Left = left;
        this.Right = right;
        }
    }   

        
        private TreeNode GetNode()
        {
            var node = new TreeNode(1, null, null);
            node.Left = new TreeNode(3, null, null);
            node.Right = new TreeNode(2, null, null);
            node.Left.Left = new TreeNode(7, null, null);
            node.Left.Right = new TreeNode(6, null, null);
            node.Left.Left.Left = new TreeNode(8, null, null);
            node.Left.Left.Right = new TreeNode(9, null, null);
            node.Right.Left = new TreeNode(5,null, null);
            node.Right.Right = new TreeNode(4, null, null);
            return node;
        }

        [Fact]
        public void CanCount()
        {
            var node = GetNode();
            int count = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            
            queue.Enqueue(node);
            
            while(queue.Any())
            {
                count++;
                TreeNode polled = queue.Dequeue();
                
                if(polled.Left == null && polled.Right == null)
                {
                        count.Should().Be(3);
                }
                if(polled.Right != null) queue.Enqueue(polled.Right);
                if(polled.Left != null) queue.Enqueue(polled.Left);
                
                
            }
                System.Console.WriteLine(count);
        }



    }
}