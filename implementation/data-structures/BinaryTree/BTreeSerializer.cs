using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.DataStructures.BinaryTree
{
    public static class BTreeSerializer
    {
        public static string Serialize(this TreeNode root)
        {
            var sb = new StringBuilder();
            var nodes = new Queue<TreeNode>();

            nodes.Enqueue(root);

            while(nodes.Any())
            {
                if(sb.Length != 0)
                {
                    sb.Append(",");
                }
                var next = nodes.Dequeue();
                if(next == null)
                {
                    sb.Append("NULL");
                    continue;
                }
                sb.Append(next.Data.ToString());
                nodes.Enqueue(next.Left);
                nodes.Enqueue(next.Right);
            }
            return sb.ToString();

        }

        public static TreeNode Deserialize(string serializedRoot)
        {
            var split = serializedRoot.Split(',');

            var nodeQueue = new Queue<TreeNode>();
            var valQueue = new Queue<string>(split);

            TreeNode root = MakeNode(valQueue.Dequeue());
            nodeQueue.Enqueue(root);
            

            while(valQueue.Any() && nodeQueue.Any())
            {
                var currentNode = nodeQueue.Dequeue();
                if(currentNode == null) continue;
                var left = MakeNode(valQueue.Dequeue());
                var right = MakeNode(valQueue.Dequeue());
                currentNode.Left=left;
                currentNode.Right=right;
                if(left != null)
                {
                    nodeQueue.Enqueue(left);
                }
                if(right != null)
                {
                    nodeQueue.Enqueue(right);
                }
            }
            return root;

        }
        private static TreeNode MakeNode(string str)
        {
            if(str == "NULL") return null;
            return new TreeNode(Int32.Parse(str));   
        }
    }
}