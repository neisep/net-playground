using Datastracture;
using Datastracture.Datastracture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatastractureTests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void BalancedBinarySearchTree_TestTree()
        {
            var binarySearchTree = new BinarySearchThree(10);

            binarySearchTree.Leaf.CreateNode(9);
            binarySearchTree.Leaf.CreateNode(11);
            binarySearchTree.Leaf.CreateNode(12);

            var three = binarySearchTree.GetThree();

            Assert.IsNotNull(three);
            Assert.AreEqual(10, three.Key);
            Assert.AreEqual(9, three.Left.Key);
            Assert.AreEqual(11, three.Right.Key);
            Assert.AreEqual(12, three.Right.Right.Key);

            //Crap i just notice this tree will not make it correct..... cause it will not do it the right way around i think.... or my brain stopped working.
            //The way i create node 12 and 11 makes it abit fuck up since 10 goes to 12 and then from 12 to 11 but it should change spot actually fuck my life!
            //Well if you do not do it the wrong way it works perfectly that means 9,11,12 and so on... But maybe createNode should rebalance the tree.
        }
    }
}
