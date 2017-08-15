using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Etc;

namespace test
{
    [TestClass]
    public class EtcTest
    {

        public TestContext TestContext
        {
            get; set;
        }

        [TestMethod]
        public void TestInversePairs()
        {
            InversePairs<int> pairs = new InversePairs<int>();
            int count = pairs.Count(new int[] { 3, 2, 1, 9, 8, 7, 6, 0, 5, 4 });
            TestContext.WriteLine(count.ToString());
        }

        [TestMethod]
        public void TestMin()
        {
            Select<int> select = new Select<int>();
            int t = select.Max(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            TestContext.WriteLine(t.ToString());
        }
    }
}
