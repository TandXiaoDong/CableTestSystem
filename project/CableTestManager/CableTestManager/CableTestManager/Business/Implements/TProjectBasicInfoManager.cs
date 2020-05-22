using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TProjectBasicInfoManager : BaseManager<TProjectBasicInfo>, ITProjectBasicInfoManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITProjectBasicInfoDBService dBService = new TProjectBasicInfoDBService();

        public TProjectBasicInfoManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
