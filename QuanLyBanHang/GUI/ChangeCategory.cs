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
    public partial class ChangeCategory : Form
    {
        string category_id;
        public ChangeCategory(string id)
        {
            InitializeComponent();
            this.category_id = id;
        }

        private void ChangeCategory_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(this.category_id);
            using (var db = new QuanLyBanHang1Entities())
            {
                var cat = db.Categories.FirstOrDefault(s => s.cat_id== id);
                textBoxName.Text = cat.cat_name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(this.category_id);
            using (var db = new QuanLyBanHang1Entities())
            {
                var cat = db.Categories.FirstOrDefault(s => s.cat_id == id);
                if(textBoxName.Text == "")
                {
                    MessageBox.Show("Enter a name");
                }
                else
                {
                    if (FindCat(textBoxName.Text))
                    {
                        MessageBox.Show("Cat name is exist");
                    }
                    else
                    {
                        cat.cat_name = textBoxName.Text;
                        db.SaveChanges();
                        MessageBox.Show("Sucess");
                        this.Close();
                    }
                }
            }
        }
        private bool FindCat(string cat_name)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var c in db.Categories)
                {
                    if (c.cat_name.ToLower() == cat_name.ToLower())
                        return true;
                }
                return false;
            }
        }
    }
}
