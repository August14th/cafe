using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.AStar
{
    public class AStar
    {
        private Point start;

        private Point end;

        private bool ignoreCorner;

        private Point[,] map;

        public AStar(Point[,] map, Point start, Point end, bool ignoreCorner)
        {
            this.map = map;
            this.start = start;
            this.end = end;
            this.ignoreCorner = ignoreCorner;
        }
        public List<Point> FindPath()
        {
            List<Point> openlist = new List<Point>();
            List<Point> closelist = new List<Point>();

            openlist.Add(start);

            while (openlist.Count != 0)
            {
                Point parent = openlist.Min();
                openlist.Remove(parent);

                closelist.Add(parent);
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx != 0 || dy != 0)
                        {

                            int x = parent.X + dx;
                            int y = parent.Y + dy;
                            // 到达终点
                            if (x == end.X && y == end.Y)
                            {
                                List<Point> path = new List<Point>();
                                path.Add(end);
                                while (parent != null)
                                {
                                    path.Add(parent);
                                    parent = parent.Parent;
                                }
                                path.Reverse();
                                return path;

                            }
                            // 不可达
                            if (x >= map.GetLength(0) || y >= map.GetLength(1) || x < 0 || y < 0 || map[x, y].Obstacle)
                            {
                                continue;
                            }
                            if (!ignoreCorner)
                            {
                                if (dx != 0 && dy != 0)
                                {
                                    if (map[x, parent.Y].Obstacle)
                                    {
                                        continue;
                                    }
                                    if (map[parent.X, y].Obstacle)
                                    {
                                        continue;
                                    }
                                }
                            }
                            // 在closelist里
                            bool contains = closelist.Exists((that) => { return that.X == x && that.Y == y; });
                            if (contains) continue;
                            Point prev = openlist.Find((that) => { return that.X == x && that.Y == y; });
                            if (prev != null)
                            {
                                prev.ResetParentIfLowerG(parent);
                            }
                            else
                            {
                                openlist.Add(new Point(x, y, false, parent, end));
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
