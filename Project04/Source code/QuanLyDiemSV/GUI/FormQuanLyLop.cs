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
    public partial class FormQuanLyLop : Form
    {
        string strMsgQuery;
        DataTable dtl = new DataTable();
        localhost.Diem ws = new localhost.Diem();

        public FormQuanLyLop()
        {
            InitializeComponent();
            setButton("clear");
        }

        void ClearBindingData()
        {
            TxtMaLop.DataBindings.Clear();
            TxtTenLop.DataBindings.Clear();
        }

        void bindingData()
        {
            ClearBindingData();

            TxtMaLop.DataBindings.Add("text", dgvLop.DataSource, "MaLop");
            TxtTenLop.DataBindings.Add("text", dgvLop.DataSource, "TenLop");
        }

        void LoadDGVLop()
        {
            dtl = JsonConvert.DeserializeObject<DataTable>(ws.ReadDataDiem("Lop", ""));
            dgvLop.DataSource = dtl;
            bindingData();
        }
        private void FormQuanLyLop_Load(object sender, EventArgs e)
        {
            LoadDGVLop();
        }

        private void dgvLop_Click(object sender, EventArgs e)
        {
            setButton("edit");
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string MaLop = TxtMaLop.Text.Trim();
            string TenLop = TxtTenLop.Text.Trim();

            if (string.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(TenLop))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            strMsgQuery = ws.CreateLop(MaLop, TenLop);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVLop();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string MaLop = TxtMaLop.Text, TenLop = TxtTenLop.Text;

            strMsgQuery = ws.UpdateLop(MaLop, TenLop);
            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVLop();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string MaLop = TxtMaLop.Text;

            strMsgQuery = ws.DeleteLop(MaLop);
            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVLop();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            setButton("clear");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadDGVLop();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng form này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void setButton(string type)
        {
            if (type == "clear")
            {
                TxtMaLop.Enabled = true;
                BtnCreate.Enabled = true;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                foreach (TextBox txt in InputRef())
                    txt.Clear();
                dgvLop.ClearSelection();
            }
            else if (type == "edit")
            {
                TxtMaLop.Enabled = false;
                BtnCreate.Enabled = false;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
        }

        private IEnumerable<TextBox> InputRef()
        {
            // Trả về một danh sách TextBox để xóa nội dung
            yield return TxtMaLop;
            yield return TxtTenLop;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            string searchText = TxtFind.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng Nhập Thông Tin Cần Tìm Kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtl = JsonConvert.DeserializeObject<DataTable>(ws.ReadDataDiem("Lop", searchText));
            dgvLop.DataSource = dtl;
        }
    }
}
