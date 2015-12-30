namespace Shapes
{
    using System;

    public class Ellipse : Shape
    {
        public Ellipse(double axesX, double axesY)
        {
            this.SemiAxesX = axesX;
            this.SemiAxesY = axesY;
            this.Center = new Point(this.SemiAxesX, this.SemiAxesY);
            this.Area = Math.PI * this.SemiAxesX * this.SemiAxesY;
            this.Perimeter = Math.PI * ((3 * (this.SemiAxesX + this.SemiAxesY)) - Math.Sqrt(((3 * this.SemiAxesX) + this.SemiAxesY) * (this.SemiAxesX + (3 * this.SemiAxesY))));
        }

        protected double SemiAxesX { get; set; }

        protected double SemiAxesY { get; set; }

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
            return string.Format("Ellipse with SemiAxesX:{0}, SemiAxesY:{1}, Center:{2}, Perimeter:{3:F2} & Area:{4:F2}.",this.SemiAxesX,this.SemiAxesY,this.Center,this.Perimeter,this.Area);
        }
    }
}
