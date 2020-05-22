using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TConnectorLibraryDetailManager : BaseManager<TConnectorLibraryDetail>, ITConnectorLibraryDetailManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITConnectorLibraryDetailDBService dBService = new TConnectorLibraryDetailDBService();

        public TConnectorLibraryDetailManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
