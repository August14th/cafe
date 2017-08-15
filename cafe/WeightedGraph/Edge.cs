using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public class Edge : IComparable<Edge>
    {
        private int from;

        private int to;

        private double weight;

        public Edge(int from, int to, double weight)
        {
            this.from = from;
            this.to = to;

            this.weight = weight;
        }

        public int From()
        {
            return from;
        }

        public int To()
        {
            return to;
        }

        public double Weight()
        {
            return weight;
        }

        public int Other(int x)
        {
            Trace.Assert(x == from || x == to);

            return x == from ? to : from;
        }

        public int CompareTo(Edge other)
        {
            return this.weight.CompareTo(other.weight);
        }

        public override string ToString()
        {
            return from + "-" + to + ": " + weight; 
        }
    }
}
