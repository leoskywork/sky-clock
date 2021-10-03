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

        public Main()
        {
            InitializeComponent();

            //for test
            //this.timerMain.Interval = 5000;

            this.timerMain.Start();
            SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());
        }

        private void SetTime(bool defaultTimeFormat, ClockFace face)
        {
            var now = DateTime.Now;
            // now = new DateTime(2021, 1, 2, 2, 3, 4);
            // now = new DateTime(2021, 10, 22, 12, 35, 47);

            this.labelTime.Text = now.ToString("H mm");

            this.labelTimeComma.Location = now.Hour < 10 ? new Point(100, 0) : new Point(180, 0);
            this.labelTimeComma.ForeColor = defaultTimeFormat ? this.labelTime.ForeColor : Color.DarkSlateGray;

            switch (face)
            {
                case ClockFace.Time:
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
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            else if(e.Button == MouseButtons.Right)
            {
                try
                {
                    this._SwapCount++;
                    this.SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error: " + ex.ToString());
                }
            }
        }

        private void labelTimeComma_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //seems interrupt the click to close function, so disable this
                // ReleaseCapture();
                // SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //end of border-less

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            //no longer working due to drag to move location function
        }

        private ClockFace GetCurrentClockFace()
        {
            return (ClockFace)(this._SwapCount % 3);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }

    public enum ClockFace
    {
        Time = 0,
        TimeWeek,
        TimeWeekDate
    }
}
