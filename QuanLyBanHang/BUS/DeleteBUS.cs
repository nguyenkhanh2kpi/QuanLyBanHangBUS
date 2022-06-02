using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class DeleteBUS
    {
        // Xóa khách hàng
        public void DeleteCustomer(Customer customer)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var listorder = (from p in db.Orders
                                 where p.cus_id == customer.id
                                 select p).ToList();
                foreach (var i in listorder)
                {
                    DeleteOrder(i);
                }
                var cus = db.Customers.FirstOrDefault(p => p.id == customer.id);
                db.Customers.Remove(cus);
                db.SaveChanges();
            }
        }
        // Xóa nhân viên
        public void DeleteEmployee(Employee employee)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var listorder = (from p in db.Orders
                                 where p.emp_id == employee.id
                                 select p).ToList();
                foreach (var i in listorder)
                {
                    DeleteOrder(i);
                }
                var emp = db.Employees.FirstOrDefault(p => p.id == employee.id);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
        // Xóa đơn hàng
        public void DeleteOrder(Order order)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var listItem = (from i in db.OrderItems
                                where i.order_id == order.order_id
                                select i).ToList();
                foreach (var d in listItem)
                {
                    DeleteOrderItem(d);
                }
                var ode = db.Orders.FirstOrDefault(o => o.order_id == order.order_id);
                db.Orders.Remove(ode);
                db.SaveChanges();
            }

        }
        // Xóa item
        public void DeleteOrderItem(OrderItem item)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var pro = db.OrderItems.FirstOrDefault(p => p.item_id == item.item_id);
                db.OrderItems.Remove(pro);
                db.SaveChanges();
            }
        }
        // Xóa sản phẩm
        public void DeleteProduct(Product product)
        {

            DeleteCart();
            using (var db = new QuanLyBanHang1Entities())
            {
                var listItem = (from i in db.OrderItems
                                where i.product_id == product.pro_id
                                select i).ToList();
                foreach (var d in listItem)
                {
                    DeleteOrderItem(d);
                }
                var pro = db.Products.FirstOrDefault(p => p.pro_id == product.pro_id);
                db.Products.Remove(pro);
                db.SaveChanges();
            }
        }
        // Xóa category
        public void DeleteCategory(Category category)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var procat = (from p in db.Products
                              where p.cat_id == category.cat_id
                              select p).ToList();
                foreach (var i in procat)
                {
                    DeleteProduct(i);
                }
                var cat = db.Categories.FirstOrDefault(p => p.cat_id == category.cat_id);
                db.Categories.Remove(cat);
                db.SaveChanges();
            }
        }
        // Xóa giỏ hàng
        public void DeleteCart()
        {
            using (var q = new QuanLyBanHang1Entities())
            {
                foreach (var item in q.CartItems)
                {
                    q.CartItems.Remove(item);
                }
                q.SaveChanges();
            }
        }
    }
}
