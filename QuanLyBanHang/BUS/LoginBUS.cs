using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class LoginBUS
    {
        // Hàm tìm nhân viên
        private Employee Find(string email)
        {
            using (var p = new QuanLyBanHang1Entities())
            {
                return p.Employees.FirstOrDefault(s => s.email == email);
            }
        }
        // Hàm check tài khoản và mật khẩu của nhân viên
        public Employee CheckPerson(string email, string password)
        {
            var per = Find(email);
            if (per != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, per.e_password))
                {
                    return per;
                }
            }
            return null;
        }
    }
}
