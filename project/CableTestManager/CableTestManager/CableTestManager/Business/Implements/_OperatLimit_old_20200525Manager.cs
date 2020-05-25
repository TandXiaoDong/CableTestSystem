using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _OperatLimit_old_20200525Manager : BaseManager<_OperatLimit_old_20200525>, I_OperatLimit_old_20200525Manager
    {
		#region ÊôĞÔ×¢Èë
		
        private I_OperatLimit_old_20200525DBService dBService = new _OperatLimit_old_20200525DBService();

        public _OperatLimit_old_20200525Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
