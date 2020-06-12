using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.Entity;

namespace CableTestManager.View.VEquipment
{
    public partial class ResistanceManage : Form
    {
        //电阻补偿-测试结果补偿电阻包括：自学习/探针/导通/短路
        //绝缘电压补偿-发送绝缘电压补偿电压
        //绝缘电阻补偿-测试结果补偿绝缘电阻
        TProjectBasicInfo projectBasicInfo;
        public ResistanceManage(TProjectBasicInfo basicInfo)
        {
            InitializeComponent();
            this.projectBasicInfo = basicInfo;
        }

        private void Init()
        {
            this.num_resComVal.Minimum = -1000000;
            this.num_resComVal.Maximum = 1000000;
            this.num_resComVal.DecimalPlaces = 2;
            this.num_resComVal.Increment = 2;

            this.num_insVolCom.Minimum = -50;
            this.num_insVolCom.Maximum = 50;
            this.num_insVolCom.DecimalPlaces = 2;
            this.num_insVolCom.Increment = 2;

            this.num_insResCom.Minimum = -1000;
            this.num_insResCom.Maximum = 1000;
            this.num_insResCom.DecimalPlaces = 2;
            this.num_insResCom.Increment = 2;

            this.num_resComVal.Value = (decimal)this.projectBasicInfo.ResistanceCompensation;
            this.num_insVolCom.Value = (decimal)this.projectBasicInfo.InsulateVolCompensation;
            this.num_insResCom.Value = (decimal)this.projectBasicInfo.InsulateResCompensation;
        }

        private void ResistanceManage_Load(object sender, EventArgs e)
        {
            Init();

            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            this.projectBasicInfo.ResistanceCompensation = (double)this.num_resComVal.Value;
            this.projectBasicInfo.InsulateVolCompensation = (double)this.num_insVolCom.Value;
            this.projectBasicInfo.InsulateResCompensation = (double)this.num_insResCom.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
