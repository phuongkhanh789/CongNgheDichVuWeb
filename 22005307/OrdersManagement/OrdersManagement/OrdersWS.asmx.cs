using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace OrdersManagement
{
    /// <summary>
    /// Summary description for OrdersWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrdersWS : System.Web.Services.WebService
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        ClsDB db = new ClsDB();
        DataTable dtl = new DataTable();

        [WebMethod]
        public string View()
        {
            string query = "select * from orders";
            db.ReadData(query, dtl);
            return JsonConvert.SerializeObject(dtl);
        }
        [WebMethod]
        public string Create(string order_code, string cust_code, string emp_code, DateTime order_request, DateTime order_promise, string cust_address)
        {
            string query,msg;
            int rec;
            if(order_request == DateTime.MinValue)
            {
                msg = "Ngày khách hàng yêu cầu giao hàng không hợp lệ!";
                return msg;
            }
            if (order_promise == DateTime.MinValue)
            {
                msg = "Ngày hẹn giao hàng không hợp lệ!";
                return msg;
            }
            string formattedorder_request = order_request.ToString("yyyy-MM-dd");
            string formattedorder_promise = order_promise.ToString("yyyy-MM-dd");
            query = "insert into orders values('" + order_code + "', '" + cust_code + "', '" + emp_code + "', '" + formattedorder_request + "', '" + formattedorder_promise + "',N'" + cust_address + "')";
            rec = db.GetResultQuery(query);
            if(rec ==1)
            {
                msg = "Thêm thành công!";
            }
            else
            {
                msg = "order_code không tồn tại!";
            }
            return msg;
        }
        [WebMethod]
        public string Update(string order_code, string cust_code, string emp_code, DateTime order_request, DateTime order_promise, string cust_address)
        {
            string query, msg;
            int rec;
            if (order_request == DateTime.MinValue)
            {
                msg = "Ngày khách hàng yêu cầu giao hàng không hợp lệ!";
                return msg;
            }
            if (order_promise == DateTime.MinValue)
            {
                msg = "Ngày hẹn giao hàng không hợp lệ!";
                return msg;
            }
            string formattedorder_request = order_request.ToString("yyyy-MM-dd");
            string formattedorder_promise = order_promise.ToString("yyyy-MM-dd");
            query = "update orders set cust_code = '" + cust_code + "', emp_code ='" + emp_code + "',order_request = '" + formattedorder_request + "', order_promise = '" + formattedorder_promise + "',cust_address=N'" + cust_address + "' where order_code = '" + order_code + "'";
            rec = db.GetResultQuery(query);
            if (rec == 1)
            {
                msg = "Thêm thành công!";
            }
            else
            {
                msg = "order_code không tồn tại!";
            }
            return msg;
        }
        [WebMethod]
        public string Delete(string order_code)
        {
            string query, msg;
            int rec;
            query = "delete from orders where order_code = '" + order_code + "'";
            rec = db.GetResultQuery(query);
            if (rec == 1)
            {
                msg = "Xoá thành công!";
            }
            else
            {
                msg = "order_code không tồn tại!";
            }
            return msg;
        }

    }

}
