using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _FuncLimit_old_20200522Manager : BaseManager<_FuncLimit_old_20200522>, I_FuncLimit_old_20200522Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_FuncLimit_old_20200522DBService dBService = new _FuncLimit_old_20200522DBService();

        public _FuncLimit_old_20200522Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
