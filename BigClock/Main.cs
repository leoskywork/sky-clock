using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigClock
{
    public partial class Main : Form, IMainView
    {
        private bool _UseDefaultTimeCommaColor = true;
        
        private bool _TopMost = false;
        private bool _HasMouseEnteredButton = false;
        private DateTime _MouseLeaveTimestamp = DateTime.MinValue;
        private ClockCore _ClockCore;

        private const int _SyncClockTimerInterval = 100;
        private const int _SyncClockOffsetAllowed = _SyncClockTimerInterval + 100;
        private const int _FastTimerInterval = 1000;
        private const int _SlowTimerInterval = 5 * 1000;
       

        public const string UITopMost = "Pin On";
        public const string UITopMostOff = "Pin Off";

        public Control Self { get { return this; } }    
        public bool HasMouseEnteredButton { get { return _HasMouseEnteredButton; } }

        public Main()
        {
            InitializeComponent();

            _ClockCore = new ClockCore(this);

            //can't do the auto 2 way binding like this.Location, due to this.Tag is not marked with [SettingsBindable]
            //have to manually read and save to global settings
            //int lastMode;
            //if (this.Tag != null && int.TryParse(this.Tag.ToString(), out lastMode) && lastMode >= 0)
            //{
            //    this._SwapCount = lastMode;
            //}
            if (Properties.Settings.Default.LastCloseMode >= 0)
            {
                _ClockCore.SwapCount = Properties.Settings.Default.LastCloseMode;
            }
          
            SetUITopMostFromSettings();

            _ClockCore.NumberOfClockFaces = Enum.GetNames(typeof(ClockFace)).Length;
            //for test
            //this.timerMain.Interval = 5000;
            this.timerMain.Interval = _SyncClockTimerInterval;
            this.timerMain.Start();
            SetUIClock(_UseDefaultTimeCommaColor, _ClockCore.GetCurrentClockFace(), true);

            this.timerFading.Interval = ClockCore.ColorFadingDelay / 2;
            this.timerFading.Start();
        }

        private void SetUIClock(bool defaultCommaColor, ClockFace face, bool isSyncClock)
        {
            var now = DateTime.Now;
            // now = new DateTime(2021, 1, 2, 9, 3, 4);
            // now = new DateTime(2021, 10, 22, 12, 35, 47);

            //1. update time label
            switch (face)
            {
                case ClockFace.Time:
                case ClockFace.TimeBlink:
                case ClockFace.TimeWeek:
                case ClockFace.TimeDate:
                case ClockFace.TimeWeekDate:
                case ClockFace.TimeWhite:
                case ClockFace.TimeBlinkWhite:
                case ClockFace.TimeWeekWhite:
                case ClockFace.TimeDateWhite:
                case ClockFace.TimeWeekDateWhite:
                    SetUIBigLabelTime(face, now);
                    SetUIBigLabelCommaBlink(defaultCommaColor, face, now);
                    break;
                case ClockFace.TimeWithSecond:
                case ClockFace.TimeWithSecondRed:
                    this.labelTime.Text = now.ToString("H:mm:ss");
                    if (this.labelTime.Font.Size != 100f) //high refresh rate, so do the check before reset
                    {
                        this.labelTime.Font = new Font("SimSun", 100f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                    }
                    this.labelTime.ForeColor = face == ClockFace.TimeWithSecondRed ? Color.DarkRed : this.ForeColor;

                    this.labelTimeComma.Hide();
                    break;
                case ClockFace.TimeSmallTopMost:
                case ClockFace.TimeSmallTopMostWhite:
                    this.labelTime.Text = now.ToString("H:mm");
                    this.labelTime.Font = new Font("SimSun", 20f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                    this.labelTime.ForeColor = face == ClockFace.TimeSmallTopMostWhite ? Color.LightGray : this.ForeColor;

                    this.labelTimeComma.Hide();
                    break;
                default:
                    MessageBox.Show("Unsupported clock face: " + face.ToString());
                    break;
            }

            //2. set refresh rate
            if (isSyncClock)
            {
                if (this.timerMain.Interval != _SyncClockTimerInterval)
                {
                    this.timerMain.Interval = _SyncClockTimerInterval;
                }
            }
            else
            {
                switch (face)
                {
                    case ClockFace.TimeBlink:
                    case ClockFace.TimeBlinkWhite:
                    case ClockFace.TimeWithSecond:
                    case ClockFace.TimeWithSecondRed:
                        this.timerMain.Interval = _FastTimerInterval;
                        break;
                    default:
                        this.timerMain.Interval = _SlowTimerInterval;
                        break;
                }
            }

            //3. then update week label and date label
            switch (face)
            {
                case ClockFace.TimeWeek:
                case ClockFace.TimeWeekWhite:
                    this.labelWeek.Text = now.DayOfWeek.ToString();
                    this.labelWeek.ForeColor = this.labelTime.ForeColor;
                    this.labelDate.Text = null;
                    break;
                case ClockFace.TimeDate:
                case ClockFace.TimeDateWhite:
                    this.labelWeek.Text = now.ToString("yyyy.M.d");
                    this.labelWeek.ForeColor = this.labelTime.ForeColor;
                    this.labelDate.Text = null;
                    break;
                case ClockFace.TimeWeekDate:
                case ClockFace.TimeWeekDateWhite:
                    this.labelWeek.Text = now.DayOfWeek.ToString();
                    this.labelWeek.ForeColor = this.labelTime.ForeColor;
                    this.labelDate.Text = now.ToString("yyyy.M.d");
                    this.labelDate.ForeColor = this.labelTime.ForeColor;
                    break;
                default:
                    this.labelWeek.Text = null;
                    this.labelDate.Text = null;
                    break;
            }

            //4. set buttons location
            SetButtonLocations(face);
        }
        private void SetUIBigLabelCommaBlink(bool defaultCommaColor, ClockFace face, DateTime now)
        {
            this.labelTimeComma.Location = now.Hour < 10 ? new Point(100, 0) : new Point(182, 0);

            if (face == ClockFace.TimeBlink && !defaultCommaColor)
            {
                this.labelTimeComma.ForeColor = Color.LightGray;
            }
            else if (face == ClockFace.TimeBlinkWhite && !defaultCommaColor)
            {
                this.labelTimeComma.ForeColor = Color.Gray;
            }
            else
            {
                this.labelTimeComma.ForeColor = this.labelTime.ForeColor;
            }

            this.labelTimeComma.Show();
        }
        private void SetUIBigLabelTime(ClockFace face, DateTime now)
        {
            this.labelTime.Text = now.ToString("H mm");
            this.labelTime.Font = new Font("SimSun", 120f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));

            switch (face)
            {
                case ClockFace.TimeWhite:
                case ClockFace.TimeBlinkWhite:
                case ClockFace.TimeWeekWhite:
                case ClockFace.TimeDateWhite:
                case ClockFace.TimeWeekDateWhite:
                    this.labelTime.ForeColor = Color.White;
                    break;
                default:
                    this.labelTime.ForeColor = this.ForeColor;
                    break;
            }
        }
        private void SetButtonLocations(ClockFace face)
        {
            int locationX = 450;
            int locationY = 24;
            switch (face)
            {
                case ClockFace.TimeWithSecond:
                case ClockFace.TimeWithSecondRed:
                    locationX = 580;
                    break;
                case ClockFace.TimeSmallTopMostWhite:
                case ClockFace.TimeSmallTopMost:
                    locationX = 10;
                    locationY = 34;
                    break;
                default:
                    break;
            }

            if (this.buttonClose.Location.X != locationX || this.buttonClose.Location.Y != locationY)
            {
                this.buttonClose.Location = new System.Drawing.Point(locationX, locationY);
                this.buttonSwap.Location = new System.Drawing.Point(locationX, locationY + 40);
                this.buttonTopMost.Location = new System.Drawing.Point(locationX, locationY + 80);
            }
        }
        private void SetUITopMostFromSettings()
        {
            _TopMost = Properties.Settings.Default.TopMost;
            this.TopMost = _TopMost;
            this.buttonTopMost.Text = this._TopMost ? UITopMost : UITopMostOff;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            _ClockCore.DimThenOffInitialAsync(this.buttonClose, this.buttonSwap, this.buttonTopMost);
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._ClockCore.Dispose();
            this._ClockCore = null;
            Properties.Settings.Default.Save();
        }
        private void timerMain_Tick(object sender, EventArgs e)
        {

            _UseDefaultTimeCommaColor = !_UseDefaultTimeCommaColor;
            SetUIClock(_UseDefaultTimeCommaColor, _ClockCore.GetCurrentClockFace(), DateTime.Now.Millisecond > _SyncClockOffsetAllowed);

            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("h:mm:ss.fff"));
        }
        private void timerFading_Tick(object sender, EventArgs e)
        {
            if (_MouseLeaveTimestamp == DateTime.MinValue || DateTime.Now < _MouseLeaveTimestamp.AddMilliseconds(ClockCore.ColorFadingDelay)) return;

            _ClockCore.DimThenOffAsync(this.buttonClose, 10, Color.Gray);
            _ClockCore.DimThenOffAsync(this.buttonSwap, 10, Color.Gray);
            _ClockCore.DimThenOffAsync(this.buttonTopMost, 10, Color.Gray);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.timerMain = null;
            this.Close();
        }
        private void buttonSwap_Click(object sender, EventArgs e)
        {
            try
            {
                _ClockCore.SwapCount++;
                Properties.Settings.Default.LastCloseMode = _ClockCore.SwapCount;
                this.SetUIClock(_UseDefaultTimeCommaColor, _ClockCore.GetCurrentClockFace(), false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.ToString());
            }
        }
        private void buttonTopMost_Click(object sender, EventArgs e)
        {
            try
            {
                this._TopMost = !this._TopMost;
                Properties.Settings.Default.TopMost = this._TopMost;
                SetUITopMostFromSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.ToString());
            }
        }

        private static void HighlightButton(Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
        }
        private static bool NormallightButton(Button button, Color foreColor)
        {
            if (!button.Visible)
            {
                button.Show();
            }

            if (button.ForeColor != foreColor)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = foreColor;
                return true;
            }

            return false;
        }


        private void buttonSwap_MouseHover(object sender, EventArgs e)
        {
            HighlightButton(this.buttonSwap, Color.SlateBlue);
        }
        private void buttonSwap_MouseEnter(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = true;
            HighlightButton(this.buttonSwap, Color.SlateBlue);
        }
        private void buttonSwap_MouseLeave(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = false;
            NormallightButton(this.buttonSwap, this.ForeColor);

            //create so many background tasks when mouse fly over this control again and again
            //DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);
            _MouseLeaveTimestamp = DateTime.Now;

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("h:mm:ss.fff")} {((Button)sender).Name} mouse leave");
        }

        private void buttonClose_MouseHover(object sender, EventArgs e)
        {
            HighlightButton(this.buttonClose, Color.Red);
        }
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = true;
            HighlightButton(this.buttonClose, Color.Red);
        }
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = false;
            NormallightButton(this.buttonClose, this.ForeColor);

            //create so many background tasks when mouse fly over this control again and again
            //DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);
            _MouseLeaveTimestamp = DateTime.Now;

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("h:mm:ss.fff")} {((Button)sender).Name} mouse leave");
        }

        private void labelTime_MouseEnter(object sender, EventArgs e)
        {
            _ClockCore.CancelPriorDimlight();
            NormallightButton(this.buttonSwap, this.ForeColor);
            NormallightButton(this.buttonClose, this.ForeColor);
            NormallightButton(this.buttonTopMost, this.ForeColor);
        }
        private void labelTime_MouseLeave(object sender, EventArgs e)
        {
            //create so many background tasks when mouse fly over time label again and again
            // DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);

            _MouseLeaveTimestamp = DateTime.Now;
        }

        private void labelTimeComma_MouseEnter(object sender, EventArgs e)
        {
            _ClockCore.CancelPriorDimlight();
            NormallightButton(this.buttonSwap, this.ForeColor);
            NormallightButton(this.buttonClose, this.ForeColor);
            NormallightButton(this.buttonTopMost, this.ForeColor);
        }
        private void labelTimeComma_MouseLeave(object sender, EventArgs e)
        {
            //create so many background tasks when mouse fly over time label again and again
            // DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);

            _MouseLeaveTimestamp = DateTime.Now;
        }

        private void buttonTopMost_MouseHover(object sender, EventArgs e)
        {
            HighlightButton(this.buttonTopMost, Color.SlateBlue);
        }
        private void buttonTopMost_MouseEnter(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = true;
            HighlightButton(this.buttonTopMost, Color.SlateBlue);
        }
        private void buttonTopMost_MouseLeave(object sender, EventArgs e)
        {
            _HasMouseEnteredButton = false;
            NormallightButton(this.buttonTopMost, this.ForeColor);

            _MouseLeaveTimestamp = DateTime.Now;
        }


        #region a border-less form movable
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

        #endregion end of border-less


    }




}
