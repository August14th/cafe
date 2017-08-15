using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public class SparseGraph : Graph
    {
        private int n;

        private int m;

        private bool directed;

        private List<int>[] edges;

        public SparseGraph(int n, bool directed)
        {
            this.n = n;
            this.edges = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                this.edges[i] = new List<int>();
            }
            this.directed = directed;
            this.m = 0;
        }

        public override IEnumerable<int> Edges(int v)
        {
            foreach (int i in edges[v])
            {
                yield return i;
            }
        }

        public override void AddEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            if (HasEdge(i, j)) return;

            edges[i].Add(j);
            if (!directed)
            {
                edges[j].Add(i);
            }
            this.m++;
        }

        public override bool HasEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            foreach (int k in edges[i])
            {
                if (k == j)
                {
                    return true;
                }
            }
            return false;
        }

        public override int V()
        {
            return n;
        }

        public override int E()
        {
            return m;
        }
    }
}