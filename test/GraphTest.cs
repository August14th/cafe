using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.Graph;
using System.Text;

namespace test
{
    [TestClass]
    [DeploymentItem("Resources", "Resources")]
    public class GraphTest
    {
        private static Graph graph;

        public TestContext TestContext
        {
            get; set;
        }

        [TestMethod]
        public void TestComponent()
        {
            TestContext.WriteLine(graph.Component().Count().ToString());
        }

        [TestMethod]
        public void TestCircle()
        {
            TestContext.WriteLine(graph.Circle().Exists().ToString());
        }

        [TestMethod]
        public void TestShortestPath()
        {
            int[] path = graph.ShortestPath(0).PathTo(6);
            StringBuilder sb = new StringBuilder();
            foreach (int v in path)
            {
                sb.Append(v + " ");
            }
            TestContext.WriteLine(sb.ToString());
        }

        [TestMethod]
        public void TestPath()
        {
            int[] path = graph.Path(0).PathTo(6);
            StringBuilder sb = new StringBuilder();
            foreach(int v in path)
            {
                sb.Append(v + " ");
            }
            TestContext.WriteLine(sb.ToString());
        }

        [ClassInitialize()]
        public static void Init(TestContext ctx)
        {
            // graph = generateRandomGraph();
            graph = generateGraphFromFile();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            // printGraph();
        }
        public void printGraph()
        {
            StringBuilder sb = new StringBuilder();
            for (int v = 0; v < graph.V(); v++)
            {
                sb.Append(v + ": ");
                foreach (int edge in graph.Edges(v))
                {
                    sb.Append(edge + " ");
                }
                sb.Append("\n");
            }
            TestContext.WriteLine(sb.ToString());
        }

        private static Graph generateGraphFromFile()
        {
            bool head = true; int edges = -1;
            foreach (var line in System.IO.File.ReadLines(@"Resources\graph01.txt"))
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
                    graph.AddEdge(Convert.ToInt32(nums[0]), Convert.ToInt32(nums[1]));
                }
            }
            Assert.IsTrue(graph.E() == edges);
            return graph;
        }

        private static Graph generateRandomGraph()
        {
            int vertexs = 10;
            int edges = 30;
            Random random = new Random();
            // graph = new DenseGraph(vertexs, false);
            graph = new SparseGraph(vertexs, false);

            for (int i = 0; i < edges; i++)
            {
                graph.AddEdge(random.Next(vertexs), random.Next(vertexs));
            }
            return graph;
        }
    }
}