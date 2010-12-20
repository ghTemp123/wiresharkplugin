﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FollowSccpStream
{
    class OutputDataReceive
    {
        public OutputDataReceive()
        {
        }

        public void ExecuteCmd(string cmd)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = "format.com";
            //p.StartInfo.Arguments = " G: /FS:FAT /Q";
            //p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.CreateNoWindow = true;//true表示不显示黑框，false表示显示dos界面
            //p.StartInfo.UseShellExecute = false;
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
            //调用程序名 
            {
                startInfo.Arguments = "/C " + cmd;
                //调用命令 CMD 
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
            }

            Process p = Process.Start(startInfo);


            p.EnableRaisingEvents = true;

            p.Exited += new EventHandler(p_Exited);
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            p.Start();
           // p.StandardInput.WriteLine("");
           // p.StandardInput.WriteLine("");

            //开始异步读取输出
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            //调用WaitForExit会等待Exited事件完成后再继续往下执行。
            p.WaitForExit();
            //p.Close();

            //Console.WriteLine("exit");

        }
        FollowStream flowstream = new FollowStream();
        void GetFromPcapFile(string decodedata)
        {
            var items = decodedata.Split(';');
            LA_update msg = new LA_update();
            msg.PacketNum = Int32.Parse(items[0]);
            msg.PacketTime = DateTime.Parse(items[1]);
            msg.imsi = items[2];
            msg.tmsi = items[3];
            msg.m3ua_opc = items[4];
            msg.m3ua_dpc = items[5];
            msg.sccp_slr = items[6];
            msg.sccp_dlr = items[7];
            msg.ip_version_MsgType = items[8];

            flowstream.FollowSccpStream(msg);
        }
        void p_OutputDataReceived(Object sender, DataReceivedEventArgs e)
        {
            //这里是正常的输出
            Console.WriteLine(e.Data);
            Task.Factory.StartNew(() => GetFromPcapFile(e.Data));
        }

        void p_ErrorDataReceived(Object sender, DataReceivedEventArgs e)
        {
            //这里得到的是错误信息
            Console.WriteLine(e.Data);

        }

        void p_Exited(Object sender, EventArgs e)
        {
            Console.WriteLine("finish");
        }

    }
}
