using System;
using System.Drawing;

public class PrintInflateRectangle
{
    public static void Main()
    {
        Rectangle rect = new Rectangle(0, 0, 10, 10);
        Size size = new Size(2, 2);

        //Result:
        Inflate(ref rect, size);

        Console.WriteLine("(x:{0}, y:{1}, w:{2}, h:{3})", rect.X, rect.Y, rect.Width, rect.Height);
    }

    public static void Inflate(ref Rectangle rect, Size inflateSize)
    {
        rect.Inflate(inflateSize.Width, inflateSize.Height);
    }
}

