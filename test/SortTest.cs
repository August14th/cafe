using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Sort;
using System.Diagnostics;
using System.Threading;

namespace test
{
    [TestClass]
    public class SortTest
    {
        private static int n = 100000;

        private static int[] data;

        [ClassInitialize()]
        public static void GenerateArray(TestContext testContext)
        {
            data = generateRandomArray(n, 0, n);
            // data = genreateNearlyOrderedArray(n, 10);
        }

        private int[] array;

        public TestContext TestContext
        {
            get; set;
        }

        [TestInitialize()]
        public void Before()
        {
            array = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                array[i] = data[i];
            }
        }

        [TestCleanup()]
        public void After()
        {
            Assert.IsTrue(isSorted(array));
            // printArray(array);
        }
        
        [TestMethod]
        public void TestSelectionSort()
        {
            SelectionSort<int> sort = new SelectionSort<int>();
            sort.Sort(array);
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            InsertionSort<int> sort = new InsertionSort<int>();
            sort.Sort(array);
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            BubbleSort<int> sort = new BubbleSort<int>();
            sort.Sort(array);
        }

        [TestMethod]
        public void TestMergeSort()
        {
            MergeSort<int> sort = new MergeSort<int>();
            sort.Sort(array);
        }

        [TestMethod]
        public void TestMergeSortBottomUp()
        {
            MergeSort<int> sort = new MergeSort<int>();
            sort.SortBottomUp(array);
        }

        [TestMethod]
        public void TestQuickSort()
        {
            QuickSort<int> sort = new QuickSort<int>();
            sort.Sort(array);
        }

        [TestMethod]
        public void TestQuickSort3Ways()
        {
            QuickSort<int> sort = new QuickSort<int>();
            sort.Sort3Ways(array);
        }
        
        private static int[] generateRandomArray(int n, int min, int max)
        {
            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(max - min + 1) + min;
            }
            return array;
        }

        private static int[] genreateNearlyOrderedArray(int n, int m)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i;
            }
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            {
                int a = rand.Next(n);
                int b = rand.Next(n);

                int temp = array[b];
                array[b] = array[a];
                array[a] = temp;
            }

            return array;
        }

        private bool isSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
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
