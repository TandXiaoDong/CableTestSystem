using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Telerik.WinControls.UI;
using CableTestManager.Business.Implements;

namespace CableTestManager.Common
{
    class StudyProbCom
    {
        private static InterfaceInfoLibraryManager libraryManager = new InterfaceInfoLibraryManager();
        public static void InitMulCombox(RadMultiColumnComboBox comBox)
        {
            var data = libraryManager.GetDataSetByFieldsAndWhere("distinct InterfaceNo", "").Tables[0];

            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    comBox.EditorControl.Rows.Add(dr[0].ToString());
                }
                comBox.EditorControl.ShowColumnHeaders = false;
                comBox.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                comBox.SelectedIndex = 0;
            }
        }
    }
}
