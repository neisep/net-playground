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

            binarySearchTree.TryToBalance(three);

            //THIS TEST IS INCOMPLETE CAUSE THE CODE IN TryToBalance is not correct and not complete, work in progress you could say...
            Assert.IsNotNull(three);
            Assert.AreEqual(10, three.Key);
            Assert.AreEqual(9, three.Left.Key);
            Assert.AreEqual(11, three.Right.Key);
            Assert.AreEqual(12, three.Left.Key);
        }
    }
}
