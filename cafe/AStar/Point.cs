using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.AStar
{
    public class Point : IComparable<Point>
    {

        public int X
        {
            get;

            private set;
        }

        public int Y
        {
            get;

            private set;
        }

        public Point Parent
        {
            get;

            private set;
        }

        public bool Obstacle
        {
            get;

            private set;
        }

        private int G;

        private int F;

        private int H;


        private Point end;
        public Point(int x, int y, bool obstale, Point parent = null, Point end = null)
        {
            this.X = x;
            this.Y = y;
            this.Obstacle = obstale;
            this.Parent = parent;
            if (end != null)
            {
                this.end = end;
                this.caculate();
            }
        }

        private void caculate()
        {
            if (this.X != Parent.X && this.Y != Parent.Y)
            {
                this.G = Parent.G + 14;
            }
            else
            {
                this.G = Parent.G + 10;
            }
            this.H = 10 * (Math.Abs(this.X - end.X) + Math.Abs(this.Y - end.Y));
            this.F = this.G + this.H;
        }

        public void ResetParentIfLowerG(Point newParent)
        {
            int newG;
            if (this.X != newParent.X && this.Y != newParent.Y)
            {
                newG = newParent.G + 14;
            }
            else
            {
                newG = newParent.G + 10;
            }

            if (newG < this.G)
            {
                this.Parent = newParent;
                this.G = newG;
                this.F = this.G + this.H;
            }
        }

        public int CompareTo(Point that)
        {
            if (this.X == that.X && this.Y == that.Y)
            {
                return 0;
            }
            else
            {
                return this.F.CompareTo(that.F);
            }
        }
    }
}
