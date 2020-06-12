/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				DeviceFaultRecord.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月12日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类DeviceFaultRecord
    /// </summary>
    [Serializable]
    public class DeviceFaultRecord
    {
        #region 私有字段

        private long _iD = 0;
        private string _deviceFaultDate = String.Empty;
        private string _deviceFaultContent = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string DeviceFaultDate
        {
            set { this._deviceFaultDate = value; }
            get { return this._deviceFaultDate; }
        }


        public string DeviceFaultContent
        {
            set { this._deviceFaultContent = value; }
            get { return this._deviceFaultContent; }
        }



        #endregion	
    }
}
