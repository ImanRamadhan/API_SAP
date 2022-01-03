using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace APIHost2Host.Helper
{
    public static class SQLAccessHelper
    {
        public static List<SqlParameter> NewParam
        {
            get { return new List<SqlParameter>(); }
        }

        public static DataTable NewDBHashtable
        {
            get
            {

                var result = new DataTable();

                result.Columns.Add("Key");
                result.Columns.Add("Value");
                result.Columns.Add("Other");

                return result.Clone();

            }
        }

        private const string c_ConnStringName = "DefaultConnectionString";
        private static string mDefaultConnStr = null;
        public static string DefaultConnStr
        {
            get
            {
                return mDefaultConnStr;
            }
            set
            {
                mDefaultConnStr = value;
            }
        }
        static SQLAccessHelper()
        {
            if (ConfigurationManager.ConnectionStrings[c_ConnStringName] != null)
            {
                mDefaultConnStr = ConfigurationManager.ConnectionStrings[c_ConnStringName].ConnectionString;
            }
        }

        // Common DB Object 
        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(mDefaultConnStr);
        }
        public static SqlConnection GetDBConnection(string ConnStrID)
        {
            if (string.IsNullOrEmpty(ConnStrID))
            {
                throw new Exception("Connection string must be specified or defined.");
            }
            else
            {
                ConnectionStringSettings ConnStr = ConfigurationManager.ConnectionStrings[ConnStrID];
                if (ConnStr == null)
                    return null;
                else
                    return new SqlConnection(ConnStr.ConnectionString);
            }
        }

        public static SqlCommand GetSqlCommand(CommandType CT, string CmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CT;
            cmd.CommandText = CmdText;
            return cmd;
        }
        public static SqlCommand GetSqlCommand(CommandType CT, string CmdText, SqlConnection DBConn)
        {
            SqlCommand cmd = GetSqlCommand(CT, CmdText);
            cmd.Connection = DBConn;
            return cmd;
        }

        // Data Access Method
        public static object DoSqlAggregateQuery(string TableName, string ColumnName, string AggSQLFunc, string ConnStrID)
        {
            using (SqlConnection conn = GetDBConnection(ConnStrID))
            {
                return DoSqlAggregateQuery(TableName, ColumnName, AggSQLFunc, conn);
            }
        }
        public static object DoSqlAggregateQuery(string TableName, string ColumnName, string AggSQLFunc)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                return DoSqlAggregateQuery(TableName, ColumnName, AggSQLFunc, conn);
            }
        }
        public static object DoSqlAggregateQuery(string TableName, string ColumnName, string AggSQLFunc, SqlConnection conn)
        {
            string SqlTxt = string.Format("SELECT {0} ({1})  as Result FROM [{2}]", AggSQLFunc, ColumnName, TableName);
            try
            {
                SqlCommand cmd = GetSqlCommand(CommandType.Text, SqlTxt, conn);
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                if (result is DBNull)
                {
                    return 0;
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                throw;
            }
            finally
            {
                // Calling Method MUST dispose their own connection
                //if (conn != null)
                //{
                //    //conn.Close();
                //    conn.Dispose();
                //}
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            //return null;
        }

        public static object DoSqlAggregateQuery(string SqlText, List<SqlParameter> parameters, string ConnStrID)
        {
            using (SqlConnection conn = GetDBConnection(ConnStrID))
            {
                return DoSqlAggregateQuery(CommandType.Text, SqlText, parameters, conn);
            }
        }
        public static object DoSqlAggregateQuery(string SqlText, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                return DoSqlAggregateQuery(CommandType.Text, SqlText, parameters, conn);
            }
        }
        public static object DoSqlAggregateQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection conn)
        {
            return DoSqlAggregateQuery(SqlType, SqlText, parameters, conn, null);
        }
        public static object DoSqlAggregateQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                SqlCommand cmd = GetSqlCommand(CommandType.Text, SqlText, conn);
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.CommandType = SqlType;
                if (trans != null)
                    cmd.Transaction = trans;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                throw;
            }
            finally
            {
                // Calling Method MUST dispose their own connection
                //if (conn != null)
                //{
                //    conn.Dispose();
                //}
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            //return null;
        }

        public static object DoSqlNonQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, string ConnStrID)
        {
            using (SqlConnection conn = GetDBConnection(ConnStrID))
            {
                return DoSqlNonQuery(SqlType, SqlText, parameters, conn);
            }
        }
        public static object DoSqlNonQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                return DoSqlNonQuery(SqlType, SqlText, parameters, conn);
            }
        }
        public static object DoSqlNonQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn)
        {
            return DoSqlNonQuery(SqlType, SqlText, parameters, Conn, -1);
        }
        public static object DoSqlNonQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn, int CommandTimeout)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = GetSqlCommand(SqlType, SqlText, Conn);
                if (CommandTimeout >= 0)
                    cmd.CommandTimeout = CommandTimeout;
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result;
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                throw;
            }
            finally
            {
                // Calling Method MUST dispose their own connection
                //if (Conn != null)
                //{
                //    Conn.Dispose();
                //}
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            //return null;
        }

        public static SqlDataReader DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                return DoSqlQuery(SqlType, SqlText, parameters, conn, -1);
            }
        }
        public static SqlDataReader DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn)
        {
            return DoSqlQuery(SqlType, SqlText, parameters, Conn, -1);
        }
        public static SqlDataReader DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn, int CommandTimeout)
        {
            try
            {
                SqlCommand cmd = GetSqlCommand(SqlType, SqlText, Conn);
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                if (CommandTimeout != -1)
                {
                    cmd.CommandTimeout = CommandTimeout;
                }
                return cmd.ExecuteReader();
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                if (Conn != null && Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                    Conn.Dispose();
                }
                // closing the connection
                throw;
            }
        }
        public static void DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, out DataTable Result)
        {
            using (SqlConnection conn = GetDBConnection())
            {
                DoSqlQuery(SqlType, SqlText, parameters, conn, out Result);
            }
        }
        public static void DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, string ConnStrID, out DataTable Result)
        {
            using (SqlConnection conn = GetDBConnection(ConnStrID))
            {
                DoSqlQuery(SqlType, SqlText, parameters, conn, out Result);
            }
        }
        public static void DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn, out DataTable Result)
        {
            DoSqlQuery(SqlType, SqlText, parameters, Conn, -1, out Result);
        }
        public static void DoSqlQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters, SqlConnection Conn, int CommandTimeout, out DataTable Result)
        {
            Result = new DataTable();
            SqlDataReader dr = DoSqlQuery(SqlType, SqlText, parameters, Conn, CommandTimeout);
            Result.Load(dr);
        }

        // Data Retrieval Method
        public static SqlDataAdapter PopulateByQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters)
        {
            SqlConnection conn = GetDBConnection();
            try
            {
                SqlCommand SelectCmd = GetSqlCommand(SqlType, SqlText, conn);
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        SelectCmd.Parameters.Add(param);
                    }
                }
                return new SqlDataAdapter(SelectCmd);
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                if (conn != null)
                {
                    conn.Dispose();
                }
                // closing the connection
                throw;
            }
        }
        public static SqlDataAdapter PopulateByTable(string TableName)
        {
            string SqlTxt = "SELECT * FROM [" + TableName + "]";
            SqlConnection conn = GetDBConnection();
            try
            {
                SqlCommand SelectCmd = GetSqlCommand(CommandType.Text, SqlTxt, conn);
                return new SqlDataAdapter(SelectCmd);
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                if (conn != null)
                {
                    conn.Dispose();
                }
                // closing the connection
                throw;
            }
        }

        public static DataTable PopulateByTableToDataTable(string TableName)
        {
            DataTable result = new DataTable();
            SqlDataAdapter da = PopulateByTable(TableName);
            da.Fill(result);
            return result;
        }

        public static DataTable PopulateByTableToDataTable(string TableName, string clause)
        {
            DataTable result = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            string SqlTxt = "SELECT * FROM [" + TableName + "] WHERE " + clause;
            SqlConnection conn = GetDBConnection();
            try
            {
                SqlCommand SelectCmd = GetSqlCommand(CommandType.Text, SqlTxt, conn);
                da = new SqlDataAdapter(SelectCmd);
                da.Fill(result);
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                if (conn != null)
                {
                    conn.Dispose();
                }
                // closing the connection
                throw;
            }


            return result;
        }

        public static bool isDataExist(string TableName, string clause)
        {
            DataTable dt = PopulateByTableToDataTable(TableName, clause);
            return (dt.Rows.Count > 0);
        }

        public static DataSet PopulateDataSetByQuery(CommandType SqlType, string SqlText, List<SqlParameter> parameters)
        {
            SqlConnection conn = GetDBConnection();
            try
            {
                DataSet ds = new DataSet();
                SqlCommand SelectCmd = GetSqlCommand(SqlType, SqlText, conn);
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        SelectCmd.Parameters.Add(param);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(SelectCmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                //(SqlException SqlEx)
                // TODO : Error handler here
                // TODO : Propagate exception back to caller
                if (conn != null)
                {
                    conn.Dispose();
                }
                // closing the connection
                throw;
            }
        }

        public static List<object> GetColumnValues(string TableName, string ColumnName, string Restrictions, bool isDistinct)
        {
            string SqlTxt = "SELECT ";
            if (isDistinct)
            {
                SqlTxt += "DISTINCT ";
            }
            SqlTxt += ((ColumnName + " FROM [") + TableName) + "]";
            if (Restrictions != "")
            {
                SqlTxt += " WHERE " + Restrictions;
            }

            List<object> alStr = new List<object>();
            using (SqlConnection conn = GetDBConnection())
            {
                SqlDataReader dr = DoSqlQuery(CommandType.Text, SqlTxt, null, conn);
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            alStr.Add(dr[0]);
                        }
                    }
                    dr.Close();
                }
            }
            return alStr;
        }
        public static List<object> GetSortedColumnValues(string TableName, string ColumnName, string Restrictions, string OrderColumn, bool isDistinct)
        {
            string SqlTxt = "SELECT";
            if (isDistinct)
            {
                SqlTxt += " DISTINCT ";
            }
            SqlTxt += ((ColumnName + " FROM [") + TableName) + "]";
            if (Restrictions != "")
            {
                SqlTxt += " WHERE " + Restrictions;
            }

            if (OrderColumn != "")
            {
                SqlTxt += " ORDER BY [" + OrderColumn + "]";
            }
            List<object> alStr = new List<object>();
            using (SqlConnection conn = GetDBConnection())
            {
                SqlDataReader dr = DoSqlQuery(CommandType.Text, SqlTxt, null, conn);
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            alStr.Add(dr[0]);
                        }
                    }
                    dr.Close();
                }
            }
            return alStr;
        }
        public static List<object> GetPKTable(string TableName)
        {
            string SqlTxt = "sp_pkeys";
            List<SqlParameter> alParams = new List<SqlParameter>();
            List<object> alStr = new List<object>();
            alParams.Add(new SqlParameter("@table_name", TableName));
            using (SqlConnection conn = GetDBConnection())
            {
                SqlDataReader dr = DoSqlQuery(CommandType.StoredProcedure, SqlTxt, alParams, conn);
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            alStr.Add("[" + dr["COLUMN_NAME"].ToString() + "]");
                        }
                    }
                    dr.Close();
                }
            }
            return alStr;
        }
        public static bool IsColumnNullable(string TableName, string ColumnName)
        {
            string SqlTxt = "sp_columns";
            bool isNullable = false;
            List<SqlParameter> alParams = new List<SqlParameter>();
            alParams.Add(new SqlParameter("@table_name", TableName));
            alParams.Add(new SqlParameter("@column_name", ColumnName));
            using (SqlConnection conn = GetDBConnection())
            {
                SqlDataReader dr = DoSqlQuery(CommandType.StoredProcedure, SqlTxt, alParams, conn);
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int nullable = Convert.ToInt16(dr["NULLABLE"]);
                        if (nullable == 0)
                        {
                            isNullable = false;
                        }
                        else
                        {
                            isNullable = true;
                        }
                    }
                    dr.Close();
                }
            }
            return isNullable;
        }

        // Miscellaneous Method 
        public static List<SqlParameter> GetParameters()
        {
            return new List<SqlParameter>();
        }
        public static SqlParameter AddParameter(List<SqlParameter> al, string paramName, object ParamValue)
        {
            SqlParameter param = new SqlParameter(paramName, ParamValue);
            al.Add(param);
            return param;
        }
        public static SqlParameter AddParameter(List<SqlParameter> al, string paramName, object ParamValue, System.Data.SqlDbType aType)
        {
            SqlParameter param = new SqlParameter(paramName, ParamValue);
            param.SqlDbType = aType;
            al.Add(param);
            return param;
        }

        // Bulk Processing
        public static bool SaveBulkDataTableToDB(string TableName, DataTable SourceTable)
        {
            return SaveBulkDataTableToDB(TableName, SourceTable, -1);
        }
        public static bool SaveBulkDataTableToDB(string TableName, DataTable SourceTable, int BulkCopyTimeout)
        {
            SqlConnection DestConn = GetDBConnection();
            try
            {
                DestConn.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(DestConn))
                {
                    s.DestinationTableName = TableName;
                    //s.BatchSize = SourceTable.Rows.Count;
                    //s.NotifyAfter = 10000;
                    if (BulkCopyTimeout != -1)
                        s.BulkCopyTimeout = BulkCopyTimeout;
                    s.WriteToServer(SourceTable);
                    s.Close();
                }
                DestConn.Close();
                return true;
            }
            catch //(Exception e)
            {
                return false;
            }
        }
    }
}
