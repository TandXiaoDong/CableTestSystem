using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.ClientSocket;
using CableTestManager.ClientSocket.AppBase;
using CommonUtils.Logger;
using CommonUtils.ByteHelper;

namespace CableTestManager.View.VEquipment
{
    public partial class DevCalibration : Form
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        public DevCalibration()
        {
            InitializeComponent();
        }

        private enum TestTypeEnum
        { 
            AssTest,
            InsVoltageTest,
            InsAssTest
        }

        private void Init()
        {
            this.num_insulateDY_voltage.Minimum = 0;
            this.num_insulateDY_voltage.Maximum = 500;

            this.num_insulateDZ_voltage.Minimum = 0;
            this.num_insulateDZ_voltage.Maximum = 500;

            this.num_insulateDY_time.Minimum = 0;
            this.num_insulateDY_time.Maximum = 120;

            this.num_insulateDZ_time.Minimum = 0;
            this.num_insulateDZ_time.Maximum = 120;

            timer.Interval = 200;
        }

        private void DevCalibration_Load(object sender, EventArgs e)
        {
            Init();

            this.timer.Elapsed += Timer_Elapsed;
            this.btn_dztest.Click += Btn_dztest_Click;
            this.btn_insulateDZTest.Click += Btn_insulateDZTest_Click;
            this.btn_insulateVoltageTest.Click += Btn_insulateVoltageTest_Click;
            SuperEasyClient.NoticeMessageEvent += SuperEasyClient_NoticeMessageEvent;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }

        private void SuperEasyClient_NoticeMessageEvent(ClientSocket.AppBase.MyPackageInfo packageInfo)
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
            if (packageInfo.Data[4] == 0xf7 && packageInfo.Data[5] == 0xcc)//电阻计量
            {
                TestItemProcess(packageInfo, TestTypeEnum.AssTest);
            }
            else if (packageInfo.Data[4] == 0xf8 && packageInfo.Data[5] == 0xcc)//绝缘电压计量
            {
                TestItemProcess(packageInfo, TestTypeEnum.InsVoltageTest);
            }
            else if (packageInfo.Data[4] == 0xf9 && packageInfo.Data[5] == 0xbb)//绝缘电阻计量
            {
                TestItemProcess(packageInfo, TestTypeEnum.InsAssTest);
            }
        }

        private void Btn_insulateVoltageTest_Click(object sender, EventArgs e)
        {
            var voltage = Convert.ToString((int)this.num_insulateDY_voltage.Value, 16).PadLeft(4, '0');
            var holdTime = Convert.ToString((int)this.num_insulateDY_time.Value, 16).PadLeft(2, '0');
            var commandStr = "02" + voltage + holdTime;
            var conductionCommand = CommonTestSendCommand(commandStr, "F8 AA");
            if (conductionCommand.Length < 1)
                return;
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
        }

        private void Btn_insulateDZTest_Click(object sender, EventArgs e)
        {
            var voltage = Convert.ToString((int)this.num_insulateDZ_voltage.Value, 16).PadLeft(4, '0');
            var holdTime = Convert.ToString((int)this.num_insulateDZ_time.Value, 16).PadLeft(2, '0');
            var commandStr = "02" + voltage + holdTime;
            var conductionCommand = CommonTestSendCommand(commandStr, "F9 AA");
            if (conductionCommand.Length < 1)
                return;
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
        }

        private void Btn_dztest_Click(object sender, EventArgs e)
        {
            var commandStr = "02";
            var conductionCommand = CommonTestSendCommand(commandStr, "F7 AA");
            if (conductionCommand.Length < 1)
                return;
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
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

        private void TestItemProcess(MyPackageInfo packageInfo, TestTypeEnum testType)
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
            var calResult = (resistance * factor).ToString("f2");

            Task.Run(()=>
            {
                switch (testType)
                {
                    case TestTypeEnum.AssTest:
                        this.tb_dzResult.Text = calResult;
                        break;
                    case TestTypeEnum.InsVoltageTest:
                        this.tb_insulateDY_Result.Text = calResult;
                        break;
                    case TestTypeEnum.InsAssTest:
                        this.tb_insulateDz_Result.Text = calResult;
                        break;
                }
            });
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
