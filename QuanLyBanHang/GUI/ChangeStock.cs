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
    public partial class ChangeStock : Form
    {
        string id;
        public ChangeStock(string i)
        {
            InitializeComponent();
            this.id = i;
        }

        private void ChangeStock_Load(object sender, EventArgs e)
        {
            try
            {
                int idd = Int32.Parse(id);
                using (var db = new QuanLyBanHang1Entities())
                {
                    var product = db.Products.FirstOrDefault(p => p.pro_id == idd);
                    labelName.Text = product.pro_name;
                    labelStockkk.Text = product.units_instock.ToString();
                }
            }
            catch
            {

            }

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    int idd = Int32.Parse(id);
                    var product = db.Products.FirstOrDefault(p => p.pro_id == idd);
                    product.units_instock = Int32.Parse(textBoxStock.Text) + product.units_instock;
                    db.SaveChanges();
                    MessageBox.Show("SUCCESS");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
