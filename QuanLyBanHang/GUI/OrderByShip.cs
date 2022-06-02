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
    public partial class OrderByShip : Form
    {
        int order;
        public OrderByShip(int order)
        {
            InitializeComponent();
            this.order = order;
        }

        private void OrderShip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxAddress.Text.Trim()!=null && textBoxBank.Text.Trim()!=null && textBoxCard.Text.Trim() !=null && textBoxName.Text.Trim()!=null && textBoxPhone.Text.Trim() != null)
            {
                using(var db= new QuanLyBanHang1Entities())
                {
                    var id = db.Orders.FirstOrDefault(o => o.order_id == this.order);
                    var ship = new OrderShip();
                    ship.order_id = id.order_id;
                    ship.ship_address = textBoxAddress.Text;
                    ship.ship_name = textBoxName.Text;
                    ship.ship_phone = textBoxPhone.Text;
                    ship.card_id = textBoxCard.Text;
                    ship.bank = textBoxBank.Text;
                    db.OrderShips.Add(ship);
                    db.SaveChanges();
                    MessageBox.Show("SUCESS");
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Complete information");
            }
        }
    }
}
