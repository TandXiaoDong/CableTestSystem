using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using CableTestManager.Common;
using CableTestManager.CUserManager;

namespace CableTestManager.Common
{
    class UserOperateRecord
    {
        public static void UpdateOperateRecord(string content)
        {
            TOperateRecordManager recordManager = new TOperateRecordManager();
            TOperateRecord operateRecord = new TOperateRecord();
            operateRecord.ID = TablePrimaryKey.InsertOperateRecordPID();
            operateRecord.OperateContent = content;
            operateRecord.OperateUser = LocalLogin.currentUserName;
            operateRecord.OperateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            recordManager.Insert(operateRecord);
        }
    }
}
