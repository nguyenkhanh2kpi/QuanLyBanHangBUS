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
using QuanLyBanHang.BUS;

namespace QuanLyBanHang.Gui
{
    public partial class AddCat : Form
    {
        Category cat = new Category();
        public AddCat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("Enter a name");
            }
            else
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    cat.cat_name = textBoxName.Text.ToString();
                    FindObjectBUS f = new FindObjectBUS();
                    if (f.FindCat(cat.cat_name) == false)
                    {
                        db.Categories.Add(cat);
                        db.SaveChanges();
                        MessageBox.Show("Sucess");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The Category Is Exist");
                    }
                }
            }

        }
    }
}
