using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class _OperatLimit_old_20200525_1Manager : BaseManager<_OperatLimit_old_20200525_1>, I_OperatLimit_old_20200525_1Manager
    {
		#region ����ע��
		
        private I_OperatLimit_old_20200525_1DBService dBService = new _OperatLimit_old_20200525_1DBService();

        public _OperatLimit_old_20200525_1Manager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
