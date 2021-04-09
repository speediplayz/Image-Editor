using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor
{
    class Vector
    {
        public double r, g, b;
        public int x, y;

        public Vector(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double distance(Vector toVector)
        {
            double distance = 0;

            double rDifSq = Math.Pow(r - toVector.r, 2);
            double gDifSq = Math.Pow(g - toVector.g, 2);
            double bDifSq = Math.Pow(b - toVector.b, 2);

            distance = Math.Sqrt(rDifSq + gDifSq + bDifSq);

            return Math.Abs(distance);
        }
    }
}
