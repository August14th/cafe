using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Leetcode
{
    public class SortColor
    {
        public void SortColors(int[] nums)
        {
            int zero = -1;
            int two = nums.Length;
            int i = 0;
            while(i < two)
            {
                if(nums[i] == 0)
                {
                    zero++;
                    int t = nums[zero];
                    nums[zero] = nums[i];
                    nums[i] = t;                    
                    i++;
                }else if(nums[i] == 2)
                {
                    two--;
                    nums[i] = nums[two];
                    nums[two] = 2;
                }else
                {
                    i++;
                }
            }
        }
    }
}
