using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.BinarySearchTree
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        public int Find(T[] array, T target)
        {
            int l = 0, r = array.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int ret = array[mid].CompareTo(target);
                if (ret == 0)
                {
                    return mid;
                }
                else if (ret > 0)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }

        public int Floor(T[] array, T target)
        {
            int l = 0, r = array.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int ret = array[mid].CompareTo(target);
                if (ret < 0)
                {
                    l = mid + 1;

                }
                else
                {
                    r = mid - 1;
                }
            }

            return r;
        }

        public int Ceil(T[] array, T target)
        {
            int l = 0, r = array.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int ret = array[mid].CompareTo(target);
                if (ret > 0)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }
    }
}
