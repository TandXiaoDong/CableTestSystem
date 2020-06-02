/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				XmlPropertyMap.cs
 *      Description:
 *				 ����ӳ��ʵ����
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��06��02��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Components
{
    /// <summary>
    /// ����ӳ��ʵ����
    /// </summary>
    [Serializable]
    public class XmlPropertyMap
    {
        #region ˽���ֶ�

        private string propertyName;
        private string columnName;

        #endregion

        #region ���췽��

        public XmlPropertyMap() { }

        public XmlPropertyMap(string propertyName, string columnName)
        {
            this.propertyName = propertyName;
            this.columnName = columnName;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ʵ�������������
        /// </summary>
        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }
        /// <summary>
        /// ��Ӧ���������
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        #endregion
    }
}
