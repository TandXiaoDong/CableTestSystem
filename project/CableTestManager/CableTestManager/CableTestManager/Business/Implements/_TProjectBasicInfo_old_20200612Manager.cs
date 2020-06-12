using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TProjectBasicInfo_old_20200612Manager : BaseManager<_TProjectBasicInfo_old_20200612>, I_TProjectBasicInfo_old_20200612Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_TProjectBasicInfo_old_20200612Service service = new _TProjectBasicInfo_old_20200612Service();

        public _TProjectBasicInfo_old_20200612Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
