using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TCableTestLibrary_old_20200618_1Manager : BaseManager<_TCableTestLibrary_old_20200618_1>, I_TCableTestLibrary_old_20200618_1Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_TCableTestLibrary_old_20200618_1Service service = new _TCableTestLibrary_old_20200618_1Service();

        public _TCableTestLibrary_old_20200618_1Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
