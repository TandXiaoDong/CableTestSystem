using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business.Implements
{
    using CableTestManager.Entity;
    using CableTestManager.Data.Interface;
    using CableTestManager.Data.Implements;
    using CableTestManager.Business.Interface;
    public class Sqlite_sequenceManager : BaseManager<Sqlite_sequence>, ISqlite_sequenceManager
    {
		#region  Ù–‘◊¢»Î
		
        private ISqlite_sequenceService service = new Sqlite_sequenceService();

        public Sqlite_sequenceManager()
        {
            base.BaseService = this.service;
        }
        
        #endregion
    }
}
