using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Etc
{
    public class Select<T> where T : IComparable<T>
    {

        private Random rand = new Random();

        public T Min(T[] array)
        {
            return Get(array, 0);
        }

        public T Max(T[] array)
        {
            return Get(array, array.Length - 1);
        }

        public T Middle(T[] array)
        {
            return Get(array, (array.Length - 1) / 2);
        }

        public T Get(T[] array, int rank)
        {
            Trace.Assert(rank >= 0 && rank < array.Length);
            int left = 0;
            int right = array.Length - 1;
            int pos = partition(array, left, right);

            while (pos != rank)
            {
                if (rank > pos)
                {
                    left = pos + 1;
                    pos = partition(array, left, right);
                }
                else if (rank < pos)
                {
                    right = pos - 1;
                    pos = partition(array, left, right);
                }
            }
            return array[pos];
        }
        
        private int partition(T[] array, int left, int right)
        {
            int random = rand.Next(right - left + 1) + left;
            swap(array, left, random);

            T pValue = array[left];
            int lt = left;

            for (int i = left + 1; i <= right; i++)
            {
                int compare = array[i].CompareTo(pValue);
                if (compare < 0)
                {
                    lt++;
                    swap(array, i, lt);
                }
            }
            array[left] = array[lt];
            array[lt] = pValue;
            return lt;
        }

        private void swap(T[] array, int i, int j)
        {
            T t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
