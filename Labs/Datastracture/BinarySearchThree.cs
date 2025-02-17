using System;
using System.Diagnostics;
using System.Xml.Linq;

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
        public int Height { get; set; }
    }

    //AVL Tree
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

        //This is balancing AVL Tree and im tring to balance the tree.
        public void TryToBalance(Leaf node)
        {
            //First get the balance factor
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                //Left side is heavy
                if (GetBalanceFactor(node.Left) > 0)
                {
                    //Left side is heavy
                    RotateLeft(node);
                }
                else
                {
                    //Right side is heavy
                    RotateRightLeft(node);
                }
            }
            else if (balanceFactor < -1)
            {
                //Right side is heavy
                if (GetBalanceFactor(node.Right) < 0)
                {
                    //Right side is heavy
                    RotateRight(node);
                }
                else
                {
                    //Left side is heavy
                    RotateLeftRight(node);
                }
            }
        }

        public void RotateLeft(Leaf node)
        {
            var rightNode = node.Right;
            node.Right = rightNode.Left;
            rightNode.Left = node;
        }

        public void RotateRightLeft(Leaf node)
        {
            RotateRight(node.Right);
            RotateLeft(node);
        }

        public void RotateRight(Leaf node)
        {
            var leftNode = node.Left;
            node.Left = leftNode.Right;
            leftNode.Right = node;
        }

        public void RotateLeftRight(Leaf node)
        {
            RotateLeft(node.Left);
            RotateRight(node);
        }

        //private int GetBalanceFactor(Leaf node)
        //{
        //    int leftHeight = node.Left != null ? node.Left.Height : 0;
        //    int rightHeight = node.Right != null ? node.Right.Height : 0;

        //    return leftHeight - rightHeight;
        //}

        public int GetBalanceFactor(Leaf tree)
        {
            // Calculate the balance factor of the tree
            return GetHeight(tree.Left) - GetHeight(tree.Right);
        }

        private int GetHeight(Leaf tree)
        {
            // Calculate the height of the tree
            return tree != null ? tree.Height : 0;
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

        public bool IsBalanced(Leaf tree)
        {
            // Check if the tree is balanced by checking the balance factor
            return Math.Abs(GetBalanceFactor(tree)) <= 1;
        }

        private enum NodeDirection
        {
            left,
            right
        }
    }
}
