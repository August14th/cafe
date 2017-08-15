using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public abstract class Graph
    {
        public abstract void AddEdge(int i, int j);

        public abstract bool HasEdge(int i, int j);

        public abstract IEnumerable<int> Edges(int i);

        public abstract int V();

        public abstract int E();

        public ShortestPath ShortestPath(int src)
        {
            return new ShortestPath(this, src);
        }

        public Path Path(int src)
        {
            return new Path(this, src);
        }

        public Component Component()
        {
            return new Component(this);
        }

        public Circle Circle()
        {
            return new Circle(this);
        }
    }
}
