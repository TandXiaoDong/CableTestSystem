using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.ControlCommon;

namespace CableTestManager.View.VEquipment
{
    public partial class DevSelfCheck : Telerik.WinControls.UI.RadForm
    {
        public DevSelfCheck()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,2);
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView2,false,true,2);
        }
    }
}
