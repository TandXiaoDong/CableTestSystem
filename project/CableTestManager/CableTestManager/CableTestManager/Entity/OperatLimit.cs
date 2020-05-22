/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				OperatLimit.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年05月22日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类OperatLimit
    /// </summary>
    [Serializable]
    public class OperatLimit
    {
        #region 私有字段

        private long _iD = 0;
        private string _interfaceLib_query = String.Empty;
        private string _interfaceLib_add = String.Empty;
        private string _ineterfaceLib_del = String.Empty;
        private string _interfaceLib_export = String.Empty;
        private string _cableLib_query = String.Empty;
        private string _cableLib_add = String.Empty;
        private string _cableLib_edit = String.Empty;
        private string _cableLib_del = String.Empty;
        private string _cableLib_export = String.Empty;
        private string _connectorLib_query = String.Empty;
        private string _connectorLib_del = String.Empty;
        private string _connectorLib_export = String.Empty;
        private string _connectorLib_add = String.Empty;
        private string _switchWearLib_query = String.Empty;
        private string _switchWearLib_add = String.Empty;
        private string _switchWearLib_edit = String.Empty;
        private string _switchWearLib_export = String.Empty;
        private string _switchStandLib_query = String.Empty;
        private string _switchStandLib_add = String.Empty;
        private string _switchStandLib_del = String.Empty;
        private string _switchStandLib_export = String.Empty;
        private string _project_query = String.Empty;
        private string _project_add = String.Empty;
        private string _project_del = String.Empty;
        private string _project_export = String.Empty;
        private string _historyTestData_query = String.Empty;
        private string _historyTestData_add = String.Empty;
        private string _historyTestData_edit = String.Empty;
        private string _historyTestData_export = String.Empty;
        private string _operatorRecord_query = String.Empty;
        private string _operatorRecord_del = String.Empty;
        private string _operatorRecord_export = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string InterfaceLib_query
        {
            set { this._interfaceLib_query = value; }
            get { return this._interfaceLib_query; }
        }


        public string InterfaceLib_add
        {
            set { this._interfaceLib_add = value; }
            get { return this._interfaceLib_add; }
        }


        public string IneterfaceLib_del
        {
            set { this._ineterfaceLib_del = value; }
            get { return this._ineterfaceLib_del; }
        }


        public string InterfaceLib_export
        {
            set { this._interfaceLib_export = value; }
            get { return this._interfaceLib_export; }
        }


        public string CableLib_query
        {
            set { this._cableLib_query = value; }
            get { return this._cableLib_query; }
        }


        public string CableLib_add
        {
            set { this._cableLib_add = value; }
            get { return this._cableLib_add; }
        }


        public string CableLib_edit
        {
            set { this._cableLib_edit = value; }
            get { return this._cableLib_edit; }
        }


        public string CableLib_del
        {
            set { this._cableLib_del = value; }
            get { return this._cableLib_del; }
        }


        public string CableLib_export
        {
            set { this._cableLib_export = value; }
            get { return this._cableLib_export; }
        }


        public string ConnectorLib_query
        {
            set { this._connectorLib_query = value; }
            get { return this._connectorLib_query; }
        }


        public string ConnectorLib_del
        {
            set { this._connectorLib_del = value; }
            get { return this._connectorLib_del; }
        }


        public string ConnectorLib_export
        {
            set { this._connectorLib_export = value; }
            get { return this._connectorLib_export; }
        }


        public string ConnectorLib_add
        {
            set { this._connectorLib_add = value; }
            get { return this._connectorLib_add; }
        }


        public string SwitchWearLib_query
        {
            set { this._switchWearLib_query = value; }
            get { return this._switchWearLib_query; }
        }


        public string SwitchWearLib_add
        {
            set { this._switchWearLib_add = value; }
            get { return this._switchWearLib_add; }
        }


        public string SwitchWearLib_edit
        {
            set { this._switchWearLib_edit = value; }
            get { return this._switchWearLib_edit; }
        }


        public string SwitchWearLib_export
        {
            set { this._switchWearLib_export = value; }
            get { return this._switchWearLib_export; }
        }


        public string SwitchStandLib_query
        {
            set { this._switchStandLib_query = value; }
            get { return this._switchStandLib_query; }
        }


        public string SwitchStandLib_add
        {
            set { this._switchStandLib_add = value; }
            get { return this._switchStandLib_add; }
        }


        public string SwitchStandLib_del
        {
            set { this._switchStandLib_del = value; }
            get { return this._switchStandLib_del; }
        }


        public string SwitchStandLib_export
        {
            set { this._switchStandLib_export = value; }
            get { return this._switchStandLib_export; }
        }


        public string Project_query
        {
            set { this._project_query = value; }
            get { return this._project_query; }
        }


        public string Project_add
        {
            set { this._project_add = value; }
            get { return this._project_add; }
        }


        public string Project_del
        {
            set { this._project_del = value; }
            get { return this._project_del; }
        }


        public string Project_export
        {
            set { this._project_export = value; }
            get { return this._project_export; }
        }


        public string HistoryTestData_query
        {
            set { this._historyTestData_query = value; }
            get { return this._historyTestData_query; }
        }


        public string HistoryTestData_add
        {
            set { this._historyTestData_add = value; }
            get { return this._historyTestData_add; }
        }


        public string HistoryTestData_edit
        {
            set { this._historyTestData_edit = value; }
            get { return this._historyTestData_edit; }
        }


        public string HistoryTestData_export
        {
            set { this._historyTestData_export = value; }
            get { return this._historyTestData_export; }
        }


        public string OperatorRecord_query
        {
            set { this._operatorRecord_query = value; }
            get { return this._operatorRecord_query; }
        }


        public string OperatorRecord_del
        {
            set { this._operatorRecord_del = value; }
            get { return this._operatorRecord_del; }
        }


        public string OperatorRecord_export
        {
            set { this._operatorRecord_export = value; }
            get { return this._operatorRecord_export; }
        }



        #endregion	
    }
}
