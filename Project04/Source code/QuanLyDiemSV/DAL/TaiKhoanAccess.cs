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
    public class TaiKhoanAccess : DatabaseAccess
    {
        public string CheckLogin(TaiKhoan taikhoan)
        {
            // Kiểm tra tài khoản tồn tại và lấy thông tin tài khoản từ CSDL
            string info = CheckLoginDTO(taikhoan);

            // Kiểm tra mật khẩu nếu tài khoản tồn tại
            if (!string.IsNullOrEmpty(info))
            {
                using (var conn = SqlConnectionData.Connect())
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("proc_logic", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user", taikhoan.sTaiKhoan);
                    command.Parameters.AddWithValue("@pass", taikhoan.sMatKhau);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return info;
                        }
                        reader.Close();
                        conn.Close();
                    }
                    else
                    {
                        return "Username hoặc Password bạn vừa nhập không chính xác với CSDL!";
                    }
                }
            }

            return "Username hoặc Password bạn vừa nhập không chính xác!";
        }
    }
}
