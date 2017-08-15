using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Heap;

namespace test
{
    [TestClass]
    public class MaxHeapTest
    {
        public TestContext TestContext
        {
            get; set;
        }

        private MaxHeap<int> heap;

        private Random rand = new Random();

        public MaxHeapTest()
        {
            heap = new MaxHeap<int>(1000);
        }

        [TestMethod]
        public void TestChange()
        {
            for (int i = 0; i < 31; i++)
            {
                heap.Insert(i,rand.Next(100));
            }
            
            heap.Change(1, 0);
           
            while (!heap.isEmpty())
            {
                TestContext.WriteLine("{0}", heap.Popup());
            }
        }
    }
}
