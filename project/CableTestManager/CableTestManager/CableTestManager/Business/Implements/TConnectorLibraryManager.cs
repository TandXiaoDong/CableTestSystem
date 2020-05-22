using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TConnectorLibraryManager : BaseManager<TConnectorLibrary>, ITConnectorLibraryManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITConnectorLibraryDBService dBService = new TConnectorLibraryDBService();

        public TConnectorLibraryManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
