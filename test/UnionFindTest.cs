using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.UnionFind;
using System.Diagnostics;

namespace test
{
    [TestClass]
    public class UnionFindTest
    {
        public TestContext TestContext
        {
            set; get;
        }

        private int count = 100000;


        [TestMethod]
        public void TestQuickFind()
        {
            UnionFind unionFind = new QuickFind(count);
            this.TestUnionFind(unionFind);
        }

        [TestMethod]
        public void TestQuickUnion()
        {
            UnionFind unionFind = new QuickUnion(count);
            this.TestUnionFind(unionFind);
        }

        [TestMethod]
        public void TestQuickUnionWithSize()
        {
            UnionFind unionFind = new QuickUnionWithSize(count);
            this.TestUnionFind(unionFind);
        }

        [TestMethod]
        public void TestQuickUnionWithRank()
        {
            UnionFind unionFind = new QuickUnionWithRank(count);
            this.TestUnionFind(unionFind);
        }

        [TestMethod]
        public void TestQuickUnionWithCompression()
        {
            UnionFind unionFind = new QuickUnionWithCompression(count);
            this.TestUnionFind(unionFind);
        }

        private void TestUnionFind(UnionFind unionFind)
        {
            int[] peers = new int[count];
            for (int i = 0; i < count; i++)
            {
                peers[i] = -1;
            }

            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                int p = rand.Next(count); int q = rand.Next(count);
                peers[p] = q;
                unionFind.union(p, q);
            }
            for (int i = 0; i < count; i++)
            {   
                if(peers[i] != -1)
                {
                    Assert.IsTrue(unionFind.isConnected(i, peers[i]));
                }  
            }
        }
    }
}