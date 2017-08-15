using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Leetcode;

namespace test.Leetcode
{
    [TestClass]
    public class SortColorTest
    {

        public TestContext TestContext
        {
            get; set;
        }

        private int[] array = new int[] { 1, 2, 1, 1, 1, 1, 1, 0, 0, 0 };

        [TestMethod]
        public void test()
        {
            SortColor s = new SortColor();
            s.SortColors(array);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            printArray(array);
        }

        void printArray(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in array)
            {
                sb.Append(i + ", ");
            }
            TestContext.WriteLine(sb.ToString());
        }
    }
}
