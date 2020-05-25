using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _OperatLimit_old_20200525_5Manager : BaseManager<_OperatLimit_old_20200525_5>, I_OperatLimit_old_20200525_5Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_OperatLimit_old_20200525_5DBService dBService = new _OperatLimit_old_20200525_5DBService();

        public _OperatLimit_old_20200525_5Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
