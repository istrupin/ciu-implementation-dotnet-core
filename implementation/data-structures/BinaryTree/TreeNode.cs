using System;
using System.Collections.Generic;

namespace Implementation.DataStructures.BinaryTree
{
    public class TreeNode
    {
        public TreeNode(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}