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
    public partial class FormQuanLyMonHoc : Form
    {
        string strMsgQuery;
        DataTable dtl = new DataTable();
        localhost.Diem ws = new localhost.Diem();

        public FormQuanLyMonHoc()
        {
            InitializeComponent();
            setButton("clear");
        }
        void ClearBindingData()
        {
            TxtMaMH.DataBindings.Clear();
            TxtTenMH.DataBindings.Clear();
            TxtSoTiet.DataBindings.Clear();
            TxtTenGV.DataBindings.Clear();
            TxtHocKy.DataBindings.Clear();
            TxtMaLop.DataBindings.Clear();
        }

        void bindingData()
        {
            ClearBindingData();

            TxtMaMH.DataBindings.Add("Text", dgvMonHoc.DataSource, "MaMH");
            TxtTenMH.DataBindings.Add("Text", dgvMonHoc.DataSource, "TenMH");
            TxtSoTiet.DataBindings.Add("Text", dgvMonHoc.DataSource, "SoTiet");
            TxtTenGV.DataBindings.Add("Text", dgvMonHoc.DataSource, "TenGV");
            TxtHocKy.DataBindings.Add("Text", dgvMonHoc.DataSource, "HocKy");
            TxtMaLop.DataBindings.Add("Text", dgvMonHoc.DataSource, "MaLop");
        }
        void LoadDGVMonHoc()
        {
            dtl = JsonConvert.DeserializeObject<DataTable>(ws.ReadDataDiem("MonHoc", ""));
            dgvMonHoc.DataSource = dtl;
            bindingData();
        }
        private void FormQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LoadDGVMonHoc();
        }

        private void dgvMonHoc_Click(object sender, EventArgs e)
        {
            setButton("edit");
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            setButton("clear");
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string MaMH = TxtMaMH.Text.Trim();
            string TenMH = TxtTenMH.Text.Trim();
            int SoTiet;
            string TenGV = TxtTenGV.Text.Trim();
            string HocKy = TxtHocKy.Text.Trim();
            string MaLop = TxtMaLop.Text.Trim();

            if (string.IsNullOrEmpty(MaMH))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(TenMH))
            {
                MessageBox.Show("Vui lòng nhập Tên môn học", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            if (!int.TryParse(TxtSoTiet.Text.Trim(), out SoTiet))
            {
                MessageBox.Show("Số tiết phải là một số nguyên.", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(TenGV))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(HocKy))
            {
                MessageBox.Show("Vui lòng nhập học kỳ", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            strMsgQuery = ws.CreateMonHoc(MaMH, TenMH, SoTiet, TenGV, HocKy, MaLop);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVMonHoc();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string MaMH = TxtMaMH.Text.Trim();
            string TenMH = TxtTenMH.Text.Trim();
            int SoTiet = int.Parse(TxtSoTiet.Text.Trim());
            string TenGV = TxtTenGV.Text.Trim();
            string HocKy = TxtHocKy.Text.Trim();
            string MaLop = TxtMaLop.Text.Trim();

            strMsgQuery = ws.UpdateMonHoc(MaMH, TenMH, SoTiet, TenGV, HocKy, MaLop);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVMonHoc();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string MaMH = TxtMaMH.Text.Trim();

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá môn học có Mã MH: " + MaMH + "?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strMsgQuery = ws.DeleteMonHoc(MaMH);

                MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

                LoadDGVMonHoc();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng form này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadDGVMonHoc();
        }
        private void setButton(string type)
        {
            if (type == "clear")
            {
                TxtMaMH.Enabled = true;
                BtnCreate.Enabled = true;
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
                foreach (TextBox txt in InputRef())
                    txt.Clear();
                dgvMonHoc.ClearSelection();
            }
            else if (type == "edit")
            {
                TxtMaMH.Enabled = false;
                BtnCreate.Enabled = false;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
        }

        private IEnumerable<TextBox> InputRef()
        {
            // Trả về một danh sách TextBox để xóa nội dung
            yield return TxtMaMH;
            yield return TxtTenMH;
            yield return TxtSoTiet;
            yield return TxtTenGV;
            yield return TxtHocKy;
            yield return TxtMaLop;
        }
    }
}
