using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.UnionFind
{
    public interface UnionFind
    {
        int find(int p);

        bool isConnected(int p, int q);

        void union(int p, int q);
    }
}
