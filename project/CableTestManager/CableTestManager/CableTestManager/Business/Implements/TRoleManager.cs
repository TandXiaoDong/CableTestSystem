using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TRoleManager : BaseManager<TRole>, ITRoleManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITRoleDBService dBService = new TRoleDBService();

        public TRoleManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
