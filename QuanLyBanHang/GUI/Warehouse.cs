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
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var products = (from p in db.Products
                                select new
                                {
                                    ID = p.pro_id,
                                    NAME = p.pro_name,
                                    STOCK = p.units_instock,
                                }).ToList();
                dataGridView1.DataSource = products;

            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    var products = (from p in db.Products
                                    orderby p.units_instock
                                    select new
                                    {
                                        ID = p.pro_id,
                                        NAME = p.pro_name,
                                        STOCK = p.units_instock,
                                    })
                                    .ToList();
                    dataGridView1.DataSource = products;

                }

            }
            if (e.ColumnIndex == 0)
            {
                using (var db = new QuanLyBanHang1Entities())
                {
                    var products = (from p in db.Products
                                    orderby p.pro_id
                                    select new
                                    {
                                        ID = p.pro_id,
                                        NAME = p.pro_name,
                                        STOCK = p.units_instock,
                                    })
                                    .ToList();
                    dataGridView1.DataSource = products;

                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string i = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            var form = new ChangeStock(i);
            form.ShowDialog();
        }
    }
}
