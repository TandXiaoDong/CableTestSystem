using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class TesterAndSwitchStandMapRelationManager : BaseManager<TesterAndSwitchStandMapRelation>, ITesterAndSwitchStandMapRelationManager
    {
		#region  Ù–‘◊¢»Î
		
        private ITesterAndSwitchStandMapRelationService service = new TesterAndSwitchStandMapRelationService();

        public TesterAndSwitchStandMapRelationManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
