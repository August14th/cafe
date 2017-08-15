using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.UnionFind
{
    public class QuickUnionWithSize: UnionFind
    {
        private int count;

        private int[] size;

        private int[] parents;

        public QuickUnionWithSize(int count)
        {
            this.count = count;
            this.parents = new int[count];
            this.size = new int[count];
            for (int i = 0; i < count; i++)
            {
                parents[i] = i;
                size[i] = 1;
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
                if(size[pRoot] > size[qRoot])
                {
                    parents[qRoot] = pRoot;
                    size[pRoot] += size[qRoot];
                }else
                {
                    parents[pRoot] = qRoot;
                    size[qRoot] += size[pRoot];
                }
            }
        }
    }
}
