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
    public partial class AddProduct : Form
    {
        private string fileName = "";
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var cats = db.Categories.ToList();
                foreach(var c in cats)
                {
                    catComboBox.Items.Add(c.cat_name);
                }
                catComboBox.SelectedIndex = 0;
            }
        }

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
            }
        }
        private void MoveFile(string fileName, string sPath)
        {
            if (!File.Exists("../../../Images/Products/" + "/" + fileName))
            {
                File.Copy(sPath,Path.Combine("../../../Images/Products/", fileName));
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
            if (!Int32.TryParse(textboxPrice.Text,out c))
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
            using(var db = new QuanLyBanHang1Entities())
            {
                c = db.Categories.FirstOrDefault(s => s.cat_name == name);
            }
            return c;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(NameVRD() && UnitVRD() && PriceVRD() && StockVRD())
            {
                Add(fileName, pictureBox1.ImageLocation);
            }
        }
        private void Add(string fileName, string filePath)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var product = new Product();
                product.pro_name = textboxName.Text;
                Category selected_cat = getCat();
                product.cat_id = selected_cat.cat_id;
                product.quantity_perUnit = textboxUnit.Text;
                product.import_price = Int32.Parse(textBoxImportPrice.Text);
                product.unit_price = Int32.Parse(textboxPrice.Text);
                product.units_instock = Int32.Parse(textboxTock.Text);
                product.pro_status = "active";
                if (fileName != "")
                {
                    product.product_img = fileName;
                    MoveFile(fileName, filePath);
                }
                product.decription = textBoxDescription.Text;
                db.Products.Add(product);
                db.SaveChanges();
                MessageBox.Show("Sucess");
                this.Close();
            }
        }
    }
}
