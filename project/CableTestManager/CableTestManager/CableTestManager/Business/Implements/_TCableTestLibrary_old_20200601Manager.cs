using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TCableTestLibrary_old_20200601Manager : BaseManager<_TCableTestLibrary_old_20200601>, I_TCableTestLibrary_old_20200601Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_TCableTestLibrary_old_20200601DBService dBService = new _TCableTestLibrary_old_20200601DBService();

        public _TCableTestLibrary_old_20200601Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
