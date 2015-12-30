namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
            this.Side = side;
            this.Height = this.Side;
            this.Width = this.Side;
        }

        protected double Side { get; set; }

        public override string ToString()
        {
            return string.Format("Square with Sides:{0}, Center:{1}, Perimeter:{2:F2} & Area:{3:F2}.", this.Side,this.Center,this.Perimeter,this.Area);
        }
    }
}
