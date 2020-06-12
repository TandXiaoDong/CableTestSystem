/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TesterAndSwitchStandMapRelation.cs
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
    /// ʵ����TesterAndSwitchStandMapRelation
    /// </summary>
    [Serializable]
    public class TesterAndSwitchStandMapRelation
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _testerStitchNo = String.Empty;
        private string _switchStandStitchNo = String.Empty;


        #endregion

        #region ��������


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string TesterStitchNo
        {
            set { this._testerStitchNo = value; }
            get { return this._testerStitchNo; }
        }


        public string SwitchStandStitchNo
        {
            set { this._switchStandStitchNo = value; }
            get { return this._switchStandStitchNo; }
        }



        #endregion	
    }
}
