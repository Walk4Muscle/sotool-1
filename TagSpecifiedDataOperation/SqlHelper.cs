using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;

namespace TagSpecifiedDataOperation
{
    public static class SqlHelper
    {
        /// <summary>
        /// SQL connection string
        /// </summary>
        
        public static readonly string strConn = ConfigurationManager.AppSettings["standardConnection"].ToString();
        //@"data source=10.168.177.13;Initial Catalog=StackOverFlowDevDB;uid=sa; pwd=Password01!";
        //public static readonly string strConn = @"data source=CN-WILLSHAO-W10/SQLSERVER2016;database=StackOverFlowDevDB; uid=sa; pwd=52Beeery1314";
        /// <summary>
        /// SQL ExecuteNonQuery
        /// </summary>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// SQL Get Datatable
        /// </summary>
        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                DataTable dt = new DataTable();

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }

                return dt;
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}