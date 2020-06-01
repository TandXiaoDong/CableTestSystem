/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				BaseManager.cs
 *      Description:
 *				 业务逻辑抽象基类
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月01日
 *      History:
 *      
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CableTestManager.Business
{
    using CableTestManager.Components;
    using CableTestManager.Data;
    public abstract class BaseManager<T> : IBaseManager<T>
    {
        private IBaseDBService<T> baseDBService;

        public IBaseDBService<T> BaseDBService
        {
            set { baseDBService = value; }
        }

        #region 封装数据访问层的常规数据访问方法

        public T GetById(object id)
        {
            return this.baseDBService.GetById(id);
        }

        public List<T> GetListByParam(params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.GetListByParam(values);
        }

        public List<T> GetListByParam(Dictionary<string, object> values)
        {
            return this.baseDBService.GetListByParam(values);
        }
        
        public List<T> GetListOrderByParam(string order, params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.GetListOrderByParam(order, values);
        }

        public List<T> GetListOrderByParam(string order, Dictionary<string, object> values)
        {
            return this.baseDBService.GetListOrderByParam(order, values);
        }

        public List<T> GetListByWhere(string where)
        {
            return this.baseDBService.GetListByWhere(where);
        }

        public List<T> GetListByWhereAndOrder(string where, string order)
        {
            return this.baseDBService.GetListByWhereAndOrder(where, order);
        }

        public DataSet GetDataSetByWhere(string where)
        {
            return this.baseDBService.GetDataSetByWhere(where);
        }

        public DataSet GetDataSetByFieldsAndParams(string returnFields, params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.GetDataSetByFieldsAndParams(returnFields, values);
        }

        public DataSet GetDataSetByFieldAndParams(string returnFields, Dictionary<string, object> values)
        {
            return this.baseDBService.GetDataSetByFieldAndParams(returnFields, values);
        }

        public DataSet GetDataSetByFieldsAndWhere(string returnFields, string where)
        {
            return this.baseDBService.GetDataSetByFieldsAndWhere(returnFields, where);
        }

        public List<T> GetAllList()
        {
            return this.baseDBService.GetAllList();
        }

        public List<T> GetAllListOrder(string order)
        {
            return this.baseDBService.GetAllListOrder(order);
        }

        public List<T> GetTopNListOrder(int n, string order)
        {
            return this.baseDBService.GetTopNListOrder(n, order);
        }

        public List<T> GetTopNListWhereOrder(int n, string where, string order)
        {
            return this.baseDBService.GetTopNListWhereOrder(n, where, order);
        }

        public DataSet GetAllDataSet()
        {
            return this.baseDBService.GetAllDataSet();
        }

        public PageResult<T> GetPageData(PageResult<T> pageResult)
        {
            return this.baseDBService.GetPageData(pageResult);
        }

        public DataSet GetPageDataSet(PageResult<T> pageResult)
        {
            return this.baseDBService.GetPageDataSet(pageResult);
        }
        
        public DataSet GetDataSetByStoreProcedure(string storeProcedureName, params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.GetDataSetByStoreProcedure(storeProcedureName, values);
        }

        public DataSet GetDataSetByStoreProcedure(string storeProcedureName, Dictionary<string, object> values)
        {
            return this.baseDBService.GetDataSetByStoreProcedure(storeProcedureName, values);
        }

        public int GetRowCount()
        {
            return this.baseDBService.GetRowCount();
        }

        public int GetRowCountByParams(params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.GetRowCountByParams(values);
        }

        public int GetRowCountByParams(Dictionary<string, object> values)
        {
            return this.baseDBService.GetRowCountByParams(values);
        }

        public int GetRowCountByWhere(string where)
        {
            return this.baseDBService.GetRowCountByWhere(where);
        }

        public int Insert(T entity)
        {
            return this.baseDBService.Insert(entity);
        }

        public int Update(T entity)
        {
            return this.baseDBService.Update(entity);
        }

        public int UpdateFields(string fields, string where)
        {
            return this.baseDBService.UpdateFields(fields, where);
        }

        public int UpdateFields(Dictionary<string, object> fields, Dictionary<string, object> where)
        {
            return this.baseDBService.UpdateFields(fields, where);
        }

        public int Delete(object id)
        {
            return this.baseDBService.Delete(id);
        }

        public int DeleteByIds(string columnName, string ids)
        {
            return this.baseDBService.DeleteByIds(columnName, ids);
        }

        public int DeleteByParam(params KeyValuePair<string, object>[] values)
        {
            return this.baseDBService.DeleteByParam(values);
        }

        public int DeleteByWhere(string where)
        {
            return this.baseDBService.DeleteByWhere(where);
        }

        public int ClearData()
        {
            return this.baseDBService.ClearData();
        }

        #endregion
    }
}
