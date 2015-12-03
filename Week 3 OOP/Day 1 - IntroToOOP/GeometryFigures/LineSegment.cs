using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class LineSegment
    {
        private Point firstPoint;
        private Point secondPoint;

        public LineSegment(Point firstPoint, Point secondPoint) 
        {
            if (firstPoint.Equals(secondPoint))
            {
                throw new ArgumentException("Cannot create a line segment with zero length");
            }

            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        public LineSegment(LineSegment lineSigment) 
        {
            this.firstPoint = lineSigment.firstPoint;
            this.secondPoint = lineSigment.secondPoint;
        }

        public Point GetFirstPoint 
        {
            get 
            {
                return this.firstPoint;
            }
        }

        public Point GetSecondPoint 
        {
            get 
            {
                return this.secondPoint;
            }
        }

        public double GetLength() 
        {
            double first = this.GetFirstPoint.GetX - this.GetSecondPoint.GetX;
            double second = this.GetSecondPoint.GetY - this.GetSecondPoint.GetY;
            double distance = Math.Sqrt(first * first + second * second);
            return distance;
        }

        public override string ToString()
        {
            double firstX = this.GetFirstPoint.GetX;
            double firstY = this.GetFirstPoint.GetY;
            double secondX = this.GetSecondPoint.GetX;
            double secondY = this.GetSecondPoint.GetY;

            return string.Format("Line[({0},{1}), ({2},{3})]", firstX, firstY, secondX, secondY);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LineSegment))
            {
                throw new FormatException("The object must be LineSegment!");
            }
            var otherLineSegment = obj as LineSegment;
            var checkForEqualsX = this.GetFirstPoint.GetX == otherLineSegment.GetFirstPoint.GetX && this.GetSecondPoint.GetX == otherLineSegment.GetSecondPoint.GetX;
            var checkForEqualsY = this.GetFirstPoint.GetY == otherLineSegment.GetFirstPoint.GetY && this.GetSecondPoint.GetY == otherLineSegment.GetSecondPoint.GetY;
            if (checkForEqualsX && checkForEqualsY)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(LineSegment first, LineSegment second) 
        {
            return first.Equals(second);
        }

        public static bool operator !=(LineSegment first, LineSegment second)
        {
            return !first.Equals(second);
        }

        public static bool operator >(LineSegment first, LineSegment second)
        {
            double firstLenght = first.GetLength();
            double secondLenght = second.GetLength();
            if (firstLenght > secondLenght)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(LineSegment first, double length)
        {
            double firstLenght = first.GetLength();
            if (firstLenght > length)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(LineSegment first, LineSegment second)
        {
            double firstLenght = first.GetLength();
            double secondLenght = second.GetLength();
            if (firstLenght < secondLenght)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(LineSegment first, double length)
        {
            double firstLenght = first.GetLength();
            if (firstLenght < length)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(LineSegment first, LineSegment second)
        {
            double firstLenght = first.GetLength();
            double secondLenght = second.GetLength();
            if (firstLenght >= secondLenght)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(LineSegment first, double length)
        {
            double firstLenght = first.GetLength();
            if (firstLenght >= length)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(LineSegment first, LineSegment second)
        {
            double firstLenght = first.GetLength();
            double secondLenght = second.GetLength();
            if (firstLenght <= secondLenght)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(LineSegment first, double length)
        {
            double firstLenght = first.GetLength();
            if (firstLenght <= length)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.GetFirstPoint.GetHashCode();
                hash = hash * 23 + this.GetSecondPoint.GetHashCode();
                return hash;
            }
        }
    }
}
