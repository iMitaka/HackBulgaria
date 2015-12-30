namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Area = width * height;
            this.Perimeter = 2 * (this.Width + this.Height);
            this.Center = new Point(0.5 * this.Width, 0.5 * this.Height);
        }

        public double Width { get; protected set; }

        public double Height { get; protected set; }

        public override string ToString()
        {
            return string.Format("Rectangle with Width:{0}, Height:{1}, Center:{2}, Perimeter:{3:F2} & Area:{4:F2}.", this.Width, this.Height, this.Center, this.Perimeter, this.Area);
        }
    }
}
