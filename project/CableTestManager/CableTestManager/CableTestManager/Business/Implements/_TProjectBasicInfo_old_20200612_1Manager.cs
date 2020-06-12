using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TProjectBasicInfo_old_20200612_1Manager : BaseManager<_TProjectBasicInfo_old_20200612_1>, I_TProjectBasicInfo_old_20200612_1Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_TProjectBasicInfo_old_20200612_1Service service = new _TProjectBasicInfo_old_20200612_1Service();

        public _TProjectBasicInfo_old_20200612_1Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
