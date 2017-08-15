using cafe.Heap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class Dijkstra : ShortestPath
    {
        private WeightedGraph graph;

        private bool[] booking;

        private double[] weight;

        private Edge[] path;

        MinHeap<double> queue;

        private void visit(int node)
        {
            Trace.Assert(!booking[node]);
            booking[node] = true;

            foreach (Edge edge in graph.Edges(node))
            {
                int to = edge.To();
                if (!booking[to])
                {
                    if (path[to] != null)
                    {
                        if (weight[to] > weight[node] + edge.Weight())
                        {
                            weight[to] = weight[node] + edge.Weight();
                            queue.Change(to, weight[to]);
                            path[to] = edge;
                        }
                    }
                    else
                    {
                        weight[to] = weight[node] + edge.Weight();
                        queue.Insert(to, weight[to]);
                        path[to] = edge;
                    }
                }
            }
        }

        public Dijkstra(WeightedGraph graph, int start)
        {
            this.graph = graph;
            queue = new MinHeap<double>(graph.V());

            booking = new bool[graph.V()];
            path = new Edge[graph.V()];
            weight = new double[graph.V()];

            visit(start);
            while (!queue.isEmpty())
            {
                int node = queue.PopupIndex();
                visit(node);
            }
        }

        public double Weight(int dest)
        {
            Trace.Assert(HasPath(dest));
            return weight[dest];
        }

        public bool HasPath(int dest)
        {
            Trace.Assert(dest >= 0 && dest <= graph.V());
            return booking[dest];
        }

        public Edge[] ShortestPath(int dest)
        {
            Trace.Assert(HasPath(dest));
            List<Edge> path = new List<Edge>();

            Edge previous = this.path[dest];
            while (previous != null)
            {
                path.Add(previous);
                dest = previous.From();
                previous = this.path[dest];
            }

            path.Reverse();
            return path.ToArray();
        }
    }
}
