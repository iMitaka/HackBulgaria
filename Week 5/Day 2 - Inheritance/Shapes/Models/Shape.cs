namespace Shapes
{
    public abstract class Shape : IMoveable
    {
        public Point Center { get; protected set; }

        protected double Perimeter { get; set; }

        protected double Area { get; set; }

        public virtual double GetPerimeter()
        {
            return this.Perimeter;
        }

        public virtual double GetArea()
        {
            return this.Area;
        }

        public override string ToString()
        {
            return string.Format("{0} with perimeter : {1} and area: {2}", this.GetType(), this.Perimeter, this.Area);
        }

        public void Move(double x, double y)
        {
            this.Center.X += x;
            this.Center.Y += y;
        }
    }
}
