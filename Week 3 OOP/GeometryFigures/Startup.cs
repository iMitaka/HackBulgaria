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
            Point firstPoint = new Point(5,5);
            Point secondPoint = new Point(7,7);
           
            LineSegment first = new LineSegment(firstPoint,secondPoint);
            LineSegment second = new LineSegment(firstPoint, secondPoint);

            Console.WriteLine(first > second);
            Console.WriteLine(first >= second);
            Console.WriteLine(first == second);

            LineSegment twoPoints = firstPoint + secondPoint;
        }
    }
}
