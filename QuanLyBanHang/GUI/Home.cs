using QuanLyBanHang.BUS;
using QuanLyBanHang.Models;
using QuanLyBanHang.UserController;
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
    public partial class Home : Form
    {
        private Employee emp;
        private Customer cus;
        public Home()
        {
            InitializeComponent();
        }
        public Home(Employee e)
        {
            InitializeComponent();
            this.emp = e;
        }
        // load form
        private void Home_Load(object sender, EventArgs e)
        {
            buttonProduct_Click(sender, e);
            DeleteCart();
            cus = null;
            textBoxCusphone.Text = "";
            labelCusname.Text = "no-customer";
            comboBox1.Items.Add("All");
            LoadDataBUS l = new LoadDataBUS();
            var cat = l.LoadCategory();
            foreach (var i in cat)
            {
                comboBox1.Items.Add(i.cat_name.ToString());
            }
            comboBox1.SelectedIndex = 0;
        }
        // load product
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadDataBUS l = new LoadDataBUS();
            List<Product> pro = new List<Product>();
            pro = l.LoadProduct();
            foreach (var i in pro)
            {
                flowLayoutPanel1.Controls.Add(new ProductControl(i));
            }
        }
        // load by cart
        private void LoadProductByCat(string category)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadDataBUS l = new LoadDataBUS();
            var a = l.LoadProductByCat(category);
            foreach (var i in a)
            {
                flowLayoutPanel1.Controls.Add(new ProductControl(i));
            }
        }

        private void DeleteCart()
        {
            DeleteBUS d = new DeleteBUS();
            d.DeleteCart();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var loginform = new Login();
            loginform.Show();
            this.Visible = false;
        }
        // nút tìm kiếm
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "All")
            {
                buttonProduct_Click(sender, e);
            }
            else
            {
                LoadProductByCat(comboBox1.SelectedItem.ToString());
            }
        }
        // nút giỏ hàng
        private void buttonCart_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            using (var db = new QuanLyBanHang1Entities())
            {
                int total = 0;
                var c = db.CartItems.ToList();
                foreach (var item in c)
                {
                    flowLayoutPanel1.Controls.Add(new CartControl(item));
                    total = total + (item.quantity * item.Product.unit_price);
                }

                labelTotalCart.Text = total.ToString();
            }
        }
        // nút check khách hàng
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
                        DialogResult dlr = MessageBox.Show(" 'Yes' to create a customer or 'No' to retry", "Customer", MessageBoxButtons.YesNo);
                        if (dlr == DialogResult.Yes)
                        {
                            var form = new AddCustomer(textBoxCusphone.Text);
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        cus = cusbyphone;
                        labelCusname.Text = cusbyphone.e_name;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonCart_Click(sender, e);
        }
        // nút thanh toán
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                if(db.CartItems.Count()!= 0)
                {

                    if (textBoxCusphone.Enabled == false)
                    {
                        buttonCart_Click(sender, e);
                        var form = new CheckOut(this.emp);
                        form.ShowDialog();
                    }
                    else
                    {
                        if (cus == null)
                        {
                            MessageBox.Show("can find your customer");
                        }
                        else
                        {
                            buttonCart_Click(sender, e);
                            var form = new CheckOut(this.emp, this.cus);
                            form.ShowDialog();
                        }
                    }
                }
            }
        }
        // nút reset
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxCusphone.Enabled = true;
            comboBox1.Items.Clear();
            Home_Load(sender, e);
        }
        // nút mua hàng nhanh
        private void buttonNocus_Click(object sender, EventArgs e)
        {
            textBoxCusphone.Enabled = false;
        }
        // nút trả hàng
        private void buttonGiveBack_Click(object sender, EventArgs e)
        {
            var give = new GiveBack();
            give.ShowDialog();
        }
        // nút quét mã khách hàng bằng thẻ
        private void buttonScan_Click(object sender, EventArgs e)
        {
            var form = new ScanForm();
            form.ShowDialog();
            textBoxCusphone.Text = form.code;
            textBoxCusphone.Refresh();
            buttonCheck_Click(sender, e);
        }
    }
}
