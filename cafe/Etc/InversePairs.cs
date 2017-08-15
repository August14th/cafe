using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Etc
{
    public class InversePairs<T> where T : IComparable<T>
    {
        private int pairs;

        public int Count(T[] array)
        {
            this.pairs = 0;
            mergeSort(array, 0, array.Length - 1);
            return pairs;
        }

        private void mergeSort(T[] array, int left, int right)
        {
            if (left == right) return;
            int middle = left + (right - left) / 2;
            mergeSort(array, left, middle);
            mergeSort(array, middle + 1, right);
            if (array[middle].CompareTo(array[middle + 1]) > 0)
            {
                merge(array, left, middle, right);
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
                        pairs += middle - i + 1;
                    }
                }
            }
        }
    }
}
