using Xunit;
using Implementation.DataStructures;
using Implementation.DataStructures.BinaryTree;
using FluentAssertions;

namespace implementation_test
{
    public class BinaryTreeSerialization
    {
        [Fact]
        public void SerializerCanSerializeNormalTree()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            const string expected = @"1,2,3,NULL,NULL,NULL,NULL";

            var actual = root.Serialize();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SerializerCanSerializeUnbalanced()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(5);

            const string expected = @"1,2,3,NULL,NULL,4,5,NULL,NULL,NULL,NULL";

            var actual = root.Serialize();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void SerializerCanSerializeWithSingleLeaf()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            const string expected = @"1,2,3,4,NULL,NULL,NULL,NULL,NULL";

            var actual = root.Serialize();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SerializerCanDeserializeNormalTree()
        {
            string ser =  @"1,2,3,NULL,NULL,NULL,NULL";
            var root = BTreeSerializer.Deserialize(ser);

            root.Data.Should().Be(1);
            root.Left.Data.Should().Be(2);
            root.Right.Data.Should().Be(3);
        }


        [Fact]
        public void SerializerCanDeSerializeUnbalanced()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(5);

            const string ser = @"1,2,3,NULL,NULL,4,5,NULL,NULL,NULL,NULL";

            var actual = BTreeSerializer.Deserialize(ser);

            root.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void SerializerCanDeserializeWithSingleLeaf()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            const string ser = @"1,2,3,4,NULL,NULL,NULL,NULL,NULL";

            var actual = BTreeSerializer.Deserialize(ser);

            root.Should().BeEquivalentTo(actual);
        }
    }
}