using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Sort
{
    public class QuickSort<T> where T : IComparable<T>
    {
        private InsertionSort<T> insertion = new InsertionSort<T>();

        private Random rand = new Random();

        public void Sort3Ways(T[] array)
        {
            Sort3Ways(array, 0, array.Length - 1);
        }

        private void Sort3Ways(T[] array, int left, int right)
        {
            if (right - left <= 15)
            {
                insertion.Sort(array, left, right);
                return;
            }
            int lt, gt;
            partition(array, left, right, out lt, out gt);
            Sort3Ways(array, left, lt);
            Sort3Ways(array, gt, right);
        }

        private void partition(T[] array, int left, int right, out int lt, out int gt)
        {
            int random = rand.Next(right - left + 1) + left;
            swap(array, random, left);

            lt = left; gt = right + 1;
            int i = left + 1;
            while (i < gt)
            {
                int compare = array[i].CompareTo(array[left]);
                if (compare < 0)
                {
                    lt++;
                    swap(array, lt, i);
                    i++;
                }
                else if (compare > 0)
                {
                    gt--;
                    swap(array, gt, i);
                }
                else
                {
                    i++;
                }
            }
            swap(array, left, lt);
            lt--;
        }

        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int left, int right)
        {
            if (right - left <= 15)
            {
                insertion.Sort(array, left, right);
            }
            else
            {
                int p = partition2(array, left, right);
                Sort(array, left, p - 1);
                Sort(array, p + 1, right);
            }
        }

        private int partition2(T[] array, int left, int right)
        {
            int random = rand.Next(right - left + 1) + left;
            swap(array, random, left);

            T pValue = array[left];
            int i = left + 1, j = right;

            while (true)
            {
                while (i <= right && array[i].CompareTo(pValue) < 0) i++;
                while (j >= left + 1 && array[j].CompareTo(pValue) > 0) j--;

                if (i < j)
                {
                    swap(array, i, j);
                    i++;
                    j--;
                }
                else
                {
                    break;
                }
            }
            swap(array, left, j);
            return j;
        }
        
        private int partition(T[] array, int left, int right)
        {
            int random = rand.Next(right - left + 1) + left;
            swap(array, left, random);

            T pValue = array[left];
            int p = left;

            for (int i = left + 1; i <= right; i++)
            {
                int compare = array[i].CompareTo(pValue);
                if (compare < 0)
                {
                    p++;
                    swap(array, i, p);
                }
            }
            array[left] = array[p];
            array[p] = pValue;
            return p;
        }

        private void swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
