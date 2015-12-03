using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    class Startup
    {
        static void Main(string[] args)
        {
            Point firstPoint = new Point(5, 5);
            Point secondPoint = new Point(7, 7);

            LineSegment first = new LineSegment(firstPoint, secondPoint);
            LineSegment second = new LineSegment(firstPoint, secondPoint);

            Console.WriteLine(first > second);
            Console.WriteLine(first >= second);
            Console.WriteLine(first == second);

            LineSegment twoPoints = firstPoint + secondPoint;

            Rectangle rect = new Rectangle(firstPoint, secondPoint);
            Rectangle anotherRect = new Rectangle(secondPoint, firstPoint);

            Console.WriteLine("Equals: " + rect.Equals(anotherRect));
            Console.WriteLine();
            Console.WriteLine("Width: {0}", rect.GetWidth);
            Console.WriteLine("Height: {0}", rect.GetHeight);
            Console.WriteLine("Lower Left: {0}", rect.GetLowerLeftPoint);
            Console.WriteLine("Lower Rigth: {0}", rect.GetLowerRightPoint);
            Console.WriteLine("Upper Left: {0}", rect.GetUpperLeftPoint);
            Console.WriteLine("Upper Rigth: {0}", rect.GetUpperRightPoint);
            Console.WriteLine("Perimeter: {0}", rect.GetPerimeter());
            Console.WriteLine("Area: {0}", rect.GetArea());
            Console.WriteLine("Center: {0}", rect.GetCenterPoint);
            Console.WriteLine();

            Vector vector = new Vector(new double[] { 1, 2, 3, 4 });
            Vector anotherVector = new Vector(new double[] { 5, 6, 7, 8, 9 });

            Console.WriteLine("{0} + {1} = {2}", vector, anotherVector, vector + anotherVector);
            Console.WriteLine("{0} - {1} = {2}", vector, anotherVector, vector - anotherVector);
            Console.WriteLine("{0} * {1} = {2}", vector, anotherVector, vector * anotherVector);
            double scalar = 0.7;
            Console.WriteLine("{0} - {1} = {2}", vector, scalar, vector - scalar);
            Console.WriteLine("{0} * {1} = {2}", vector, scalar, vector * scalar);
            Console.WriteLine();
        }
    }
}
