using ImageEditor;
using System.Drawing;

namespace Image_Editor
{
    public static class ImageTools
    {
        static KMeans kmeans = new KMeans();

        public static Bitmap SegmentImage(int colors, Bitmap image, int iterations, int minAlpha)
        {
            Color[,] map = kmeans.KMeansAlgorithm(image, colors, iterations, minAlpha);
            return kmeans.ConvertColorMapToImage(map);
        }

        public static Bitmap SegmentImage(Bitmap image, Color[] colors, int minAlpha)
        {
            Color[,] map = kmeans.KMeansAlgorithm(image, colors, minAlpha);
            return kmeans.ConvertColorMapToImage(map);
        }

        public static Bitmap ResizeImage(int width, int height, Bitmap image)
        {
            if (width < 1) width = 1;
            if (height < 1) height = 1;
            Bitmap newImg = new Bitmap(width, height);

            using(Graphics g = Graphics.FromImage(newImg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
                g.Dispose();
            }

            return newImg;
        }

        public static Bitmap GrayScaleImage(Bitmap image)
        {
            Bitmap copy = new Bitmap(image);
            return kmeans.ConvertToGrayScale(copy);
        }

        public static Bitmap CircleSampling(Bitmap image, int samples, int radius, int alpha, int scale)
        {
            return Sampling.sampleImage(image, samples, radius, alpha, scale);
        }

        public static Bitmap BubbleEffect(Bitmap image, int points, float div1, float div2)
        {
            Bitmap copy = new Bitmap(image);
            return Bubbles.GenerateNoise(copy.Width, copy.Height, points, copy, div1, div2);
        }

        public static Bitmap InvertImage(Bitmap image)
        {
            Bitmap copy = new Bitmap(image);

            for(int x = 0; x < copy.Width; x++)
            {
                for(int y = 0; y < copy.Height; y++)
                {
                    copy.SetPixel(x, y, invert(copy.GetPixel(x, y)));
                }
            }

            return copy;
        }

        public static Bitmap IncreaseColors(Bitmap image, int r, int g, int b)
        {
            Bitmap copy = new Bitmap(image);

            for (int x = 0; x < copy.Width; x++)
            {
                for (int y = 0; y < copy.Height; y++)
                {
                    Color pix = copy.GetPixel(x, y);

                    int newR = pix.R + r > 255 ? 255 : pix.R + r;
                    int newG = pix.G + g > 255 ? 255 : pix.G + g;
                    int newB = pix.B + b > 255 ? 255 : pix.B + b;

                    if (newR < 0) newR = 0;
                    if (newG < 0) newG = 0;
                    if (newB < 0) newB = 0;

                    copy.SetPixel(x, y, Color.FromArgb(pix.A, newR, newG, newB));
                }
            }

            return copy;
        }

        public static Bitmap Flip(Bitmap image, string axis)
        {
            Bitmap copy = new Bitmap(image);
            Bitmap newImg = new Bitmap(copy.Width, copy.Height);

            for (int x = 0; x < copy.Width; x++)
            {
                for (int y = 0; y < copy.Height; y++)
                {
                    int newX = copy.Width - 1 - x;
                    int newY = copy.Height - 1 - y;

                    if (axis == "x") newY = y;
                    if (axis == "y") newX = x;

                    newImg.SetPixel(newX, newY, copy.GetPixel(x, y));
                }
            }

            return newImg;
        }

        static Color invert(Color c)
        {
            return Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B);
        }
    }
}
