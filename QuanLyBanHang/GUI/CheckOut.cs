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
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using QuanLyBanHang.BUS;

namespace QuanLyBanHang.Gui
{
    public partial class CheckOut : Form
    {
        // các biến toàn cục
        private Employee employee;
        private Customer customer;
        private int  orderrr_id;
        private Order thisorder;
        private int totalbill = 0;
        private CustomerRank cusRank = new CustomerRank();
        public CheckOut(Employee emp, Customer cus)
        {
            InitializeComponent();
            this.employee = emp;
            this.customer = cus;
        }
        public CheckOut(Employee emp)
        {
            InitializeComponent();
            this.employee = emp;
            this.customer = null;
        }

        // Xác định khách hàng thuộc loại vàng bạc hay đồng
        public CustomerRank LoadOrCreateCusRank()
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                if(customer != null)
                {
                    var cr = db.CustomerRanks.FirstOrDefault(r => r.cus_id == customer.id);
                    if (cr != null)
                    {
                        if (cr.reward >= 20)
                        {
                            checkBoxGold.Checked = true;
                        }
                        else if (cr.reward >= 15 && cr.reward < 20)
                        {
                            checkBoxSilver.Checked = true;
                        }
                        else
                        {
                            checkBoxBronze.Checked = true;
                        }
                        return cr;
                    }
                    else
                    {
                        var crr = new CustomerRank();
                        crr.cus_id = customer.id;
                        crr.reward = 0;
                        db.CustomerRanks.Add(crr);
                        db.SaveChanges();
                        return crr;
                    }
                }
                return null;
            }
        }

        // Load form check out
        private void CheckOut_Load(object sender, EventArgs e)
        {
            CountCartBUS index = new CountCartBUS();
            if(index.CountCart() == 0)
            {
                MessageBox.Show("Your cart is empty");
                this.Close();
            }
            else
            {
                LoadOrCreateCusRank();
                this.thisorder = CreateOrder();
                comboBoxPayment.SelectedIndex = 0;
                buttonOrder.Enabled = false;
                using (var db = new QuanLyBanHang1Entities())
                {
                    int total = 0;
                    if (db.CartItems.Count() == 0)
                    {
                        buttonOrder.Enabled = false;
                    }
                    foreach (var i in db.CartItems)
                    {
                        total = total + ((int)i.quantity * (int)i.price);
                    }
                    dataGridView1.DataSource = db.CartItems.Select(a => new
                    {
                        Name = a.Product.pro_name,
                        Quantity = a.quantity,
                        Price = a.price,
                        Total = a.quantity * a.price,
                    }).ToList();
                    if (customer != null)
                    {
                        textBoxCusName.Text = customer.e_name;
                        textBoxCusPhone.Text = customer.phone_number.ToString();
                    }
                    labelTotal.Text = total.ToString();
                }
            }
        }


        private void buttonOrder_Click(object sender, EventArgs e)
        {
            var order = thisorder;
            using (var db = new QuanLyBanHang1Entities())
            {
                var cartitems = db.CartItems.ToList();
                foreach (var item in cartitems)
                {
                    var i = AddItem(order, item);
                    db.OrderItems.Add(i);
                    ChangeStock(item.Product, item.quantity);
                }
            }
            RemoveCart();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "bill";
            saveFile.Filter = "Excel (*.xlsx)|*.xlsx ";
            saveFile.FileName = "C:/Users/KHANH/OneDrive/Desktop/DeTaiWinF/git-remake/QuanLyBanHang/bills/" + "order_" + order.order_id.ToString() + ".xlsx";
            ExportExcel(saveFile.FileName);
            MessageBox.Show("SUCCESS");
            Reward(customer, totalbill);
            RememberDiscount();
            this.Close();
        }

        // Lưu lại các discount trong ngày
        public void RememberDiscount()
        {
            // remember discount
            using (var db = new QuanLyBanHang1Entities())
            {
                var discount = db.Discounts.FirstOrDefault(d => d.date_discount == DateTime.Today);
                if (discount != null)
                {
                    discount.discount1 += Int32.Parse(labeldiscount.Text) + Int32.Parse(textBoxGiftCart.Text);
                }
                else
                {
                    Discount disc = new Discount();
                    disc.date_discount = DateTime.Today;
                    disc.discount1 = 0;
                    disc.discount1 += Int32.Parse(labeldiscount.Text) + Int32.Parse(textBoxGiftCart.Text);
                    db.Discounts.Add(disc);
                }
                db.SaveChanges();
            }
        }

        // Thay đổi giỏ hàng
        private void ChangeStock(Product product, int quantity)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var p = db.Products.FirstOrDefault(s => s.pro_id == product.pro_id);
                p.units_instock = p.units_instock - quantity;
                db.SaveChanges();
            }
        }
        // xóa giỏ hàng
        private void RemoveCart()
        {
            DeleteBUS d = new DeleteBUS();
            d.DeleteCart();
        }

        private Order CreateOrder()
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
                this.orderrr_id = order.order_id;
                return order;
            }
        }
        private OrderItem AddItem(Order oder, CartItem cartitem)
        {
            OrderItem oitem = new OrderItem();
            using (var db = new QuanLyBanHang1Entities())
            {
                oitem.order_id = oder.order_id;
                oitem.product_id = cartitem.product_id;
                oitem.unit_price = cartitem.Product.unit_price;
                oitem.quantity = cartitem.quantity;
                db.OrderItems.Add(oitem);
                db.SaveChanges();
            }
            return oitem;
        }

        private void ExportExcel(string path)
        {
            int total = 0;
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            for(int i=0; i < dataGridView1.Rows.Count; i++)
            {
                for(int j=0; j<dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
                total =total + Int32.Parse(dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count-1].Value.ToString());
            }
            application.Cells[dataGridView1.Rows.Count+3, dataGridView1.Columns.Count-2] = "Total";
            application.Cells[dataGridView1.Rows.Count + 3, dataGridView1.Columns.Count - 1] = total;

            application.Cells[dataGridView1.Rows.Count + 4, dataGridView1.Columns.Count - 2] = "Discount";
            application.Cells[dataGridView1.Rows.Count + 4, dataGridView1.Columns.Count - 1] = Int32.Parse(labeldiscount.Text) + Int32.Parse(textBoxGiftCart.Text);

            application.Cells[dataGridView1.Rows.Count + 5, dataGridView1.Columns.Count - 2] = "Last Total";
            application.Cells[dataGridView1.Rows.Count + 5, dataGridView1.Columns.Count - 1] = total -  Int32.Parse(labeldiscount.Text) - Int32.Parse(textBoxGiftCart.Text);
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
            totalbill = total;
        }




        private void Reward(Customer customer, int bill)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                if (customer != null)
                {
                    var cure = db.CustomerRanks.FirstOrDefault(c => c.cus_id == customer.id);
                    if (bill >= 500000)
                    {
                        cure.reward += 5;
                    }
                    else if (bill >= 300000 && bill < 500000)
                    {
                        cure.reward += 3;
                    }
                    db.SaveChanges();
                }
            }
        }
        


        // ok click

        private void button1_Click(object sender, EventArgs e)
        {
         
            switch (comboBoxPayment.SelectedIndex)
            {
                case 0:
                    buttonOrder.Enabled = true;
                    break;
                case 1:
                    var card = new PayCard(this.orderrr_id);
                    card.ShowDialog();
                    buttonOrder.Enabled = true;
                    break;
                case 2:
                    var ship = new OrderByShip(this.orderrr_id);
                    ship.ShowDialog();
                    buttonOrder.Enabled = true;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(labeldiscount.Text == "")
            {
                if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                {
                    int total = Int32.Parse(labelTotal.Text);
                    if (total > 400000)
                    {
                        total = total - 50000;
                        labelTotal.Text = total.ToString();
                        labeldiscount.Text = 50000.ToString();
                        
                    }
                }
            }
   
        }

        private void buttonGiftCart_Click(object sender, EventArgs e)
        {
            try
            {
                int total = Int32.Parse(labelTotal.Text);
                total = total - Int32.Parse(textBoxGiftCart.Text);
                labelTotal.Text = total.ToString();
            }
            catch
            {
                MessageBox.Show("Enter a number");
            }
    
        }
    }
}
