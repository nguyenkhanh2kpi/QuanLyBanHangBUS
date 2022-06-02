using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class LoadDataBUS
    {
        // load sản phẩm
        public List<Product> LoadProduct()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var a = db.Products.ToList();
                return a;
            }
        }

        // load category
        public List<Category> LoadCategory()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var a = db.Categories.ToList();
                return a;
            }
        }
        //load product by category
        public List<Product> LoadProductByCat(string category)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var a = (from p in db.Products
                         where p.Category.cat_name.ToString() == category
                         select p).ToList();
                return a;
            }
        }
        // load giỏ hàng
        public List<CartItem> LoadCart()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var c = db.CartItems.ToList();
                return c;
            }
        }
        // load category trên admin
        public object LoadCategoryAdmin()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var cat = (from c in db.Categories
                           select new { ID = c.cat_id, Name = c.cat_name }).ToList();
                return cat;
            }
        }
        // load product cho trang admin
        public object LoadProductAdmin()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var pro = (from p in db.Products
                           select new
                           {
                               ID = p.pro_id,
                               Name = p.pro_name,
                               Stock = p.units_instock,
                               Price = p.unit_price,
                               Status = p.pro_status == "active" ? true : false
                           }).ToList();
                return pro;
            }
        }
        // load nhan vien trong admin
        public object LoadEmployee()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var employee = (from emp in db.Employees
                                select new
                                {
                                    ID = emp.id,
                                    Name = emp.e_name,
                                    Gender = emp.gender == "nam" ? "Male" : "Female",
                                    Phone = emp.phone_number,
                                    Email = emp.email,
                                    Status = emp.e_status == "active" ? true : false
                                }).ToList();
                return employee;
            }
        }
    }
}
