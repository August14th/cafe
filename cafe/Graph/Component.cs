using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public class Component
    {
        private Graph graph;

        private bool[] visited;

        private int[] id;

        private int count;
        
        public Component(Graph graph)
        {
            this.graph = graph;
            count = 0;
            visited = new bool[graph.V()];
            id = new int[graph.V()];
            for (int i = 0; i < graph.V(); i++)
            {
                if (!visited[i])
                {
                    this.dfs(i, count);
                    count++;
                }
            }
        }

        public bool IsConnected(int i, int j)
        {
            Trace.Assert(i >= 0 && i < graph.V());
            Trace.Assert(j >= 0 && j < graph.V());
            return id[i] == id[j];
        }

        public int Count()
        {
            return count;
        }

        private void dfs(int i, int id)
        {
            visited[i] = true;
            this.id[i] = id;
            foreach (int edge in graph.Edges(i))
            {
                if (!visited[edge])
                {
                    dfs(edge, id);
                }
            }
        }
    }
}
