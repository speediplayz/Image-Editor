using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor
{
    public static class Sampling
    {
        public static Bitmap sampleImage(Bitmap original, int imageSamples, int radius, int alpha, int scale)
        {
            Random rand = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            Bitmap image = new Bitmap(original);

            int samples = imageSamples;

            Bitmap output = new Bitmap((int)(image.Width * scale), (int)(image.Height * scale));
            Graphics g = Graphics.FromImage(output);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, output.Width, output.Height);

            for (int i = 0; i < samples; i++)
            {
                int randX = rand.Next(0, image.Width);
                int randY = rand.Next(0, image.Height);

                Color pixel = image.GetPixel(randX, randY);
                Color newPix = Color.FromArgb(alpha, pixel);

                g.FillEllipse(new SolidBrush(newPix), ((randX * scale) - radius), ((randY * scale) - radius), (float)radius * 2, (float)radius * 2);
            }

            g.Dispose();
            return output;
        }
    }
}
