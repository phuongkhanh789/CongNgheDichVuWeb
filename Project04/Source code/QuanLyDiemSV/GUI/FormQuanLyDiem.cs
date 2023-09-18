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

namespace GUI
{
    public partial class FormQuanLyDiem : Form
    {
        string strMsgQuery;
        DataTable dtl = new DataTable();
        localhost.Diem ws = new localhost.Diem();

        public FormQuanLyDiem()
        {
            InitializeComponent();
        }
        void ClearBindingData()
        {
            TxtMaSV.DataBindings.Clear();
            TxtMaMH.DataBindings.Clear();
            TxtDiem.DataBindings.Clear();
            TxtHocLuc.DataBindings.Clear();
        }
        void BindingData()
        {
            ClearBindingData();

            TxtMaSV.DataBindings.Add("Text", dgvDiem.DataSource, "MaSV");
            TxtMaMH.DataBindings.Add("Text", dgvDiem.DataSource, "MaMH");
            TxtDiem.DataBindings.Add("Text", dgvDiem.DataSource, "Diem");
            TxtHocLuc.DataBindings.Add("Text", dgvDiem.DataSource, "HocLuc");
        }
        void LoadDGVDiem()
        {
            dtl = JsonConvert.DeserializeObject<DataTable>(ws.ReadDataDiem("Diem", ""));
            dgvDiem.DataSource = dtl;
            BindingData();
        }
        private void FormQuanLyDiem_Load(object sender, EventArgs e)
        {
            LoadDGVDiem();
        }

        private void dgvDiem_Click(object sender, EventArgs e)
        {
            BindingData();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearBindingData();
            TxtMaSV.Clear();
            TxtMaMH.Clear();
            TxtDiem.Clear();
            TxtHocLuc.Clear();
         
            ClearBindingData();

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string maSV = TxtMaSV.Text.Trim();
            string maMH = TxtMaMH.Text.Trim();
            float diem = float.Parse(TxtDiem.Text.Trim());
            string hocLuc = TxtHocLuc.Text.Trim();

            strMsgQuery = ws.CreateDiem(maSV, maMH, diem, hocLuc);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVDiem();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string maSV = TxtMaSV.Text.Trim();
            string maMH = TxtMaMH.Text.Trim();
            float diem = float.Parse(TxtDiem.Text.Trim());
            string hocLuc = TxtHocLuc.Text.Trim();

            strMsgQuery = ws.UpdateDiem(maSV, maMH, diem, hocLuc);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVDiem();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string MaMH = TxtMaMH.Text.Trim(), MaSV = TxtMaSV.Text.Trim();

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá mã sinh viên: " + MaSV + " và mã môn học có Mã MH: " + MaMH + "?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strMsgQuery = ws.DeleteDiem(MaSV,MaMH);

                MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

                LoadDGVDiem();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadDGVDiem();
        }
    }
}
