using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BigClock
{
    public class PowerTool
    {
        public const string Version = "1.0.1";
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