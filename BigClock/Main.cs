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
    public partial class Main : Form
    {
        private bool _UseDefaultTimeFormat = true;
        private int _SwapCount = (int)ClockFace.TimeWeekDate;
        private const int _InitialTimerInterval = 100;
        private const int _FastTimerInterval = 1000;
        private const int _SlowTimerInterval = 30 * 1000;

        public Main()
        {
            InitializeComponent();

            //can't do the auto 2 way binding like this.Location, due to this.Tag is not marked with [SettingsBindable]
            //have to manually read and save to global settings
            //int lastMode;
            //if (this.Tag != null && int.TryParse(this.Tag.ToString(), out lastMode) && lastMode >= 0)
            //{
            //    this._SwapCount = lastMode;
            //}
            if(Properties.Settings.Default.LastCloseMode >= 0)
            {
                this._SwapCount = Properties.Settings.Default.LastCloseMode;
            }

            //for test
            //this.timerMain.Interval = 5000;
            this.timerMain.Interval = _InitialTimerInterval;
            this.timerMain.Start();
            SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());
        }

        private void SetTime(bool defaultTimeFormat, ClockFace face)
        {
            var now = DateTime.Now;
            // now = new DateTime(2021, 1, 2, 2, 3, 4);
            // now = new DateTime(2021, 10, 22, 12, 35, 47);

            //1. update time label
            if (face == ClockFace.TimeWithSecond || face == ClockFace.TimeWithSecondRed)
            {
                this.labelTime.Text = now.ToString("H:mm:ss");
                if (this.labelTime.Font.Size != 100f)
                {
                    this.labelTime.Font = new Font("SimSun", 100f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                }

                this.labelTimeComma.Hide();

                this.timerMain.Interval = _FastTimerInterval;
            }
            else
            {
                this.labelTime.Text = now.ToString("H mm");
                if (this.labelTime.Font.Size != 120f)
                {
                    this.labelTime.Font = new Font("SimSun", 120F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                }
                this.labelTimeComma.Show();
                this.labelTimeComma.Location = now.Hour < 10 ? new Point(100, 0) : new Point(180, 0);
                this.labelTimeComma.ForeColor = defaultTimeFormat ? this.labelTime.ForeColor : (face == ClockFace.TimeBlink ? Color.LightGray : Color.DarkSlateGray);

                this.timerMain.Interval = face == ClockFace.TimeBlink ? _FastTimerInterval : _SlowTimerInterval;

            }

            this.labelTime.ForeColor = face == ClockFace.TimeWithSecondRed ? Color.DarkRed : this.ForeColor;

            //2. then update week label and date label
            switch (face)
            {
                case ClockFace.Time:
                case ClockFace.TimeBlink:
                case ClockFace.TimeWithSecond:
                case ClockFace.TimeWithSecondRed:
                    this.labelWeek.Text = null;
                    this.labelDate.Text = null;

                    break;
                case ClockFace.TimeWeek:
                    this.labelWeek.Text = now.DayOfWeek.ToString();
                    this.labelDate.Text = null;

                    break;
                case ClockFace.TimeWeekDate:
                    this.labelWeek.Text = now.DayOfWeek.ToString();
                    this.labelDate.Text = now.ToString("yyyy.M.d");

                    break;
                default:
                    MessageBox.Show("Unsupported clock face: " + face.ToString());
                    break;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {

            _UseDefaultTimeFormat = !_UseDefaultTimeFormat;
            SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());

            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("h:m:s.fff"));
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.timerMain = null;
            this.Close();
        }

        //a border-less form movable
        //ref https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void labelTime_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonSwap_MouseDown(object sender, MouseEventArgs e)
        {
            //seems interrupt the click to close function, so disable this
            //if (e.Button == MouseButtons.Left)
            //{
            //    ReleaseCapture();
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            //}
            //else if(e.Button == MouseButtons.Right)
            //{
               
            //}
        }

        private void labelTimeComma_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //end of border-less

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            try
            {
                this._SwapCount++;
                Properties.Settings.Default.LastCloseMode = this._SwapCount;
                this.SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.ToString());
            }
        }

        private ClockFace GetCurrentClockFace()
        {
            return (ClockFace)(this._SwapCount % 6);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }

    public enum ClockFace
    {
        TimeWeekDate,
        TimeWeek,

        Time,
        TimeBlink,
        TimeWithSecond,
        TimeWithSecondRed
    }
}
