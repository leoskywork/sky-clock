using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BigClock
{
    public partial class ClockSetting : Form
    {
        public const int DefaultLifeSpanSeconds = 100;
        
        private float _DefaultSize;
        private DateTime _DisplayAt;
        private int _TimerMinute;
        private DateTime _TimerStartTime;
        private bool _RunningTask;
        private ClockFace _ClockFace;

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

            this.labelTimerMessage.Visible = false;
            _ClockFace = args.CurrentFace;

            if (Environment.MachineName == "LEO-PC-PRO")
            {
                this.buttonTest.Visible = true;
                this.TopMost = true;
            }
            else
            {
                this.buttonTest.Visible = false;
            }
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
            var timerSeconds = _TimerMinute * 60 - 4;
            var lifeSeconds = timerSeconds > DefaultLifeSpanSeconds ? timerSeconds : DefaultLifeSpanSeconds;
            var remainingSeconds = lifeSeconds - (int)passed.TotalSeconds;
            this.Text = $"Setting - auto close in {(remainingSeconds > 60 ? remainingSeconds/60 + " min " : "")}{remainingSeconds%60} s";

            if (_RunningTask)
            {
                if (passed.TotalSeconds > lifeSeconds - 10)
                {
                    this.Out("Running task");
                    RunTaskAsync();
                }

                if (passed.TotalSeconds > lifeSeconds - 4)
                {
                    this.Out("Sleeping PC");
                    SleepPCAsync();
                }
            }

            if (passed.TotalSeconds > lifeSeconds)
            {
                this.Close();
            }

            if (DateTime.Now.Second % 10 == 0)
            {
                this.Out(this.Text);
            }
        }

        private void RunTaskAsync()
        {
            var processNames = new List<string>(); // new[] { "chrome" };

            if(this.checkBoxKillChrome.Checked)
            {
                processNames.Add("chrome");
            }

            Task.Factory.StartNew(() =>
            {
                var processes = Process.GetProcesses();
                var currentSessionId = Process.GetCurrentProcess().SessionId;
                var currentUserProcesses = processes.Where(p => p.SessionId == currentSessionId).ToList();
                int count = 0;
                int opt = 1;
                opt = 2;

                if (opt == 1)
                {
                    foreach (var process in currentUserProcesses)
                    {
                        System.Diagnostics.Debug.WriteLine($"{++count}. found：{process.ProcessName}, {process.Id}");

                        foreach (string processName in processNames)
                        {
                            if (process.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase))
                            {
                            }
                        }
                    }
                }
                else if (opt == 2)
                {
                    foreach (var name in processNames)
                    {
                        Process[] targetProcesses = Process.GetProcessesByName(name);
                        this.Out($"find {targetProcesses.Length} {name}, going to kill");

                        foreach (Process process in targetProcesses)
                        {
                            process.Kill();
                            //process.WaitForExit();
                        }
                    }
                }
            });
        }

        private void SleepPCAsync()
        {
            Task.Factory.StartNew(() =>
            {
                string cmd = $"ipconfig";
                cmd = "rundll32.exe powrprof.dll, SetSuspendState Sleep";

                string result = CmdExecutor.ExecuteCommand(cmd);
                this.Out(result);
            });
        }

        private void buttonTimerStart_Click(object sender, EventArgs e)
        {
            SetButtonAppearance(true);
            _TimerMinute = (int)numericUpDownTimerMinute.Value;
            _TimerStartTime = DateTime.Now;
            this.Out($"Run task in {_TimerMinute}min, at {_TimerStartTime.AddMinutes(_TimerMinute).ToShortTimeString()}");

        }

        private void SetButtonAppearance(bool taskRunning)
        {
            this.buttonTimerStart.Enabled = !taskRunning;
            this.buttonTimerCancel.Enabled = taskRunning;
            this.numericUpDownTimerMinute.Enabled = !taskRunning;
            this.checkBoxKillChrome.Enabled = !taskRunning;
            _RunningTask = taskRunning;
        }

        private void buttonTimerCancel_Click(object sender, EventArgs e)
        {
            SetButtonAppearance(false);
            _TimerMinute = 0;
            _TimerStartTime = DateTime.MinValue;
            _DisplayAt = DateTime.Now;
            this.Out("Cancelled");

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            this.buttonTest.Enabled = false;
            this.Out("Testing");
            _DisplayAt = DateTime.Now;

            RunTaskAsync();
            //SleepPCAsync();

            System.Threading.Thread.Sleep(200);
            this.buttonTest.Enabled = true;
        }

        private void Out(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action<string>)Out, message);
                return;
            }

            //this.labelTimerMessage.Text = message;
            this.textBoxMessage.Text += DateTime.Now.ToString("h:mm:ss ") + message + Environment.NewLine;
            textBoxMessage.SelectionStart = textBoxMessage.Text.Length;
            textBoxMessage.ScrollToCaret();

            this.BeginInvoke((Action)(() =>
            {
                //Thread.Sleep(200);
                //textBoxMessage.Focus();
                textBoxMessage.Select(textBoxMessage.Text.Length - Environment.NewLine.Length, 0);
            }));
        }

        private void ClockSetting_Load(object sender, EventArgs e)
        {
            this.textBoxMessage.Text = null;
            this.Out(_ClockFace.ToString());

        }
    }

    
}
