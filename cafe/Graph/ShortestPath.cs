using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.Graph
{
    public class ShortestPath
    {
        private Queue<int> queue = new Queue<int>();

        private int[] from;

        private int[] order;

        private bool[] visited;

        public ShortestPath(Graph graph, int src)
        {
            queue = new Queue<int>();
            from = new int[graph.V()];
            order = new int[graph.V()];
            visited = new bool[graph.V()];

            visited[src] = true; from[src] = -1; order[src] = 0;
            queue.Enqueue(src);
            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                foreach (int child in graph.Edges(node))
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        from[child] = node;
                        order[child] = order[node] + 1;
                    }
                }
            }
        }
        public bool HasPath(int dest)
        {
            return visited[dest];
        }

        public int[] PathTo(int k)
        {
            List<int> stack = new List<int>();
            while (k != -1)
            {
                stack.Add(k);
                k = from[k];
            }

            stack.Reverse();
            return stack.ToArray<int>();
        }
    }
}
