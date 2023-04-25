using Datastracture.Datastracture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;

namespace Datastracture
{
    [TestClass]
    public class DatastractureTestCase
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dummy = new Sorting();
            var unsortedArray = new int[] { 1, 4, 6, 7, 1, 6, 4, 9, 2, 5 }
            ;
            var dummy2 = dummy.QuickSort(unsortedArray, 0, unsortedArray.Length-1);
        }
    }
}
