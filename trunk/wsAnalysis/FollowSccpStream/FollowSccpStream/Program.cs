﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Data.Linq;

namespace FollowSccpStream
{
    class Program
    {

        public static DataClasses1DataContext mydb = new DataClasses1DataContext(common.connString);
		//没有出现sccp对之前的回调字典
		private static Dictionary<int, string> dCallback = new Dictionary<int, string>();
		//出现sccp对之后的只包含一项slr或者dlr的稀疏矩阵字典
        private static Dictionary<string, string> dConn = new Dictionary<string, string>();  
		//opc+dpc+slr+dlr索引字典，索引到包标签
        private static Dictionary<int?, string> dFlow = new Dictionary<int?, string>();
		
        static void Main(string[] args)
        {
            Console.Write("是否初始化数据库？");
            string inittable = Console.ReadLine();
            if (inittable == "y")
            {
                Console.WriteLine(inittable);
                InitTable();
            }
            Class2.FlowStatics();


        }
        static void InitTable()
        {
            var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
            var type = typeof(DataContext).Assembly.GetType(typeName);
            var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
            var metaTable = mydb.Mapping.GetTable(typeof(LA_update1));
            var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
            string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.LA_update1') and   type = 'U')
                drop table dbo.LA_update1";
            mydb.ExecuteCommand(delSql.ToString());
            mydb.ExecuteCommand(sql.ToString());
            GC.Collect();
            GC.Collect();

            var totalMessge = mydb.LA_update.Where(e => e.FileNum == 0).Take(5000);
            FollowSccpStream(totalMessge);
            GC.Collect();
            GC.Collect();
            SendOrders(DefineFlow(totalMessge), "LA_update1");
            GC.Collect();
            GC.Collect();
        }

		//根据消息寻呼做记录
		//通过回调的方式获取 opc+dpc+slr+dlr字典值的关键字的集合
        static void FollowSccpStream(IEnumerable<LA_update> totalMessge)
        {
 /*            for (int m = 0; m < 2; m++)
            { */
			
			    //int tNum=0;//回调参数
                foreach (LA_update i in totalMessge)
                {
				    //寻呼消息
                    if (i.sccp_slr == null && i.sccp_dlr == null)
                    {
                        if (i.tmsi !=null)
						    dCallback.Add(i.PacketNum,i.tmsi);
                            //dConn.Add(i.tmsi, i.PacketNum);  //开始记录包标签
						if (i.imsi !=null)
						    dCallback.Add(i.PacketNum,i.imsi);
                            //dConn.Add(i.imsi, i.PacketNum);  //开始记录包标签
                    }
                    
					//位置更新消息
                    if (i.sccp_slr != null && i.sccp_dlr == null)
                    {
                        if (dConn.ContainsKey(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr))   //查询conn索引表
						{
                            if (!dFlow.ContainsKey(i.PacketNum))
                            {
                                dFlow.Add(i.PacketNum, dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]);//Flow正常增加包标签
                                if (i.tmsi != null || i.imsi != null)
                                {
								    foreach(var call in dCallback)
									 if(tmsi.value==i.tmsi || tmsi.value==i.imsi)
									dFlow.Add(tmsi.key,dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]  //Flow补充增加TMSI标签号
                                }
                            }
						}
						else
						{
						    dCallback.Add( i.PacketNum,i.m3ua_opc + i.m3ua_dpc + i.sccp_slr);//开始记录包标签
						}
                    }
					
					//CC消息
					if (i.sccp_slr != null && i.sccp_dlr != null)
                    {
					    //if (!dFlow.ContainsKey(i.PacketNum))
                            dFlow.Add(i.PacketNum, i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr);
							
                        if (!dConn.ContainsKey(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr))
                            dConn.Add(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr, i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr);
						else
						{
						    tNum=dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr];
							dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]=i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr;
							dFlow.add(tNum,dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]);
						}

                        if (!dConn.ContainsKey(i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr))
                            dConn.Add(i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr, i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr);
						{
						    tNum=dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr];
							dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]=i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr;
							dFlow.add(tNum,dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]);
						}
                        if (!dConn.ContainsKey(i.m3ua_dpc + i.m3ua_opc + i.sccp_slr))
                            dConn.Add(i.m3ua_dpc + i.m3ua_opc + i.sccp_slr, i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr);
						{
						    tNum=dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr];
							dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]=i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr;
							dFlow.add(tNum,dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]);
						}
                        if ( !dConn.ContainsKey(i.m3ua_dpc + i.m3ua_opc + i.sccp_dlr))
                            dConn.Add(i.m3ua_dpc + i.m3ua_opc + i.sccp_dlr, i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr);
						{
						    tNum=dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr];
							dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]=i.m3ua_opc + i.m3ua_dpc + i.sccp_slr + i.sccp_dlr;
							dFlow.add(tNum,dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_slr]);
						}
						


                    }
                    
					//后续消息
                    if (i.sccp_slr == null && i.sccp_dlr != null)
                    {
                        if (dConn.ContainsKey(i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr))
						{
                            if (!dFlow.ContainsKey(i.PacketNum))
                            {
                                dFlow.Add(i.PacketNum, dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr]);//此处增加包标签
                                if (i.tmsi != null)
                                {
                                    if (dConn.ContainsKey(i.tmsi))
                                    dConn[i.tmsi]= dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr];//此处修改新的地址
                                }
                                if (i.imsi != null)
                                {
                                    if (dConn.ContainsKey(i.imsi))
                                        dConn[i.imsi] = dConn[i.m3ua_opc + i.m3ua_dpc + i.sccp_dlr];//此处修改新的地址
                                }
                            }
						}
						else
						{
						dConn.Add(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr, i.PacketNum);//开始记录包标签
						}
                    }
					
					//此处是否需要删除主键
					if (i.messge == sccp.released )
					{
					    dConn.Remove(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr);
						dConn.Remove(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr);
						dConn.Remove(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr);
						dConn.Remove(i.m3ua_opc + i.m3ua_dpc + i.sccp_slr);
					}
                }
            /* } */
            Console.WriteLine(dFlow.Count());
            Console.WriteLine(dConn.Count());
        }
        static IEnumerable<LA_update1> DefineFlow(IEnumerable<LA_update> totalMessge)
        {
            var connLookup = dFlow.ToLookup(e => e.Value);
            //Dictionary<string, string> _dConn = new Dictionary<string, string>();

            foreach (var i in connLookup)
            {
                //Console.WriteLine(i.Key);
                //Console.WriteLine(i.Select(e=>e.Key).Aggregate((total, next)=>total+next));
                var nLst = i.Select(e => e.Key);
                //foreach (var n in nLst)
                //    Console.WriteLine(n);
                var nFlow = totalMessge.Where(e => nLst.Contains(e.PacketNum));
                nFlow = nFlow.OrderBy(e => e.PacketTime);
                //var sccp = nFlow.Where(e => e.ip_version_MsgType == "SCCP.Release Complete").FirstOrDefault();
                //if (sccp != null)
                //{ 
                foreach (var m in nFlow)
                {
                    LA_update1 mFlow = new LA_update1();
                    //Console.WriteLine(m.ip_version_MsgType);
                    mFlow.BeginFrameNum = m.BeginFrameNum;
                    mFlow.DumpFor = m.DumpFor;
                    mFlow.FileNum = m.FileNum;
                    mFlow.imsi = m.imsi;
                    mFlow.ip_version = m.ip_version;
                    mFlow.ip_version_MsgType = m.ip_version_MsgType;
                    mFlow.m3ua_dpc = m.m3ua_dpc;
                    mFlow.m3ua_opc = m.m3ua_opc;
                    mFlow.PacketNum = m.PacketNum;
                    mFlow.PacketTime = m.PacketTime;
                    mFlow.PacketTime_ms_ = m.PacketTime_ms_;
                    mFlow.sccp_dlr = m.sccp_dlr;
                    mFlow.sccp_slr = m.sccp_slr;
                    mFlow.tmsi = m.tmsi;
                    mFlow.opcdpcsccp = i.Key;
                    yield return mFlow;
                }
            }
        }

        static void SendOrders(IEnumerable<LA_update1> mFlow, string tablename)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (SqlConnection con = new SqlConnection(common.connString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = mFlow;
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      SqlBulkCopyOptions.CheckConstraints |
                      SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    //bc.BulkCopyTimeout=0;
                    bc.BatchSize = 10;
                    bc.DestinationTableName = tablename;
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
            sw.Stop();
            Console.WriteLine(tablename + "---" + sw.Elapsed.TotalSeconds.ToString() + "---");
            GC.Collect();
            GC.Collect();
            Console.ReadKey();
        }
    }
}
 