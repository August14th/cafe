using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class BellmanFord : ShortestPath
    {
        private WeightedGraph graph;

        private bool[] booking;

        private bool[] rotation;

        private Edge[] path;

        private double[] weight;

        private bool negative;

        public BellmanFord(WeightedGraph graph, int start)
        {
            this.graph = graph;
            booking = new bool[graph.V()];
            rotation = new bool[graph.V()];
            booking[start] = true;
            path = new Edge[graph.V()];

            weight = new double[graph.V()];
            for(int i = 0; i < weight.Length; i++)
            {
                weight[i] = double.PositiveInfinity;
            }
            weight[start] = 0;

            for (int pass = 1; pass < graph.V(); pass++)
            {
                for(int i = 0; i < booking.Length; i++)
                {
                    if(booking[i])
                    {
                        booking[i] = false;
                        foreach (Edge edge in graph.Edges(i))
                        {
                            int to = edge.To();
                            if(weight[to] > weight[i] + edge.Weight())
                            {
                                path[to] = edge;
                                weight[to] = weight[i] + edge.Weight();
                                rotation[to] = true;
                            }                            
                        }
                    }        
                }
                bool[] temp = booking;
                booking = rotation;
                rotation = temp;
            }

            for (int i = 0; i < graph.V(); i++)
            {
                foreach (Edge edge in graph.Edges(i))
                {
                    if (weight[edge.To()] > weight[i] + edge.Weight())
                    {
                        negative = true;
                        break;
                    }
                }
                if (!negative)
                {
                    break;
                }
            }
        }

        public bool Negative()
        {
            return negative;
        }

        public double Weight(int dest)
        {
            Trace.Assert(!negative);
            return weight[dest];
        }

        public bool HasPath(int dest)
        {
            Trace.Assert(!negative);
            return path[dest] != null;
        }

        public Edge[] ShortestPath(int dest)
        {
            Trace.Assert(!negative);
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
