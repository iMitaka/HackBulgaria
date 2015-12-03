using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }

        public static Point Origin
        {
            get
            {
                return new Point();
            }
        }

        public double GetX
        {
            get
            {
                return this.x;
            }
        }

        public double GetY
        {
            get
            {
                return this.y;
            }
        }

        public override string ToString()
        {
            return string.Format("Point({0},{1})", this.x, this.y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                throw new FormatException("The object must be a Point!");
            }
            var otherPoint = obj as Point;
            return this.x == otherPoint.x && this.y == otherPoint.y;
        }

        public static bool operator ==(Point first, Point second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Point first, Point second)
        {
            return !first.Equals(second);
        }

        public static LineSegment operator +(Point first, Point second)
        {
            return new LineSegment(first, second);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.x.GetHashCode();
                hash = hash * 23 + this.y.GetHashCode();
                return hash;
            }
        }
    }
}
