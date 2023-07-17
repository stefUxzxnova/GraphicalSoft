namespace Draw.src.GUI
{
    partial class ResizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.widthNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.heightNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(114, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Въведете ширина и/или височина:";
            // 
            // widthNumericUpDown1
            // 
            this.widthNumericUpDown1.Location = new System.Drawing.Point(73, 122);
            this.widthNumericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthNumericUpDown1.Name = "widthNumericUpDown1";
            this.widthNumericUpDown1.Size = new System.Drawing.Size(410, 22);
            this.widthNumericUpDown1.TabIndex = 1;
            // 
            // heightNumericUpDown2
            // 
            this.heightNumericUpDown2.Location = new System.Drawing.Point(73, 187);
            this.heightNumericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightNumericUpDown2.Name = "heightNumericUpDown2";
            this.heightNumericUpDown2.Size = new System.Drawing.Size(410, 22);
            this.heightNumericUpDown2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Resize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 307);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heightNumericUpDown2);
            this.Controls.Add(this.widthNumericUpDown1);
            this.Controls.Add(this.label1);
            this.Name = "ResizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown widthNumericUpDown1;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown2;
        private System.Windows.Forms.Button button1;
    }
}