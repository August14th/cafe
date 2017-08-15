using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Sort
{
    public class SelectionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                int min = i;
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }
                T temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }        
    }
}
