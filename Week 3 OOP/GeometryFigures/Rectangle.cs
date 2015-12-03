using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class Rectangle
    {
        private readonly Point lowerLeftPoint;
        private readonly Point lowerRightPoint;
        private readonly Point upperLeftPoint;
        private readonly Point upperRightPoint;
        private readonly LineSegment lowerSide;
        private readonly LineSegment upperSide;
        private readonly LineSegment leftSide;
        private readonly LineSegment rightSide;
        private readonly double width;
        private readonly double height;
        private readonly Point center;

        public Rectangle(Point first, Point second)
        {
            if (first.GetX == second.GetX || first.GetY == second.GetY) 
            {
                throw new ArgumentException("Points cannot be on same axis!");
            } 

            if (first.GetY > second.GetY)
            {
		//Reverse points for to avoid exceptions

                Point tempPoint = first;
                first = second;
                second = tempPoint;
            }

            this.width = second.GetX - first.GetX;
            this.height = second.GetY - first.GetY;

            this.lowerLeftPoint = first;
            this.upperLeftPoint = new Point(first.GetX, second.GetY - this.width);
            this.upperRightPoint = second;
            this.lowerRightPoint = new Point(second.GetX, first.GetY + this.width);

            this.upperSide = new LineSegment(this.upperLeftPoint, this.upperRightPoint);
            this.lowerSide = new LineSegment(this.lowerLeftPoint, this.lowerRightPoint);
            this.leftSide = new LineSegment(this.lowerLeftPoint, this.upperLeftPoint);
            this.rightSide = new LineSegment(this.lowerRightPoint, this.upperRightPoint);

            this.center = new Point(first.GetX + this.width / 2, first.GetY + this.height / 2);
        }

        public Rectangle(Rectangle rectangle) 
        {
            Point first = rectangle.lowerLeftPoint;
            Point second = rectangle.upperRightPoint;

            if (first.GetY > second.GetY)
            {
		//Reverse points for to avoid exceptions

                Point tempPoint = first;
                first = second;
                second = tempPoint;
            }

            this.width = second.GetX - first.GetX;
            this.height = second.GetY - first.GetY;

            this.lowerLeftPoint = first;
            this.upperLeftPoint = new Point(first.GetX, second.GetY - this.width);
            this.upperRightPoint = second;
            this.lowerRightPoint = new Point(second.GetX, first.GetY + this.width);

            this.upperSide = new LineSegment(this.upperLeftPoint, this.upperRightPoint);
            this.lowerSide = new LineSegment(this.lowerLeftPoint, this.lowerRightPoint);
            this.leftSide = new LineSegment(this.lowerLeftPoint, this.upperLeftPoint);
            this.rightSide = new LineSegment(this.lowerRightPoint, this.upperRightPoint);

            this.center = new Point(first.GetX + this.width / 2, first.GetY + this.height / 2);
        }

        public Point LowerLeftPoint 
        {
            get 
            {
                return this.lowerLeftPoint; 
            }
        }

        public Point LowerRightPoint 
        {
            get 
            {
                return this.lowerRightPoint; 
            } 
        }

        public Point UpperLeftPoint 
        {
            get 
            {
                return this.upperLeftPoint; 
            }
        }

        public Point UpperRightPoint 
        {
            get
            {
                return this.upperRightPoint;
            }
        }

        public LineSegment LowerSide 
        {
            get 
            {
                return this.lowerSide; 
            }
        }

        public LineSegment UpperSide 
        { 
            get
            {
                return this.upperSide; 
            }
        }

        public LineSegment LeftSide 
        {
            get
            {
                return this.leftSide;
            }
        }

        public LineSegment RightSide 
        {
            get
            { 
                return this.rightSide; 
            } 
        }

        public double Width 
        {
            get
            {
                return this.width;
            }
        }

        public double Height 
        {
            get 
            {
                return this.height; 
            }
        }

        public Point Center 
        {
            get
            {
                return this.center; 
            }
        }

        public double GetPerimeter()
        {
            return 2 * this.width + 2 * this.height;
        }

        public double GetArea()
        {
            return this.width * this.height;
        }

        public override string ToString()
        {
            return string.Format("Rectangle[({0}, {1}), ({2}, {3})]", this.lowerLeftPoint.GetX, this.lowerLeftPoint.GetY, this.height, this.width);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                Rectangle rect = obj as Rectangle;
                if (!this.lowerLeftPoint.Equals(rect.lowerLeftPoint)) return false;
                if (!this.lowerRightPoint.Equals(rect.lowerRightPoint)) return false;
                if (!this.upperLeftPoint.Equals(rect.upperLeftPoint)) return false;
                if (!this.upperRightPoint.Equals(rect.upperRightPoint)) return false;
                if (!this.lowerSide.Equals(rect.lowerSide)) return false;
                if (!this.upperSide.Equals(rect.upperSide)) return false;
                if (!this.leftSide.Equals(rect.leftSide)) return false;
                if (!this.rightSide.Equals(rect.rightSide)) return false;
                if (!this.width.Equals(rect.width)) return false;
                if (!this.height.Equals(rect.height)) return false;
                if (!this.center.Equals(rect.center)) return false;

                return true;
            }
            else return false;
        }

        public static bool operator ==(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Equals(rect2);
        }

        public static bool operator !=(Rectangle rect1, Rectangle rect2)
        {
            return !rect1.Equals(rect2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 7;
                hash = hash * 3 + this.lowerLeftPoint.GetHashCode();
                hash = hash * 3 + this.lowerRightPoint.GetHashCode();
                hash = hash * 3 + this.upperLeftPoint.GetHashCode();
                hash = hash * 3 + this.upperRightPoint.GetHashCode();
                hash = hash * 3 + this.lowerSide.GetHashCode();
                hash = hash * 3 + this.upperSide.GetHashCode();
                hash = hash * 3 + this.leftSide.GetHashCode();
                hash = hash * 3 + this.rightSide.GetHashCode();
                hash = hash * 3 + this.width.GetHashCode();
                hash = hash * 3 + this.height.GetHashCode();
                hash = hash * 3 + this.center.GetHashCode();

                return hash;
            }
        }
    }
}
