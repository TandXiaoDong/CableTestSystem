using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Entity;
using CableTestManager.Model;

namespace CableTestManager.View
{
    public partial class FrmEnvironmentParams : Telerik.WinControls.UI.RadForm
    {
        //public double temperature;
        //public double ambientHumidity;
        private TProjectBasicInfo basicInfo;
        private DeviceConfig devConfig;
        public FrmEnvironmentParams(TProjectBasicInfo info, DeviceConfig config)
        {
            InitializeComponent();
            this.basicInfo = info;
            this.devConfig = config;
        }

        private void FrmEnvironmentParams_Load(object sender, EventArgs e)
        {
            this.tb_temperature.Text = this.devConfig.Temperature.ToString();
            this.tb_ambientHumidity.Text = this.devConfig.Humidity.ToString();

            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            if (this.tb_temperature.Text.Trim() == "")
            {
                MessageBox.Show("环境温度不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.tb_ambientHumidity.Text.Trim() == "")
            {
                MessageBox.Show("环境湿度不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double cTemperature;
            double cAmbientHumidity;
            if (!double.TryParse(this.tb_temperature.Text.Trim(), out cTemperature))
            {
                MessageBox.Show("请设置正确的环境温度！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cTemperature < 0 || cTemperature > 50)
            {
                MessageBox.Show("环境温度取值范围不正确，请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(this.tb_ambientHumidity.Text.Trim(), out cAmbientHumidity))
            {
                MessageBox.Show("请设置正确的环境湿度！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cAmbientHumidity < 20 || cAmbientHumidity > 85)
            {
                MessageBox.Show("环境湿度取值范围不正确，请重新设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.basicInfo.Temperature = cTemperature;
            this.basicInfo.AmbientHumidity = cAmbientHumidity;
            this.devConfig.Temperature = cTemperature;
            this.devConfig.Humidity = cAmbientHumidity;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
