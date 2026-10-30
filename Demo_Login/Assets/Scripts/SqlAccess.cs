using UnityEngine;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;

public class SqlAccess
{
    //mysql连接对象
    public static MySqlConnection dbConnection;

    //默认构造函数
    public SqlAccess(string connectionString)
    {
        OpenSql(connectionString);
    }

    //打开数据库
    public void OpenSql(string connectionString)
    {
        try
        {
            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
        }
        catch (Exception e)
        {
            throw new Exception("服务器连接失败 " + e.Message.ToString());
        }
    }

    //关闭数据库
    public void CloseSql()
    {
        if (dbConnection != null)
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dbConnection = null;
        }
    }

    //读取数据
    public void ReadData(DataSet ds)
    {
        if (ds != null)
        {
            DataTable user = ds.Tables[0];
            //行列
            foreach (DataRow row in user.Rows)
            {
                foreach (DataColumn colum in user.Columns)
                {
                    Debug.Log(row[colum]);
                }
            }
        }
    }

    //执行方法
    public DataSet ExecuteQuery(string sqlString)
    {
        if (dbConnection.State == ConnectionState.Open)
        {
            //表的集合
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("SQL:" + sqlString +"/n" + e.Message.ToString());
            }
            return ds;
        }
        return null;
    }

    //创建表
    public DataSet CreateTable(string name,string[] col,string[] colType)
    {
        if (col.Length != colType.Length)
        {
            throw new Exception("columns.Length != colType.Length");
        }
        string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];
        for (int i = 1; i < col.Length; ++i)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        return ExecuteQuery(query);
    }

    //创建表 自动id
    public DataSet CreateTableAutoID(string name, string[] col, string[] colType)
    {
        if (col.Length != colType.Length)
        {
            throw new Exception("columns.Length != colType.Length");
        }
        string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0] + " NOT NULL AUTO_INCREMENT";
        for (int i = 1; i < col.Length; ++i)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ", PRIMARY KEY (" + col[0] + ")" + ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }

    //插入数据
    public DataSet InsertInto(string tableName, string[] values)
    {
        string query = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + "'" + values[i] + "'";
        }
        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }

    //向某行插入数据
    public DataSet InsertInto(string tableName,string[] col,string[] values)
    {
        if (col.Length != values.Length)
        {
            throw new Exception("columns.Length != colType.Length");
        }
        string query = "INSERT INTO " + tableName + " (" + col[0];
        for (int i = 1; i < col.Length; ++i)
        {
            query += ", " + col[i];
        }
        query += ") VALUES (" + "'" + values[0] + "'";
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + "'" + values[i] + "'";
        }
        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }

    //查询表中的所有数据
    public DataSet SelectInto(string tableName)
    {
        string query = "select * from " + " " + tableName;
        return ExecuteQuery(query);
    }

    //条件查询
    public DataSet SelectInto(string tableName, string[] items, string[] col, string[] operation, string[] values)
    {
        if (col.Length != operation.Length || operation.Length != values.Length)
        {
            throw new Exception("col.Length != operation.Length != values.Length");
        }
        string query = "SELECT " + items[0];
        for (int i = 1; i < items.Length; ++i)
        {
            query += ", " + items[i];
        }
        query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + "'" + values[0] + "' ";
        for (int i = 1; i < col.Length; ++i)
        {
            query += " AND " + col[i] + operation[i] + "'" + values[0] + "' ";
        }
        //select  * from table_1 where name pwd and '' '' ;
        Debug.Log(query);
        return ExecuteQuery(query);
    }

    //条件查询
    public DataSet SelectInto(string tableName,string tb_name,string tb_password,string name,string password)
    {
        string query = "SELECT * FROM " + tableName + " WHERE " + tb_name + "=" + "'" + name + "' " + "AND " + tb_password + "=" + "'" + password + "'";
        return ExecuteQuery(query);
    }

    //更新数据
    public DataSet UpdataInto(string tableName,string[] cols,string[] colsvalues, string[] selectkey,string[] selectvalue)
    {
        string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];
        for (int i = 1; i < colsvalues.Length; ++i)
        {
            query += ", " + cols[i] + " =" + colsvalues[i];
        }
        query += " WHERE " + selectkey + " = " + selectvalue + " ";
        Debug.Log(query);
        return ExecuteQuery(query);
    }

    //删除数据
    public DataSet DelectInto(string tableName,string[] cols,string[] colsvalues)
    {
        string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];
        for (int i = 1; i < colsvalues.Length; ++i)
        {
            query += " or " + cols[i] + " = " + colsvalues[i];
        }
        Debug.Log(query);
        return ExecuteQuery(query);
    }
}
