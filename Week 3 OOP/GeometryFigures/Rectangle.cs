using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class Rectangle
    {
        private Point first;
        private Point second;

        public Rectangle(Point first, Point second) 
        {
            this.first = first;
            this.second = second;
        }

        public Rectangle(Rectangle rectangle) 
        {
            this.first = rectangle.first;
            this.second = rectangle.second;
        }
    }
}
