using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class FuncLimitManager : BaseManager<FuncLimit>, IFuncLimitManager
    {
		#region  Ù–‘◊¢»Î
		
        private IFuncLimitDBService dBService = new FuncLimitDBService();

        public FuncLimitManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
