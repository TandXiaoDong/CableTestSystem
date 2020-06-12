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
		
        private ITRoleService service = new TRoleService();

        public TRoleManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
