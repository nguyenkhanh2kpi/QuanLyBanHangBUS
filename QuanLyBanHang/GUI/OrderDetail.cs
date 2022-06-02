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
    public partial class OrderDetail : Form
    {
        private Order order;
        public OrderDetail(Order o)
        {
            InitializeComponent();
            this.order = o;
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var order_items = (from i in db.OrderItems
                                   where i.order_id == this.order.order_id
                                   select new
                                   {
                                       ID = i.item_id,
                                       Product = i.Product.pro_name,
                                       Price = i.unit_price,
                                       Quantity = i.quantity,
                                       Total = (i.unit_price * i.quantity).ToString(),
                                   }).ToList();
                dataGridView1.DataSource = order_items;
                int total = 0;
                foreach(var i in order_items)
                {
                    total += Int32.Parse(i.Total);
                }
                label1.Text = total.ToString();
            }
        }
    }
}
