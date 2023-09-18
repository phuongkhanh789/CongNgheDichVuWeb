using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Holidays : DBAccess
    {
        private static string _table = "holidays";
        private static string _fields = "ID, holiday_date, holiday_name_group, holiday_name_en, holiday_name_vi, remark, updated_by, updated_date";
        private static string _fields2 = "holiday_date, holiday_name_group, holiday_name_en, holiday_name_vi, remark, updated_by, updated_date";

        public int CountAll()
        {
            var count = 0;
            if (_OpenConn())
            {
                DataTable dt = new DataTable();
                try
                {
                    var sql = "SELECT count(*) FROM " + _table + ";";
                    SqlCommand Sqlcmd = new SqlCommand(sql, _conn);
                    count = Convert.ToInt32(Sqlcmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    // xử lý lỗi tại đây
                    Console.WriteLine("Count All Data Error: ");
                    Console.WriteLine(ex.ToString());
                    return count;
                }
            }

            _CloseConn();

            return count;
        }

        

        public DataTable ReadAll(string Oder = null)
        {
            DataTable dt = new DataTable();
            if (_OpenConn())
            {

                try
                {
                    string query = "SELECT " + _fields + " FROM " + _table;
                    if (Oder != null)
                    {
                        query = "SELECT " + _fields + " FROM " + _table + "ODER BY " + Oder + "ASC";
                    }
                    Console.WriteLine("query" + query);
                    dt = ExecuteDataTable(query);
                }
                catch (Exception err)
                {
                    Console.WriteLine(" All Error");
                    Console.Write(err.ToString());
                    return dt;
                }
            }
            _CloseConn();
            return dt;
        }
        public DataTable ReadItem(string Item)
        {
            string query = "SELECT " + _fields + " FROM " + _table + " WHERE ID = '" + Item + "';";
            return ExecuteDataTable(query);
        }
        public DataTable ExecuteDataTable(string query)
        {
            DataTable dt = new DataTable();
            if(_OpenConn())
            {
                try
                {
                    SqlCommand Sqlcmd = new SqlCommand(query, _conn);
                    dt.Load(Sqlcmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
            return dt;
        }
        public string Create(HolidaysDTO Item)
        {
            string holidayDate = Item.Holiday_date != null ? Item.Holiday_date.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameGroup = Item.Holiday_name_group != null ? Item.Holiday_name_group.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameEn = Item.Holiday_name_en != null ? Item.Holiday_name_en.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameVi = Item.Holiday_name_vi != null ? Item.Holiday_name_vi.ToString().Replace("\'", "\\\'") : string.Empty;
            string remark = Item.Remark != null ? Item.Remark.ToString().Replace("\'", "\\\'") : string.Empty;
            string updatedBy = Item.Updated_by != null ? Item.Updated_by.ToString().Replace("\'", "\\\'") : string.Empty;
            string updatedDate = Item.Updated_date != null ? Item.Updated_date.ToString().Replace("\'", "\\\'") : string.Empty;

            string query = "INSERT INTO " + _table + "(" + _fields2 + ") VALUES ('"+holidayDate+"', '"+holidayNameGroup+"', '"+holidayNameEn+"', N'"+holidayNameVi+"', '"+remark+"', '"+updatedBy+"', '"+updatedDate+"')";
            Console.WriteLine("Query: " + query);
            return ExecuteNonQuery(query);
        }
        public string Update(HolidaysDTO Item)
        {
            string holidayDate = Item.Holiday_date != null ? Item.Holiday_date.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameGroup = Item.Holiday_name_group != null ? Item.Holiday_name_group.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameEn = Item.Holiday_name_en != null ? Item.Holiday_name_en.ToString().Replace("\'", "\\\'") : string.Empty;
            string holidayNameVi = Item.Holiday_name_vi != null ? Item.Holiday_name_vi.ToString().Replace("\'", "\\\'") : string.Empty;
            string remark = Item.Remark != null ? Item.Remark.ToString().Replace("\'", "\\\'") : string.Empty;
            string updatedBy = Item.Updated_by != null ? Item.Updated_by.ToString().Replace("\'", "\\\'") : string.Empty;
            string updatedDate = Item.Updated_date != null ? Item.Updated_date.ToString().Replace("\'", "\\\'") : string.Empty;

            string query = "UPDATE " + _table + " SET Holiday_date = '" + holidayDate + "', Holiday_name_group = '" + holidayNameGroup + "', Holiday_name_en = '" + holidayNameEn + "', Holiday_name_vi = N'" + holidayNameVi + "', Remark = '" + remark + "', Updated_by = '" + updatedBy + "', Updated_date = '" + updatedDate + "' WHERE ID = " + Item.ID;
            Console.WriteLine("Query: " + query);
            return ExecuteNonQuery(query);
        }
        public string Delete(int id)
        {
            string query = "DELETE FROM " + _table + " WHERE ID = " + id;
            Console.WriteLine("Query: " + query);
            return ExecuteNonQuery(query);
        }
        public DataTable Find(string keyword)
        {
            string query = "SELECT * FROM " + _table + " WHERE Holiday_name_vi LIKE '%" + keyword + "%'";
            Console.WriteLine("Query: " + query);
            return ExecuteDataTable(query);
        }
        public DataSet ExecuteDataSet(string query)
        {
            DataSet ds = new DataSet();
            if (_OpenConn())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, _conn);
                    da.Fill(ds, "result");

                }
                catch (Exception err)
                {
                    return ds;
                }
            }
            _CloseConn();
            return ds;
        }
        public SqlDataReader ExecuteDataReader(string query)
        {
            if (_OpenConn())
            {
                try
                {
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand(query, _conn);
                    dr = cmd.ExecuteReader();
                    return dr;
                }
                catch (Exception err)
                {
                    return null;
                }
            }
            _CloseConn();
            return null;
        }
        public string ExecuteNonQuery(string query)
        {
            string affected = null;
            if (_OpenConn())
            {
                //SqlTransaction trans = _conn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(query, _conn);
                    cmd.ExecuteNonQuery();

                    //trans.Commit();
                }
                catch (SqlException ex)
                {
                    //trans.Rollback();
                    affected = ex.ToString();
                }
            }

            _CloseConn();

            return affected;
        }
    }
}
