using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.ClientSocket;
using CableTestManager.ClientSocket.AppBase;
using CommonUtils.ByteHelper;
using System.Threading.Tasks;

namespace CableTestManager.View
{
    public partial class AddConnection : Telerik.WinControls.UI.RadForm
    {
        private bool IsConnect;
        public  string serverIP;
        public  int serverPort;
        public AddConnection(string serviceURL,int servicePort)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.serverPort = servicePort;
            this.serverIP = serviceURL;
            EventHandlers();
        }

        private void EventHandlers()
        {
            this.Load += AddConnection_Load;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_apply.Click += Btn_apply_Click;
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            //保存数据
            var serviceURL = this.tb_hostname.Text.Trim();
            var servicePort = this.tb_port.Text.Trim();
            if (serviceURL == "")
            {
                MessageBox.Show("服务器地址不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (servicePort == "")
            {
                MessageBox.Show("服务器端口不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int port = 0;
            if (!int.TryParse(servicePort, out port))
            {
                MessageBox.Show("服务器端口无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.serverIP = serviceURL;
            this.serverPort = port;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void SendMessage()
        {
            //SuperEasyClient.SendMessage(StentSignalEnum.RequestData, new byte[0]);
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddConnection_Load(object sender, EventArgs e)
        {
            if (serverIP != "")
                this.tb_hostname.Text = serverIP;
            else
                this.tb_hostname.Text = "127.0.0.1";
            if (serverPort != 0)
                this.tb_port.Text = serverPort.ToString();
            else
                this.tb_port.Text = "1001";
        }
    }
}
