namespace Shapes
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
            this.Vertex3 = vertex3;
            this.Perimeter = this.GetPerimeter();
            this.Area = this.GetArea();
            this.Center = new Point(0, 0);
        }

        protected Point Vertex1 { get; set; }

        protected Point Vertex2 { get; set; }

        protected Point Vertex3 { get; set; }

        public override double GetArea()
        {
            return ((this.Vertex1.X * (Math.Max(this.Vertex2.Y, this.Vertex3.Y) - Math.Min(this.Vertex2.Y, this.Vertex3.Y)))
                + (this.Vertex2.X * (Math.Max(this.Vertex1.Y, this.Vertex3.Y) - Math.Min(this.Vertex1.Y, this.Vertex3.Y)))
                + (this.Vertex3.X * (Math.Max(this.Vertex1.Y, this.Vertex2.Y) - Math.Min(this.Vertex1.Y, this.Vertex2.Y)))) / 2;
        }

        public override double GetPerimeter()
        {
            double first = Math.Sqrt(Math.Pow(Math.Max(this.Vertex1.X, this.Vertex2.X) - Math.Min(this.Vertex1.X, this.Vertex2.X), 2) + Math.Pow(Math.Max(this.Vertex1.Y, this.Vertex2.Y) - Math.Max(this.Vertex1.Y, this.Vertex2.Y), 2));
            double second = Math.Sqrt(Math.Pow(Math.Max(this.Vertex1.X, this.Vertex3.X) - Math.Min(this.Vertex1.X, this.Vertex3.X), 2) + Math.Pow(Math.Max(this.Vertex1.Y, this.Vertex3.Y) - Math.Max(this.Vertex1.Y, this.Vertex3.Y), 2));
            double tirth = Math.Sqrt(Math.Pow(Math.Max(this.Vertex3.X, this.Vertex2.X) - Math.Min(this.Vertex3.X, this.Vertex2.X), 2) + Math.Pow(Math.Max(this.Vertex3.Y, this.Vertex2.Y) - Math.Max(this.Vertex3.Y, this.Vertex2.Y), 2));
            return first + second + tirth;
        }

        public override string ToString()
        {
            return string.Format("Triangle with Vortex1:{0}, Vortex2:{1}, Vortex3:{2}, Center:{3}, Perimeter:{4:F2} & Area:{5:F2}.", this.Vertex1, this.Vertex2, this.Vertex3,this.Center,this.Perimeter,this.Area);
        }
    }
}
