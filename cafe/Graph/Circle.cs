using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public class Circle
    {
        private Graph graph;

        private bool[] visited;

        private int[] from;

        private bool exists;

        public bool Exists()
        {
            return exists;
        }

        public Circle(Graph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];
            from = new int[graph.V()];
            for (int i = 0; i < graph.V(); i++)
            {
                from[i] = -1;
            }
            for (int i = 0; i < graph.V(); i++)
            {
                if (!visited[i])
                {
                    if (dfs(i))
                    {
                        exists = true;
                        return;
                    }
                }
            }
            exists = false;
        }

        private bool dfs(int i)
        {
            visited[i] = true;
            foreach (int child in graph.Edges(i))
            {
                if (visited[child])
                {
                    if(child != from[i])
                    {
                        return true;
                    }
                }else
                {
                    from[child] = i;
                    if (dfs(child))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
