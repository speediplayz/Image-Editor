using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NETInputOutput
{
    public static class NETIO
    {
        private static Form createForm(int width, int height, string title)
        {
            Form form = new Form();
            form.Size = new Size(width, height);
            form.Text = title;
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;

            return form;
        }

        public static double[] InputDouble(int size, string title, string displayMsg, string[] labels, string[] defaults)
        {
            double[] output = new double[size];
            TextBox[] boxes = new TextBox[size];

            Form form = createForm(289, 99 + size * 26, title);

            Label lblDisplay = new Label();
            lblDisplay.Location = new Point(16, 13);
            lblDisplay.Text = displayMsg;
            lblDisplay.AutoSize = true;

            for (int i = 0; i < size; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(122, 30 + i * 26);
                lbl.AutoSize = true;
                lbl.Text = labels[i] != null ? labels[i] : "Undefined";

                TextBox txt = new TextBox();
                txt.Size = new Size(100, 20);
                txt.Location = new Point(16, 30 + i * 26);
                txt.Text = defaults[i];

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                boxes[i] = txt;
            }

            Button cmdContinue = new Button();
            cmdContinue.Location = new Point(16, 30 + size * 26);
            cmdContinue.Size = new Size(245, 23);
            cmdContinue.Text = "Continue";
            cmdContinue.Click += (s, e) => form.Close();

            form.Controls.Add(lblDisplay);
            form.Controls.Add(cmdContinue);
            form.ShowDialog();
            form.Dispose();

            for (int i = 0; i < size; i++)
            {
                double val;
                if (double.TryParse(boxes[i].Text, out val)) output[i] = val;
            }

            return output;
        }

        public static int[] InputInt(int size, string title, string displayMsg, string[] labels, string[] defaults)
        {
            double[] doubles = InputDouble(size, title, displayMsg, labels, defaults);
            int[] output = new int[size];
            for (int i = 0; i < size; i++)
            {
                output[i] = (int)doubles[i];
            }
            return output;
        }

        public static float[] InputFloat(int size, string title, string displayMsg, string[] labels, string[] defaults)
        {
            double[] doubles = InputDouble(size, title, displayMsg, labels, defaults);
            float[] output = new float[size];
            for (int i = 0; i < size; i++)
            {
                output[i] = (float)doubles[i];
            }
            return output;
        }

        public static string[] InputString(int size, string title, string displayMsg, string[] labels, string[] defaults)
        {
            string[] output = new string[size];
            TextBox[] boxes = new TextBox[size];

            Form form = createForm(289, 99 + size * 26, title);

            Label lblDisplay = new Label();
            lblDisplay.Location = new Point(16, 13);
            lblDisplay.Text = displayMsg;
            lblDisplay.AutoSize = true;

            for (int i = 0; i < size; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(122, 30 + i * 26);
                lbl.AutoSize = true;
                lbl.Text = labels[i] != null ? labels[i] : "Undefined";

                TextBox txt = new TextBox();
                txt.Size = new Size(100, 20);
                txt.Location = new Point(16, 30 + i * 26);
                txt.Text = defaults[i];

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                boxes[i] = txt;
            }

            Button cmdContinue = new Button();
            cmdContinue.Location = new Point(16, 30 + size * 26);
            cmdContinue.Size = new Size(245, 23);
            cmdContinue.Text = "Continue";
            cmdContinue.Click += (s, e) => form.Close();

            form.Controls.Add(lblDisplay);
            form.Controls.Add(cmdContinue);
            form.ShowDialog();
            form.Dispose();

            for (int i = 0; i < size; i++)
            {
                output[i] = boxes[i].Text;
            }

            return output;
        }

        public static double[] InputDouble(int size, string title, string displayMsg, string[] labels)
        {
            string[] defaults = new string[size];
            for (int i = 0; i < size; i++) defaults[i] = "";

            return InputDouble(size, title, displayMsg, labels, defaults);
        }

        public static int[] InputInt(int size, string title, string displayMsg, string[] labels)
        {
            string[] defaults = new string[size];
            for (int i = 0; i < size; i++) defaults[i] = "";

            return InputInt(size, title, displayMsg, labels, defaults);
        }

        public static float[] InputFloat(int size, string title, string displayMsg, string[] labels)
        {
            string[] defaults = new string[size];
            for (int i = 0; i < size; i++) defaults[i] = "";

            return InputFloat(size, title, displayMsg, labels, defaults);
        }

        public static string[] InputString(int size, string title, string displayMsg, string[] labels)
        {
            string[] defaults = new string[size];
            for (int i = 0; i < size; i++) defaults[i] = "";

            return InputString(size, title, displayMsg, labels, defaults);
        }

        public static void MessageBox(string title, string[] lines)
        {
            Label[] labels = new Label[lines.Length];

            Form form = createForm(289, 93 + lines.Length * 16, title);

            for (int i = 0; i < lines.Length; i++)
            {
                Label lbl = new Label();
                lbl.Location = new Point(16, 16 * (i + 1));
                lbl.AutoSize = true;
                lbl.Text = lines[i];

                form.Controls.Add(lbl);
            }

            Button cmdContinue = new Button();
            cmdContinue.Location = new Point(16, 24 + lines.Length * 16);
            cmdContinue.Size = new Size(245, 23);
            cmdContinue.Text = "Close";
            cmdContinue.Click += (s, e) => form.Close();

            form.Controls.Add(cmdContinue);
            form.ShowDialog();
            form.Dispose();
        }

        public static void MessageBox(string title, object obj)
        {
            MessageBox(title, new string[] { obj.ToString() });
        }
    }
}
