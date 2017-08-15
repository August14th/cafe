using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class DenseGraph : WeightedGraph
    {
        private int n;

        private Edge[,] edges;

        private int m;

        private bool directed;

        public DenseGraph(int n, bool directed)
        {
            this.n = n;
            edges = new Edge[n, n];
            this.m = 0;
            this.directed = directed;
        }

        public override IEnumerable<Edge> Edges(int v)
        {
            for (int i = 0; i < n; i++)
            {
                if (edges[v, i] != null)
                {
                    yield return edges[v, i];
                }
            }
        }

        public override void AddEdge(int i, int j, double wt)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            if (HasEdge(i, j)) return;

            this.edges[i, j] = new Edge(i, j, wt);
            if (!directed)
            {
                this.edges[j, i] = new Edge(j, i, wt);
            }
            this.m++;
        }

        public override bool HasEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            return this.edges[i, j] != null;
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
