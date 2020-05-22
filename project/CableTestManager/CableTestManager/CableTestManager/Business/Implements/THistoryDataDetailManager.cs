using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class THistoryDataDetailManager : BaseManager<THistoryDataDetail>, ITHistoryDataDetailManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITHistoryDataDetailDBService dBService = new THistoryDataDetailDBService();

        public THistoryDataDetailManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
