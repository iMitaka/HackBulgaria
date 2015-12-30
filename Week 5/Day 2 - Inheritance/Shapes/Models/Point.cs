namespace Shapes
{
    public class Point : IMoveable
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public void Move(double x, double y)
        {
            this.X += x;
            this.Y += y;
        }

        public override string ToString()
        {
            return string.Format("Point(X={0},Y={1})", this.X, this.Y);
        }
    }
}
