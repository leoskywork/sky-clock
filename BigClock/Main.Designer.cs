namespace BigClock
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labelTime = new System.Windows.Forms.Label();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.labelDate = new System.Windows.Forms.Label();
            this.labelWeek = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.labelTimeComma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTime.Font = new System.Drawing.Font("SimSun", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.Location = new System.Drawing.Point(0, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(930, 228);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "time";
            this.labelTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseDown);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 30000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // labelDate
            // 
            this.labelDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDate.Font = new System.Drawing.Font("SimSun", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.Location = new System.Drawing.Point(0, 430);
            this.labelDate.Name = "labelDate";
            this.labelDate.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.labelDate.Size = new System.Drawing.Size(930, 200);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "date";
            // 
            // labelWeek
            // 
            this.labelWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWeek.Font = new System.Drawing.Font("SimSun", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWeek.Location = new System.Drawing.Point(0, 228);
            this.labelWeek.Name = "labelWeek";
            this.labelWeek.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.labelWeek.Size = new System.Drawing.Size(930, 202);
            this.labelWeek.TabIndex = 2;
            this.labelWeek.Text = "week";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(834, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(60, 40);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Kill";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseDown);
            // 
            // buttonSwap
            // 
            this.buttonSwap.Location = new System.Drawing.Point(756, 12);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(60, 40);
            this.buttonSwap.TabIndex = 4;
            this.buttonSwap.Text = "Mode";
            this.buttonSwap.UseVisualStyleBackColor = true;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            this.buttonSwap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSwap_MouseDown);
            // 
            // labelTimeComma
            // 
            this.labelTimeComma.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTimeComma.Font = new System.Drawing.Font("SimSun", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTimeComma.Location = new System.Drawing.Point(207, 0);
            this.labelTimeComma.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelTimeComma.Name = "labelTimeComma";
            this.labelTimeComma.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelTimeComma.Size = new System.Drawing.Size(80, 178);
            this.labelTimeComma.TabIndex = 5;
            this.labelTimeComma.Text = ":";
            this.labelTimeComma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTimeComma_MouseDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(930, 630);
            this.ControlBox = false;
            this.Controls.Add(this.labelTimeComma);
            this.Controls.Add(this.buttonSwap);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelWeek);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTime);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::BigClock.Properties.Settings.Default, "LastCloseLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::BigClock.Properties.Settings.Default.LastCloseLocation;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEO Time";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLight;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelWeek;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.Label labelTimeComma;
    }
}

