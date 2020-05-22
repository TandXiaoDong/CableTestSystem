using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TCableTestLibraryManager : BaseManager<TCableTestLibrary>, ITCableTestLibraryManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITCableTestLibraryDBService dBService = new TCableTestLibraryDBService();

        public TCableTestLibraryManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
