using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastracture.Algo
{
    public class QuickSort
    {
        private Random _random = new Random();
        public int[] Sort(int[] unsortedArray, int left, int right)
        {
            if (left < right)
            {
                //Select Pivot Value
                var pivotIndex = _random.Next(left, right);
                int NewPivotValue = Partition(unsortedArray, left, right, pivotIndex);

                Sort(unsortedArray, left, NewPivotValue - 1);
                Sort(unsortedArray, NewPivotValue + 1, right);
            }

            return unsortedArray;
        }

        private int Partition(int[] unsortedArray, int left, int right, int pivotIndex)
        {
            int pivotValue = unsortedArray[pivotIndex];

            Swap(unsortedArray, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (unsortedArray[i] < pivotValue)
                {
                    Swap(unsortedArray, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(unsortedArray, storeIndex, right);
            return storeIndex;
        }

        private void Swap(int[] data, int left, int right)
        {
            var temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }
    }
}
