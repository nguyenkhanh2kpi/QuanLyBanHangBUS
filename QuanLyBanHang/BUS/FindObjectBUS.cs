using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class FindObjectBUS
    {
        // tim nhan vien
        public Employee FindEmployee(string selected_emp_id)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var employee = db.Employees.FirstOrDefault(emp => emp.id.ToString() == selected_emp_id);
                return employee;    
            }
        }
        // tim khach hanng
        public Customer FindCustomer(string selected_cus)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var customer = db.Customers.FirstOrDefault(emp => emp.id.ToString() == selected_cus);
                return customer;
            }
        }
        // Tim Category neu ton tai
        public bool FindCat(string cat_name)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var c in db.Categories)
                {
                    if (c.cat_name.ToLower() == cat_name.ToLower())
                        return true;
                }
                return false;
            }
        }
    }
}
