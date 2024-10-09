using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigClock
{
    public partial class ClockSetting : Form
    {
        public const int LifeSpanSeconds = 100;
        
        private float _DefaultSize;
        private DateTime _DisplayAt;

        public event EventHandler<ClockSettingChangeArgs> ClockSettingChanged;

        public ClockSetting(ClockSettingArgs args)
        {
            InitializeComponent();

            _DefaultSize = args.CurrentClockSize;
            this.numericUpDownFontSize.Value = (decimal)_DefaultSize;

            if (!string.IsNullOrEmpty(args.PreviewValue))
            {
                this.labelPreview.Text = args.PreviewValue;
            }

            this.timerClose.Interval = 1000;
            this.timerClose.Start();

        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            var newSize = (float)numericUpDownFontSize.Value;
            this.labelPreview.Font = new System.Drawing.Font("SimSun", newSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.buttonApply.Enabled = newSize != _DefaultSize;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            this.buttonApply.Enabled = false;

            var changedArgs = new ClockSettingChangeArgs()
            {
                FontSize = (float)this.numericUpDownFontSize.Value
            };
            this.ClockSettingChanged(this, changedArgs);

            this.Close();
        }

        public void ShowAside(Control parent)
        {
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + 60, parent.Location.Y + 160);
            }

            _DisplayAt = DateTime.Now;
            this.Show();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            var passed = DateTime.Now - _DisplayAt;

            this.Text = $"Setting - auto close in {LifeSpanSeconds - (int)passed.TotalSeconds}s";

            if (passed.TotalSeconds > LifeSpanSeconds)
            {
                this.Close();
            }
        }

        private void labelFontSize_Click(object sender, EventArgs e)
        {

        }
    }

    
}
