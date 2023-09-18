using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrdersManagement
{
    public class ClsDB
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        private static SqlDataAdapter adapter;

        private static string strConn = @"Data Source=DESKTOP-J1U6LOE\SQLEXPRESS01;Initial Catalog=db_orders;Integrated Security=True";
        private string connectionString;

        public void ConnectDB()
        {
            if(conn.State!=ConnectionState.Open)
            {
                conn.ConnectionString = strConn;
                conn.Open();
            }
        }
        public void CloseDB()
        {
            conn.Close();
            conn.Dispose();
        }
        public void ReadData(string query, DataTable dtl)
        {
            ConnectDB();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtl);
            }
            catch (SqlException e)
            {
                throw e;
            }
            CloseDB();
        }
        public int GetResultQuery(string query)
        {
            ConnectDB();
            int rec = 0;
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                rec = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                rec = 0;
            }
            return rec;
            CloseDB();
        }
        public int GetScalar(string query)
        {
            int result = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query,connection))
                    {
                        object scalarValue = command.ExecuteScalar();
                        if(scalarValue!=null && scalarValue!=DBNull.Value)
                        {
                            result = Convert.ToInt32(scalarValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện truy vấn:" + ex.Message);
            }
            return result;
        }
    }
}