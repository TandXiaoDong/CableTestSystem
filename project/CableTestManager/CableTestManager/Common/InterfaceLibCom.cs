using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CableTestManager.Business.Implements;

namespace CableTestManager.Common
{
    class InterfaceLibCom
    {
        private static InterfaceInfoLibraryManager interLibManager;
        public static System.Data.DataTable data;

        public static bool IsExistDevicePoint(string pointPin)
        {
            if (interLibManager == null)
            {
                interLibManager = new InterfaceInfoLibraryManager();
            }
            if (data == null)
            {
                data = interLibManager.GetDataSetByFieldsAndWhere($"distinct SwitchStandStitchNo", "").Tables[0];
            }
            if (data.Rows.Count <= 0)
                return false;
            foreach (DataRow dr in data.Rows)
            {
                var point = dr[0].ToString();
                if (pointPin.Contains(","))//four line method
                {
                    if (point.Contains(","))
                    {
                        var pointArray = point.Split(',');
                        foreach (var val in pointArray)
                        {
                            if (pointPin.ToString() == val)
                                return true;
                        }
                    }
                }
                else//for two line method
                {
                    if (pointPin == point)
                        return true;
                }
            }
            return false;
        }
    }
}
