﻿namespace BigClock
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
            this.buttonOutlinerHolder = new System.Windows.Forms.Button();
            this.timerFading = new System.Windows.Forms.Timer(this.components);
            this.buttonTopMost = new System.Windows.Forms.Button();
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
            this.labelTime.MouseEnter += new System.EventHandler(this.labelTime_MouseEnter);
            this.labelTime.MouseLeave += new System.EventHandler(this.labelTime_MouseLeave);
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
            this.labelDate.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
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
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.Location = new System.Drawing.Point(780, 24);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 40);
            this.buttonClose.TabIndex = 100;
            this.buttonClose.Text = "Kill";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseHover);
            // 
            // buttonSwap
            // 
            this.buttonSwap.BackColor = System.Drawing.Color.Transparent;
            this.buttonSwap.FlatAppearance.BorderSize = 0;
            this.buttonSwap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSwap.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSwap.Location = new System.Drawing.Point(780, 74);
            this.buttonSwap.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(100, 40);
            this.buttonSwap.TabIndex = 101;
            this.buttonSwap.Text = "Change";
            this.buttonSwap.UseVisualStyleBackColor = false;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            this.buttonSwap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSwap_MouseDown);
            this.buttonSwap.MouseEnter += new System.EventHandler(this.buttonSwap_MouseEnter);
            this.buttonSwap.MouseLeave += new System.EventHandler(this.buttonSwap_MouseLeave);
            this.buttonSwap.MouseHover += new System.EventHandler(this.buttonSwap_MouseHover);
            // 
            // labelTimeComma
            // 
            this.labelTimeComma.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTimeComma.Font = new System.Drawing.Font("SimSun", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTimeComma.Location = new System.Drawing.Point(210, 0);
            this.labelTimeComma.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelTimeComma.Name = "labelTimeComma";
            this.labelTimeComma.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelTimeComma.Size = new System.Drawing.Size(90, 178);
            this.labelTimeComma.TabIndex = 5;
            this.labelTimeComma.Text = ":";
            this.labelTimeComma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTimeComma_MouseDown);
            this.labelTimeComma.MouseEnter += new System.EventHandler(this.labelTimeComma_MouseEnter);
            this.labelTimeComma.MouseLeave += new System.EventHandler(this.labelTimeComma_MouseLeave);
            // 
            // buttonOutlinerHolder
            // 
            this.buttonOutlinerHolder.Location = new System.Drawing.Point(911, 267);
            this.buttonOutlinerHolder.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOutlinerHolder.Name = "buttonOutlinerHolder";
            this.buttonOutlinerHolder.Size = new System.Drawing.Size(1, 1);
            this.buttonOutlinerHolder.TabIndex = 10;
            this.buttonOutlinerHolder.UseVisualStyleBackColor = true;
            // 
            // timerFading
            // 
            this.timerFading.Interval = 10000;
            this.timerFading.Tick += new System.EventHandler(this.timerFading_Tick);
            // 
            // buttonTopMost
            // 
            this.buttonTopMost.BackColor = System.Drawing.Color.Transparent;
            this.buttonTopMost.FlatAppearance.BorderSize = 0;
            this.buttonTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTopMost.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTopMost.Location = new System.Drawing.Point(780, 124);
            this.buttonTopMost.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTopMost.Name = "buttonTopMost";
            this.buttonTopMost.Size = new System.Drawing.Size(100, 40);
            this.buttonTopMost.TabIndex = 102;
            this.buttonTopMost.Text = "Pin Off";
            this.buttonTopMost.UseVisualStyleBackColor = false;
            this.buttonTopMost.Click += new System.EventHandler(this.buttonTopMost_Click);
            this.buttonTopMost.MouseEnter += new System.EventHandler(this.buttonTopMost_MouseEnter);
            this.buttonTopMost.MouseLeave += new System.EventHandler(this.buttonTopMost_MouseLeave);
            this.buttonTopMost.MouseHover += new System.EventHandler(this.buttonTopMost_MouseHover);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(930, 630);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTopMost);
            this.Controls.Add(this.buttonOutlinerHolder);
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
            this.Text = "LEO Clock";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLight;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
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
        private System.Windows.Forms.Button buttonOutlinerHolder;
        private System.Windows.Forms.Timer timerFading;
        private System.Windows.Forms.Button buttonTopMost;
    }
}

