using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class SparseGraph : WeightedGraph
    {
        private int n;

        private int m;

        private bool directed;

        private List<Edge>[] edges;

        public SparseGraph(int n, bool directed)
        {
            this.n = n;
            this.edges = new List<Edge>[n];
            for (int i = 0; i < n; i++)
            {
                this.edges[i] = new List<Edge>();
            }
            this.directed = directed;
            this.m = 0;
        }

        public override IEnumerable<Edge> Edges(int v)
        {
            foreach (Edge edge in edges[v])
            {
                yield return edge;
            }
        }

        public override void AddEdge(int i, int j, double wt)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            if (HasEdge(i, j)) return;

            edges[i].Add(new Edge(i, j, wt));
            if (!directed)
            {
                edges[j].Add(new Edge(j, i, wt));
            }
            this.m++;
        }

        public override bool HasEdge(int i, int j)
        {
            Trace.Assert(i >= 0 && i < n);
            Trace.Assert(j >= 0 && j < n);

            foreach (Edge edge in edges[i])
            {
                if (edge.Other(i) == j)
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