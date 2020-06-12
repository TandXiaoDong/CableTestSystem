/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				DeviceFaultRecord.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��06��12��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����DeviceFaultRecord
    /// </summary>
    [Serializable]
    public class DeviceFaultRecord
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _deviceFaultDate = String.Empty;
        private string _deviceFaultContent = String.Empty;


        #endregion

        #region ��������


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
