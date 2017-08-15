using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.UnionFind
{
    public class QuickUnion: UnionFind
    {
        private int count;
       
        private int[] parents;

        public QuickUnion(int count)
        {
            this.count = count;
            this.parents = new int[count];
            for (int i = 0; i < count; i++)
            {
                parents[i] = i;
            }
        }

        public int find(int p)
        {
            Trace.Assert(p >= 0 && p < count);

            while(parents[p] != p)
            {
                p = parents[p];
            }
            return p;
        }

        public bool isConnected(int p, int q)
        {
            return find(p) == find(q);
        }

        public void union(int p, int q)
        {
            int pRoot = find(p);
            int qRoot = find(q);

            if(pRoot != qRoot)
            {
                parents[qRoot] = pRoot;
            }
        }
    }
}
