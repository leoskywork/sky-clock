using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace BigClock
{
    public interface IMainView : IDisposable
    {
        Control Self { get; }
        bool HasMouseEnteredButton { get; }
    }

    public class ClockCore : IDisposable
    {
        public const int ColorFadingDelay = 10 * 1000;
        public const int ColorEmptyDelay = 1000;

        public int SwapCount { get; set; } = (int)ClockFace.TimeWeekDate;
        public int NumberOfClockFaces { get; set; } = 1;


        private IMainView _GUI;
        private List<CancellationTokenSource> _CancelTokens = new List<CancellationTokenSource>();

        public ClockCore(IMainView gui)
        {
            _GUI = gui ?? throw new ArgumentNullException(nameof(gui));
        }


        public ClockFace GetCurrentClockFace()
        {
            return (ClockFace)(SwapCount % NumberOfClockFaces);
        }

        public Task DimlightAsync(Button button, int delay, Color fadingTo, CancellationTokenSource tokenSource = null)
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

                this._GUI.Self.BeginInvoke((Action)(() =>
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
            if (_GUI.HasMouseEnteredButton) return false;

            if (this._GUI.Self.Disposing || this._GUI.Self.IsDisposed || button == null || button.Disposing || button.IsDisposed) return false;
            if (!button.Visible) return false;
            if (button.ForeColor == fadingTo) return false;

            return true;
        }

        public void DimThenOffAsync(Button button, int dimDelay, Color fadingTo)
        {
            this.DimThenOffAsync(button, dimDelay, fadingTo, ColorEmptyDelay);
        }
        public void DimThenOffAsync(Button button, int dimDelay, Color fadingTo, int killDelay)
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

        public void DimThenOffInitialAsync(params Button[] buttons)
        {
            if (buttons == null || buttons.Length == 0) return;

            foreach (var button in buttons)
            {
                DimThenOffAsync(button, ColorFadingDelay, Color.Gray, ColorEmptyDelay);
            }
        }

        public void CancelPriorDimlight()
        {
            for (int i = _CancelTokens.Count - 1; i >= 0; i--)
            {
                _CancelTokens[i].Cancel();
                _CancelTokens.RemoveAt(i);
            }
        }


        public void Dispose()
        {
            _GUI = null;
            _CancelTokens = null;
        }
    }
}
