using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.UnionFind
{
    public class QuickFind: UnionFind
    {
        private int count;

        private int[] groups;

        public QuickFind(int count)
        {
            this.count = count;
            this.groups = new int[count];
            for(int i = 0; i < count; i++)
            {
                this.groups[i] = i;
            }
        }

        public int find(int p)
        {
            Trace.Assert(p >= 0 && p < count);
            return groups[p];
        }

        public void union(int p, int q)
        {
            Trace.Assert(p >= 0 && p < count && q >= 0 && q < count);
            int pQroup = find(p);
            int qQroup = find(q);

            if (pQroup != qQroup)
            {
                for(int i = 0; i < count; i++)
                {
                   if(groups[i] == qQroup)
                    {
                        groups[i] = pQroup;
                    } 
                }
            }
        }

        public bool isConnected(int p, int q)
        {
            return find(p) == find(q);
        }
    }
}
