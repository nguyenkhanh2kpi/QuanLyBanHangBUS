using QuanLyBanHang.Gui;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.UserController
{
    public partial class ProductControl : UserControl
    {
        private Product product;
        public ProductControl()
        {
            InitializeComponent();
        }
        public ProductControl(Product product)
        {
            InitializeComponent();
            this.product = product;
            LoadProduct();
        }

        private void LoadProduct()
        {
            string path = "../../../Images/Products/" + product.product_img;
            //pictureBox1.ImageLocation = File.Exists(path) ? path : "../../Resources/no-avatar.png";
            labelProduct.Text = product.pro_name;
            //labelPrice.Text = product.unit_price.ToString();
            //labelUnit.Text = product.quantity_perUnit;
        
        }

        // create cartitem
        public CartItem CreCartItem(Product pro, int quantity)
        {
            CartItem item = new CartItem();
            item.product_id = pro.pro_id;
            item.quantity = quantity;
            item.price = pro.unit_price * quantity;
            return item;
        }


        // kiem tra neu san pham da ton tai trong gio hang thi tang quantity them 1 don vi
        private bool IsExistInCart()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                bool find = false;
                List<CartItem> cart = db.CartItems.ToList();
                foreach (var item in cart)
                {
                    if (item.product_id == this.product.pro_id)
                    {
                        if (item.quantity < item.Product.units_instock)
                        {
                            item.quantity += 1;
                        }
                        item.price = item.Product.unit_price * item.quantity;
                        find = true;
                    }
                }
                if (find)
                {
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                if (!IsExistInCart())
                {
                    if (this.product.units_instock > 0)
                    {
                        CartItem c = CreCartItem(this.product, 1);
                        db.CartItems.Add(c);
                    }
                    db.SaveChanges();
                }
            }
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            var f = new ProductDetail(product);
            f.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
