using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CableTestManager.Business.Implements;

namespace CableTestManager.Common
{
    class TablePrimaryKey
    {
        public static long InsertDevFaultRecordPID()
        {
            long id = -1;
            DeviceFaultRecordManager objManager = new DeviceFaultRecordManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertInterfaceLibPID()
        {
            long id = -1;
            InterfaceInfoLibraryManager objManager = new InterfaceInfoLibraryManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertCableLibPID()
        {
            long id = -1;
            TCableTestLibraryManager objManager = new TCableTestLibraryManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertConnectorLibPID()
        {
            long id = -1;
            TConnectorLibraryManager objManager = new TConnectorLibraryManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertTesterAndSwitcherMapPID()
        {
            long id = -1;
            TesterAndSwitchStandMapRelationManager objManager = new TesterAndSwitchStandMapRelationManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertHistoryDetailPID()
        {
            long id = -1;
            THistoryDataDetailManager objManager = new THistoryDataDetailManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertHistoryBasicPID()
        {
            long id = -1;
            THistoryDataDetailManager objManager = new THistoryDataDetailManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertOperateRecordPID()
        {
            long id = -1;
            TOperateRecordManager objManager = new TOperateRecordManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertProjectBInfoPID()
        {
            long id = -1;
            TProjectBasicInfoManager objManager = new TProjectBasicInfoManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertSwitchWorkLibPID()
        {
            long id = -1;
            TSwitchWorkWearLibraryManager objManager = new TSwitchWorkWearLibraryManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertRolePID()
        {
            long id = -1;
            TRoleManager objManager = new TRoleManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertFuncLimitPID()
        {
            long id = -1;
            FuncLimitManager objManager = new FuncLimitManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }

        public static long InsertOperateLimitPID()
        {
            long id = -1;
            OperatLimitManager objManager = new OperatLimitManager();
            var dt = objManager.GetDataSetByWhere("order by ID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return 0;
            if (long.TryParse(dt.Rows[0]["ID"].ToString(), out id))
                return id + 1;
            return id;
        }
    }
}
