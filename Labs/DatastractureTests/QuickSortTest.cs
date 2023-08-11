using Datastracture.Algo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriorityList
{
    [TestClass]
    public class DatastractureTestCase
    {
        [TestMethod]
        public void QuickSort()
        {
            var sorting = new QuickSort();
            var unsortedArray = new int[] { 1, 4, 6, 7, 1, 6, 4, 9, 2, 5 }
            ;
            var sortedArray = sorting.Sort(unsortedArray, 0, unsortedArray.Length - 1);

            Assert.AreEqual(1, sortedArray[0]);
            Assert.AreEqual(1, sortedArray[1]);
            Assert.AreEqual(2, sortedArray[2]);
            Assert.AreEqual(4, sortedArray[3]);
            Assert.AreEqual(5, sortedArray[5]);
            Assert.AreEqual(6, sortedArray[6]);
            Assert.AreEqual(6, sortedArray[7]);
            Assert.AreEqual(7, sortedArray[8]);
            Assert.AreEqual(9, sortedArray[9]);
        }
    }
}
