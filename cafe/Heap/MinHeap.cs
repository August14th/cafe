using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Heap
{
    public class MinHeap<Item> : MaxHeap<Item> where Item : IComparable<Item>
    {

        public MinHeap(int capacity) : base(capacity)
        {
        }

        public MinHeap(Item[] items) : base(items)
        {
        }

        protected override int Compare(Item i1, Item i2)
        {
            return base.Compare(i2, i1);
        }
    }
}
