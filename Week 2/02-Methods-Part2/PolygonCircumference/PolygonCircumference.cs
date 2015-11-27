using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System;

public class PolygonCircumference
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

        var result = CalcCircumference(points);
        Console.WriteLine(result);
    }
    public static float CalcCircumference(PointF[] points)
    {
        List<PointF> pointsList = new List<PointF>();
        pointsList = points.ToList();

        pointsList.Add(pointsList[0]);
        double result = 0;
        for (int i = 0; i < pointsList.Count - 1; i++)
        {
            result += DistanceTo(pointsList[i + 1], pointsList[i]);
        }
        pointsList.RemoveAt(pointsList.Count - 1);
        return (float)result;
    }
    private static double DistanceTo(PointF point, PointF secondPoint)
    {
        return Math.Sqrt((secondPoint.X - point.X) * (secondPoint.X - point.X) + (secondPoint.Y - point.Y) * (secondPoint.Y - point.Y));
    }
}

