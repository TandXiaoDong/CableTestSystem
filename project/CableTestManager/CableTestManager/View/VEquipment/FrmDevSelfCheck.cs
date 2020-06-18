using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CableTestManager.ClientSocket;
using CableTestManager.ClientSocket.AppBase;
using CableTestManager.Common;
using CommonUtils.ByteHelper;

namespace CableTestManager.View.VEquipment
{
    public partial class FrmDevSelfCheck : Form
    {
        //标准值的测试阈值，正负阈值，加减百分之十，范围内自检合格
        private double devSelfCheckThreshold;
        public FrmDevSelfCheck()
        {
            InitializeComponent();
        }

        private void FrmDevSelfCheck_Load(object sender, EventArgs e)
        {
            this.devSelfCheckThreshold = SelfCheckParams.GetSelfCheckParams();
            this.lbx_checkTip.Visible = false;
            this.btn_exit.Click += Btn_exit_Click;
            this.btn_startCheck.Click += Btn_startCheck_Click;
            SuperEasyClient.NoticeMessageEvent += SuperEasyClient_NoticeMessageEvent;
        }

        private void SuperEasyClient_NoticeMessageEvent(MyPackageInfo packageInfo)
        {
            var dataLength = packageInfo.Data.Length;
            //导通测试成功后，更新UI，并开始测试下一个
            //收到f2 cc
            if (packageInfo.Header.Length < 4 || packageInfo.Data.Length < 4)
                return;
            if (packageInfo.Data[0] != 0xff || packageInfo.Data[1] != 0xff)
            {
                return;
            }
            if (packageInfo.Data[4] == 0xfb && packageInfo.Data[5] == 0xcc)//设备自检
            {
                TestItemProcess(packageInfo);
            }
        }

        private void Btn_startCheck_Click(object sender, EventArgs e)
        {
            var commandStr = "02";
            var conductionCommand = CommonTestSendCommand(commandStr, "FB AA");
            if (conductionCommand.Length < 1)
                return;
            this.lbx_checkTip.Text = "";
            this.btn_startCheck.Enabled = false;
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestItemProcess(MyPackageInfo packageInfo)
        {
            var baseNum = DecConvert2Hex(packageInfo.Data[10]);
            var power = (int)packageInfo.Data[11];
            byte[] buffer = new byte[4];
            Array.Copy(packageInfo.Data, 12, buffer, 0, 4);
            var resistanceVal = Convert.ToUInt32(BitConverter.ToString(buffer).Replace("-", ""), 16);
            var resistance = resistanceVal / 65536.0;
            double factor = 0;
            if (baseNum == "00")
            {
                double.TryParse(Convert.ToString((int)packageInfo.Data[11], 16).Substring(0, 1), out factor);
            }
            else if (baseNum == "01")
            {
                factor = 10 * Math.Pow(10, power);
            }
            var calResult = resistance * factor;
            this.tb_checkResult.Text = calResult.ToString("f3");
            var min = devSelfCheckThreshold - (devSelfCheckThreshold * 0.1);
            var max = devSelfCheckThreshold + (devSelfCheckThreshold * 0.1);

            if (calResult >= min && calResult <= max)
            {
                this.lbx_checkTip.Text = "自检结果在500正负10%范围内";
            }
            else
            {
                this.lbx_checkTip.Text = "自检结果不在500正负10%范围内";
                this.lbx_checkTip.ForeColor = Color.Red;
            }
            this.lbx_checkTip.Visible = true;
            this.btn_startCheck.Enabled = true;
        }

        private byte[] CommonTestSendCommand(string testCommandString, string testFunCode)
        {
            //eg:FF FF 00 0D F2 AA 00 01 00 02 00 03 00 06 01 02 01 0A
            if (testCommandString.Length < 1)
                return new byte[0];
            byte[] conductionByte = new byte[2 + testCommandString.Length / 2];
            var conductArray = (testFunCode + " " + SplitStringByEmpty(testCommandString)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return ConvertByte.HexStringToByte(conductionByte, conductArray, 0);
        }

        private string DecConvert2Hex(byte b)
        {
            return Convert.ToString(b, 16).PadLeft(2, '0');
        }
        private string SplitStringByEmpty(string hexString)
        {
            var arrayString = string.Empty;
            var conductionInfoChar = hexString.ToCharArray();
            for (int i = 0; i < conductionInfoChar.Length; i += 2)
            {
                arrayString += conductionInfoChar[i].ToString() + conductionInfoChar[i + 1].ToString() + " ";
            }
            return arrayString;
        }
    }
}
