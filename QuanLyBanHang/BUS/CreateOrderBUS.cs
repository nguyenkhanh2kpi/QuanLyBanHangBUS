using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class CreateOrderBUS
    {
        public Order CreateOrder(Customer customer, Employee employee, int orderrr_id)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                Order order = new Order();
                if (customer == null)
                {
                    order.cus_id = null;
                }
                else
                {
                    order.cus_id = customer.id;
                }
                order.emp_id = employee.id;
                order.order_date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                db.Orders.Add(order);
                db.SaveChanges();
                orderrr_id = order.order_id;
                return order;
            }
        }
    }
}
