using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _OperatLimit_old_20200525_4Manager : BaseManager<_OperatLimit_old_20200525_4>, I_OperatLimit_old_20200525_4Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_OperatLimit_old_20200525_4DBService dBService = new _OperatLimit_old_20200525_4DBService();

        public _OperatLimit_old_20200525_4Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
