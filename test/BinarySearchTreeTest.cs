using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.BinarySearchTree;

namespace test
{
    [TestClass]
    [DeploymentItem("Resources", "Resources")]
    public class BinarySearchTreeTest
    {
        private static string[] Bible;

        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            string bible = System.IO.File.ReadAllText(@"Resources\bible.txt");
            Bible = bible.Split(' ');
        }

        public BinarySearchTreeTest()
        {

        }
        public TestContext TestContext
        {
            get; set;
        }

        [TestMethod]
        public void TestOrder()
        {
            BinarySearchTree<int, string> bst = new BinarySearchTree<int, string>();

            bst.Insert(5, "5");
            bst.Insert(6, "6");
            bst.Insert(3, "3");
            bst.Insert(4, "4");
            bst.Insert(7, "7");
            bst.Insert(1, "1");
            bst.Insert(2, "2");

            int count = 0;
           
            bst.Remove(3);
            bst.InOrder(value => { count++; TestContext.WriteLine("{0}", value); });
        }

        [TestMethod]
        public void TestForEach()
        {
            BinarySearchTree<int, string> bst = new BinarySearchTree<int, string>();

            bst.Insert(5, "5");
            bst.Insert(6, "6");
            bst.Insert(3, "3");
            bst.Insert(3, "3");
            bst.Insert(4, "7");
            bst.Insert(1, "1");
            bst.Insert(3, "2");
            // bst.InOrder(value => { TestContext.WriteLine("{0}", value); });
            // TestContext.WriteLine("{0}", bst.Rank(100));
            // int selected = 0;
            // bool found = bst.select(6, ref selected);
            // TestContext.WriteLine("{0}", found);
            // TestContext.WriteLine("{0}", selected);

            int pre = -1;
            bool ok = bst.Ceil(6, ref pre);
            TestContext.WriteLine("{0}", pre);
        }

        [TestMethod]
        public void TestInsert()
        {
            BinarySearchTree<string, Integer> bst = new BinarySearchTree<string, Integer>();
            Integer count = 0;
            foreach (var word in Bible)
            {
                string wd = word.ToLower();
                if (bst.Find(wd, out count))
                {
                    count.value++;
                }
                else
                {
                    bst.Insert(wd, 1);
                }
            }
            bool ok = bst.Find("god", out count);
            TestContext.WriteLine("God-{0}", count.value);
        }
    }

    class Integer
    {
        public int value;

        public static implicit operator int(Integer i)
        {
            return i.value;
        }

        public static implicit operator Integer(int i)
        {
            return new Integer() { value = i };
        }
    }
}
