namespace BigClock
{
    partial class ClockSetting
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
            this.components = new System.ComponentModel.Container();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFontSize.Location = new System.Drawing.Point(12, 30);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(119, 20);
            this.labelFontSize.TabIndex = 0;
            this.labelFontSize.Text = "Clock size:";
            this.labelFontSize.Click += new System.EventHandler(this.labelFontSize_Click);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(174, 22);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(120, 34);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonApply.Location = new System.Drawing.Point(337, 19);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(88, 37);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPreview.Location = new System.Drawing.Point(12, 130);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(100, 34);
            this.labelPreview.TabIndex = 3;
            this.labelPreview.Text = "10:30";
            // 
            // timerClose
            // 
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // ClockSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 353);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.labelFontSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClockSetting";
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Timer timerClose;
    }
}