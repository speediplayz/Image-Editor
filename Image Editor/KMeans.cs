using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace ImageEditor
{
    class KMeans
    {

        public Color[,] KMeansAlgorithm(Bitmap image, Color[] colors, int minAlpha)
        {
            Vector[,] vectorList = new Vector[image.Width, image.Height];
            Color[,] output = new Color[image.Width, image.Height];

            //convert image to vector list
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    if (pixel.A >= minAlpha)
                    {
                        vectorList[x, y] = new Vector(pixel.R, pixel.G, pixel.B);
                    }
                }
            }

            for(int y = 0; y < vectorList.GetLength(1); y++)
            {
                for(int x = 0; x < vectorList.GetLength(0); x++)
                {
                    if(vectorList[x,y] != null)
                    {
                        Vector c = vectorList[x, y];
                        Color closest = FindClosestColor(Color.FromArgb((int)c.r, (int)c.g, (int)c.b), colors);
                        output[x, y] = closest;
                    }
                }
            }

            return output;
        }

        private Color FindClosestColor(Color t, Color[] colors)
        {
            Color min = colors[0];
            double minDist = double.PositiveInfinity;

            foreach(Color c in colors)
            {
                double dist = Math.Sqrt((c.R-t.R)*(c.R-t.R)+(c.G-t.G)*(c.G-t.G)+(c.B-t.B)*(c.B-t.B));
                if(dist < minDist) { minDist = dist; min = c; }
            }

            return min;
        }

        public Color[,] KMeansAlgorithm(Bitmap image, int k, int iterations, int minAlpha)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            List<Vector> centroids = new List<Vector>();
            List<List<Vector>> clusters = new List<List<Vector>>();
            Vector[,] vectorList = new Vector[image.Width, image.Height];

            //convert image to vector list
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    if(pixel.A >= minAlpha)
                    {
                        vectorList[x, y] = new Vector(pixel.R, pixel.G, pixel.B);
                    }
                }
            }

            //generate k random points
            for (int i = 0; i < k; i++)
            {
                int x = rand.Next(0, vectorList.GetLength(0));
                int y = rand.Next(0, vectorList.GetLength(1));
                Color pix = image.GetPixel(x, y);
                while(pix.A < minAlpha)
                {
                    x = rand.Next(0, vectorList.GetLength(0));
                    y = rand.Next(0, vectorList.GetLength(1));
                    pix = image.GetPixel(x, y);
                }
                Vector centroid = vectorList[x, y];
                List<Vector> cluster = new List<Vector>();

                clusters.Add(cluster);
                centroids.Add(centroid);
            }

            for(int count = 0; count < iterations; count++)
            {
                //assign closest centroid to each pixel
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (vectorList[x, y] != null)
                        {
                            double distanceToCentroid = double.MaxValue;
                            int closestCentroidIndex = 0;
                            Vector current = vectorList[x, y];

                            current.setPosition(x, y);

                            foreach (Vector cen in centroids)
                            {
                                double distance = current.distance(cen);

                                if (distance < distanceToCentroid)
                                {
                                    distanceToCentroid = distance;
                                    closestCentroidIndex = centroids.IndexOf(cen);
                                }
                            }

                            clusters[closestCentroidIndex].Add(current);
                        }
                    }
                }

                //adjust centroid positions
                for (int i = 0; i < centroids.Count; i++)
                {
                    Vector cen = centroids[i];

                    int index = centroids.IndexOf(cen);
                    List<Vector> cluster = clusters[index];

                    double rTotal = 0;
                    double gTotal = 0;
                    double bTotal = 0;

                    foreach (Vector v in cluster)
                    {
                        rTotal += v.r;
                        gTotal += v.g;
                        bTotal += v.b;
                    }

                    Vector newCentroid = new Vector(rTotal / cluster.Count, gTotal / cluster.Count, bTotal / cluster.Count);
                    centroids[index] = newCentroid;
                }
            }

            //change colors of each cluster to centroid color
            List<Color> centroidColors = new List<Color>();
            Color[,] output = new Color[image.Width, image.Height];

            foreach(Vector cen in centroids)
            {
                //crash prevention - corrupt pixels will turn white
                if((int)cen.r < 0 || (int)cen.g < 0 || (int)cen.b < 0)
                {
                    cen.r = 0;
                    cen.g = 0;
                    cen.b = 0;
                }

                Color color = Color.FromArgb((int)cen.r, (int)cen.g, (int)cen.b);
                centroidColors.Add(color);
            }

            foreach(List<Vector> cluster in clusters)
            {
                int index = clusters.IndexOf(cluster);
                foreach(Vector v in cluster)
                {
                    v.r = centroidColors[index].R;
                    v.g = centroidColors[index].G;
                    v.b = centroidColors[index].B;

                    output[v.x, v.y] = Color.FromArgb((int)v.r, (int)v.g, (int)v.b);
                }
            }

            return output;
        }

        public Bitmap ConvertToGrayScale(Bitmap image)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    newImage.SetPixel(x, y, Color.FromArgb(pixel.A, gray, gray, gray));
                }
            }

            return newImage;
        }

        public Bitmap ConvertColorMapToImage(Color[,] colorMap)
        {
            int width = colorMap.GetLength(0);
            int height = colorMap.GetLength(1);

            Bitmap newImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    newImage.SetPixel(x, y, colorMap[x, y]);
                }
            }

            return newImage;
        }
    }
}
