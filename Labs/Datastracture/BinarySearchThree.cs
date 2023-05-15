
//TODO Fix sorting when creating new node highest level should be at top on right and on left should be opposite.
//Calculate Balance factor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastracture.Datastracture
{
    public class BinarySearchThree
    {
        private int _parentValue;
        private int _leftNodeCount = 0;
        private int _rightNodeCount = 0;
        private int[] _leftNode = new int[4];
        private int[] _rightNode = new int[4];
        public void CreateThree()
        {
            var random = new Random();
            _parentValue = random.Next(10, 100);

            for (int i = 0; i < 4; i++)
            {
                var nodeValue = random.Next(10, _parentValue - 1);
                CreateNode(_parentValue, nodeValue);

                nodeValue = random.Next(_parentValue + 1, 100);
                CreateNode(_parentValue, nodeValue);
            }
        }

        public int GetTopValue()
        {
            return _parentValue;
        }

        public string GetLeftNode()
        {
            var leftNode = "";
            for (int i = 0; i < 4; i++)
            {
                leftNode += $" {_leftNode[i]}";
            }

            return leftNode;
        }
        public string GetRightNode()
        {
            var rightNode = "";
            for (int i = 0; i < 4; i++)
            {
                rightNode += $" {_rightNode[i]}";
            }

            return rightNode;
        }

        public void CreateNode(int parentValue, int nodeValue)
        {
            if (nodeValue > parentValue)
                CreateRightNode(nodeValue);

            if(nodeValue < parentValue)
                CreateLeftNode(nodeValue);
        }

        public void CreateLeftNode(int nodeValue)
        {
            _leftNode[_leftNodeCount] = nodeValue;
            _leftNodeCount++;
        }

        public void CreateRightNode(int nodeValue)
        {
            _rightNode[_rightNodeCount] = nodeValue;
            _rightNodeCount++;
        }

        public void GetBalanceFactor()
        {

        }
    }
}
