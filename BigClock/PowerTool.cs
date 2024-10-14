using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigClock
{
    public class PowerTool
    {
        public const string Version = "1.0.1";
        public const string AppName = "LEO Clock";


        //ref https://www.cnblogs.com/sekon/p/5043766.html
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        //        实现休眠，代码如下：
        //SetSuspendState(true, true, true);
        //        实现睡眠，代码如下：
        //SetSuspendState(false, true, true);
        public static void OSSleep(int delaySeconds = 5)
        {
            RunAsync(delaySeconds * 1000, () => SetSuspendState(false, true, true), "sleep os");
        }



        [DllImport("user32")]
        public static extern void LockWorkStation();
        //        然后，使用如下代码就可以实现锁定：
        //LockWorkStation();
        public static void OSLock(int delaySeconds = 5)
        {
            RunAsync(delaySeconds * 1000, () => LockWorkStation(), "lock os");
        }

        private static void RunAsync(int delayMS, Action action, string message = null)
        {
            Task.Factory.StartNew(() =>
            {
                System.Diagnostics.Debug.WriteLine($"async delay: {delayMS}ms, msg: {message}");

                if (delayMS > 0)
                {
                    Thread.Sleep(delayMS);
                }

                action?.Invoke();
            });
        }

        public static void OSShutdown(int delaySeconds = 5)
        {
            if (delaySeconds < 0)
            {
                delaySeconds = 0;
            }

            Process.Start("shutdown", $"/s /t {delaySeconds}");  // 参数 /s 的意思是要关闭计算机, 参数 /t 0 的意思是告诉计算机 0 秒之后执行命令
        }

        public static void OSReboot(int delaySeconds)
        {
            if (delaySeconds < 0)
            {
                delaySeconds = 0;
            }

            Process.Start("shutdown", $"/r /t {delaySeconds}"); // 参数 /r 的意思是要重新启动计算机
        }
    }

    public class PowerEventHub
    {
        public static readonly PowerEventHub Default = new PowerEventHub();

        public event EventHandler<ChangeClockFaceEventArgs> FaceChanged;

        private PowerEventHub()
        {

        }

        public void FireFaceChanged(ChangeClockFaceEventArgs e)
        {
            FaceChanged?.Invoke(this, e);
        }

    }

    public class ChangeClockFaceEventArgs : EventArgs
    {
        public ClockFace NewFace { get; set; }
    }

    public class CmdExecutor
    {
        public static string ExecuteCommand(string command)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = false;// true;


                process.Start();

                //process.StandardInput.WriteLine("@echo test"); //错误: 不支持输入重新定向，立即退出此进程。
                process.StandardInput.WriteLine(command);
                //process.StandardInput.WriteLine("timeout /T 10"); //错误: 不支持输入重新定向，立即退出此进程。
                process.StandardInput.WriteLine("exit");
                //process.WaitForExit();

                return process.StandardOutput.ReadToEnd();
            }
        }
    }

    //    class Program
    //    {
    //        static void Main()
    //        {
    //            //string command = "ipconfig"; // 示例命令
    //            //string result = CmdExecutor.ExecuteCommand(command);
    //            //Console.WriteLine(result);
    //        }
    //    }
    //}
}