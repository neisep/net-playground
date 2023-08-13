using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
