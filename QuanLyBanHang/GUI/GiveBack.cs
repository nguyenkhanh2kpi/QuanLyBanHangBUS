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
    public partial class GiveBack : Form
    {
        private Customer cus;
        public GiveBack()
        {
            InitializeComponent();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBoxCusphone.Text == null)
            {
                MessageBox.Show("Enter a phone number");
            }
            else
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    var cusbyphone = db.Customers.FirstOrDefault(s => s.phone_number == textBoxCusphone.Text);
                    if (cusbyphone == null)
                    {
                        MessageBox.Show("can't find your customer");
                    }
                    else
                    {
                        cus = cusbyphone;
                        labelCusname.Text = cusbyphone.e_name;
                        LoadOrder(cus);
                    }
                }
            }
        }

        private void LoadOrder(Customer customer)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var order = (from o in db.Orders
                             where o.cus_id == customer.id
                             select new
                             {
                                 ID = o.order_id,
                                 CUS_NAME = o.Customer.e_name,
                                 DATE = o.order_date,

                             }).ToList();
                dataGridViewOrder.DataSource = order;

            }
        }

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[0].Value.ToString();
            using(var db = new QuanLyBanHang1Entities())
            {
                var Order = db.Orders.FirstOrDefault(s => s.order_id.ToString() == id);
                var listDetail = (from i in db.OrderItems
                                  where i.order_id == Order.order_id
                                  select new
                                  {
                                      ID = i.item_id,
                                      PRODUCT = i.Product.pro_name,
                                      QUANTITY = i.quantity,
                                      PRICE = i.unit_price,
                                  }).ToList();
                dataGridViewDetail.DataSource = listDetail;
            }
        }

        private void GiveBackItem(OrderItem item)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var it = db.OrderItems.FirstOrDefault(i => i.item_id == item.item_id);
                ChangeStock(it);
                db.OrderItems.Remove(it);
                db.SaveChanges();
                MessageBox.Show("SUCCESS");
            }
        }

        private void ChangeStock(OrderItem item)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var pro = db.Products.FirstOrDefault(p => p.pro_id == item.product_id);
                pro.units_instock += item.quantity;
                db.SaveChanges();
            }
        }

        private void dataGridViewDetail_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    contextMenuStrip1.Show();
                }
            }
        }

        private void giveBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridViewDetail.Rows[dataGridViewOrder.CurrentRow.Index].Cells[0].Value.ToString();
            using(var db = new QuanLyBanHang1Entities())
            {
                var item = db.OrderItems.FirstOrDefault(i => i.item_id.ToString() == id);
                MessageBox.Show(item.item_id.ToString());
                GiveBackItem(item);
                
            }
        }
    }
}
