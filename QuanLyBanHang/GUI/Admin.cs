using QuanLyBanHang.BUS;
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
    public partial class Admin : Form
    {
        string manage = "";
        public Admin()
        {
            InitializeComponent();
        }
        private void buttonCategory_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStripCatProduct;
            labeltitle.Text = "Category";
            this.manage = "Category";
            LoadDataBUS d = new LoadDataBUS();
            var cat = d.LoadCategoryAdmin();
            dataGridView1.DataSource = cat;
        }
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStripCatProduct;
            labeltitle.Text = "Product";
            this.manage = "Product";
            LoadDataBUS l = new LoadDataBUS();
            var pro = l.LoadProductAdmin();
            dataGridView1.DataSource = pro;
        }
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStripPerson;
            labeltitle.Text = "Employee";
            this.manage = "Employee";
            LoadDataBUS l = new LoadDataBUS();
            var employee = l.LoadEmployee();
            dataGridView1.DataSource = employee;

        } 
        /*
        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStripPerson;
            labeltitle.Text = "Customer";
            this.manage = "Customer";
            using (var db = new QuanLyBanHang1Entities())
            {
                var employee = (from emp in db.Customers
                                select new
                                {
                                    ID = emp.id,
                                    Name = emp.e_name,
                                    Phone = emp.phone_number,
                                }).ToList();
                dataGridView1.DataSource = employee;
            }
        }
        */
        /*
        private void buttonOrder_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            labeltitle.Text = "Order";
            this.manage = "Order";
            using (var db = new QuanLyBanHang1Entities())
            {
                var od = (from o in db.Orders
                          select new
                          {
                              id = o.order_id,
                              customer = o.Customer.e_name,
                              phone = o.Customer.phone_number,
                              order_date = o.order_date,
                          }).ToList();
                dataGridView1.DataSource = od;
            }
        }
        */

        // Sales click
        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Report();
            form.ShowDialog();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 13);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
        }


        // right click
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (labeltitle.Text == "Order")
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1)
                    {
                        contextMenuStrip1.Show();
                    }
                }
                else
                {
                    if(labeltitle.Text =="Customer" || labeltitle.Text == "Employee")
                    {
                        if (e.RowIndex != -1 && e.ColumnIndex != -1)
                        {
                            contextMenuStripPerson.Show();
                        }
                    }
                    else
                    {
                        if (e.RowIndex != -1 && e.ColumnIndex != -1)
                        {
                            contextMenuStripCatProduct.Show();
                        }
                    }
                }
            }
        }


        // add tool trip click
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (this.manage)
            {
                case "Category":
                    var formc = new AddCat();
                    formc.ShowDialog();
                    break;
                case "Product":
                    var formp = new AddProduct();
                    formp.ShowDialog();
                    break;
                default:
                    MessageBox.Show("No object selected");
                    break;

            }
        }
        // nut chang tren toolstrip
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.manage)
                {
                    case "Category":
                        string selected_cat_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        var formc = new ChangeCategory(selected_cat_id);
                        formc.ShowDialog();
                        break;
                    case "Product":
                        string selected_pro_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        var formp = new ChangeProduct(selected_pro_id);
                        formp.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("No object selected");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        // nut remove tren toolstrip Category va Product
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.manage)
                {
                    case "Category":
                        try
                        {
                            string selected_cat_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                            var formc = new RemoveCategory(selected_cat_id);
                            formc.ShowDialog();
                        }
                        catch
                        {
                            MessageBox.Show("deleting relevant data");
                        }
                
                        break;
                    case "Product":
                        try
                        {
                            string selected_pro_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                            var formp = new RemoveProduct(selected_pro_id);
                            formp.ShowDialog();
                        }
                        catch
                        {
                            MessageBox.Show("deleting relevant data");
                        }
            
                        break;
                   default:
                        MessageBox.Show("No object selected");
                        break;

                }
            }
            catch
            {
                MessageBox.Show("Fail");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Visible = false;
        }
        // nut detail tren toolstrip
        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                try
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        string order_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        var order = db.Orders.FirstOrDefault(o => o.order_id.ToString() == order_id);
                        var formDetail = new OrderDetail(order);
                        formDetail.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        // nut dang ki nhan vien, khach hang
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (manage)
            {
                case "Employee":
                    var form = new Register();
                    form.ShowDialog();
                    break;
                case "Customer":
                    var form1 = new AddCustomer();
                    form1.ShowDialog();
                    break;
                default:
                    break;
            }
        }


        // nut xoa nhan vien, khach hanng
        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (manage)
            {
                case "Employee":
                    try
                    {
                        string selected_emp_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        FindObjectBUS f = new FindObjectBUS();
                        var form1 = new RemoveEmp(f.FindEmployee(selected_emp_id));
                        form1.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("deleting relevant data");
                    }
                    break;
                case "Customer":
                    try
                    {
                        string selected_cus_id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                        FindObjectBUS f = new FindObjectBUS();
                        var form1 = new RemoveCustomer(f.FindCustomer(selected_cus_id));
                        form1.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("deleting relevant data");
                    }
        
                    break;
                default:
                    break;
            }
        }
        // nut best saler
        private void button3_Click(object sender, EventArgs e)
        {
            var form = new BestSellerForm();
            form.ShowDialog();
        }
        // nut gift cart
        private void button4_Click(object sender, EventArgs e)
        {
            var form = new GiftCard();
            form.ShowDialog();
        }
        // nut quan ly kho hang (warehouse)
        private void buttonwarehouse_Click(object sender, EventArgs e)
        {
            var form = new Warehouse();
            form.ShowDialog();
        }
    }
}
