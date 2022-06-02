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
    public partial class RemoveCategory : Form
    {
        Category category;
        public RemoveCategory(string cat_id)
        {
            int id = Int32.Parse(cat_id);
            InitializeComponent();
            using (var db = new QuanLyBanHang1Entities())
            {
                category = db.Categories.FirstOrDefault(s => s.cat_id == id);
            }
        }

        private void RemoveCategory_Load(object sender, EventArgs e)
        {
            labelID.Text = category.cat_id.ToString();
            labelName.Text = category.cat_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = new DeleteBUS();
            d.DeleteCategory(category);
            MessageBox.Show("Success");
            this.Close();
        }
    }
}
