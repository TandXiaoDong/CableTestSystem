using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TSwitchWorkWearLibraryManager : BaseManager<TSwitchWorkWearLibrary>, ITSwitchWorkWearLibraryManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITSwitchWorkWearLibraryDBService dBService = new TSwitchWorkWearLibraryDBService();

        public TSwitchWorkWearLibraryManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
