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
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTimeSize = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelClock = new System.Windows.Forms.TableLayoutPanel();
            this.panelClockTop = new System.Windows.Forms.Panel();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.panelRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.groupBoxTimeSize.SuspendLayout();
            this.tableLayoutPanelClock.SuspendLayout();
            this.panelClockTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(3, 5);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(60, 30);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonApply.Location = new System.Drawing.Point(78, 5);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(80, 32);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.BackColor = System.Drawing.Color.Gray;
            this.labelPreview.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPreview.ForeColor = System.Drawing.Color.White;
            this.labelPreview.Location = new System.Drawing.Point(3, 5);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(100, 34);
            this.labelPreview.TabIndex = 3;
            this.labelPreview.Text = "10:30";
            this.labelPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerClose
            // 
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // groupBoxTimeSize
            // 
            this.groupBoxTimeSize.Controls.Add(this.tableLayoutPanelClock);
            this.groupBoxTimeSize.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTimeSize.Name = "groupBoxTimeSize";
            this.groupBoxTimeSize.Size = new System.Drawing.Size(758, 207);
            this.groupBoxTimeSize.TabIndex = 4;
            this.groupBoxTimeSize.TabStop = false;
            this.groupBoxTimeSize.Text = "Clock";
            // 
            // tableLayoutPanelClock
            // 
            this.tableLayoutPanelClock.ColumnCount = 2;
            this.tableLayoutPanelClock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 576F));
            this.tableLayoutPanelClock.Controls.Add(this.panelClockTop, 0, 0);
            this.tableLayoutPanelClock.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanelClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClock.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanelClock.Name = "tableLayoutPanelClock";
            this.tableLayoutPanelClock.RowCount = 2;
            this.tableLayoutPanelClock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelClock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelClock.Size = new System.Drawing.Size(752, 183);
            this.tableLayoutPanelClock.TabIndex = 3;
            // 
            // panelClockTop
            // 
            this.panelClockTop.Controls.Add(this.numericUpDownFontSize);
            this.panelClockTop.Controls.Add(this.buttonApply);
            this.panelClockTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClockTop.Location = new System.Drawing.Point(3, 3);
            this.panelClockTop.Name = "panelClockTop";
            this.panelClockTop.Size = new System.Drawing.Size(170, 175);
            this.panelClockTop.TabIndex = 0;
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Location = new System.Drawing.Point(12, 225);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(758, 116);
            this.groupBoxTimer.TabIndex = 5;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
            // 
            // panelRight
            // 
            this.panelRight.AutoScroll = true;
            this.panelRight.Controls.Add(this.labelPreview);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(179, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(570, 175);
            this.panelRight.TabIndex = 2;
            // 
            // ClockSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 353);
            this.Controls.Add(this.groupBoxTimer);
            this.Controls.Add(this.groupBoxTimeSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClockSetting";
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.groupBoxTimeSize.ResumeLayout(false);
            this.tableLayoutPanelClock.ResumeLayout(false);
            this.panelClockTop.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.GroupBox groupBoxTimeSize;
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClock;
        private System.Windows.Forms.Panel panelClockTop;
        private System.Windows.Forms.Panel panelRight;
    }
}