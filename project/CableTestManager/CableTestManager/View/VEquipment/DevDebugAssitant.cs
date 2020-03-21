using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CableTestManager.View.VEquipment
{
    public partial class DevDebugAssitant : Telerik.WinControls.UI.RadForm
    {
        public DevDebugAssitant()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
        }

        private void DevDebugAssitant_Load(object sender, EventArgs e)
        {

        }
    }
}
