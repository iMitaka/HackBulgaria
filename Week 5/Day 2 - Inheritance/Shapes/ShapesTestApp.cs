using System;
using System.Collections.Generic;

namespace Shapes
{
    public class Program
    {
        public static void Main()
        {
            var shapes = new List<Shape>();
            var square = new Square(10);
            var rectangle = new Rectangle(5.5, 6.5);
            var triangle = new Triangle(new Point(1, 5), new Point(3, 7), new Point(8, 3));
            var ellipse = new Ellipse(3, 7);
            var circle = new Circle(5.5);
            shapes.Add(circle);
            shapes.Add(ellipse);
            shapes.Add(triangle);
            shapes.Add(rectangle);
            shapes.Add(square);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
                Console.WriteLine();
            }
        }
    }
}
