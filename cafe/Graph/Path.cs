using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public class Path
    {
        private bool[] visited;
        private int[] from;

        private Graph graph;

        public Path(Graph graph, int src)
        {
            this.graph = graph;

            visited = new bool[graph.V()];
            from = new int[graph.V()];
            for (int i = 0; i < from.Length; i++)
            {
                from[i] = -1;
            }
            dfs(src);
        }

        public bool HasPath(int dest)
        {
            Trace.Assert(dest >= 0 && dest < graph.V());
            return visited[dest];
        }

        public int[] PathTo(int dest)
        {
            if (HasPath(dest))
            {
                List<int> list = new List<int>();
                while (dest != -1)
                {
                    list.Add(dest);
                    dest = from[dest];
                }
                list.Reverse();
                return list.ToArray<int>();
            }
            else
            {
                return null;
            }
        }

        private void dfs(int i)
        {
            visited[i] = true;
            foreach (int child in graph.Edges(i))
            {
                if (!visited[child])
                {
                    from[child] = i;
                    dfs(child);
                }
            }
        }
    }
}
