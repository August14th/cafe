using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Heap
{
    public class MaxHeap<Item> where Item : IComparable<Item>
    {
        private int[] heap;

        private int[] reverse;

        private Item[] data;

        private int size;

        private int capacity;

        protected virtual int Compare(Item i1, Item i2)
        {
            return i1.CompareTo(i2);
        }

        public MaxHeap(int capacity)
        {
            heap = new int[capacity];
            reverse = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                reverse[i] = -1;
            }
            data = new Item[capacity];
            size = 0;
            this.capacity = capacity;
        }

        public MaxHeap(Item[] items)
        {
            capacity = items.Length;
            this.heap = new int[capacity];
            this.reverse = new int[capacity];
            this.data = new Item[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                this.data[i] = items[i];
                this.heap[i] = i;
                this.reverse[i] = i;
            }

            size = items.Length;
            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                shiftDown(i);
            }
        }

        public bool Contains(int i)
        {
            Trace.Assert(i >= 0 && i < capacity);
            return reverse[i] != -1;
        }

        private int count = 0;

        public void Insert(Item item)
        {
            Trace.Assert(count + 1 <= capacity);
            data[count] = item;
            heap[size] = count;
            reverse[count] = size;
            count++;
            size++;
            shiftUp(size - 1);
        }

        public void Insert(int idx, Item item)
        {
            Trace.Assert(idx < capacity);
            data[idx] = item;
            heap[size] = idx;
            reverse[idx] = size;

            size++;
            shiftUp(size - 1);
        }

        public int PopupIndex()
        {
            Trace.Assert(size > 0);
            int maxIdx = heap[0];
            Popup();
            return maxIdx;
        }

        public Item Popup()
        {
            Trace.Assert(size > 0);
            Item pop = this.data[heap[0]];

            reverse[heap[0]] = -1;
            this.heap[0] = this.heap[size - 1];
            reverse[heap[0]] = 0;

            this.size--;
            this.shiftDown(0);
            return pop;
        }

        public Item Get(int k)
        {
            Trace.Assert(k >= 0 && k < capacity);
            return this.data[k];
        }

        public void Change(int k, Item item)
        {
            int i = reverse[k];
            Trace.Assert(i != -1);
            this.data[k] = item;
            shiftDown(i);
            shiftUp(i);

        }

        public int Size()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        private void shiftUp(int k)
        {
            while (k > 0 && Compare(data[heap[(k - 1) / 2]], data[heap[k]]) < 0)
            {
                int temp = heap[k];
                heap[k] = heap[(k - 1) / 2];
                heap[(k - 1) / 2] = temp;

                reverse[heap[(k - 1) / 2]] = (k - 1) / 2;
                reverse[heap[k]] = k;

                k = (k - 1) / 2;
            }
        }

        private void shiftDown(int k)
        {
            while (2 * k + 1 < size)
            {
                int j = 2 * k + 1;
                if (j + 1 < size && Compare(data[heap[j + 1]], data[heap[j]]) > 0)
                {
                    j++;
                }

                if (Compare(data[heap[k]], data[heap[j]]) > 0)
                {
                    break;
                }
                else
                {
                    int temp = heap[j];
                    heap[j] = heap[k];
                    heap[k] = temp;

                    reverse[heap[j]] = j;
                    reverse[heap[k]] = k;

                    k = j;
                }
            }
        }
    }
}
