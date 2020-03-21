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
		#region ����ע��
		
        private ITSwitchWorkWearLibraryService service = new TSwitchWorkWearLibraryService();

        public TSwitchWorkWearLibraryManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
