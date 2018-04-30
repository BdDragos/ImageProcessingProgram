namespace ImageLab1
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
            this.loadImage = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.solarizeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.redVal = new System.Windows.Forms.NumericUpDown();
            this.blueVal = new System.Windows.Forms.NumericUpDown();
            this.greenVal = new System.Windows.Forms.NumericUpDown();
            this.resultImage = new System.Windows.Forms.PictureBox();
            this.noiseButton = new System.Windows.Forms.Button();
            this.windowButton = new System.Windows.Forms.Button();
            this.edgeButton = new System.Windows.Forms.Button();
            this.pseudoButton = new System.Windows.Forms.Button();
            this.spatialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(12, 12);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(621, 523);
            this.loadImage.TabIndex = 0;
            this.loadImage.TabStop = false;
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(1266, 12);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(120, 72);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load Image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // solarizeButton
            // 
            this.solarizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solarizeButton.Location = new System.Drawing.Point(1266, 90);
            this.solarizeButton.Name = "solarizeButton";
            this.solarizeButton.Size = new System.Drawing.Size(120, 72);
            this.solarizeButton.TabIndex = 2;
            this.solarizeButton.Text = "Solarize Image";
            this.solarizeButton.UseVisualStyleBackColor = true;
            this.solarizeButton.Click += new System.EventHandler(this.solarizeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1266, 463);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 72);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1263, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Red Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1263, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Blue Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1263, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Green Value";
            // 
            // redVal
            // 
            this.redVal.Location = new System.Drawing.Point(1266, 185);
            this.redVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redVal.Name = "redVal";
            this.redVal.Size = new System.Drawing.Size(120, 22);
            this.redVal.TabIndex = 10;
            // 
            // blueVal
            // 
            this.blueVal.Location = new System.Drawing.Point(1266, 241);
            this.blueVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueVal.Name = "blueVal";
            this.blueVal.Size = new System.Drawing.Size(120, 22);
            this.blueVal.TabIndex = 11;
            // 
            // greenVal
            // 
            this.greenVal.Location = new System.Drawing.Point(1266, 298);
            this.greenVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenVal.Name = "greenVal";
            this.greenVal.Size = new System.Drawing.Size(120, 22);
            this.greenVal.TabIndex = 12;
            // 
            // resultImage
            // 
            this.resultImage.Location = new System.Drawing.Point(639, 12);
            this.resultImage.Name = "resultImage";
            this.resultImage.Size = new System.Drawing.Size(621, 523);
            this.resultImage.TabIndex = 13;
            this.resultImage.TabStop = false;
            // 
            // noiseButton
            // 
            this.noiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noiseButton.Location = new System.Drawing.Point(1266, 326);
            this.noiseButton.Name = "noiseButton";
            this.noiseButton.Size = new System.Drawing.Size(120, 52);
            this.noiseButton.TabIndex = 14;
            this.noiseButton.Text = "Noise redution";
            this.noiseButton.UseVisualStyleBackColor = true;
            this.noiseButton.Click += new System.EventHandler(this.noiseButton_Click);
            // 
            // windowButton
            // 
            this.windowButton.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.windowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowButton.Location = new System.Drawing.Point(1266, 384);
            this.windowButton.Name = "windowButton";
            this.windowButton.Size = new System.Drawing.Size(120, 73);
            this.windowButton.TabIndex = 15;
            this.windowButton.Text = "Window Filter";
            this.windowButton.UseVisualStyleBackColor = true;
            this.windowButton.Click += new System.EventHandler(this.windowButton_Click);
            // 
            // edgeButton
            // 
            this.edgeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edgeButton.Location = new System.Drawing.Point(1392, 12);
            this.edgeButton.Name = "edgeButton";
            this.edgeButton.Size = new System.Drawing.Size(142, 72);
            this.edgeButton.TabIndex = 16;
            this.edgeButton.Text = "Edge accentuation";
            this.edgeButton.UseVisualStyleBackColor = true;
            this.edgeButton.Click += new System.EventHandler(this.edgeButton_Click);
            // 
            // pseudoButton
            // 
            this.pseudoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pseudoButton.Location = new System.Drawing.Point(1393, 90);
            this.pseudoButton.Name = "pseudoButton";
            this.pseudoButton.Size = new System.Drawing.Size(141, 72);
            this.pseudoButton.TabIndex = 17;
            this.pseudoButton.Text = "Pseudocolor";
            this.pseudoButton.UseVisualStyleBackColor = true;
            this.pseudoButton.Click += new System.EventHandler(this.pseudoButton_Click);
            // 
            // spatialButton
            // 
            this.spatialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spatialButton.Location = new System.Drawing.Point(1393, 168);
            this.spatialButton.Name = "spatialButton";
            this.spatialButton.Size = new System.Drawing.Size(142, 72);
            this.spatialButton.TabIndex = 18;
            this.spatialButton.Text = "Spatial medium";
            this.spatialButton.UseVisualStyleBackColor = true;
            this.spatialButton.Click += new System.EventHandler(this.spatialButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 575);
            this.Controls.Add(this.spatialButton);
            this.Controls.Add(this.pseudoButton);
            this.Controls.Add(this.edgeButton);
            this.Controls.Add(this.windowButton);
            this.Controls.Add(this.noiseButton);
            this.Controls.Add(this.resultImage);
            this.Controls.Add(this.greenVal);
            this.Controls.Add(this.blueVal);
            this.Controls.Add(this.redVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.solarizeButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.loadImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.loadImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loadImage;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button solarizeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown redVal;
        private System.Windows.Forms.NumericUpDown blueVal;
        private System.Windows.Forms.NumericUpDown greenVal;
        private System.Windows.Forms.PictureBox resultImage;
        private System.Windows.Forms.Button noiseButton;
        private System.Windows.Forms.Button windowButton;
        private System.Windows.Forms.Button edgeButton;
        private System.Windows.Forms.Button pseudoButton;
        private System.Windows.Forms.Button spatialButton;
    }
}

