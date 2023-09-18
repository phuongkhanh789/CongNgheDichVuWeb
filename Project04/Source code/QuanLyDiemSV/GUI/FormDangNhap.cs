using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.sTaiKhoan = TxtUsername.Text;
            taikhoan.sMatKhau = TxtPassword.Text;
            string getuser = TKBLL.CheckLogin(taikhoan);

            // Trả lại kết quả nếu không đúng
            switch (getuser)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Username không được để trống !");
                    return;
                case "requeid_password":
                    MessageBox.Show("Password không được để trống !");
                    return;
                case "Username hoặc Password bạn vừa nhập không chính xác với CSDL!":
                    MessageBox.Show("Username hoặc Password bạn vừa nhập không chính xác với CSDL!");
                    return;
            }

            // Hiển thị thông báo đăng nhập thành công và chuyển đến trang chủ
            MessageBox.Show("Bạn đã đăng nhập vào hệ thống thành công !");
            FormHome formTrangChu = new FormHome();
            formTrangChu.Show();
            this.Hide();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
