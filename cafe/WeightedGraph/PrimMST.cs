using cafe.Heap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class PrimMST : MST
    {
        private WeightedGraph graph;

        private MinHeap<Edge> queue;

        private Edge[] edges;

        private bool[] visited;

        private double wt;

        private void visit(int k)
        {
            if (visited[k])
            {
                Trace.Assert(!visited[k]);
            }
            visited[k] = true;
            foreach (Edge edge in graph.Edges(k))
            {
                if (!visited[edge.To()])
                {
                    Edge e = queue.Get(edge.To());

                    if (e == null)
                    {
                        queue.Insert(edge.To(), edge);
                    }
                    else if (e.Weight() > edge.Weight())
                    {
                        queue.Change(edge.To(), edge);
                    }
                }
            }
        }

        public PrimMST(WeightedGraph graph)
        {
            List<Edge> edges = new List<Edge>();
            this.graph = graph;
            queue = new MinHeap<Edge>(graph.V());
            visited = new bool[graph.V()];
            visit(0);

            while (!queue.isEmpty())
            {
                Edge min = queue.Popup();
                edges.Add(min);
                wt += min.Weight();
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

    }
}
