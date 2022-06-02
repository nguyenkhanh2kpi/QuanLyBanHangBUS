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
    public partial class RemoveEmp : Form
    {
        Employee emp;
        public RemoveEmp(Employee emp)
        {
            InitializeComponent();
            this.emp = emp;
        }

        private void RemoveEmp_Load(object sender, EventArgs e)
        {
            labelID.Text = this.emp.id.ToString();
            labelName.Text = this.emp.e_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteBUS d = new DeleteBUS();
            d.DeleteEmployee(emp);
            MessageBox.Show("SUCCESS");
            this.Close();
        }
    }
}
