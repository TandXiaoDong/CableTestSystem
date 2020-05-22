using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _THistoryDataBasic_old_20200318_1Manager : BaseManager<_THistoryDataBasic_old_20200318_1>, I_THistoryDataBasic_old_20200318_1Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_THistoryDataBasic_old_20200318_1DBService dBService = new _THistoryDataBasic_old_20200318_1DBService();

        public _THistoryDataBasic_old_20200318_1Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
