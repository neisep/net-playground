using Datastracture;
using Datastracture.Datastracture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatastractureTests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void UnBalancedBinarySearchTree_TestTree()
        {
            var binarySearchTree = new BinarySearchThree(10);

            var leaf = binarySearchTree.Leaf;
            leaf.CreateNode(9);
            leaf.CreateNode(11);
            leaf.CreateNode(12);

            var three = binarySearchTree.GetThree();

            Assert.IsNotNull(three);
            Assert.AreEqual(10, three.Key);
            Assert.AreEqual(9, three.Left.Key);
            Assert.AreEqual(11, three.Right.Key);
            Assert.AreEqual(12, three.Right.Right.Key);
        }

        [TestMethod]
        public void BalancedBinarySearchTree_TestTree()
        {
            var binarySearchTree = new BinarySearchThree(10);

            // Test case 1: Unbalanced tree with 3 nodes
            var leaf = binarySearchTree.Leaf;
            leaf.CreateNode(5);
            leaf.CreateNode(15);
            binarySearchTree.TryToBalance(leaf);
            Assert.IsTrue(binarySearchTree.IsBalanced(binarySearchTree.GetThree()));

            // Test case 2: Unbalanced tree with 4 nodes
            leaf = new Leaf(10);
            leaf.CreateNode(5);
            leaf.CreateNode(15);
            leaf.CreateNode(20);
            binarySearchTree.TryToBalance(leaf);
            Assert.IsTrue(binarySearchTree.IsBalanced(binarySearchTree.GetThree()));
        }
    }
}
