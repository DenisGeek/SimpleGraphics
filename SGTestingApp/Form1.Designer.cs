namespace SGTestingApp
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sgControlBox1 = new CustomControls.SGControlBox();
            sgpTriangleIsosceles2 = new CustomControls.SimpleGraphicsPrimitives.SGPTriangleIsosceles();
            sgpCircle2 = new CustomControls.SimpleGraphicsPrimitives.SGPCircle();
            sgpTriangleEquilateral1 = new CustomControls.SimpleGraphicsPrimitives.SGPTriangleEquilateral();
            sgpRectangle1 = new CustomControls.SimpleGraphicsPrimitives.SGPRectangle();
            sgpCircle1 = new CustomControls.SimpleGraphicsPrimitives.SGPCircle();
            sgControlBox2 = new CustomControls.SGControlBox();
            sgpTriangleIsosceles1 = new CustomControls.SimpleGraphicsPrimitives.SGPTriangleIsosceles();
            sgControlBox1.SuspendLayout();
            sgControlBox2.SuspendLayout();
            SuspendLayout();
            // 
            // sgControlBox1
            // 
            sgControlBox1.BackColor = SystemColors.MenuHighlight;
            sgControlBox1.Controls.Add(sgpTriangleIsosceles2);
            sgControlBox1.Controls.Add(sgpCircle2);
            sgControlBox1.Controls.Add(sgpTriangleEquilateral1);
            sgControlBox1.Controls.Add(sgpRectangle1);
            sgControlBox1.Controls.Add(sgpCircle1);
            sgControlBox1.Dock = DockStyle.Right;
            sgControlBox1.Location = new Point(433, 0);
            sgControlBox1.Name = "sgControlBox1";
            sgControlBox1.Size = new Size(369, 624);
            sgControlBox1.TabIndex = 0;
            // 
            // sgpTriangleIsosceles2
            // 
            sgpTriangleIsosceles2.BorderColor = Color.MediumBlue;
            sgpTriangleIsosceles2.BorderHighlightColor = Color.OrangeRed;
            sgpTriangleIsosceles2.BorderHighlightWidth = 3;
            sgpTriangleIsosceles2.DrawVertexAngle = false;
            sgpTriangleIsosceles2.FillColor = Color.Chartreuse;
            sgpTriangleIsosceles2.Location = new Point(56, 246);
            sgpTriangleIsosceles2.Name = "sgpTriangleIsosceles2";
            sgpTriangleIsosceles2.Size = new Size(124, 178);
            sgpTriangleIsosceles2.TabIndex = 4;
            sgpTriangleIsosceles2.Text = "sgpTriangleIsosceles2";
            // 
            // sgpCircle2
            // 
            sgpCircle2.BorderColor = Color.Lavender;
            sgpCircle2.BorderHighlightColor = Color.Violet;
            sgpCircle2.BorderHighlightWidth = 3;
            sgpCircle2.FillColor = Color.Green;
            sgpCircle2.Location = new Point(129, 26);
            sgpCircle2.Name = "sgpCircle2";
            sgpCircle2.Size = new Size(205, 189);
            sgpCircle2.TabIndex = 3;
            sgpCircle2.Text = "sgpCircle2";
            // 
            // sgpTriangleEquilateral1
            // 
            sgpTriangleEquilateral1.BorderColor = Color.DeepPink;
            sgpTriangleEquilateral1.BorderHighlightColor = Color.Violet;
            sgpTriangleEquilateral1.BorderHighlightWidth = 3;
            sgpTriangleEquilateral1.DrawSide = true;
            sgpTriangleEquilateral1.FillColor = Color.Cyan;
            sgpTriangleEquilateral1.Location = new Point(33, 117);
            sgpTriangleEquilateral1.Name = "sgpTriangleEquilateral1";
            sgpTriangleEquilateral1.Size = new Size(116, 98);
            sgpTriangleEquilateral1.TabIndex = 2;
            sgpTriangleEquilateral1.Text = "sgpTriangleEquilateral1";
            // 
            // sgpRectangle1
            // 
            sgpRectangle1.BorderColor = Color.Blue;
            sgpRectangle1.BorderHighlightColor = Color.Violet;
            sgpRectangle1.BorderHighlightWidth = 3;
            sgpRectangle1.FillColor = Color.Green;
            sgpRectangle1.Location = new Point(74, 174);
            sgpRectangle1.Name = "sgpRectangle1";
            sgpRectangle1.Size = new Size(231, 130);
            sgpRectangle1.TabIndex = 1;
            sgpRectangle1.Text = "sgpRectangle1";
            // 
            // sgpCircle1
            // 
            sgpCircle1.BorderColor = Color.Blue;
            sgpCircle1.BorderHighlightColor = Color.Violet;
            sgpCircle1.BorderHighlightWidth = 3;
            sgpCircle1.FillColor = Color.Green;
            sgpCircle1.Location = new Point(42, 26);
            sgpCircle1.Name = "sgpCircle1";
            sgpCircle1.Size = new Size(129, 142);
            sgpCircle1.TabIndex = 0;
            sgpCircle1.Text = "sgpCircle1";
            // 
            // sgControlBox2
            // 
            sgControlBox2.Controls.Add(sgpTriangleIsosceles1);
            sgControlBox2.Dock = DockStyle.Fill;
            sgControlBox2.Location = new Point(0, 0);
            sgControlBox2.Name = "sgControlBox2";
            sgControlBox2.Size = new Size(433, 624);
            sgControlBox2.TabIndex = 1;
            // 
            // sgpTriangleIsosceles1
            // 
            sgpTriangleIsosceles1.BorderColor = Color.Blue;
            sgpTriangleIsosceles1.BorderHighlightColor = Color.Violet;
            sgpTriangleIsosceles1.BorderHighlightWidth = 3;
            sgpTriangleIsosceles1.DrawVertexAngle = true;
            sgpTriangleIsosceles1.FillColor = Color.Green;
            sgpTriangleIsosceles1.Location = new Point(0, 0);
            sgpTriangleIsosceles1.Name = "sgpTriangleIsosceles1";
            sgpTriangleIsosceles1.Size = new Size(433, 624);
            sgpTriangleIsosceles1.TabIndex = 0;
            sgpTriangleIsosceles1.Text = "sgpTriangleIsosceles1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 624);
            Controls.Add(sgControlBox2);
            Controls.Add(sgControlBox1);
            Name = "Form1";
            Text = "Form1";
            sgControlBox1.ResumeLayout(false);
            sgControlBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.SGControlBox sgControlBox1;
        private CustomControls.SimpleGraphicsPrimitives.SGPTriangleEquilateral sgpTriangleEquilateral1;
        private CustomControls.SimpleGraphicsPrimitives.SGPRectangle sgpRectangle1;
        private CustomControls.SimpleGraphicsPrimitives.SGPCircle sgpCircle1;
        private CustomControls.SimpleGraphicsPrimitives.SGPCircle sgpCircle2;
        private CustomControls.SGControlBox sgControlBox2;
        private CustomControls.SimpleGraphicsPrimitives.SGPTriangleIsosceles sgpTriangleIsosceles1;
        private CustomControls.SimpleGraphicsPrimitives.SGPTriangleIsosceles sgpTriangleIsosceles2;
    }
}