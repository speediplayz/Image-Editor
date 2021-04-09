using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Image_Editor
{
    public static class Bubbles
    {

        public static Bitmap GenerateNoise(int width, int height, int pointCount, Bitmap image, float div1, float div2)
        {
            List<Point> points = new List<Point>();
            List<List<Point>> pointGroups = new List<List<Point>>();

            for (int i = 0; i < pointCount; i++)
            {
                List<Point> list = new List<Point>();
                Random r = new Random(DateTime.Now.Millisecond);
                int x = r.Next(0, width);
                int y = r.Next(0, height);

                while (points.Contains(new Point(x, y)))
                {
                    x = r.Next(0, width);
                    y = r.Next(0, height);
                }

                points.Add(new Point(x, y));
                pointGroups.Add(list);
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float closest = float.PositiveInfinity;
                    int index = -1;

                    for (int i = 0; i < points.Count; i++)
                    {
                        Point p = points[i];
                        float dist = distance(x, y, p.X, p.Y);
                        if (dist < closest)
                        {
                            closest = dist;
                            index = i;
                        }
                    }

                    pointGroups[index].Add(new Point(x, y));
                }
            }

            List<Point> centers = new List<Point>();
            List<Point> furthestPoints = new List<Point>();

            foreach (List<Point> pointList in pointGroups)
            {
                int x = 0, y = 0;
                foreach (Point p in pointList)
                {
                    x += p.X;
                    y += p.Y;
                }
                x /= pointList.Count;
                y /= pointList.Count;
                centers.Add(new Point(x, y));

                float furthest = 0;
                int index = -1;

                for (int i = 0; i < pointList.Count; i++)
                {
                    Point p = pointList[i];
                    float dist = distance(p.X, p.Y, x, y);
                    if (dist > furthest)
                    {
                        furthest = dist;
                        index = i;
                    }
                }
                furthestPoints.Add(pointList[index]);
            }

            Bitmap noise = new Bitmap(width, height);

            for (int i = 0; i < pointGroups.Count; i++)
            {
                List<Point> pointList = pointGroups[i];
                Point center = centers[i];
                Point furthest = furthestPoints[i];
                float farDist = distance(center.X, center.Y, furthest.X, furthest.Y);

                foreach (Point p in pointList)
                {
                    float dist = distance(p.X, p.Y, center.X, center.Y);
                    float val = 1f - (dist / farDist);
                    int cVal = (int)(val * 255);
                    noise.SetPixel(p.X, p.Y, Color.FromArgb(cVal, cVal, cVal));
                }
            }

            Bitmap returnImage = new Bitmap(width, height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int pixelValR = (int)((image.GetPixel(x, y).R + noise.GetPixel(x, y).R / div1) / div2);
                    int pixelValG = (int)((image.GetPixel(x, y).G + noise.GetPixel(x, y).G / div1) / div2);
                    int pixelValB = (int)((image.GetPixel(x, y).B + noise.GetPixel(x, y).B / div1) / div2);
                    if (pixelValR > 255) pixelValR = 255;
                    if (pixelValG > 255) pixelValG = 255;
                    if (pixelValB > 255) pixelValB = 255;
                    returnImage.SetPixel(x, y, Color.FromArgb(pixelValR, pixelValG, pixelValB));
                }
            }
            return returnImage;
        }

        private static float distance(int x1, int y1, int x2, int y2)
        {
            return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}
