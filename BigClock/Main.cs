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
    public partial class Main : Form
    {
        private bool _UseDefaultTimeCommaColor = true;
        private int _SwapCount = (int)ClockFace.TimeWeekDate;
        private bool _TopMost = false;
        private int _NumberOfClockFaces = 1;
        private bool _HasMouseEnteredButton = false;
        private DateTime _MouseLeaveTimestamp = DateTime.MinValue;
        private List<CancellationTokenSource> _CancelTokens = new List<CancellationTokenSource>();

        private const int _SyncClockTimerInterval = 100;
        private const int _SyncClockOffsetAllowed = _SyncClockTimerInterval + 100;
        private const int _FastTimerInterval = 1000;
        private const int _SlowTimerInterval = 5 * 1000;
        private const int _ColorFadingDelay = 10 * 1000;
        private const int _ColorEmptyDelay = 1000;

        public const string UITopMost = "Pin On";
        public const string UITopMostOff = "Pin Off";

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
            if (Properties.Settings.Default.LastCloseMode >= 0)
            {
                _SwapCount = Properties.Settings.Default.LastCloseMode;
            }

            _TopMost = Properties.Settings.Default.TopMost;
            this.buttonTopMost.Text = _TopMost ? UITopMost : UITopMostOff;

            _NumberOfClockFaces = Enum.GetNames(typeof(ClockFace)).Length;
            //for test
            //this.timerMain.Interval = 5000;
            this.timerMain.Interval = _SyncClockTimerInterval;
            this.timerMain.Start();
            SetTime(_UseDefaultTimeCommaColor, GetCurrentClockFace(), true);

            this.timerFading.Interval = _ColorFadingDelay / 2;
            this.timerFading.Start();
        }

        private void SetTime(bool defaultCommaColor, ClockFace face, bool isSyncClock)
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
                case ClockFace.TimeWeekDateWhite:
                    this.labelTime.Text = now.ToString("H mm");
                    this.labelTime.Font = new Font("SimSun", 120f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                    this.labelTime.ForeColor = face == ClockFace.TimeWeekDateWhite ? Color.White : this.ForeColor;

                    this.labelTimeComma.Location = now.Hour < 10 ? new Point(100, 0) : new Point(182, 0);
                    //(face == ClockFace.TimeBlink ? Color.LightGray : Color.DarkSlateGray);
                    this.labelTimeComma.ForeColor = face == ClockFace.TimeBlink && !defaultCommaColor ? Color.LightGray : this.labelTime.ForeColor;
                    this.labelTimeComma.Show();
                    //this.TopMost = false;
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
                    //this.TopMost = false;
                    break;
                case ClockFace.TimeSmallTopMost:
                case ClockFace.TimeSmallTopMostWhite:
                    this.labelTime.Text = now.ToString("H:mm");
                    this.labelTime.Font = new Font("SimSun", 20f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
                    this.labelTime.ForeColor = face == ClockFace.TimeSmallTopMostWhite ? Color.LightGray : this.ForeColor;

                    this.labelTimeComma.Hide();
                    //this.TopMost = true; //23-03-13, use a button to control this now
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
                    this.labelWeek.Text = now.DayOfWeek.ToString();
                    this.labelWeek.ForeColor = this.labelTime.ForeColor;
                    this.labelDate.Text = null;
                    break;
                case ClockFace.TimeDate:
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
            AdjustButtonLocations(face);

        }

        private void AdjustButtonLocations(ClockFace face)
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

        private void timerMain_Tick(object sender, EventArgs e)
        {

            _UseDefaultTimeCommaColor = !_UseDefaultTimeCommaColor;
            SetTime(_UseDefaultTimeCommaColor, GetCurrentClockFace(), DateTime.Now.Millisecond > _SyncClockOffsetAllowed);

            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("h:mm:ss.fff"));
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DimThenOffInitialAsync(this.buttonClose, this.buttonSwap, this.buttonTopMost);
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
                this.SetTime(_UseDefaultTimeCommaColor, GetCurrentClockFace(), false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.ToString());
            }
        }

        private ClockFace GetCurrentClockFace()
        {
            return (ClockFace)(_SwapCount % _NumberOfClockFaces);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._CancelTokens = null;
            Properties.Settings.Default.Save();
        }

        private static void HighlightButton(Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
        }

        private bool NormallightButton(Button button)
        {
            return NormallightButton(button, this.ForeColor);
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
 
        private Task DimlightAsync(Button button, int delay, Color fadingTo, CancellationTokenSource tokenSource = null)
        {
            if (delay <= 0) throw new ArgumentException("delay need greater than 0");
            if (tokenSource?.IsCancellationRequested == true) return null;
            if (!PrecheckDimlight(button, fadingTo)) return null;

            //thread pool is difficult to make 2 work items to work with each other(last one must wait for first one to finish)
            //ThreadPool.QueueUserWorkItem((_) =>

            //this is way too complex then it need to be, do not need to support the cancellation
            //can't use Task.Wait() as it is supported in v4.5 not v4.0
            if (tokenSource == null)
            {
                tokenSource = new CancellationTokenSource();
                _CancelTokens.Add(tokenSource);
            }

            return Task.Factory.StartNew(() =>
            {
                if (tokenSource.IsCancellationRequested) return;
                if (!PrecheckDimlight(button, fadingTo)) return;
                Thread.Sleep(delay);
                System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("h:mm:ss.fff")} {button.Name} fading to color {fadingTo}, canceled {tokenSource.IsCancellationRequested}");
                if (tokenSource.IsCancellationRequested) return;
                if (!PrecheckDimlight(button, fadingTo)) return;

                this.BeginInvoke((Action)(() =>
                {
                    if (tokenSource.IsCancellationRequested) return;

                    if (fadingTo == Color.Empty)
                    {
                        button.Hide();
                    }
                    else
                    {
                        button.BackColor = Color.Transparent;
                        button.ForeColor = fadingTo;
                    }

                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("h:mm:ss.fff")} {button.Name} fading to color {fadingTo}");
                }));
            }, tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
        }

        private bool PrecheckDimlight(Button button, Color fadingTo)
        {
            if (_HasMouseEnteredButton) return false;

            if (this.Disposing || this.IsDisposed || button == null || button.Disposing || button.IsDisposed) return false;
            if (!button.Visible) return false;
            if (button.ForeColor == fadingTo) return false;

            return true;
        }

        private void DimThenOffAsync(Button button, int dimDelay, Color fadingTo, int killDelay)
        {
            var task = DimlightAsync(button, dimDelay, fadingTo);

            if (task != null)
            {
                var source = new CancellationTokenSource();
                _CancelTokens.Add(source);
                task.ContinueWith((_) => DimlightAsync(button, killDelay, Color.Empty, source));
            }
            else
            {
                DimlightAsync(button, killDelay, Color.Empty);
            }
        }

        private void DimThenOffInitialAsync(params Button[] buttons)
        {
            if (buttons == null || buttons.Length == 0) return;

            foreach (var button in buttons)
            {
                DimThenOffAsync(button, _ColorFadingDelay, Color.Gray, _ColorEmptyDelay);
            }
        }

        private void CancelPriorDimlight()
        {
            
            for (int i = _CancelTokens.Count - 1; i >= 0; i--)
            {
                _CancelTokens[i].Cancel();
                _CancelTokens.RemoveAt(i);
            }
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
            NormallightButton(this.buttonSwap);

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
            NormallightButton(this.buttonClose);

            //create so many background tasks when mouse fly over this control again and again
            //DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);
            _MouseLeaveTimestamp = DateTime.Now;

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("h:mm:ss.fff")} {((Button)sender).Name} mouse leave");
        }

        private void labelTime_MouseEnter(object sender, EventArgs e)
        {
            CancelPriorDimlight();
            NormallightButton(this.buttonSwap);
            NormallightButton(this.buttonClose);
            NormallightButton(this.buttonTopMost);
        }

        private void labelTime_MouseLeave(object sender, EventArgs e)
        {
            //create so many background tasks when mouse fly over time label again and again
            // DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);

            _MouseLeaveTimestamp = DateTime.Now;
        }

        private void labelTimeComma_MouseEnter(object sender, EventArgs e)
        {
            CancelPriorDimlight();
            NormallightButton(this.buttonSwap);
            NormallightButton(this.buttonClose);
            NormallightButton(this.buttonTopMost);
        }

        private void labelTimeComma_MouseLeave(object sender, EventArgs e)
        {
            //create so many background tasks when mouse fly over time label again and again
            // DimThenOffMultipleAsync(this.buttonClose, this.buttonSwap);

            _MouseLeaveTimestamp = DateTime.Now;
        }

        private void timerFading_Tick(object sender, EventArgs e)
        {
            if (_MouseLeaveTimestamp == DateTime.MinValue || DateTime.Now < _MouseLeaveTimestamp.AddMilliseconds(_ColorFadingDelay)) return;

            DimThenOffAsync(this.buttonClose, 10, Color.Gray, _ColorEmptyDelay);
            DimThenOffAsync(this.buttonSwap, 10, Color.Gray, _ColorEmptyDelay);
            DimThenOffAsync(this.buttonTopMost, 10, Color.Gray, _ColorEmptyDelay);
        }

        private void buttonTopMost_Click(object sender, EventArgs e)
        {
            try
            {
                this._TopMost = !this._TopMost;
                this.TopMost = _TopMost;
                this.buttonTopMost.Text = this._TopMost ? UITopMost : UITopMostOff;
                Properties.Settings.Default.TopMost = this._TopMost;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error: " + ex.ToString());
            }
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
            NormallightButton(this.buttonTopMost);

            _MouseLeaveTimestamp = DateTime.Now;
        }
    }

    public enum ClockFace
    {
        TimeWeekDate,
        TimeWeekDateWhite,
        TimeWeek,
        TimeDate,
        Time,

        TimeWithSecond,
        TimeWithSecondRed,
        TimeBlink,

        TimeSmallTopMostWhite,
        TimeSmallTopMost,
    }


    /*



    */
}
