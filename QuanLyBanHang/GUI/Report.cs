using QuanLyBanHang.Entities;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Gui
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            LoadSalesByEmployeeToday();
            LoadSalesByEmplyeeMonth();
            labeldiscounttoday.Text = GetDiscountToday().ToString();
            labeldiscountthismonth.Text = GetDiscountThismonth().ToString();
        }

        //This month
        private void LoadSalesByEmplyeeMonth()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                List<EmpSale> lists = new List<EmpSale>();

                foreach (var nv in db.Employees)
                {
                    int s = CountOrderMonthLy(nv.id);
                    int t = TotalEmpMonthLY(nv.id);
                    lists.Add(new EmpSale(nv.id, nv.e_name, s, t));
                }
                var a = (from b in lists
                         select new
                         {
                             ID = b.id,
                             NAME = b.name,
                             COUNT = b.count,
                             TOTAL = b.total,
                         }
                          ).ToList();
                dataGridViewMonth.DataSource = a;
                int total = 0;
                foreach (var i in a)
                {
                    total += i.TOTAL;
                }
                labelMoth.Text = total.ToString();
            }

            labelprofitday.Text = GetProfitToDay().ToString();
            labelprofitmonth.Text = GetProfitThisMonth().ToString();
        }

        // Today

        private void LoadSalesByEmployeeToday()
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                List<EmpSale> lists = new List<EmpSale>();

                foreach(var nv in db.Employees)
                {
                    int s = CountOrder(nv.id);
                    int t = TotalEmp(nv.id);
                    lists.Add(new EmpSale(nv.id, nv.e_name, s, t));
                }
                var a = (from b in lists
                        select new { 
                        ID = b.id,
                        NAME = b.name,
                        COUNT = b.count,
                        TOTAL = b.total,
                        }
                          ).ToList();
                dataGridViewToday.DataSource = a;
                int total = 0;
                foreach(var i in a)
                {
                    total += i.TOTAL;
                }
                labelDay.Text = total.ToString();
            }
        }

        // tinh tong don hang theo id
        private int TotalOrder(int order_id)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var order_item = from i in db.OrderItems
                                 where i.order_id == order_id
                                 select i;
                int total = 0;
                foreach(var item in order_item)
                {
                    total += item.unit_price * item.quantity;
                }
                return total;
            }
        }


        // today
        private int TotalEmp(int emp_id)
        {
            int total = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                var od = from o in db.Orders
                         where o.emp_id == emp_id && o.order_date == DateTime.Today
                         select o;
                foreach(var i in od)
                {
                    total += TotalOrder(i.order_id);
                }
            }
            return total;
        }
        private int TotalEmpMonthLY(int emp_id)
        {
            int total = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                var od = from o in db.Orders
                         where o.emp_id == emp_id && o.order_date.Value.Month == DateTime.Today.Month
                         select o;
                foreach (var i in od)
                {
                    total += TotalOrder(i.order_id);
                }
            }
            return total;
        }

        private int CountOrder(int emp_id)
        {
            int count = 0;
            using(var db = new QuanLyBanHang1Entities())
            {
                var empO = from o in db.Orders
                           where o.emp_id == emp_id && o.order_date == DateTime.Today
                          select o;
                foreach(var i in empO)
                {
                    count++;
                }
            }
            return count;
        }
        private int CountOrderMonthLy(int emp_id)
        {
            int count = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                var empO = from o in db.Orders
                           where o.emp_id == emp_id && o.order_date.Value.Month == DateTime.Today.Month
                           select o;
                foreach (var i in empO)
                {
                    count++;
                }
            }
            return count;
        }

        private int GetProfitToDay()
        {
            int profit = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach(var i in db.OrderItems)
                {
                    if(i.Order.order_date == DateTime.Today)
                    {
                        profit += (int)(i.Product.unit_price - i.Product.import_price);
                    }
                }
            }
            return profit - GetDiscountToday() ;
        }
        private int GetProfitThisMonth()
        {
            int profit = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var i in db.OrderItems)
                {
                    if (i.Order.order_date.Value.Month == DateTime.Today.Month)
                    {
                        profit += (int)(i.Product.unit_price - i.Product.import_price);
                    }
                }
            }
            return profit - GetDiscountThismonth();
        }

        // get discount today
        private int GetDiscountToday()
        {
            int discount = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var i in db.Discounts)
                {
                    if (i.date_discount.Value == DateTime.Today)
                    {
                        discount =(int)i.discount1;
                    }
                }
            }
            return discount;
        }
        private int GetDiscountThismonth()
        {
            int discount = 0;
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var i in db.Discounts)
                {
                    if (i.date_discount.Value.Month == DateTime.Today.Month)
                    {
                        discount = (int)i.discount1;
                    }
                }
            }
            return discount;
        }
    }
}
