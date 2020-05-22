using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class OperatLimitManager : BaseManager<OperatLimit>, IOperatLimitManager
    {
		#region  Ù–‘◊¢»Î
		
        private IOperatLimitDBService dBService = new OperatLimitDBService();

        public OperatLimitManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
