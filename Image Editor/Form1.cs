using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NETInputOutput;

namespace Image_Editor
{
    public partial class Form1 : Form
    {
        Bitmap image;
        List<Bitmap> previousStates = new List<Bitmap>();
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        public void DrawImage()
        {
            if (image != null)
            {
                Bitmap display = (Bitmap)image.Clone();
                display = ImageTools.ResizeImage(Width - 32, Height - 63, display);
                g.Clear(BackColor);
                g.DrawImage(display, 8, 16);
            }
        }

        private void ditheringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image != null)
            {

                int[] vals = NETIO.InputInt(3, "Details", "Effect Details", new string[] { "Color Count", "Iterations", "Minimum Alpha" }, new string[] { "16", "2", "64" });

                previousStates.Add(new Bitmap(image));
                image = ImageTools.SegmentImage(vals[0], image, vals[1], vals[2]);
                DrawImage();
            }
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                previousStates.Add(new Bitmap(image));
                image = ImageTools.GrayScaleImage(image);
                DrawImage();
            }
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                previousStates.Add(new Bitmap(image));
                image = ImageTools.InvertImage(image);
                DrawImage();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(open.FileName);
                DrawImage();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                image.Save(save.FileName);
            }
        }

        private void increaseColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                int[] rgbVals = NETIO.InputInt(3, "Color", "RGB Values", new string[] { "R:", "G:", "B:" }, new string[] { "", "", "" });

                previousStates.Add(new Bitmap(image));
                image = ImageTools.IncreaseColors(image, rgbVals[0], rgbVals[1], rgbVals[2]);
                DrawImage();
            }
        }

        private void flipXAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                previousStates.Add(image);
                image = ImageTools.Flip(image, "x");
                DrawImage();
            }
        }

        private void flipYAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                previousStates.Add(image);
                image = ImageTools.Flip(image, "y");
                DrawImage();
            }
        }

        private void bubbleEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image != null)
            {

                float[] vals = NETIO.InputFloat(3, "Details", "Effect Details", new string[] { "Bubble Count", "Bubble Opacity Divider", "Image Mixing Divider" }, new string[] { "", "", "" });

                previousStates.Add(image);
                image = ImageTools.BubbleEffect(image, (int)vals[0], vals[1], vals[2]);
                DrawImage();
            }
        }

        private void circleSamplingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                int[] vals = NETIO.InputInt(4, "Details", "Effect Details", new string[] { "Samples", "Radius", "Alpha", "Scaling" }, new string[] { "1600", "50", "96", "2" });
                
                previousStates.Add(image);
                image = ImageTools.CircleSampling(image, vals[0], vals[1], vals[2], vals[3]);
                DrawImage();
            }
        }


        private void colorDistancingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image != null)
            {
                int[] inputs = NETIO.InputInt(2, "Details", "Distancing Info", new string[] { "Minimum Alpha", "Count" }, new string[] { "64", "3" });
                int minAlpha = inputs[0];
                int input = inputs[1];

                string[] labels = new string[input];
                string[] defaults = new string[input];

                for(int i = 0; i < input; i++)
                {
                    labels[i] = "Color #" + (i+1).ToString();
                    defaults[i] = "0, 0, 0";
                }

                string[] colorsString = NETIO.InputString(input, "Details", "Specify Colors", labels, defaults);
                Color[] colors = new Color[input];
                for(int i = 0; i < input; i++)
                {
                    string s = colorsString[i];
                    s = s.Replace(" ", "");
                    string[] vals = s.Split(',');
                    colors[i] = Color.FromArgb(int.Parse(vals[0]), int.Parse(vals[1]), int.Parse(vals[2]));
                }
                previousStates.Add(image);
                image = ImageTools.SegmentImage(image, colors, minAlpha);
                DrawImage();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(image != null)
            {
                g = CreateGraphics();
                DrawImage();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(previousStates.Count > 0)
            {
                image = new Bitmap(previousStates.ElementAt(previousStates.Count - 1));
                previousStates.RemoveAt(previousStates.Count - 1);

                DrawImage();
            }
        }
    }
}
