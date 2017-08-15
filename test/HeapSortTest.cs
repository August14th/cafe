using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Sort;
using System.Diagnostics;

namespace test
{
    [TestClass]
    public class HeapSortTest
    {

        private static int count = 1000000;

        public TestContext TestContext
        {
            get; set;
        }

        private static int[] array = getRandomArray(count);

        [TestMethod]
        public void TestSort1()
        {
            int[] arr = copy(array);
            HeapSort<int> heap = new HeapSort<int>();
            heap.Sort1(arr);

            validate(arr);
            TestContext.WriteLine("{0}", arr[10000]);
        }

        [TestMethod]
        public void TestSort2()
        {
            int[] arr = copy(array);
            HeapSort<int> heap = new HeapSort<int>();
            heap.Sort2(arr);

            validate(arr);
            TestContext.WriteLine("{0}", arr[10000]);
        }

        [TestMethod]
        public void TestSort3()
        {
            int[] arr = copy(array);
            HeapSort<int> heap = new HeapSort<int>();
            heap.Sort3(arr);

            validate(arr);
            TestContext.WriteLine("{0}", arr[10000]);
        }

        private void validate(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                Trace.Assert(array[i] <= array[i + 1]);
            }
        }

        private static int[] getRandomArray(int n)
        {
            Random rand = new Random();
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = rand.Next(n);
            }
            return array;
        }

        private int[] copy(int[] array)
        {
            int[] temp = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            return temp;
        }

        private string toString(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]).Append(" ");
            }
            return sb.ToString();
        }

    }
}
