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
    public partial class FormQuanLySinhVien : Form
    {
        string strMsgQuery;
        DataTable dtl = new DataTable();
        localhost.Diem ws = new localhost.Diem();

        public FormQuanLySinhVien()
        {
            InitializeComponent();
            SetButton("clear");
        }
        void ClearBindingData()
        {
            TxtMaLop.DataBindings.Clear();
            TxtMaSV.DataBindings.Clear();
            TxtHoTen.DataBindings.Clear();
            TxtNgaySinh.DataBindings.Clear();
            TxtGT.DataBindings.Clear();
            TxtDC.DataBindings.Clear();
            TxtSDT.DataBindings.Clear();
        }
        void bindingData()
        {
            ClearBindingData();

            TxtMaLop.DataBindings.Add("text", dgvSinhVien.DataSource, "MaLop");
            TxtMaSV.DataBindings.Add("text", dgvSinhVien.DataSource, "MaSV");
            TxtHoTen.DataBindings.Add("text", dgvSinhVien.DataSource, "HoTen");
            TxtNgaySinh.DataBindings.Add("text", dgvSinhVien.DataSource, "NgaySinh");
            TxtGT.DataBindings.Add("text", dgvSinhVien.DataSource, "GioiTinh");
            TxtDC.DataBindings.Add("text", dgvSinhVien.DataSource, "DiaChi");
            TxtSDT.DataBindings.Add("text", dgvSinhVien.DataSource, "SoDT");
        }

        void LoadDGVSinhVien()
        {
            dtl = JsonConvert.DeserializeObject<DataTable>(ws.ReadDataDiem("SinhVien", ""));
            dgvSinhVien.DataSource = dtl;
            bindingData();
        }
        private void FormQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDGVSinhVien();
        }

        private void dgvSinhVien_Click(object sender, EventArgs e)
        {
            SetButton("edit");
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            SetButton("clear");
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string MaSV = TxtMaSV.Text.Trim();
            string HoTen = TxtHoTen.Text.Trim();
            DateTime NgaySinh = TxtNgaySinh.Value;
            int GioiTinh = TxtGT.Text.Trim() == "Nam" ? 1 : 0;
            string DiaChi = TxtDC.Text.Trim();
            string SoDT = TxtSDT.Text.Trim();
            string MaLop = TxtMaLop.Text.Trim();

            if (string.IsNullOrEmpty(MaSV))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(HoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (NgaySinh == default(DateTime))
            {
                MessageBox.Show("Vui lòng chọn Ngày sinh", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(DiaChi))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(SoDT))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            strMsgQuery = ws.CreateSinhVien(MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, MaLop);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVSinhVien();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string MaSV = TxtMaSV.Text.Trim();
            string HoTen = TxtHoTen.Text.Trim();
            DateTime NgaySinh = TxtNgaySinh.Value; // Lấy giá trị ngày sinh từ DateTimePicker
            int GioiTinh = TxtGT.Text.Trim() == "Nam" ? 1 : 0;
            string DiaChi = TxtDC.Text.Trim();
            string SoDT = TxtSDT.Text.Trim();
            string MaLop = TxtMaLop.Text.Trim();

            strMsgQuery = ws.UpdateSinhVien(MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, MaLop);

            MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

            LoadDGVSinhVien();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string MaSV = TxtMaSV.Text.Trim();

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá sinh viên có Mã SV: " + MaSV + "?", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strMsgQuery = ws.DeleteSinhVien(MaSV);

                MessageBox.Show(strMsgQuery, "Thông báo!", MessageBoxButtons.OK);

                LoadDGVSinhVien();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadDGVSinhVien();
        }
        private void SetButton(string type)
        {
            switch (type)
            {
                case "clear":
                    BtnCreate.Enabled = true;
                    BtnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                    TxtMaLop.Enabled = true;
                    ClearForm();
                    break;
                case "edit":
                    BtnCreate.Enabled = false;
                    BtnUpdate.Enabled = true;
                    BtnDelete.Enabled = true;
                    TxtMaLop.Enabled = false;
                    break;
            }
        }

        private void ClearForm()
        {
            TxtMaLop.Text = string.Empty;
            TxtMaSV.Text = string.Empty;
            TxtHoTen.Text = string.Empty;
            TxtNgaySinh.Value = DateTime.Now;
            TxtGT.Text = string.Empty;
            TxtDC.Text = string.Empty;
            TxtSDT.Text = string.Empty;
        }
    }
}
