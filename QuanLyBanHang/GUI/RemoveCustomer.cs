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
    public partial class RemoveCustomer : Form
    {
        Customer customer;
        public RemoveCustomer(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void RemoveCustomer_Load(object sender, EventArgs e)
        {
            labelID.Text = customer.id.ToString();
            labelName.Text = customer.e_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = new DeleteBUS();
            d.DeleteCustomer(customer);
            MessageBox.Show("SUCESS");
            this.Close();
        }
    }
}
