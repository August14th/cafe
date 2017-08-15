using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cafe.Heap;

namespace cafe.Sort
{
    public class HeapSort<T> where T : IComparable<T>
    {
        public void Sort1(T[] arr)
        {
            MaxHeap<T> heap = new MaxHeap<T>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                heap.Insert(i, arr[i]);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = heap.Popup();
            }
        }

        public void Sort2(T[] arr)
        {
            MaxHeap<T> heap = new MaxHeap<T>(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = heap.Popup();
            }
        }

        public void Sort3(T[] arr)
        {
            for (int i = (arr.Length - 1) / 2; i >= 0; i--)
            {
                shiftDown(arr, arr.Length, i);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                T temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                shiftDown(arr, i, 0);
            }
        }

        private void shiftDown(T[] arr, int n, int k)
        {
            while (2 * k + 1 < n)
            {
                int j = 2 * k + 1;
                if (j + 1 < n)
                {
                    if (arr[j + 1].CompareTo(arr[j]) > 0)
                    {
                        j += 1;
                    }
                }
                if (arr[k].CompareTo(arr[j]) > 0)
                {
                    break;
                }
                else
                {
                    T temp = arr[j];
                    arr[j] = arr[k];
                    arr[k] = temp;
                    k = j;
                }
            }
        }
    }
}