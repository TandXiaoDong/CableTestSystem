using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TUserManager : BaseManager<TUser>, ITUserManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITUserDBService dBService = new TUserDBService();

        public TUserManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
