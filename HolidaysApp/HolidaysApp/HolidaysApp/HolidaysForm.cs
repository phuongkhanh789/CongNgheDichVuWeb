using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace HolidaysApp
{
    public partial class HolidaysForm : Form
    {
        HolidaysBUS HoBUS = new HolidaysBUS();
        HolidaysDTO HoDTO = new HolidaysDTO();
        private HolidaysDTO holidayId;

        public HolidaysForm()
        {
            InitializeComponent();
        }

        private void HolidaysForm_Load(object sender, EventArgs e)
        {
            DgvHolidays.DataSource = HoBUS.ReadAll();
            // Làm mờ TextBox "Id" và "Updated_date"
            TxtId.Enabled = false;
            TxtUpdatedDate.Enabled = false;
        }
        private void LoadDataFromDataGridViewToTextBoxes()
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (DgvHolidays.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = DgvHolidays.SelectedRows[0];

                // Gán giá trị từ các ô vào các TextBox tương ứng
                TxtId.Text = selectedRow.Cells["Id"].Value.ToString();
                TxtHolidayDate.Text = selectedRow.Cells["Holiday_date"].Value.ToString();
                TxtHolidayNameGroup.Text = selectedRow.Cells["Holiday_name_group"].Value.ToString();
                TxtHolidayNameEn.Text = selectedRow.Cells["Holiday_name_en"].Value.ToString();
                TxtHolidayNameVi.Text = selectedRow.Cells["Holiday_name_vi"].Value.ToString();
                TxtRemark.Text = selectedRow.Cells["Remark"].Value.ToString();
                TxtUpdatedBy.Text = selectedRow.Cells["Updated_by"].Value.ToString();
                TxtUpdatedDate.Text = selectedRow.Cells["Updated_date"].Value.ToString();
            }
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var holiday_date = TxtHolidayDate.Text;

            // Kiểm tra ngày lễ không được để trống
            if (string.IsNullOrEmpty(holiday_date))
            {
                MessageBox.Show("Vui lòng nhập ngày lễ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng ngày hợp lệ
            if (!DateTime.TryParse(holiday_date, out DateTime parsedDate))
            {
                MessageBox.Show("Ngày lễ không hợp lệ. Vui lòng nhập ngày theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gán dữ liệu vào DTO và thực hiện tạo ngày lễ mới
            HoDTO.Holiday_date = TxtHolidayDate.Text;
            HoDTO.Holiday_name_group = TxtHolidayNameGroup.Text;
            HoDTO.Holiday_name_en = TxtHolidayNameEn.Text;
            HoDTO.Holiday_name_vi = TxtHolidayNameVi.Text;
            HoDTO.Remark = TxtRemark.Text;
            HoDTO.Updated_by = TxtUpdatedBy.Text;
            HoDTO.Updated_date = parsedDate;

            string result = HoBUS.Create(HoDTO);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn đã thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvHolidays_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataFromDataGridViewToTextBoxes();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (DgvHolidays.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = DgvHolidays.SelectedRows[0];

                // Lấy giá trị của cột ID từ hàng được chọn
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                // Gọi phương thức Delete từ lớp HolidaysBUS để xóa ngày lễ
                string result = HoBUS.Delete(id);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Bạn đã xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nạp lại dữ liệu từ cơ sở dữ liệu vào DataGridView
                    DgvHolidays.DataSource = HoBUS.ReadAll();

                    // Xóa dữ liệu trong các TextBox
                    TxtId.Text = "";
                    TxtHolidayDate.Text = "";
                    TxtHolidayNameGroup.Text = "";
                    TxtHolidayNameEn.Text = "";
                    TxtHolidayNameVi.Text = "";
                    TxtRemark.Text = "";
                    TxtUpdatedBy.Text = "";
                    TxtUpdatedDate.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày lễ để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (DgvHolidays.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = DgvHolidays.SelectedRows[0];

                // Lấy giá trị của cột ID từ hàng được chọn
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                // Gán dữ liệu vào DTO và thực hiện cập nhật ngày lễ
                HoDTO.ID = id;
                HoDTO.Holiday_date = TxtHolidayDate.Text;
                HoDTO.Holiday_name_group = TxtHolidayNameGroup.Text;
                HoDTO.Holiday_name_en = TxtHolidayNameEn.Text;
                HoDTO.Holiday_name_vi = TxtHolidayNameVi.Text;
                HoDTO.Remark = TxtRemark.Text;
                HoDTO.Updated_by = TxtUpdatedBy.Text;
                HoDTO.Updated_date = DateTime.Now;

                string result = HoBUS.Update(HoDTO);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nạp lại dữ liệu từ cơ sở dữ liệu vào DataGridView
                    DgvHolidays.DataSource = HoBUS.ReadAll();

                    // Xóa dữ liệu trong các TextBox
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày lễ để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            TxtId.Text = "";
            TxtHolidayDate.Text = "";
            TxtHolidayNameGroup.Text = "";
            TxtHolidayNameEn.Text = "";
            TxtHolidayNameVi.Text = "";
            TxtRemark.Text = "";
            TxtUpdatedBy.Text = "";
            TxtUpdatedDate.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = TxtFind.Text;

            HolidaysBUS holidaysBUS = new HolidaysBUS();
            DataTable searchResults = holidaysBUS.Find(keyword);

            if (searchResults.Rows.Count > 0)
            {
                DgvHolidays.DataSource = searchResults;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
