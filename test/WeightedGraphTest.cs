using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.WeightedGraph;
using System.Text;

namespace test
{
    [TestClass]
    [DeploymentItem("Resources", "Resources")]
    public class WeightedGraphTest
    {
        private static WeightedGraph graph;

        public TestContext TestContext
        {
            get; set;
        }

        [ClassInitialize()]
        public static void Init(TestContext ctx)
        {
            // graph = generateRandomGraph();
            graph = generateGraphFromFile();
        }

        [TestMethod]
        public void TestLazyPrimMST()
        {
            LazyPrimMST mst = graph.LazyPrimMST();
            Edge[] edges = mst.Edges();
            foreach (Edge edge in edges)
            {
                // TestContext.WriteLine(edge.ToString());
            }
            TestContext.WriteLine(mst.Weight().ToString());
        }

        [TestMethod]
        public void TestPrimMST()
        {
            PrimMST mst = graph.PrimMST();
            Edge[] edges = mst.Edges();
            foreach(Edge edge in edges)
            {
                // TestContext.WriteLine(edge.ToString());
            }
            TestContext.WriteLine(mst.Weight().ToString());
        }

        [TestMethod]
        public void TestKruskMST()
        {
            MST mst = graph.KruskMST();
            Edge[] edges = mst.Edges();
            foreach (Edge edge in edges)
            {
                // TestContext.WriteLine(edge.ToString());
            }
            TestContext.WriteLine(mst.Weight().ToString());
        }

        [TestMethod]
        public void TestDijkstra()
        {
            Dijkstra dijkstra = graph.Dijkstra(0);

            for (int i = 1; i < graph.V(); i++)
            {
                Edge[] path = dijkstra.ShortestPath(i);
                
                TestContext.WriteLine("Path: " + ToString(path));
                TestContext.WriteLine("Weight: " + dijkstra.Weight(i).ToString());
            }            
        }

        [TestMethod]
        public void TestBellmanFord()
        {
            BellmanFord bellman = graph.BellmanFord(0);

            for (int i = 1; i < graph.V(); i++)
            {
                Edge[] path = bellman.ShortestPath(i);

                TestContext.WriteLine("Path: " + ToString(path));
                TestContext.WriteLine("Weight: " + bellman.Weight(i).ToString());
            }
        }

        private string ToString(Edge[] edges)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < edges.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(edges[i].From() + " -> " + edges[i].To());
                }
                else
                {
                    sb.Append(" -> " + edges[i].To());
                }

            }
            return sb.ToString();
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        private static WeightedGraph generateGraphFromFile()
        {
            bool head = true; int edges = -1;
            foreach (var line in System.IO.File.ReadLines(@"Resources\ShortestPath01.txt"))
            {
                string[] nums = line.Split(' ');
                if (head)
                {
                    graph = new SparseGraph(Convert.ToInt32(nums[0]), false);
                    // graph = new DenseGraph(Convert.ToInt32(nums[0]), false);
                    edges = Convert.ToInt32(nums[1]);
                    head = false;
                }
                else
                {
                    graph.AddEdge(Convert.ToInt32(nums[0]), Convert.ToInt32(nums[1]), Convert.ToDouble(nums[2]));
                }
            }
            Assert.IsTrue(graph.E() == edges);
            return graph;
        }
    }
}
