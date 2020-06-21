using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TCableTestLibrary_old_20200621Manager : BaseManager<_TCableTestLibrary_old_20200621>, I_TCableTestLibrary_old_20200621Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_TCableTestLibrary_old_20200621Service service = new _TCableTestLibrary_old_20200621Service();

        public _TCableTestLibrary_old_20200621Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
