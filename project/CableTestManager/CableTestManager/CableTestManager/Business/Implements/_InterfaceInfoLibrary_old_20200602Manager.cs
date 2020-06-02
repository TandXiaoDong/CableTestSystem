using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _InterfaceInfoLibrary_old_20200602Manager : BaseManager<_InterfaceInfoLibrary_old_20200602>, I_InterfaceInfoLibrary_old_20200602Manager
    {
		#region  Ù–‘◊¢»Î
		
        private I_InterfaceInfoLibrary_old_20200602DBService dBService = new _InterfaceInfoLibrary_old_20200602DBService();

        public _InterfaceInfoLibrary_old_20200602Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
