namespace Image_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ditheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipXAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipYAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bubbleEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleSamplingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDistancingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.undoToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton2.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ditheringToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.invertColorsToolStripMenuItem,
            this.increaseColorsToolStripMenuItem,
            this.flipXAxisToolStripMenuItem,
            this.flipYAxisToolStripMenuItem,
            this.bubbleEffectToolStripMenuItem,
            this.circleSamplingToolStripMenuItem,
            this.colorDistancingToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripDropDownButton1.Text = "Effects";
            // 
            // ditheringToolStripMenuItem
            // 
            this.ditheringToolStripMenuItem.Name = "ditheringToolStripMenuItem";
            this.ditheringToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ditheringToolStripMenuItem.Text = "Dithering";
            this.ditheringToolStripMenuItem.Click += new System.EventHandler(this.ditheringToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayScaleToolStripMenuItem.Text = "Gray Scale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // invertColorsToolStripMenuItem
            // 
            this.invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            this.invertColorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invertColorsToolStripMenuItem.Text = "Invert Colors";
            this.invertColorsToolStripMenuItem.Click += new System.EventHandler(this.invertColorsToolStripMenuItem_Click);
            // 
            // increaseColorsToolStripMenuItem
            // 
            this.increaseColorsToolStripMenuItem.Name = "increaseColorsToolStripMenuItem";
            this.increaseColorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.increaseColorsToolStripMenuItem.Text = "Increase Colors";
            this.increaseColorsToolStripMenuItem.Click += new System.EventHandler(this.increaseColorsToolStripMenuItem_Click);
            // 
            // flipXAxisToolStripMenuItem
            // 
            this.flipXAxisToolStripMenuItem.Name = "flipXAxisToolStripMenuItem";
            this.flipXAxisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.flipXAxisToolStripMenuItem.Text = "Flip X-Axis";
            this.flipXAxisToolStripMenuItem.Click += new System.EventHandler(this.flipXAxisToolStripMenuItem_Click);
            // 
            // flipYAxisToolStripMenuItem
            // 
            this.flipYAxisToolStripMenuItem.Name = "flipYAxisToolStripMenuItem";
            this.flipYAxisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.flipYAxisToolStripMenuItem.Text = "Flip Y-Axis";
            this.flipYAxisToolStripMenuItem.Click += new System.EventHandler(this.flipYAxisToolStripMenuItem_Click);
            // 
            // bubbleEffectToolStripMenuItem
            // 
            this.bubbleEffectToolStripMenuItem.Name = "bubbleEffectToolStripMenuItem";
            this.bubbleEffectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bubbleEffectToolStripMenuItem.Text = "Bubble Effect";
            this.bubbleEffectToolStripMenuItem.Click += new System.EventHandler(this.bubbleEffectToolStripMenuItem_Click);
            // 
            // circleSamplingToolStripMenuItem
            // 
            this.circleSamplingToolStripMenuItem.Name = "circleSamplingToolStripMenuItem";
            this.circleSamplingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.circleSamplingToolStripMenuItem.Text = "Circle Sampling";
            this.circleSamplingToolStripMenuItem.Click += new System.EventHandler(this.circleSamplingToolStripMenuItem_Click);
            // 
            // colorDistancingToolStripMenuItem
            // 
            this.colorDistancingToolStripMenuItem.Name = "colorDistancingToolStripMenuItem";
            this.colorDistancingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorDistancingToolStripMenuItem.Text = "Color Distancing";
            this.colorDistancingToolStripMenuItem.Click += new System.EventHandler(this.colorDistancingToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Effects";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ditheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipXAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipYAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bubbleEffectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleSamplingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDistancingToolStripMenuItem;
    }
}

