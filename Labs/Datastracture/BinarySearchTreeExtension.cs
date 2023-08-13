using Datastracture.Datastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastracture
{
    public static class BinarySearchTreeExtension
    {
        public static void CreateNode(this Leaf parentNode, int node)
        {
            if (parentNode.Key < node)
            {
                //move right
                if (parentNode.Right == null)
                    parentNode.Right = new Leaf(node);
                else
                    CreateNode(parentNode.Right, node);
            }
            else if (parentNode.Key > node)
            {
                //move left
                if (parentNode.Left == null)
                    parentNode.Left = new Leaf(node);
                else
                    CreateNode(parentNode.Left, node);
            }
        }

        public static void Search(this Leaf currentNode, int value)
        {
            if (currentNode.Key < value)
            {
                currentNode.Right.Search(value);
            }
            else if (currentNode.Key > value)
            {
                currentNode.Left.Search(value);
            }
        }
    }
}
