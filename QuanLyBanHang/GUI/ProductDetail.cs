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

namespace QuanLyBanHang.Gui
{
    public partial class ProductDetail : Form
    {
        public ProductDetail()
        {
            InitializeComponent();
        }
        public ProductDetail(Product product)
        {
            InitializeComponent();
            using (var db = new QuanLyBanHang1Entities())
            {
                var cat = db.Categories.FirstOrDefault(c => c.cat_id == product.cat_id);

                labelCategory.Text = cat.cat_name;

            }

            string path = "../../../Images/Products/" + product.product_img;
            pictureBox1.ImageLocation = File.Exists(path) ? path : "../../Resources/no-avatar.png";
            labelTitle.Text = product.pro_name;
            labelPrice.Text = product.unit_price.ToString();
            labelStatus.Text = product.pro_status.ToString();
            labelUnitStock.Text = product.units_instock.ToString();
            labelDescrip.Text = product.decription;
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
