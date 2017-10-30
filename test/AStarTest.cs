using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cafe.AStar;

namespace test
{

    [TestClass]
    public class AStarTest
    {
        public AStarTest()
        {
            Point[,] map = new Point[8, 6];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (x == 4)
                    {
                        if (y == 2 || y == 3 || y == 4)
                        {
                            map[x, y] = new Point(x, y, true);
                            continue;
                        }
                    }
                    map[x, y] = new Point(x, y, false);
                }
            }
            aStar = new AStar(map, map[2, 3], map[6, 3], false);
        }

        private AStar aStar;

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void Test()
        {

            List<Point> path = aStar.FindPath();
            if (path != null)
            {
                StringBuilder sb = new StringBuilder();
                bool start = true;
                path.ForEach(point =>
                {
                    if (start)
                    {
                        sb.Append("(" + point.X + "," + point.Y + ")");
                        start = false;
                    }
                    else
                    {
                        sb.Append("->(" + point.X + "," + point.Y + ")");
                    }
                });
                TestContext.WriteLine("Path:{0}", sb);
            }
        }
    }
}
