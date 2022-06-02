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
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Gui
{
    public partial class ChangeProduct : Form
    {
        private string fileName = "";
        private int product_id;
        private Product product;
        private string catname;
        public ChangeProduct(string id)
        {
            InitializeComponent();
            this.product_id = Int32.Parse(id);
            using (var db = new QuanLyBanHang1Entities())
            {
                this.product = db.Products.FirstOrDefault(p => p.pro_id == this.product_id);
                this.catname = product.Category.cat_name;
            }
        }
        private void MoveFile(string fileName, string sPath)
        {
            if (!File.Exists("../../../Images/Products/" + "/" + fileName))
            {
                File.Copy(sPath, Path.Combine("../../../Images/Products/", fileName));
            }
        }
        // name varidate
        public bool NameVRD()
        {
            using (QuanLyBanHang1Entities db = new QuanLyBanHang1Entities())
            {
                var q1 = db.Categories.FirstOrDefault(s => s.cat_name == textboxName.Text);
                if (q1 != null)
                {
                    errorProvider1.SetError(textboxName, "This name already exist!");
                    return false;
                }
                else return true;
            }
        }
        public bool UnitVRD()
        {
            if (textboxUnit.Text == "")
            {
                errorProvider1.SetError(textboxUnit, "Enter your unit");
                return false;
            }
            else
            {
                errorProvider1.SetError(textboxUnit, null);
                return true;
            }
        }
        public bool PriceVRD()
        {
            int c;
            if (!Int32.TryParse(textboxPrice.Text, out c))
            {
                errorProvider1.SetError(textboxPrice, "Enter a number");
                return false;
            }
            else
            {
                errorProvider1.SetError(textboxUnit, null);
                return true;
            }
        }
        public bool StockVRD()
        {
            int c;
            if (!Int32.TryParse(textboxPrice.Text, out c))
            {
                errorProvider1.SetError(textboxPrice, "Enter a number");
                return false;
            }
            else
            {
                errorProvider1.SetError(textboxUnit, null);
                return true;
            }
        }
        public Category getCat()
        {
            Category c;
            string name = catComboBox.SelectedItem.ToString();
            using (var db = new QuanLyBanHang1Entities())
            {
                c = db.Categories.FirstOrDefault(s => s.cat_name == name);
            }
            return c;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (NameVRD() && UnitVRD() && PriceVRD() && StockVRD())
            {
                Change(fileName, pictureBox1.ImageLocation);
            }
        }
        private void LoadProduct()
        {
            textboxName.Text = product.pro_name;
            textboxUnit.Text = product.quantity_perUnit;
            textBoxImportPrice.Text = product.import_price.ToString();
            textboxPrice.Text = product.unit_price.ToString();
            textboxTock.Text = product.units_instock.ToString();
            product.pro_status = "active";
            pictureBox1.Image = File.Exists($"../../../Images/Products/{product.product_img}") ? Image.FromFile($"../../../Images/Products/{product.product_img}") : Properties.Resources.user__2_;
            textBoxDescription.Text = product.decription;
            catComboBox.SelectedItem = 0;
            while (catComboBox.SelectedItem.ToString() != catname)
            {
                catComboBox.SelectedIndex++;
            }
        }
        private void Change(string fileName, string filePath)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var pro = db.Products.FirstOrDefault(s => s.pro_id == product_id);
                pro.pro_name = textboxName.Text;
                Category selected_cat = getCat();
                pro.cat_id = selected_cat.cat_id;
                pro.quantity_perUnit = textboxUnit.Text;
                pro.import_price = Int32.Parse(textBoxImportPrice.Text);
                pro.unit_price = Int32.Parse(textboxPrice.Text);
                pro.units_instock = Int32.Parse(textboxTock.Text);
                pro.pro_status = "active";
                if (fileName != "")
                {
                    pro.product_img = fileName;
                    MoveFile(fileName, filePath);
                }
                pro.decription = textBoxDescription.Text;
                db.SaveChanges();
                MessageBox.Show("Sucess");
                this.Close();
            }
        }
        private void ChangeProduct_Load(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var cats = db.Categories.ToList();
                foreach (var c in cats)
                {
                    catComboBox.Items.Add(c.cat_name);
                }
                catComboBox.SelectedIndex = 0;
            }
            LoadProduct();
        }
        // brow
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif";
            dlg.Title = "Select Photo";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dlg.FileName;
                fileName = dlg.SafeFileName;
                MessageBox.Show(fileName);
            }
        }
        private void addButton_Click_1(object sender, EventArgs e)
        {
            if (NameVRD() && UnitVRD() && PriceVRD() && StockVRD())
            {
                Change(fileName, pictureBox1.ImageLocation);
            }

        }
    }
}
