using cafe.Heap;
using cafe.UnionFind;
using System.Collections.Generic;
using System.Linq;
using System;

namespace cafe.WeightedGraph
{
    public class KruskMST : MST
    {
        private Edge[] edges;

        private double wt;

        public KruskMST(WeightedGraph graph)
        {
            MinHeap<Edge> queue = new MinHeap<Edge>(graph.E());
            for (int i = 0; i < graph.V(); i++)
            {
                foreach (Edge edge in graph.Edges(i))
                {
                    if (edge.From() < edge.To())
                    {
                        queue.Insert(edge);
                    }
                }
            }
            List<Edge> edges = new List<Edge>();
            UnionFind.UnionFind unionFind = new QuickUnionWithCompression(graph.V());
            while (!queue.isEmpty())
            {
                Edge edge = queue.Popup();
                if (!unionFind.isConnected(edge.From(), edge.To()))
                {
                    edges.Add(edge);
                    wt += edge.Weight();
                    unionFind.union(edge.From(), edge.To());
                }
            }

            this.edges = edges.ToArray<Edge>();
        }

        public Edge[] Edges()
        {
            return edges;
        }

        public double Weight()
        {
            return wt;
        }
    }
}
