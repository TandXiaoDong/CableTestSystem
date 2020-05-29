using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using CableTestManager.Common;

namespace CableTestManager.View.VInterface
{
    public partial class AddSignalInterfaceDefine : RadForm
    {
        public string interfacePointName;
        public string switchStandPointNo;
        public string testMethod;
        private int maxPin = 384;
        private DataTable _2linePindata;
        private DataTable _4linePindata;
        private List<int> _2devPointList;
        private List<string> _4devPointList;

        public AddSignalInterfaceDefine()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void AddSignalInterfaceDefine_Load(object sender, EventArgs e)
        {
            Init();
            CheckChangeEvent();
            this.FormClosed += AddSignalInterfaceDefine_FormClosed;
            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.rbt_2lineMethod.CheckStateChanged += Rbt_2lineMethod_CheckStateChanged;
            this.rbt_4lineMethod.CheckStateChanged += Rbt_4lineMethod_CheckStateChanged;
            this.cb_switchStandPointNo.SelectedIndexChanged += Cb_switchStandPointNo_SelectedIndexChanged;
        }

        private void AddSignalInterfaceDefine_FormClosed(object sender, FormClosedEventArgs e)
        {
            InterfaceLibCom.data = null;
        }

        private void Cb_switchStandPointNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            var index = this.cb_switchStandPointNo.SelectedIndex;
            if (index < 0)
                return;
            if (this.rbt_2lineMethod.IsChecked)
            {
                var c2lineValue = _2linePindata.Rows[index][0].ToString();
                this.cb_switchStandPointNo.Text = c2lineValue;
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                var c4lineValue = _4linePindata.Rows[index][0].ToString();
                this.cb_switchStandPointNo.Text = c4lineValue;
            }
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
            this.cb_switchStandPointNo.MultiColumnComboBoxElement.Columns.Add("data");
            this.rbt_2lineMethod.CheckState = CheckState.Checked;
            _2linePindata = new DataTable();
            _2linePindata.Columns.Add("ID");
            _4linePindata = new DataTable();
            _4linePindata.Columns.Add("ID");
        }

        private void Rbt_4lineMethod_CheckStateChanged(object sender, EventArgs e)
        {
            CheckChangeEvent();
        }

        private void Rbt_2lineMethod_CheckStateChanged(object sender, EventArgs e)
        {
            CheckChangeEvent();
        }

        private void CheckChangeEvent()
        {
            this.BeginInvoke(new Action(()=>
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

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            var interfacePointName = this.tb_InterfacePointName.Text.Trim();
            var switchStandPointNo = this.cb_switchStandPointNo.Text.Trim();
            if (interfacePointName == "")
            {
                MessageBox.Show("接点名称不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (switchStandPointNo == "")
            {
                MessageBox.Show("转接台针脚号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.rbt_2lineMethod.IsChecked)
            {
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
                this.switchStandPointNo = pointNo.ToString();
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                if (!switchStandPointNo.Contains(","))
                {
                    MessageBox.Show("针脚号格式错误！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                this.switchStandPointNo = switchStandPointNo;
            }

            this.interfacePointName = interfacePointName;

            if (this.rbt_2lineMethod.IsChecked)
            {
                testMethod = "二线法";
            }
            else if (this.rbt_4lineMethod.IsChecked)
            {
                testMethod = "四线法";
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
