namespace Shapes
{
    using System;

    public class Circle : Ellipse
    {
        public Circle(double axes)
            : base(axes, axes)
        {
            this.Radius = axes;
            if (this.SemiAxesY > this.SemiAxesX)
            {
                this.SemiAxesX = this.SemiAxesY;
            }
            else
            {
                this.SemiAxesY = this.SemiAxesX;
            }

            this.Area = Math.PI * Math.Pow(this.Radius, 2);
            this.Perimeter = 2 * Math.PI * this.Radius;
            this.Center = new Point(this.Radius, this.Radius);
        }

        protected double Radius { get; set; }

        public override double GetArea()
        {
            return this.Area;
        }

        public override double GetPerimeter()
        {
            return this.Perimeter;
        }

        public override string ToString()
        {
            return string.Format("Circle with Radius:{0}, Center:{1}, Perimeter:{2:F2} & Area:{3:F2}.", this.Radius, this.Center, this.Perimeter, this.Area);
        }
    }
}
