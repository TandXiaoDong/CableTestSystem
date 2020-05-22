using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TOperateRecordManager : BaseManager<TOperateRecord>, ITOperateRecordManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITOperateRecordDBService dBService = new TOperateRecordDBService();

        public TOperateRecordManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
