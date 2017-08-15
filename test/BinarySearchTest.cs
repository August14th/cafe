using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.BinarySearchTree;

namespace test
{
    [TestClass]
    public class BinarySearchTest
    {
        public TestContext TestContext
        {
            get; set;
        }
        [TestMethod]
        public void TestFind()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            BinarySearch<int> searcher = new BinarySearch<int>();
            int idx = searcher.Find(array, 3);

            Assert.AreEqual(idx, 2);
        }

        [TestMethod]
        public void TestFloor()
        {
            int[] array = new int[] {0, 1, 2, 3, 4, 6, 6, 7, 8, 9, 10 };

            BinarySearch<int> searcher = new BinarySearch<int>();
            int idx = searcher.Floor(array, 6);

            Assert.AreEqual(idx, 4);
        }

        [TestMethod]
        public void TestCeil()
        {
            int[] array = new int[] { 0, 1, 2, 3, 4, 6, 6, 7, 8, 9, 10 };

            BinarySearch<int> searcher = new BinarySearch<int>();
            int idx = searcher.Ceil(array, 5);

            Assert.AreEqual(idx, 5);
        }
    }
}
