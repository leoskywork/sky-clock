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
            this.timerMain.Start();
            SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());
        }

        private void SetTime(bool defaultTimeFormat, ClockFace face)// bool miniMode = false)
        {
            var now = DateTime.Now;
            this.labelTime.Text = now.ToString(defaultTimeFormat ? "H:mm" : "H*mm"); //"H:mm tt" : "h mm tt");

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
                    this.labelDate.Text = now.ToString("yyyy.MM.dd");
                    //this.labelDate.Text = "2028.22.22";

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
        //end of border-less

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            this._SwapCount++;
            this.SetTime(_UseDefaultTimeFormat, GetCurrentClockFace());
        }

        private ClockFace GetCurrentClockFace()
        {
            return (ClockFace)(this._SwapCount % 3);
        }
    }

    public enum ClockFace
    {
        Time = 0,
        TimeWeek,
        TimeWeekDate
    }
}
