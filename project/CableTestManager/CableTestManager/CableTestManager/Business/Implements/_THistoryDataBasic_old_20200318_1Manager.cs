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
		
        private I_THistoryDataBasic_old_20200318_1Service service = new _THistoryDataBasic_old_20200318_1Service();

        public _THistoryDataBasic_old_20200318_1Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
