using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;

namespace CableTestManager.Common
{
    class InterfaceBasicInfo
    {
        public static InterfaceInfoLibrary QueryInterfaceLibInfo(string priID)
        {
            InterfaceInfoLibrary interfaceInfo = new InterfaceInfoLibrary();
            InterfaceInfoLibraryManager infoLibraryManager = new InterfaceInfoLibraryManager();
            var data = infoLibraryManager.GetDataSetByWhere($"where ID='{priID}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                interfaceInfo.ID = int.Parse(data.Rows[0]["ID"].ToString());
                interfaceInfo.InterfaceNo = data.Rows[0]["InterfaceNo"].ToString();
                interfaceInfo.ContactPointName = data.Rows[0]["ContactPointName"].ToString();
                interfaceInfo.SwitchStandStitchNo = data.Rows[0]["SwitchStandStitchNo"].ToString();
                interfaceInfo.ContactPoint = data.Rows[0]["ContactPoint"].ToString();
                interfaceInfo.MeasureMethod = data.Rows[0]["MeasureMethod"].ToString();
                interfaceInfo.ConnectorName = data.Rows[0]["ConnectorName"].ToString();
                interfaceInfo.Operator = data.Rows[0]["Operator"].ToString();
                interfaceInfo.Remark = data.Rows[0]["Remark"].ToString();
                interfaceInfo.UpdateDate = data.Rows[0]["UpdateDate"].ToString();
            }
            return interfaceInfo;
        }
    }
}
