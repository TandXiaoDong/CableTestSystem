using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TProjectBasicInfoManager : BaseManager<TProjectBasicInfo>, ITProjectBasicInfoManager
    {
		#region ����ע��
		
        private ITProjectBasicInfoService service = new TProjectBasicInfoService();

        public TProjectBasicInfoManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
