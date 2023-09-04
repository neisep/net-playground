using System.Diagnostics;

namespace Datastracture.Datastracture
{
    public class Leaf
    {
        public Leaf(int key)
        {
            Key = key;
        }

        public int Key { get; set; }
        public Leaf Left { get; set; }
        public Leaf Right { get; set; }
    }

    public class BinarySearchThree
    {
        public Leaf Leaf { get; set; }

        public BinarySearchThree(int rootNode)
        {
            var leaf = new Leaf(rootNode);
            leaf.Key = rootNode;

            Leaf = leaf;
        }

        public Leaf GetThree()
        {
            return Leaf;
        }

        //well this code is incorrect i might calculate left side and right side but not left to right and make sure its on the same height.... its just weird...
        //balancing should be when both left side and right side doesn't different more then 1 if it does differ then it means its not balanced but i might be completly wrong.
        //Anyway i have change this code tomorow or some other day.
        public void TryToBalance(Leaf topNode)
        {
            //First calculate each nodes in different direction!
            var currentNode = topNode.Left;
            var totalLeftNodes = GetTotalNodes(currentNode, NodeDirection.left);

            currentNode = topNode.Right;
            var totalRightNodes = GetTotalNodes(currentNode, NodeDirection.right);

            if (totalLeftNodes != totalRightNodes)
                Debug.WriteLine($"Probobly an unbalanced tree left: {totalLeftNodes} right: {totalRightNodes}");

            if (totalLeftNodes < totalRightNodes)
                Debug.WriteLine("Right node is greater then Left node");

            if (totalLeftNodes > totalRightNodes)
                Debug.WriteLine("Right node is less then Left node");
        }

        private int GetTotalNodes(Leaf currentNode, NodeDirection nodeDirection)
        {
            var deep = 0;
            while (currentNode != null)
            {
                deep++;
                if(nodeDirection == NodeDirection.left)
                    currentNode = currentNode.Left;
                if (nodeDirection == NodeDirection.right)
                    currentNode = currentNode.Right;
            }
            return deep;
        }

        private enum NodeDirection
        {
            left,
            right
        }
    }
}
