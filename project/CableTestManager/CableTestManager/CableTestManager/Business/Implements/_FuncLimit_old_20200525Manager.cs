using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _FuncLimit_old_20200525Manager : BaseManager<_FuncLimit_old_20200525>, I_FuncLimit_old_20200525Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_FuncLimit_old_20200525DBService dBService = new _FuncLimit_old_20200525DBService();

        public _FuncLimit_old_20200525Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
