namespace ImageDownsizer
{
    partial class ImageDownsizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            uploadBtn = new Button();
            label1 = new Label();
            imageLbl = new Label();
            label2 = new Label();
            timeLbl = new Label();
            downsizeBtn = new Button();
            parallelDownsizeBtn = new Button();
            label3 = new Label();
            factorUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)factorUpDown).BeginInit();
            SuspendLayout();
            // 
            // uploadBtn
            // 
            uploadBtn.Font = new Font("Segoe UI", 10F);
            uploadBtn.Location = new Point(220, 48);
            uploadBtn.Name = "uploadBtn";
            uploadBtn.Size = new Size(151, 29);
            uploadBtn.TabIndex = 0;
            uploadBtn.Text = "Upload Image";
            uploadBtn.UseVisualStyleBackColor = true;
            uploadBtn.Click += uploadBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(415, 50);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 1;
            label1.Text = "Image:";
            // 
            // imageLbl
            // 
            imageLbl.AutoSize = true;
            imageLbl.Location = new Point(483, 53);
            imageLbl.Name = "imageLbl";
            imageLbl.Size = new Size(0, 20);
            imageLbl.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(253, 378);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 3;
            label2.Text = "Processing Time:";
            // 
            // timeLbl
            // 
            timeLbl.AutoSize = true;
            timeLbl.Location = new Point(396, 380);
            timeLbl.Name = "timeLbl";
            timeLbl.Size = new Size(0, 20);
            timeLbl.TabIndex = 4;
            // 
            // downsizeBtn
            // 
            downsizeBtn.Enabled = false;
            downsizeBtn.Font = new Font("Segoe UI", 10F);
            downsizeBtn.Location = new Point(220, 278);
            downsizeBtn.Name = "downsizeBtn";
            downsizeBtn.Size = new Size(151, 33);
            downsizeBtn.TabIndex = 5;
            downsizeBtn.Text = "Consequential";
            downsizeBtn.UseVisualStyleBackColor = true;
            downsizeBtn.Click += downsizeBtn_Click;
            // 
            // parallelDownsizeBtn
            // 
            parallelDownsizeBtn.Enabled = false;
            parallelDownsizeBtn.Font = new Font("Segoe UI", 10F);
            parallelDownsizeBtn.Location = new Point(415, 280);
            parallelDownsizeBtn.Name = "parallelDownsizeBtn";
            parallelDownsizeBtn.Size = new Size(151, 31);
            parallelDownsizeBtn.TabIndex = 6;
            parallelDownsizeBtn.Text = "Parallel";
            parallelDownsizeBtn.UseVisualStyleBackColor = true;
            parallelDownsizeBtn.Click += parallelDownsizeBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(214, 160);
            label3.Name = "label3";
            label3.Size = new Size(176, 23);
            label3.TabIndex = 8;
            label3.Text = " Down-scaling factor: ";
            // 
            // factorUpDown
            // 
            factorUpDown.Enabled = false;
            factorUpDown.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            factorUpDown.Location = new Point(396, 160);
            factorUpDown.Name = "factorUpDown";
            factorUpDown.ReadOnly = true;
            factorUpDown.Size = new Size(150, 27);
            factorUpDown.TabIndex = 9;
            factorUpDown.Tag = "95";
            factorUpDown.ValueChanged += factorUpDown_Change;
            // 
            // ImageDownsizer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(factorUpDown);
            Controls.Add(label3);
            Controls.Add(parallelDownsizeBtn);
            Controls.Add(downsizeBtn);
            Controls.Add(timeLbl);
            Controls.Add(label2);
            Controls.Add(imageLbl);
            Controls.Add(label1);
            Controls.Add(uploadBtn);
            Name = "ImageDownsizer";
            Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)factorUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button uploadBtn;
        private Label label1;
        private Label imageLbl;
        private Label label2;
        private Label timeLbl;
        private Button downsizeBtn;
        private Button parallelDownsizeBtn;
        private Label label3;
        private NumericUpDown factorUpDown;
    }
}