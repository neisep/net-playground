using System;

namespace Datastracture.Datastracture
{
    public class Sorting
    {
        private Random _random = new Random();

        public int[] QuickSort(int[] unsortedArray, int left, int right)
        {
            if(left < right)
            {
                //Select Pivot Value
                var pivotIndex = _random.Next(left, right);
                int NewPivotValue = Partition(unsortedArray, left, right, pivotIndex);

                QuickSort(unsortedArray, left, NewPivotValue - 1);
                QuickSort(unsortedArray, NewPivotValue + 1, right);
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

        //public void DummySort(int[] unsortedArray, int[] unsortedPartionOne, int[] unsortedPartionTwo)
        //{
        //    int counterOne = 0;
        //    int counterTwo = 0;

        //    var random = new Random().Next(1,10);
        //    var pivotValue = unsortedArray[random];
        //    foreach (var i in unsortedArray)
        //    {
        //        if (pivotValue >= i)
        //        {
        //            unsortedPartionOne[counterOne] = i;
        //            counterOne++;
        //        }
        //        else
        //        {
        //            unsortedPartionTwo[counterTwo] = i;
        //            counterTwo++;
        //        }
        //    }

        //    DummySort(unsortedPartionOne, new int[10], new int[10]);
        //}
    }
}
