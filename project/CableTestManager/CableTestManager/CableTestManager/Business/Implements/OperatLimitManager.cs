using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class OperatLimitManager : BaseManager<OperatLimit>, IOperatLimitManager
    {
		#region ÊôĞÔ×¢Èë
		
        private IOperatLimitService service = new OperatLimitService();

        public OperatLimitManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
