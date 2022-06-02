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
    public partial class PayCard : Form
    {
        int orderid;
        public PayCard(int orderid)
        {
            InitializeComponent();
            this.orderid = orderid;
        }

        private void PayCard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textCartId.Text!="" && textBoxBank.Text != "")
            {
                using(var db = new QuanLyBanHang1Entities())
                {
                    var card = new OrderByCard();
                    card.order_id = orderid;
                    card.card_id = textCartId.Text;
                    card.bank = textBoxBank.Text;
                    db.OrderByCards.Add(card);
                    db.SaveChanges();
                    MessageBox.Show("OK");
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
