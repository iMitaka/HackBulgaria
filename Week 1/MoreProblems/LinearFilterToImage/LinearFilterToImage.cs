using System.Drawing;

public class LinearFilterToImage
{
    public static void Main()
    {
        var bitmap = (Bitmap)System.Drawing.Image.FromFile("images.bmp");
        string path = "BluredImage.bmp";

        Blur(bitmap, path);
    }

    public static void Blur(Bitmap image, string savePath)
    {
        int blurSize = 5;
        Bitmap blurred = new Bitmap(image.Width, image.Height);
        Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
        using (Graphics graphics = Graphics.FromImage(blurred))
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

        for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
        {
            for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
            {
                int avgR = 0, avgG = 0, avgB = 0;
                int blurPixelCount = 0;
                for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                {
                    for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                    {
                        Color pixel = blurred.GetPixel(x, y);

                        avgR += pixel.R;
                        avgG += pixel.G;
                        avgB += pixel.B;

                        blurPixelCount++;
                    }
                }

                avgR = avgR / blurPixelCount;
                avgG = avgG / blurPixelCount;
                avgB = avgB / blurPixelCount;
                for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                    for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                        blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
            }
        }
        blurred.Save(savePath);
    }
}

