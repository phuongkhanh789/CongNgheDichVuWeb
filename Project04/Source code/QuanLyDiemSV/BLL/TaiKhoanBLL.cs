using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess tkAccess = new TaiKhoanAccess();
        public string CheckLogin(TaiKhoan taikhoan)
        {
           if(taikhoan.sTaiKhoan == "") //Check nghiệp vụ
            {
                return "requeid_taikhoan";
            }
            if (taikhoan.sMatKhau == "") //Check nghiệp vụ
            {
                return "requeid_password";
            }
            string info = tkAccess.CheckLogin(taikhoan);
            return info;
        }
    }
}
