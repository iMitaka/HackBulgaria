using System.Drawing;
using System.Drawing.Drawing2D;
public class InterpolateImage
{
    public static void Main()
    {
        Bitmap bitmap = (Bitmap)Image.FromFile("images.bmp");
        string path = "InterpolateImage.bmp";
        Size size = new Size(1920, 1080);
        ResampleImage(bitmap, size, path);
    }

    public static void ResampleImage(Bitmap bitmap, Size newSize, string savePath)
    {
        Bitmap result = new Bitmap(newSize.Width, newSize.Height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(bitmap, 0, 0, newSize.Width, newSize.Height);
        }

        result.Save(savePath);
    }
}

