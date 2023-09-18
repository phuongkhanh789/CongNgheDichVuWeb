using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersApp
{
    public partial class OrdersForm : Form
    {
        string strMsgQuery;
        DataTable dtl = new DataTable();
        localhost.OrdersWS ws = new localhost.OrdersWS();

        public OrdersForm()
        {
            InitializeComponent();
            AppView();
            dgvOrders.CellClick += dgvOrders_CellClick;
            if(dgvOrders.Rows.Count > 0)
            {
                DataGridViewRow firstRow = dgvOrders.Rows[0];
                TxtOrderCode.Text = firstRow.Cells["order_code"].Value.ToString();
                TxtCustomerCode.Text = firstRow.Cells["cust_code"].Value.ToString();
                TxtEmployeeCode.Text = firstRow.Cells["emp_code"].Value.ToString();
                TxtOrderRequest.Text = firstRow.Cells["order_request"].Value.ToString();
                TxtOrderPromise.Text = firstRow.Cells["order_promise"].Value.ToString();
                TxtCustomerAdd.Text = firstRow.Cells["cust_address"].Value.ToString();
            }
        }
        void ClearBindingData()
        {
            TxtOrderCode.DataBindings.Clear();
            TxtCustomerCode.DataBindings.Clear();
            TxtEmployeeCode.DataBindings.Clear();
            TxtOrderRequest.DataBindings.Clear();
            TxtOrderPromise.DataBindings.Clear();
            TxtCustomerAdd.DataBindings.Clear();
        }
        void bindingData()
        {
            ClearBindingData();
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];
                TxtOrderCode.Text = selectedRow.Cells["order_code"].Value.ToString();
                TxtCustomerCode.Text = selectedRow.Cells["cust_code"].Value.ToString();
                TxtEmployeeCode.Text = selectedRow.Cells["emp_code"].Value.ToString();
                TxtOrderRequest.Text = selectedRow.Cells["order_request"].Value.ToString();
                TxtOrderPromise.Text = selectedRow.Cells["order_promise"].Value.ToString();
                TxtCustomerAdd.Text = selectedRow.Cells["cust_address"].Value.ToString();
            }

        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            AppView();
        }
        private void AppView()
        {
            try
            {
                string jsonResult = ws.View();
                dtl = JsonConvert.DeserializeObject<DataTable>(jsonResult);
                dgvOrders.DataSource = dtl;
                bindingData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:" + ex.Message);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0 && e.RowIndex < dgvOrders.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = dgvOrders.Rows[e.RowIndex];
                TxtOrderCode.Text = selectedRow.Cells["order_code"].Value.ToString();
                TxtCustomerCode.Text = selectedRow.Cells["cust_code"].Value.ToString();
                TxtEmployeeCode.Text = selectedRow.Cells["emp_code"].Value.ToString();
                TxtOrderRequest.Text = selectedRow.Cells["order_request"].Value.ToString();
                TxtOrderPromise.Text = selectedRow.Cells["order_promise"].Value.ToString();
                TxtCustomerAdd.Text = selectedRow.Cells["cust_address"].Value.ToString();
            }
        }
        private void AppCreate(string order_code, string cust_code, string emp_code, DateTime order_request, DateTime order_promise, string cust_address)
        {
            try
            {
                strMsgQuery = ws.Create(order_code, cust_code, emp_code, order_request, order_promise, cust_address);
                MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);
                AppView();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:"+ex.Message);
            }
        }

        //private void BtnCreate_Click(object sender, EventArgs e)
        //{
        //    string order_code = TxtOrderCode.Text.Trim();
        //    string cust_code = TxtCustomerCode.Text.Trim();
        //    string emp_code = TxtEmployeeCode.Text.Trim();
        //    DateTime order_request = TxtOrderRequest.Text.Trim();
        //    string order_promise = TxtOrderPromise.Text.Trim();
        //    string cust_address = TxtCustomerAdd.Text.Trim();
        //    if(string.IsNullOrEmpty(order_code))
        //    {
        //        MessageBox.Show("Vui lòng nhập order_code","Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(cust_code))
        //    {
        //        MessageBox.Show("Vui lòng nhập cust_code", "Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(emp_code))
        //    {
        //        MessageBox.Show("Vui lòng nhập emp_code", "Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(order_request))
        //    {
        //        MessageBox.Show("Vui lòng nhập order_request ", "Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(order_promise))
        //    {
        //        MessageBox.Show("Vui lòng nhập order_promise ", "Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(cust_address))
        //    {
        //        MessageBox.Show("Vui lòng nhập cust_address ", "Thông báo!", MessageBoxButtons.OK);
        //        return;
        //    }
        //    AppCreate(order_code, cust_code, emp_code, order_request, order_promise, cust_address);
        //}
    }
}
