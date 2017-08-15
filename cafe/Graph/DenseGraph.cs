using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph.WeightedGraph
{
    public class DenseGraph : Graph
    {
        private int n;

        private bool[,] edges;

        private int m;

        private bool directed;

        public DenseGraph(int n, bool directed)
        {
            this.n = n;
            edges = new bool[n, n];
            this.m = 0;
            this.directed = directed;
        }

        public override IEnumerable<int> Edges(int v)
        {
            for (int i = 0; i < n; i++)
            {
                if (edges[v, i])
                {
                    yield return i;
                }
            }
        }

        public override void AddEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            if (HasEdge(i, j)) return;

            this.edges[i, j] = true;
            if (!directed)
            {
                this.edges[j, i] = true;
            }
            this.m++;
        }

        public override bool HasEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            return this.edges[i, j];
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
