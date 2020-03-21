using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class DeviceFaultRecordManager : BaseManager<DeviceFaultRecord>, IDeviceFaultRecordManager
    {
		#region  Ù–‘◊¢»Î
		
        private IDeviceFaultRecordService service = new DeviceFaultRecordService();

        public DeviceFaultRecordManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
