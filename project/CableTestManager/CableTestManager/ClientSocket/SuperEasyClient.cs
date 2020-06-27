using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SuperSocket.ClientEngine;
using CommonUtils.ByteHelper;
using CommonUtils.Logger;
using CableTestManager.ClientSocket.AppBase;
using System.Configuration;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.ProtoBase;

namespace CableTestManager.ClientSocket
{
    public class SuperEasyClient
    {
        public delegate void NoticeConnect(bool IsConnect, ConnectStatusEnum tipMessageEnum);
        public delegate void NoticeMessage(MyPackageInfo packageInfo);

        public static event NoticeConnect NoticeConnectEvent;
        public static event NoticeMessage NoticeMessageEvent;

        public static EasyClient<MyPackageInfo> client;
        public static string serverUrl = "";
        public static string serverPort = "";
        private static bool IsNormalClose;
        private static bool IsStartReconnect;
        private static MyPackageInfo myPackageInfo;
        private static int attmpts = 0;
        private static Object obj = new object();

        public enum ConnectStatusEnum
        {
            Connected,
            ReConnected,
            DisConnected,
            ConnectOutTime,
            ConnectError//如服务器IP或端口号输入错误
        }

        private static void SendNoticeMessage(MyPackageInfo packageInfo)
        {
            NoticeMessageEvent(packageInfo);
        }

        private static void SendNoticeConnect(bool IsConnect, ConnectStatusEnum tipMessageEnum)
        {
            NoticeConnectEvent(IsConnect, tipMessageEnum);
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        public static async void ConnectServer()
        {
            //if (client != null || !client.IsConnected)
            //    return;
            client = new EasyClient<MyPackageInfo>();

            LogHelper.Log.Info("开始连接服务...");
            client = new EasyClient<MyPackageInfo>();
            client.ReceiveBufferSize = 65535;

            client.Initialize(new MyReceiveFilter());
            client.Connected += OnClientConnected;
            client.NewPackageReceived += OnPagckageReceived;
            client.Error += OnClientError;
            client.Closed += OnClientClosed;

            //var webSocketUrl = System.Configuration.ConfigurationManager.AppSettings["WebSocketURL"].ToString();//ip
            //var webSocketPort = System.Configuration.ConfigurationManager.AppSettings["WebSocketPort"].ToString();//port
            var connected = await client.ConnectAsync(new IPEndPoint(IPAddress.Parse(serverUrl), int.Parse(serverPort)));
        }

        private void Recon(bool connected)
        {
            int times = 1;
            while (!connected)
            {
                Task.Delay(1000).Wait();
                if (connected)
                {
                    break;
                }
                if (times > 3)
                {
                    SendNoticeConnect(client.IsConnected, ConnectStatusEnum.ConnectOutTime);
                    LogHelper.Log.Info("连接服务超时...");
                    break;
                }
                times++;
            }
        }

        public static void CloseConnect()
        {
            IsNormalClose = true;
            client.Close();
        }

        private static void OnClientClosed(object sender, EventArgs e)
        {
            SendNoticeConnect(client.IsConnected, ConnectStatusEnum.DisConnected);
            LogHelper.Log.Info("已断开与服务的连接...");
            ReConnectServer();
        }

        private static void ConServer()
        {
            client.ConnectAsync(new IPEndPoint(IPAddress.Parse(serverUrl), int.Parse(serverPort)));
        }

        private static bool ReConnectServer()
        {
            if (!IsNormalClose)
            {
                //异常断开连接，尝试重连
                LogHelper.Log.Info("开始重连...");
                do
                {
                    lock (obj)
                    {
                        if (client.IsConnected)
                        {
                            LogHelper.Log.Info("已经连接服务...");
                            break;
                        }
                        IsStartReconnect = true;
                        LogHelper.Log.Info("尝试重新连接，重连次数为" + attmpts);
                        ConServer();
                        attmpts++;
                        Thread.Sleep(1000);
                    }
                } while (!client.IsConnected && attmpts <= 6);
                attmpts = 0;
                LogHelper.Log.Info("重新连接完毕，退出循环");
                if (client.IsConnected)
                {
                    LogHelper.Log.Info("重新连接成功！");
                    return true;
                }
                else
                {
                    LogHelper.Log.Info("重新连接失败");
                    return false;
                }
            }
            else
            {
                IsNormalClose = false;//正常关闭完成后，重置
                IsFirstConErr = true;
                return true;
            }
        }

        private static bool IsFirstConErr = true;
        private static void OnClientError(object sender, ErrorEventArgs e)
        {
            if (IsFirstConErr)
            {
                IsFirstConErr = false;
                LogHelper.Log.Info("客户端错误...");
                if (!ReConnectServer())
                {
                    LogHelper.Log.Info("客户端错误：" + e.Exception.Message);
                    SendNoticeConnect(client.IsConnected, ConnectStatusEnum.ConnectError);
                }
            }
        }

        private static void OnPagckageReceived(object sender, PackageEventArgs<MyPackageInfo> e)
        {
            if (e.Package.Data.Length > 1 || e.Package.Header.Length > 0)
            {
                SendNoticeMessage(e.Package);
                myPackageInfo = e.Package;
            }
            //LogHelper.Log.Info("收到服务消息【Byte】:"+"head:"+BitConverter.ToString(e.Package.Header)+" body:"+BitConverter.ToString(e.Package.Data));
        }

        private static void OnClientConnected(object sender, EventArgs e)
        {
            if (IsStartReconnect)
            {
                //重连成功
                IsStartReconnect = false;
                SendNoticeConnect(client.IsConnected, ConnectStatusEnum.ReConnected);
                LogHelper.Log.Info("重连成功...");
            }
            else
            {
                //正常连接
                SendNoticeConnect(client.IsConnected, ConnectStatusEnum.Connected);
                LogHelper.Log.Info("已连接到服务器...");
            }
        }

        /// <summary>
        /// 发送命令和消息到服务器
        /// </summary>
        /// <param name="command"></param>
        /// <param name="message"></param>
        public static void SendMessage(DeviceFunCodeEnum command, string message)
        {
            if (client == null || !client.IsConnected || message.Length <= 0)
                return;
            var response = BitConverter.GetBytes((ushort)command).Reverse().ToList();
            var arr = System.Text.Encoding.UTF8.GetBytes(message);
            response.AddRange(BitConverter.GetBytes((ushort)arr.Length).Reverse().ToArray());
            response.AddRange(arr);
            client.Send(response.ToArray());
            LogHelper.Log.Info($"发送{command.GetDescription()}数据：" + message + " byte:" + BitConverter.ToString(response.ToArray()));
        }

        public static void SendMessage(DeviceFunCodeEnum command, byte[] message)
        {
            if (client == null || !client.IsConnected)
                return;
            var response = BitConverter.GetBytes((ushort)command).Reverse().ToList();
            if (message.Length > 0)
            {
                response.AddRange(BitConverter.GetBytes((ushort)message.Length).ToArray());//低位在前
                response.AddRange(message);
            }
            client.Send(response.ToArray());
            //LogHelper.Log.Info($"发送指令：" + BitConverter.ToString(response.ToArray()));
        }
    }
}
