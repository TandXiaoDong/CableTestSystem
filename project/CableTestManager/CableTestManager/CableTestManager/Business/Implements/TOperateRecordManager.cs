using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TOperateRecordManager : BaseManager<TOperateRecord>, ITOperateRecordManager
    {
		#region ����ע��
		
        private ITOperateRecordService service = new TOperateRecordService();

        public TOperateRecordManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
