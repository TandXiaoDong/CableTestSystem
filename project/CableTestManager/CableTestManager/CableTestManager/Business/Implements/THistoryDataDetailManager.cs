using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class THistoryDataDetailManager : BaseManager<THistoryDataDetail>, ITHistoryDataDetailManager
    {
		#region ����ע��
		
        private ITHistoryDataDetailService service = new THistoryDataDetailService();

        public THistoryDataDetailManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
