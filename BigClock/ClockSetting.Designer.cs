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
            this.labelSize = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.buttonClearMessage = new System.Windows.Forms.Button();
            this.checkBoxSleepPC = new System.Windows.Forms.CheckBox();
            this.checkBoxKillChrome = new System.Windows.Forms.CheckBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonTimerCancel = new System.Windows.Forms.Button();
            this.labelTimerMessage = new System.Windows.Forms.Label();
            this.numericUpDownTimerMinute = new System.Windows.Forms.NumericUpDown();
            this.buttonTimerStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.groupBoxTimeSize.SuspendLayout();
            this.tableLayoutPanelClock.SuspendLayout();
            this.panelClockTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBoxTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(69, 5);
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
            this.buttonApply.Location = new System.Drawing.Point(8, 54);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(121, 32);
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
            this.panelClockTop.Controls.Add(this.labelSize);
            this.panelClockTop.Controls.Add(this.numericUpDownFontSize);
            this.panelClockTop.Controls.Add(this.buttonApply);
            this.panelClockTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClockTop.Location = new System.Drawing.Point(3, 3);
            this.panelClockTop.Name = "panelClockTop";
            this.panelClockTop.Size = new System.Drawing.Size(170, 175);
            this.panelClockTop.TabIndex = 0;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSize.Location = new System.Drawing.Point(4, 7);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(59, 20);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "Size:";
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
            // groupBoxTimer
            // 
            this.groupBoxTimer.Controls.Add(this.buttonClearMessage);
            this.groupBoxTimer.Controls.Add(this.checkBoxSleepPC);
            this.groupBoxTimer.Controls.Add(this.checkBoxKillChrome);
            this.groupBoxTimer.Controls.Add(this.textBoxMessage);
            this.groupBoxTimer.Controls.Add(this.buttonTest);
            this.groupBoxTimer.Controls.Add(this.buttonTimerCancel);
            this.groupBoxTimer.Controls.Add(this.labelTimerMessage);
            this.groupBoxTimer.Controls.Add(this.numericUpDownTimerMinute);
            this.groupBoxTimer.Controls.Add(this.buttonTimerStart);
            this.groupBoxTimer.Location = new System.Drawing.Point(12, 225);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(758, 257);
            this.groupBoxTimer.TabIndex = 5;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
            // 
            // buttonClearMessage
            // 
            this.buttonClearMessage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearMessage.Location = new System.Drawing.Point(461, 203);
            this.buttonClearMessage.Name = "buttonClearMessage";
            this.buttonClearMessage.Size = new System.Drawing.Size(100, 32);
            this.buttonClearMessage.TabIndex = 11;
            this.buttonClearMessage.Text = "Clear";
            this.buttonClearMessage.UseVisualStyleBackColor = true;
            this.buttonClearMessage.Click += new System.EventHandler(this.buttonClearMessage_Click);
            // 
            // checkBoxSleepPC
            // 
            this.checkBoxSleepPC.AutoSize = true;
            this.checkBoxSleepPC.Checked = true;
            this.checkBoxSleepPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSleepPC.Location = new System.Drawing.Point(626, 109);
            this.checkBoxSleepPC.Name = "checkBoxSleepPC";
            this.checkBoxSleepPC.Size = new System.Drawing.Size(93, 19);
            this.checkBoxSleepPC.TabIndex = 10;
            this.checkBoxSleepPC.Text = "Sleep PC";
            this.checkBoxSleepPC.UseVisualStyleBackColor = true;
            // 
            // checkBoxKillChrome
            // 
            this.checkBoxKillChrome.AutoSize = true;
            this.checkBoxKillChrome.Checked = true;
            this.checkBoxKillChrome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKillChrome.Location = new System.Drawing.Point(626, 72);
            this.checkBoxKillChrome.Name = "checkBoxKillChrome";
            this.checkBoxKillChrome.Size = new System.Drawing.Size(117, 19);
            this.checkBoxKillChrome.TabIndex = 9;
            this.checkBoxKillChrome.Text = "Kill Chrome";
            this.checkBoxKillChrome.UseVisualStyleBackColor = true;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.White;
            this.textBoxMessage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxMessage.ForeColor = System.Drawing.Color.Black;
            this.textBoxMessage.Location = new System.Drawing.Point(9, 66);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessage.Size = new System.Drawing.Size(577, 182);
            this.textBoxMessage.TabIndex = 8;
            this.textBoxMessage.Text = "test";
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTest.Location = new System.Drawing.Point(626, 20);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(100, 32);
            this.buttonTest.TabIndex = 7;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonTimerCancel
            // 
            this.buttonTimerCancel.Enabled = false;
            this.buttonTimerCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTimerCancel.Location = new System.Drawing.Point(211, 24);
            this.buttonTimerCancel.Name = "buttonTimerCancel";
            this.buttonTimerCancel.Size = new System.Drawing.Size(100, 32);
            this.buttonTimerCancel.TabIndex = 6;
            this.buttonTimerCancel.Text = "Cancel";
            this.buttonTimerCancel.UseVisualStyleBackColor = true;
            this.buttonTimerCancel.Click += new System.EventHandler(this.buttonTimerCancel_Click);
            // 
            // labelTimerMessage
            // 
            this.labelTimerMessage.BackColor = System.Drawing.Color.Gray;
            this.labelTimerMessage.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTimerMessage.ForeColor = System.Drawing.Color.White;
            this.labelTimerMessage.Location = new System.Drawing.Point(618, 220);
            this.labelTimerMessage.Name = "labelTimerMessage";
            this.labelTimerMessage.Size = new System.Drawing.Size(125, 28);
            this.labelTimerMessage.TabIndex = 5;
            this.labelTimerMessage.Text = "msg";
            // 
            // numericUpDownTimerMinute
            // 
            this.numericUpDownTimerMinute.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownTimerMinute.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownTimerMinute.Location = new System.Drawing.Point(9, 24);
            this.numericUpDownTimerMinute.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownTimerMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimerMinute.Name = "numericUpDownTimerMinute";
            this.numericUpDownTimerMinute.Size = new System.Drawing.Size(60, 30);
            this.numericUpDownTimerMinute.TabIndex = 4;
            this.numericUpDownTimerMinute.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // buttonTimerStart
            // 
            this.buttonTimerStart.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTimerStart.Location = new System.Drawing.Point(90, 23);
            this.buttonTimerStart.Name = "buttonTimerStart";
            this.buttonTimerStart.Size = new System.Drawing.Size(100, 32);
            this.buttonTimerStart.TabIndex = 5;
            this.buttonTimerStart.Text = "Start";
            this.buttonTimerStart.UseVisualStyleBackColor = true;
            this.buttonTimerStart.Click += new System.EventHandler(this.buttonTimerStart_Click);
            // 
            // ClockSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 494);
            this.Controls.Add(this.groupBoxTimer);
            this.Controls.Add(this.groupBoxTimeSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClockSetting";
            this.Text = "Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClockSetting_FormClosing);
            this.Load += new System.EventHandler(this.ClockSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.groupBoxTimeSize.ResumeLayout(false);
            this.tableLayoutPanelClock.ResumeLayout(false);
            this.panelClockTop.ResumeLayout(false);
            this.panelClockTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.groupBoxTimer.ResumeLayout(false);
            this.groupBoxTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerMinute)).EndInit();
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
        private System.Windows.Forms.Button buttonTimerStart;
        private System.Windows.Forms.NumericUpDown numericUpDownTimerMinute;
        private System.Windows.Forms.Label labelTimerMessage;
        private System.Windows.Forms.Button buttonTimerCancel;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.CheckBox checkBoxKillChrome;
        private System.Windows.Forms.CheckBox checkBoxSleepPC;
        private System.Windows.Forms.Button buttonClearMessage;
        private System.Windows.Forms.Label labelSize;
    }
}