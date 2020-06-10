using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Business.Implements;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Model;
using CableTestManager.Common;

namespace CableTestManager.View
{
    public partial class RadProbMeasure : Telerik.WinControls.UI.RadForm
    {
        private InterfaceInfoLibraryManager InterfaceInfoLibrary;
        private ProbTestConfig testConfig;

        public RadProbMeasure(ProbTestConfig probTestConfig)
        {
            InitializeComponent();
            this.testConfig = probTestConfig;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void RadProbMeasure_Load(object sender, EventArgs e)
        {
            if (this.testConfig.ProbTestType == ProbTestConfig.ProbTestTypeEnum.ProbTestByInterface)
            {

            }
            else if (this.testConfig.ProbTestType == ProbTestConfig.ProbTestTypeEnum.ProbTestByLimit)
            {
                this.num_fminPin.Value = this.testConfig.LimitMin;
                this.num_fmaxPin.Value = this.testConfig.LimitMax;
                this.num_fthreshold.Value = (decimal)this.testConfig.TestThresholdVal;
            }
            this.cobInter.MultiColumnComboBoxElement.Columns.Add("A");
            StudyProbCom.InitMulCombox(this.cobInter);
            InterfaceInfoLibrary = new InterfaceInfoLibraryManager();

            this.btn_InterStart.Click += Btn_InterStart_Click;
            this.btn_InterCancel.Click += Btn_InterCancel_Click;

            this.btn_fstartTest.Click += Btn_fstartTest_Click;
            this.btn_fcancel.Click += Btn_fcancel_Click;
        }

        private void Btn_fcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_InterCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_InterStart_Click(object sender, EventArgs e)
        {
            CommitStudyByInterface();
        }

        private void Btn_fstartTest_Click(object sender, EventArgs e)
        {
            this.testConfig.LimitMax = (int)this.num_fmaxPin.Value;
            this.testConfig.LimitMin = (int)this.num_fminPin.Value;
            this.testConfig.TestThresholdVal = (float)this.num_fthreshold.Value;
            this.testConfig.ProbTestType = ProbTestConfig.ProbTestTypeEnum.ProbTestByLimit;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void CommitStudyByInterface()
        {
            if (this.cobInter.Text == "")
            {
                MessageBox.Show("请选择一个A接口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.testConfig.TestInterAList = ConvertDevPointHex(GetAllDevPointByInter(this.cobInter.Text.Trim()));
            this.testConfig.TestThresholdVal = (float)this.conductionThresholdByPin.Value;
            this.testConfig.ProbTestType = ProbTestConfig.ProbTestTypeEnum.ProbTestByInterface;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private List<int> GetAllDevPointByInter(string interName)
        {
            var data = this.InterfaceInfoLibrary.GetDataSetByWhere($"where InterfaceNo='{interName}'").Tables[0];
            List<int> list = new List<int>();
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    int point;
                    if (int.TryParse(dr["SwitchStandStitchNo"].ToString(), out point))
                    {
                        list.Add(point);
                    }
                }
                if (list.Count <= 0)
                    return list;
                list.Sort();
                //分奇数偶数
                List<int> sigList = new List<int>();
                List<int> douList = new List<int>();
                foreach (var val in list)
                {
                    if ((val + 1) % 2 == 0)
                    {
                        sigList.Add(val);
                    }
                    else
                    {
                        douList.Add(val);
                    }
                }
                list.Clear();
                list.AddRange(sigList);
                list.AddRange(douList);
            }
            return list;
        }

        private StringBuilder ConvertDevPointHex(List<int> decList)
        {
            StringBuilder sb = new StringBuilder();
            if (decList.Count > 0)
            {
                foreach (var val in decList)
                {
                    var hexVal = DecConvert2ByteHexStr(val);
                    sb.Append(hexVal);
                }
            }
            return sb;
        }

        private string DecConvert2ByteHexStr(int dec)
        {
            return Convert.ToString(dec, 16).PadLeft(4, '0');
        }
    }
}
