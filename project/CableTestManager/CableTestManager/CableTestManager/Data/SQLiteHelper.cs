/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				SQLiteHelper.cs
 *      Description:
 *				 SQL数据访问辅助类
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月21日
 *      History:
 *      
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace CableTestManager.Data
{
    /// <summary>
    /// SQLite数据访问辅助类
    /// </summary>
    public class SQLiteHelper
{
        public static readonly string CONSTR = "Data Source=cabledata.db;Version=3;Password=abc12320200624..";//Password=abc12320200624..
                                                                                     //public static readonly string CONSTR = ConfigurationManager.ConnectionStrings["SQLiteString"].ConnectionString;

        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回连接对象</returns>
        private static SQLiteConnection CreateConnection(string connectionString)
    {
        SQLiteConnection con = new SQLiteConnection(connectionString);
            //con.SetPassword("abc12320200624..");
        con.Open();
            //con.ChangePassword("abc12320200624..");//加密
        return con;
    }
    /// <summary>
    /// 执行增删改的辅助方法
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdText">要执行的SQL语句或存储过程名</param>
    /// <param name="values">SQL语句中的参数</param>
    /// <returns>返回收影响的行数</returns>
    public static int ExecuteCommand(string connectionString, CommandType cmdType, string cmdText, SQLiteParameter[] values)
    {
        using (SQLiteConnection con = CreateConnection(connectionString))
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            if (values != null && values.Length > 0) cmd.Parameters.AddRange(values);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

	
        /// <summary>
        /// 执行增删改的辅助方法
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">要执行的SQL语句或存储过程名</param>
        /// <param name="values">SQL语句中的参数</param>
        /// <returns>返回收影响的行数</returns>
        public static int ExecuteCommand(string connectionString, CommandType cmdType, List<string> cmdTextList, SQLiteParameter[] values)
        {
            using (SQLiteConnection con = CreateConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = con;
                cmd.CommandType = cmdType;
                var sqlTransact = con.BeginTransaction();
                int result = 0;
                foreach (var cmdText in cmdTextList)
                {
                    cmd.CommandText = cmdText;
                    if (values != null && values.Length > 0) cmd.Parameters.AddRange(values);
                    result += cmd.ExecuteNonQuery();
                }
                sqlTransact.Commit();
                con.Close();
                return result;
            }
        }


    /// <summary>
    /// 执行查询的方法
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdText">要执行的SQL语句或存储过程名</param>
    /// <param name="values">SQL语句中的参数</param>
    /// <returns>返回数据读取器对象</returns>
    public static SQLiteDataReader GetReader(string connectionString, CommandType cmdType, string cmdText, SQLiteParameter[] values)
    {
        SQLiteConnection con = CreateConnection(connectionString);
        SQLiteCommand cmd = new SQLiteCommand();
        cmd.Connection = con;
        cmd.CommandType = cmdType;
        cmd.CommandText = cmdText;
        if (values != null && values.Length > 0) cmd.Parameters.AddRange(values);
        SQLiteDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    /// <summary>
    /// 执行带聚合函数的查询方法
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdText">要执行的SQL语句或存储过程名</param>
    /// <param name="values">SQL语句中的参数</param>
    /// <returns>返回执行结果中第一行第一列的值</returns>
    public static object GetScalar(string connectionString, CommandType cmdType, string cmdText, SQLiteParameter[] values)
    {
        using (SQLiteConnection con = CreateConnection(connectionString))
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            if (values != null && values.Length > 0) cmd.Parameters.AddRange(values);
            object result = cmd.ExecuteScalar();
            con.Close();
            return result;
        }
    }
    /// <summary>
    /// 执行查询的方法，返回数据集
    /// </summary>
    /// <param name="connectionString">数据库连接字符串</param>
    /// <param name="cmdType">命令类型</param>
    /// <param name="cmdText">要执行的SQL语句或存储过程名</param>
    /// <param name="values">SQL语句或存储过程的参数列表</param>
    /// <returns>返回相应的数据集</returns>
    public static DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, SQLiteParameter[] values)
    {
        using (SQLiteConnection con = new SQLiteConnection(connectionString))
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            adapter.SelectCommand = new SQLiteCommand();
            adapter.SelectCommand.Connection = con;
            adapter.SelectCommand.CommandType = cmdType;
            adapter.SelectCommand.CommandText = cmdText;
            if (values != null && values.Length > 0) adapter.SelectCommand.Parameters.AddRange(values);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
    }
}
}
