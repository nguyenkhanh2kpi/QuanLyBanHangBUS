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
    public partial class CartControl : UserControl
    {
        private CartItem cartItem;
        private Product product;
        public CartControl()
        {
            InitializeComponent();
        }
        public CartControl(CartItem item)
        {
            this.cartItem = item;
            InitializeComponent();
            LoadCartItem();
        }
        private void LoadCartItem()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                product = db.Products.FirstOrDefault(s => s.pro_id == cartItem.product_id);
                string path = "../../../Images/Products/" + product.product_img;
                pictureBox1.ImageLocation = File.Exists(path) ? path : "../../Resources/no-avatar.png";
                labelTitle.Text = product.pro_name;
                labelQuantity.Text = cartItem.quantity.ToString();
                labelPrice.Text = product.unit_price.ToString();
                labelTotal.Text = (product.unit_price * cartItem.quantity).ToString();
            }
        }
        private void pictureBoxRemove_Click_1(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                CartItem item = db.CartItems.FirstOrDefault(s => s.product_id == this.cartItem.product_id);
                try
                {
                    db.CartItems.Remove(item);
                }
                catch
                {
                    MessageBox.Show("Press 'UPDATE' to reload");
                }
                MessageBox.Show(" Press 'UPDATE' to reload");

                db.SaveChanges();
                LoadCartItem();
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (labelQuantity.Text != "0")
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    CartItem c = db.CartItems.FirstOrDefault(s => s.product_id == this.product.pro_id);
                    if (c.quantity < c.Product.units_instock)
                    {
                        c.quantity += 1;
                    }
                    db.SaveChanges();
                    labelQuantity.Text = c.quantity.ToString();
                }
            }
            else
            {
                MessageBox.Show("Your CartItem is deleted");
            }
        }

        private void buttonSub_Click_1(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                CartItem c = db.CartItems.FirstOrDefault(s => s.product_id == this.product.pro_id);
                if (c != null)
                {
                    c.quantity -= 1;
                    if (c.quantity <= 0)
                    {
                        db.CartItems.Remove(c);
                    }
                    labelQuantity.Text = c.quantity.ToString();
                }
                db.SaveChanges();
            }
        }
    }
}
