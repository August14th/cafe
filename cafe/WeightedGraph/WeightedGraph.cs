using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.WeightedGraph
{
    public abstract class WeightedGraph
    {
        public abstract void AddEdge(int i, int j, double wt);

        public abstract bool HasEdge(int i, int j);

        public abstract IEnumerable<Edge> Edges(int i);

        public abstract int V();

        public abstract int E();

        public Dijkstra Dijkstra(int dest)
        {
            return new Dijkstra(this, dest);
        }

        public BellmanFord BellmanFord(int dest)
        {
            return new BellmanFord(this, dest);
        }

        public KruskMST KruskMST()
        {
            return new KruskMST(this);
        }

        public LazyPrimMST LazyPrimMST()
        {
            return new LazyPrimMST(this);
        }

        public PrimMST PrimMST()
        {
            return new PrimMST(this);
        }
    }
}
