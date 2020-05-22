using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class THistoryDataBasicManager : BaseManager<THistoryDataBasic>, ITHistoryDataBasicManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITHistoryDataBasicDBService dBService = new THistoryDataBasicDBService();

        public THistoryDataBasicManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
