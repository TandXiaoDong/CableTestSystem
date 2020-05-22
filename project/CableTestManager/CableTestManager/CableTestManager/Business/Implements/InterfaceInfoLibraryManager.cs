using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class InterfaceInfoLibraryManager : BaseManager<InterfaceInfoLibrary>, IInterfaceInfoLibraryManager
    {
		#region  Ù–‘◊¢»Î
		
        private IInterfaceInfoLibraryDBService dBService = new InterfaceInfoLibraryDBService();

        public InterfaceInfoLibraryManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
