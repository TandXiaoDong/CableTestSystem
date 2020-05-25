using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TRole_old_20200525Manager : BaseManager<_TRole_old_20200525>, I_TRole_old_20200525Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_TRole_old_20200525DBService dBService = new _TRole_old_20200525DBService();

        public _TRole_old_20200525Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
