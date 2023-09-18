using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBAccess
    {
        protected SqlConnection _conn;
        //Chuyen doi Ket Noi hoac database
        //static string host = "";
        //static string data = "";
        //static string UserDB = "";
        //static string PassDB = "";

        public static string strProvider = @"Data Source=DESKTOP-J1U6LOE\SQLEXPRESS01;Initial Catalog=app;Integrated Security=True";

        public bool _OpenConn()
        {
            try
            {
                _conn = new SqlConnection(strProvider);
                _conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void _CloseConn()
        {
            _conn.Close();
            _conn.Dispose();
        }
        
    }
}
