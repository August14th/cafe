using cafe.Heap;
using cafe.UnionFind;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class LazyPrimMST : MST
    {
        private WeightedGraph graph;

        private MinHeap<Edge> heap;

        private Edge[] edges;

        private bool[] visited;

        private double wt;

        public LazyPrimMST(WeightedGraph graph)
        {
            this.graph = graph;
            this.heap = new MinHeap<Edge>(graph.E());
            List<Edge> edges = new List<Edge>();
            visited = new bool[graph.V()];
            visit(0);
            while (!heap.isEmpty())
            {
                Edge min = heap.Popup();
                if (visited[min.To()])
                {
                    continue;
                }
                wt = wt + min.Weight();
                edges.Add(min);
                visit(min.To());
            }
            this.edges = edges.ToArray<Edge>();
        }

        public double Weight()
        {
            return wt;
        }

        public Edge[] Edges()
        {
            return edges;
        }

        private void visit(int k)
        {
            Trace.Assert(!visited[k]);
            visited[k] = true;
            foreach (var edge in graph.Edges(k))
            {
                if (!visited[edge.Other(k)])
                {
                    heap.Insert(edge);
                }
            }
        }
    }
}
