﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Data.Linq;
using System.IO;

namespace FollowSccpStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = @"tshark  ";
            cmd += @" -r  D:\ScapyProject\mmm.pcap ";
            ColumnFormat.FormatColumn();
            System.IO.StreamWriter log = new System.IO.StreamWriter(@"f:\log2.txt", false);
            log.WriteLine(cmd);
            log.Flush();
            log.Close();

           // DecoderPacketPcap(cmd);

            Console.WriteLine(cmd);
            OutputDataReceive output = new OutputDataReceive();
            output.ExecuteCmd(cmd);


        }

        static void GetFromPcapFile()
        {
            string cmd = @"tshark  ";
            cmd += @" -r  D:\ScapyProject\mmm.pcap   -t  e  -T fields  ";
            cmd += @"  -e frame.number -e frame.time  -e gsm_a.imsi -e gsm_a.tmsi ";
            cmd += @" -e m3ua.protocol_data_opc -e m3ua.protocol_data_dpc -e sccp.slr -e sccp.dlr ";
            cmd += @" -e sccp.message_type  -E  separator=; ";
            // p.StandardInput.WriteLine("exit");
            Console.WriteLine(cmd);
            OutputDataReceive output = new OutputDataReceive();
            output.ExecuteCmd(cmd);
            //var d=DecoderPacketNum(1);
            //Console.WriteLine(d.PacketTime);
            //GetFromPcapFile();
            //for (int i = 0; i < 10000; i++)
            // flowstream.FollowSccpStream(DecoderPacketNum(i));

        }


        static void DecoderPacketPcap(string cmd)
        {
            FollowStream flowstream = new FollowStream();
            string dat = CommonFunction.ExecuteCmd(cmd);
            string[] txtLines = dat.Substring(dat.IndexOf("\r\n")).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in txtLines)
            {
                string nLine=line.Replace("[Malformed Packet]", "");
                nLine = nLine.Trim();
                var items = nLine.Split(new char[] { ' ' });
                LA_update msg = new LA_update();
                msg.PacketNum = Int32.Parse(items[0]);
                msg.PacketTime = DateTime.Parse(items[1]);
                msg.imsi = items[2];
                msg.tmsi = items[3];
                msg.m3ua_opc = items[4];
                msg.m3ua_dpc = items[5];
                msg.sccp_slr = items[6];
                msg.sccp_dlr = items[7];
                for (int i = 8; i < items.Count(); i++)
                    msg.ip_version_MsgType += items[i];

                flowstream.FollowSccpStream(msg);
            }
        }

        static void GetFromDatabase()
        {
            var message = CommonFunction.MyDatabase.LA_update.Select(e => e.ip_version_MsgType).Distinct().ToList();
            FollowStream flowstream = new FollowStream(message);
            //var filenum = CommonFunction.MyDatabase.LA_update.Select(e => e.FileNum).Count();
            var msgmax = CommonFunction.MyDatabase.LA_update.Select(e => e.FileNum).Count();
            Console.WriteLine(msgmax);
            var msg = CommonFunction.MyDatabase.LA_update;
            for (int i = 0; i < msgmax; i++)
                flowstream.FollowSccpStream(msg.Where(e => e.PacketNum == i).FirstOrDefault());
            //保存
            flowstream.FlowStatistics.Save();
        }

    }
}
 