using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Gui
{
    public partial class BestSellerForm : Form
    {
        public BestSellerForm()
        {
            InitializeComponent();
        }
        private void BesteSellerForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = "";
        }
        //San pham ban nhieu nhat toan thoi gian
        private void buttonBest_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                int choice = CheckRankingBoard();
                if (choice == 0) MessageBox.Show("Please choose a Ranking Board");
                else
                {
                    if (choice == 1) labelTitle.Text = "Best Selling Product";
                    if (choice == 5) labelTitle.Text = "Top 5 Selling Product";
                    if (choice == 10) labelTitle.Text = "Top 10 Selling Product";
                    var query = (from p in db.Products
                                 let totalQuantity = (from op in db.OrderItems
                                                      where op.product_id == p.pro_id
                                                      select op.quantity).Sum()
                                 where totalQuantity >= 0
                                 orderby totalQuantity descending
                                 select new
                                 {
                                     Id = p.pro_id,
                                     Name = p.pro_name,
                                     Category = p.Category.cat_name,
                                     Price = p.unit_price,
                                     TotalSold = totalQuantity,
                                 }).Take(choice).ToList();
                    dataGridView1.DataSource = query;
                }
                
            }
        }
        //San pham ban nhieu nhat trong khoang thoi gian tu chon
        private void buttonChosedTime_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var date1 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                var date2 = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
                int choice = CheckRankingBoard();
                if (choice == 0) MessageBox.Show("Please choose a Ranking Board");
                else
                {
                    if (choice == 1) labelTitle.Text = "Best Selling Product";
                    if (choice == 5) labelTitle.Text = "Top 5 Selling Product";
                    if (choice == 10) labelTitle.Text = "Top 10 Selling Product";
                    var query = (from p in db.Products
                                 let totalQuantity = (from op in db.OrderItems
                                                      join o in db.Orders on op.order_id equals o.order_id
                                                      where op.product_id == p.pro_id && o.order_date >= date1 && o.order_date <= date2
                                                      select op.quantity).Sum()
                                 where totalQuantity >= 0
                                 orderby totalQuantity descending
                                 select new
                                 {
                                     Id = p.pro_id,
                                     Name = p.pro_name,
                                     Category = p.Category.cat_name,
                                     Price = p.unit_price,
                                     TotalSold = totalQuantity,
                                 }).Take(choice).ToList();
                    dataGridView1.DataSource = query;
                }
                
            }
        }
        public int CheckRankingBoard()
        {
            if (comboBox1.Text == "Best-selling Product")
                return 1;
            else
            {
                if (comboBox1.Text == "Top 5 selling Product")
                    return 5;
                else
                {
                    if (comboBox1.Text == "Top 10 selling Product")
                        return 10;
                    else
                        return 0;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string productid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                using (var db = new QuanLyBanHang1Entities())
                {

                    var product = db.Products.FirstOrDefault(s => s.pro_id.ToString() == productid);
                    var product_detail = (from i in db.Products
                                          where i.pro_id == product.pro_id
                                          select new
                                          {
                                              Id = i.pro_id,
                                              Name = i.pro_name,
                                              Category = i.Category.cat_name,
                                              Measurement = i.quantity_perUnit,
                                              Stock = i.units_instock,
                                              Price = i.unit_price,
                                              Status = i.pro_status
                                          }).ToList();
                    dataGridView2.DataSource = product_detail;
                }
                
            }
        }
    }
}
