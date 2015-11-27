using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class PolygonArea
{
    public static void Main()
    {
        List<PointF> pointsList = new List<PointF>();
        pointsList.Add(new PointF(15.2f, 12.2f));
        pointsList.Add(new PointF(16.2f, 51.2f));
        pointsList.Add(new PointF(27.2f, 23.2f));
        pointsList.Add(new PointF(35.2f, 42.2f));

        PointF[] points = pointsList.ToArray();

        //Reasult:

        var result = CalcArea(points);
        Console.WriteLine(result);
    }
    public static float CalcArea(PointF[] points)
    {
        int i, j;
        double area = 0;

        for (i = 0; i < points.Length; i++)
        {
            j = (i + 1) % points.Length;

            area += points[i].X * points[j].Y;
            area -= points[i].Y * points[j].X;
        }

        area /= 2;
        return (float)(area < 0 ? -area : area);
    }
   
    // Solution with List:
    //
    //public static float Area(List<PointF> vertices)
    //{
    //    vertices.Add(vertices[0]);
    //    return Math.Abs(vertices.Take(vertices.Count - 1).Select((p, i) => (p.X * vertices[i + 1].Y) - (p.Y * vertices[i + 1].X)).Sum() / 2);
    //}
}

