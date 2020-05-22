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
		
        private ISqlite_sequenceDBService dBService = new Sqlite_sequenceDBService();

        public Sqlite_sequenceManager()
        {
            base.BaseDBService = this.dBService;
        }
        
        #endregion
    }
}
