using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _TCableTestLibrary_old_20200618Manager : BaseManager<_TCableTestLibrary_old_20200618>, I_TCableTestLibrary_old_20200618Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_TCableTestLibrary_old_20200618Service service = new _TCableTestLibrary_old_20200618Service();

        public _TCableTestLibrary_old_20200618Manager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
