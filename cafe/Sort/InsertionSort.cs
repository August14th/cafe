using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Sort
{
    public class InsertionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array, int left, int right) 
        {
            if (left >= right) return;
            for (int i = left + 1; i <= right; i++)
            {
                T e = array[i];
                int j;
                for (j = i; j > left; j--)
                {
                    if (array[j - 1].CompareTo(e) > 0)
                    {
                        array[j] = array[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                array[j] = e;
            }
        }

        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
    }
}
