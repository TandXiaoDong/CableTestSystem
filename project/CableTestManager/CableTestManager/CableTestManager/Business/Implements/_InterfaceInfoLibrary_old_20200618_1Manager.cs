using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _InterfaceInfoLibrary_old_20200618_1Manager : BaseManager<_InterfaceInfoLibrary_old_20200618_1>, I_InterfaceInfoLibrary_old_20200618_1Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_InterfaceInfoLibrary_old_20200618_1Service service = new _InterfaceInfoLibrary_old_20200618_1Service();

        public _InterfaceInfoLibrary_old_20200618_1Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
