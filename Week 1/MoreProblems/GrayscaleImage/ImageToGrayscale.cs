using System.Drawing;

public class ImageToGrayscale
{
    public static void Main()
    {
        string path = "Grayscale.bmp";
        Bitmap bitmap = (Bitmap)Image.FromFile("images.bmp");
        GreyScaleImage(bitmap, path);
    }


    public static void GreyScaleImage(Bitmap bitmap, string savePath)
    {
        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                Color pixel = bitmap.GetPixel(i, j);
                //Color newPixel = Color.FromArgb(pixel.G, pixel.B, pixel.R);
                int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                Color grey = Color.FromArgb(pixel.A, grayScale, grayScale, grayScale);
                bitmap.SetPixel(i, j, grey);
            }
        }

        bitmap.Save(savePath);
    }
}

