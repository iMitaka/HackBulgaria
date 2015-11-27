using System;

public class FindClockAngle
{
    public static void Main()
    {

        Console.WriteLine("the angle is {0} degrees at {1:hh:mm}", GetClockHandsAngle(DateTime.Now), DateTime.Now);
    }

    public static int GetClockHandsAngle(DateTime time)
    {
        return (int)angle(time.Hour, time.Minute);
    }
    private static double angle(int h, int m)
    {
        double hAngle = 0.5D * (h * 60 + m);
        double mAngle = 6 * m;
        double angle = Math.Abs(hAngle - mAngle);
        angle = Math.Min(angle, 360 - angle);
        return angle;
    }
}

