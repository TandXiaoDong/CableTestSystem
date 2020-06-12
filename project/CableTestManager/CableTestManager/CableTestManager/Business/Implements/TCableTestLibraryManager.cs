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
		
        private ITCableTestLibraryService service = new TCableTestLibraryService();

        public TCableTestLibraryManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
