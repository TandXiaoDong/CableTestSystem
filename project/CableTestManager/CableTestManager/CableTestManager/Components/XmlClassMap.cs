/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				XmlClassMap.cs
 *      Description:
 *				 ��ӳ��ʵ����
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��05��25��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Components
{
    /// <summary>
    /// ��ӳ��ʵ����
    /// </summary>
    [Serializable]
    public class XmlClassMap
    {
        #region ˽���ֶ�

        private string className;
        private string tableName;
        private Dictionary<string, XmlPropertyMap> properties = new Dictionary<string, XmlPropertyMap>();
        private XmlPropertyMap identity = null;
        private Dictionary<string, XmlPropertyMap> ids = new Dictionary<string, XmlPropertyMap>();
        #endregion

        #region ���췽��

        public XmlClassMap() { }

        public XmlClassMap(string className, string tableName)
        {
            this.className = className;
            this.tableName = tableName;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ����
        /// </summary>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        /// <summary>
        /// ��Ӧ�ı���
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        /// <summary>
        /// ��Ӧ������Լ���
        /// </summary>
        public Dictionary<string, XmlPropertyMap> Properties
        {
            get { return properties; }
            set { properties = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public XmlPropertyMap Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public Dictionary<string, XmlPropertyMap> Ids
        {
            get { return ids; }
            set { ids = value; }
        }
        #endregion
    }
}
