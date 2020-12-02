using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TCPTest
{
    public partial class Form1 : Form
    {
        // 创建一个和客户端通信的套接字
        Socket socketwatch = null;
        //定义一个集合，存储客户端信息
        Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };

        public Form1()
        {
            InitializeComponent();
        }

        public void AppServer()
        {
            //定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端发送信息需要一个IP地址和端口号
            IPAddress address = IPAddress.Parse("127.0.0.1");
            //将IP地址和端口号绑定到网络节点point上
            IPEndPoint point = new IPEndPoint(address, 8088);
            //此端口专门用来监听的

            //监听绑定的网络节点
            socketwatch.Bind(point);

            //将套接字的监听队列长度限制为20
            socketwatch.Listen(20);

            //负责监听客户端的线程:创建一个监听线程
            Thread threadwatch = new Thread(watchconnecting);

            //将窗体线程设置为与后台同步，随着主线程结束而结束
            threadwatch.IsBackground = true;

            //启动线程
            threadwatch.Start();
        }

        //监听客户端发来的请求
        void watchconnecting()
        {
            Socket connection = null;
            //持续不断监听客户端发来的请求
            while (true)
            {
                try
                {
                    connection = socketwatch.Accept();
                    socketwatch = connection;
                }
                catch (Exception ex)
                {
                    //提示套接字监听异常
                    Console.WriteLine(ex.Message);
                    break;
                }

                //获取客户端的IP和端口号
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //客户端网络结点号
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                //显示与客户端连接情况
                Console.WriteLine("成功与" + remoteEndPoint + "客户端建立连接！\t\n");
                //添加客户端信息
                clientConnectionItems.Add(remoteEndPoint, connection);

                //IPEndPoint netpoint = new IPEndPoint(clientIP,clientPort);
                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程
                ParameterizedThreadStart pts = new ParameterizedThreadStart(recv);
                Thread thread = new Thread(pts);
                //设置为后台线程，随着主线程退出而退出
                thread.IsBackground = true;
                //启动线程
                thread.Start(connection);
            }
        }

        /// <summary>
        /// 接收客户端发来的信息，客户端套接字对象
        /// </summary>
        /// <param name="socketclientpara"></param>
        void recv(object socketclientpara)
        {
            Socket socketServer = socketclientpara as Socket;

            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节  即1M
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区，并返回其字节数组的长度
                try
                {
                    int length = socketServer.Receive(arrServerRecMsg);

                    //将机器接受到的字节数组转换为人可以读懂的字符串
                    //string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    byte[] buffer = new byte[length];
                    Array.Copy(arrServerRecMsg, 0, buffer, 0, buffer.Length);
                    ReceiveProcess(buffer);
                    //将发送的字符串信息附加到文本框txtMsg上
                    //Console.WriteLine("客户端:" + socketServer.RemoteEndPoint + ",time:" + GetCurrentTime() + "\r\n" + strSRecMsg + "\r\n\n");

                    //socketServer.Send(Encoding.UTF8.GetBytes("测试server 是否可以发送数据给client "));
                }
                catch (Exception ex)
                {
                    clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());

                    Console.WriteLine("Client Count:" + clientConnectionItems.Count);

                    //提示套接字监听异常
                    Console.WriteLine("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    //关闭之前accept出来的和客户端进行通信的套接字
                    socketServer.Close();
                    break;
                }
            }
        }

        private void SendMessage(byte[] buffer)
        {
            socketwatch.Send(buffer);
        }

        private void ReceiveProcess(byte[] buffer)
        {
            if (this.check_autoSend.CheckState == CheckState.Unchecked)
                return;
            if (buffer[0] == 0xff && buffer[1] == 0xff)
            {
                if (buffer[4] == 0xf2)//导通
                {
                    StartConduct();
                }
                else if (buffer[4] == 0xf3)//短路
                {
                    StartShort();
                }
                else if (buffer[4] == 0xf4)//绝缘
                {
                    StartInsulate();
                }
            }
        }

        ///
        /// 获取当前系统时间的方法
        /// 当前时间
        DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //发送数据A：1-192 B:193-384
            StartConduct();
        }

        private async void StartConduct()
        {
            await Task.Run(() =>
            {
                //导通测试
                for (int i = 0; i < 192; i++)
                {
                    int a = i + 1;
                    int b = 192 + i + 1;
                    var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                    var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                    byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                    byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                    byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                    SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF2, 0xBB, a1, a2, b1, b2, 0x00, 0x00, 0x00, 0x00, 0x06, 0x07 });

                    Task.Delay((int)this.num_interval.Value).Wait();
                }
                SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf2, 0xcc, 0x00, 0x00 });

            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                //导通测试
                for (int i = 0; i < 192; i++)
                {
                    int a = i + 1;
                    int b = 192 + i + 1;
                    var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                    var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                    byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                    byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                    byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                    SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF2, 0xBB, a1, a2, b1, b2, 0x00, 0x00, 0x00, 0x00, 0x06, 0x07 });

                    Task.Delay((int)this.num_interval.Value).Wait();
                }
                SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf2, 0xcc, 0x00, 0x00 });
                Task.Delay(100).Wait();
                //短路测试
                for (int i = 0; i < 192; i++)
                {
                    int a = i + 1;
                    int b = 192 + i + 1;
                    var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                    var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                    byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                    byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                    byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                    SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF3, 0xBB, a1, a2, b1, b2, 0x01, 0x05, 0x00, 0x35, 0x69, 0xee });

                    Task.Delay((int)this.num_interval.Value).Wait();
                }
                SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf3, 0xcc, 0x00, 0x00 });
                Task.Delay(100).Wait();
                //绝缘测试FF-FF-00-0C-F4-BB-00-01-00-05-01-05-00-35-69-EE
                for (int i = 0; i < 192; i++)
                {
                    int a = i + 1;
                    int b = 192 + i + 1;
                    var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                    var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                    byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                    byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                    byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                    SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF4, 0xBB, a1, a2, b1, b2, 0x01, 0x05, 0x01, 0x35, 0x69, 0xee });

                    Task.Delay((int)this.num_interval.Value).Wait();
                }
                SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf4, 0xcc, 0x00, 0x00 });
                Task.Delay(100).Wait();
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //短路测试
            StartShort();
        }

        private async void StartShort()
        {
            await Task.Run(() =>
             {
                 for (int i = 0; i < 192; i++)
                 {
                     int a = i + 1;
                     int b = 192 + i + 1;
                     var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                     var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                     byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                     byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                     byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                     byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                     SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF3, 0xBB, a1, a2, b1, b2, 0x01, 0x05, 0x00, 0x35, 0x69, 0xee });

                     Task.Delay((int)this.num_interval.Value).Wait();
                 }
                 SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf3, 0xcc, 0x00, 0x00 });
             });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //绝缘测试FF-FF-00-0C-F4-BB-00-01-00-05-01-05-00-35-69-EE
            StartInsulate();
        }

        private async void StartInsulate()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 192; i++)
                {
                    int a = i + 1;
                    int b = 192 + i + 1;
                    var aStr = Convert.ToString(a, 16).PadLeft(4, '0');
                    var bStr = Convert.ToString(b, 16).PadLeft(4, '0');
                    byte a1 = Convert.ToByte(aStr.Substring(0, 2), 16);
                    byte a2 = Convert.ToByte(aStr.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(bStr.Substring(0, 2), 16);
                    byte b2 = Convert.ToByte(bStr.Substring(2, 2), 16);
                    SendMessage(new byte[] { 0xFF, 0xFF, 0x00, 0x0C, 0xF4, 0xBB, a1, a2, b1, b2, 0x01, 0x05, 0x01, 0x35, 0x69, 0xee });

                    Task.Delay((int)this.num_interval.Value * 10).Wait();
                }
                SendMessage(new byte[] { 0xff, 0xff, 0x00, 0x04, 0xf4, 0xcc, 0x00, 0x00 });
            });
        }
    }
}
