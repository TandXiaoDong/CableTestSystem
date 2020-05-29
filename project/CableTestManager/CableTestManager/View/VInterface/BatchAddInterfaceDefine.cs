using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using CableTestManager.Common;

namespace CableTestManager.View.VInterface
{
    public partial class BatchAddInterfaceDefine : Telerik.WinControls.UI.RadForm
    {
        public NameRuleEnum nameRule;
        public string testMethod;
        public string startInterfacePoint;
        public string startPin;
        public int totalNum;
        private const string NUMBER_RAISE = "1,2,3...数字递增";
        private int maxPin = 384;
        private List<int> _2devPointList;
        private List<string> _4devPointList;

        public enum NameRuleEnum
        {
            NumberRaise,
            CapitalLetterRaise,
            SmallLetterRaise
        }

        public BatchAddInterfaceDefine()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BatchAddInterfaceDefine_Load(object sender, EventArgs e)
        {
            Init();
            CheckChangeEvent();
            this.rbt_2lineMethod.CheckStateChanged += Rbt_2lineMethod_CheckStateChanged;
            this.rbt_4lineMethod.CheckStateChanged += Rbt_4lineMethod_CheckStateChanged;
            this.cb_switchStandPointNo.SelectedIndexChanged += Cb_switchStandPointNo_SelectedIndexChanged;
            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.FormClosed += BatchAddInterfaceDefine_FormClosed;
        }

        private void BatchAddInterfaceDefine_FormClosed(object sender, FormClosedEventArgs e)
        {
            InterfaceLibCom.data = null;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            this.nameRule = NameRuleEnum.NumberRaise;
            if (this.tb_startInterfacePoint.Text.Trim() == "")
            {
                MessageBox.Show("起始接点不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.startInterfacePoint = this.tb_startInterfacePoint.Text.Trim();
            var switchStandPointNo = this.cb_switchStandPointNo.Text.Trim();
            if (this.rbt_2lineMethod.IsChecked)
            {
                this.testMethod = "二线法";
                int pointNo;
                if (!int.TryParse(switchStandPointNo, out pointNo))
                {
                    MessageBox.Show("转接台针脚号不为正整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (pointNo < 1 || pointNo > 384)
                {
                    MessageBox.Show("请输入大于0小于385之间的正整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.startPin = pointNo.ToString();
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                this.testMethod = "四线法";
                if (!switchStandPointNo.Contains(","))
                {
                    MessageBox.Show("针脚号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] _4lineArray = switchStandPointNo.Split(',');
                if (_4lineArray[0] == "")
                {
                    MessageBox.Show("针脚号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_4lineArray[1] == "")
                {
                    MessageBox.Show("针脚号格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.startPin = switchStandPointNo;
            }

            int pinNum;
            if (!int.TryParse(this.tb_PinNum.Text, out pinNum))
            {
                MessageBox.Show("请输入满足条件的操作数量！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.totalNum = pinNum;
            if (pinNum < 1)
            {
                MessageBox.Show("执行数量小于1！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.totalNum = 0;
            }
            if (this.rbt_2lineMethod.IsChecked)
            {
                if (pinNum > maxPin)
                    this.totalNum = this._2devPointList.Count;
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                if (pinNum > maxPin / 2)
                    this.totalNum = this._4devPointList.Count;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Init()
        {
            this._2devPointList = new List<int>();
            this._4devPointList = new List<string>();
            for (int i = 1; i <= maxPin; i++)
            {
                if (!InterfaceLibCom.IsExistDevicePoint(i.ToString()))
                {
                    this._2devPointList.Add(i);
                }
            }
            for (int i = 1; i <= maxPin; i += 2)
            {
                var curPoint = i + "," + (i + 1);
                if (!InterfaceLibCom.IsExistDevicePoint(curPoint))
                {
                    this._4devPointList.Add(curPoint);
                }
            }
            this.rbt_2lineMethod.CheckState = CheckState.Checked;

            this.cb_switchStandPointNo.Columns.Add("ID");
            this.cb_nameRule.MultiColumnComboBoxElement.Columns.Add("rule");
            this.cb_nameRule.EditorControl.Rows.Add(NUMBER_RAISE);
            this.cb_nameRule.SelectedIndex = 0;
            this.cb_nameRule.EditorControl.ShowColumnHeaders = false;
            this.cb_nameRule.BestFitColumns();
            this.cb_nameRule.EditorControl.Rows[0].IsSelected = false;
        }

        private void Cb_switchStandPointNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            var index = this.cb_switchStandPointNo.SelectedIndex;
            if (index < 0)
                return;
            if (this.rbt_2lineMethod.IsChecked)
            {
                //var c2lineValue = _2linePindata.Rows[index][0].ToString();
                //this.cb_switchStandPointNo.Text = c2lineValue;
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                //var c4lineValue = _4linePindata.Rows[index][0].ToString();
                //this.cb_switchStandPointNo.Text = c4lineValue;
            }
        }


        private void Rbt_4lineMethod_CheckStateChanged(object sender, EventArgs e)
        {
            this.lbx_tip.Text = "请输入1-192之间的正整数";
            CheckChangeEvent();
        }

        private void Rbt_2lineMethod_CheckStateChanged(object sender, EventArgs e)
        {
            this.lbx_tip.Text = "请输入1-384之间的正整数";
            CheckChangeEvent();
        }

        private void CheckChangeEvent()
        {
            this.BeginInvoke(new Action(() =>
            {
                lock (this)
                {
                    this.cb_switchStandPointNo.EditorControl.Rows.Clear();
                    this.cb_switchStandPointNo.EditorControl.BeginEdit();
                    if (this.rbt_2lineMethod.CheckState == CheckState.Checked)
                    {
                        for (int i = 0; i < this._2devPointList.Count; i++)
                        {
                            this.cb_switchStandPointNo.EditorControl.Rows.Add(this._2devPointList[i]);
                        }
                    }
                    else if (this.rbt_4lineMethod.CheckState == CheckState.Checked)
                    {
                        for (int i = 0; i < this._4devPointList.Count; i += 2)
                        {
                            this.cb_switchStandPointNo.EditorControl.Rows.Add(this._4devPointList[i]);
                        }
                    }
                    this.cb_switchStandPointNo.EditorControl.EndEdit();
                    this.cb_switchStandPointNo.SelectedIndex = 0;
                    this.cb_switchStandPointNo.EditorControl.ShowColumnHeaders = false;
                    this.cb_switchStandPointNo.EditorControl.ClearSelection();
                    this.cb_switchStandPointNo.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                }
            }));
        }
    }
}
