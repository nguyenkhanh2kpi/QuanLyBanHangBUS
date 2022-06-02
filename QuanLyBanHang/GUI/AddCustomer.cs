using QuanLyBanHang.Helper;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Gui
{
    public partial class AddCustomer : Form
    {
        string phone = null;
        public AddCustomer()
        {
            InitializeComponent();
        }
        public AddCustomer(string phone)
        {
            InitializeComponent();
            this.phone = phone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                var customer = new Customer();
                if(NameVaridate() && PhoneVaridate())
                {
                    customer.e_name = textBoxName.Text;
                    customer.regis_date = DateTime.Today;
                    customer.phone_number = textBoxPhone.Text;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    MessageBox.Show("Sucess");
                    this.Close();
                }
            }
        }

        private bool NameVaridate()
        {
            var name = textBoxName.Text;
            var match = Regex.Match(name, RegexString.NAME, RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(name))
            {
                errorProvider1.SetError(textBoxName, "Must Enter A Name");
                return false;
            }
            else if (!match.Success)
            {
                errorProvider1.SetError(textBoxName, "First Name Must Be Alphabet");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBoxName, null);
                return true;
            }
        }
        private bool PhoneVaridate()
        {
            int a;
            if (!Int32.TryParse(textBoxPhone.Text, out a))
            {
                errorProvider1.SetError(textBoxPhone, "Must Be A Phone NumBer");
                return false;
            }
            else
            {
                using(var db = new QuanLyBanHang1Entities())
                {
                    foreach(var i in db.Customers)
                    {
                        if(i.phone_number.ToString()== textBoxPhone.Text)
                        {
                            errorProvider1.SetError(textBoxPhone, "The phone number is exist");
                            return false;
                        }
                    }
                }
                errorProvider1.SetError(textBoxPhone, null);
                return true;
            }
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (this.phone!=null)
            {
                textBoxPhone.Text = phone.ToString(); 
            }
        }
    }
}
