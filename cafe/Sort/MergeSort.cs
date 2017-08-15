using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Sort
{
    public class MergeSort<T> where T : IComparable<T>
    {
        private InsertionSort<T> insertion = new InsertionSort<T>();

        public void Sort(T[] array)
        {
            mergeSort(array, 0, array.Length - 1);
        }

        public void SortBottomUp(T[] array)
        {
            mergeSortBottomUp(array, 0, array.Length - 1);
        }
        
        private void mergeSort(T[] array, int left, int right)
        {
            if (right - left <= 15)
            {
                insertion.Sort(array, left, right);
            }
            else
            {
                int middle = left + (right - left) / 2;
                mergeSort(array, left, middle);
                mergeSort(array, middle + 1, right);
                if (array[middle].CompareTo(array[middle + 1]) > 0)
                {
                    merge(array, left, middle, right);
                }
            }
        }

        private void mergeSortBottomUp(T[] array, int left, int right)
        {
            for (int size = 1; size < array.Length; size += size)
            {
                for (int i = 0; i + size < array.Length; i += 2* size)
                {
                    merge(array, i, i + size - 1, min(i + 2 * size - 1, array.Length - 1));
                }
            }
        }
        
        private void merge(T[] array, int left, int middle, int right)
        {
            T[] temp = new T[right - left + 1];
            for (int k = 0; k < temp.Length; k++)
            {
                temp[k] = array[left + k];
            }

            int i = left; int j = middle + 1;
            for (int k = left; k <= right; k++)
            {
                if (i > middle)
                {
                    array[k] = temp[j - left];
                    j++;
                }
                else if (j > right)
                {
                    array[k] = temp[i - left];
                    i++;
                }
                else
                {
                    int compare = temp[i - left].CompareTo(temp[j - left]);
                    if (compare < 0)
                    {
                        array[k] = temp[i - left];
                        i++;
                    }
                    else
                    {
                        array[k] = temp[j - left];
                        j++;
                    }
                }
            }
        }

        private int min(int i, int j)
        {
            return i < j ? i : j;
        }
    }
}
