using QuanLyBanHang.BUS;
using QuanLyBanHang.Helper;
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
    public partial class RemoveProduct : Form
    {
        Product product;
        public RemoveProduct(string pro)
        {
            InitializeComponent();
            using (var db = new QuanLyBanHang1Entities())
            {
                this.product = db.Products.FirstOrDefault(p => p.pro_id.ToString() == pro);

            }
        }

        private void RemoveProduct_Load(object sender, EventArgs e)
        {
            labelID.Text = product.pro_id.ToString();
            labelName.Text = product.pro_name;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var d = new DeleteBUS();
            d.DeleteProduct(product);
            MessageBox.Show("Sucess");
            this.Close();
        }
    }
}
