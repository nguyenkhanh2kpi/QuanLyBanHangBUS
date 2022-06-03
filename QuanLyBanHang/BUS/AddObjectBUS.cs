using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class AddObjectBUS
    {
        public void AddCart(Product product)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                if (product == null)
                {
                    return;
                }
                CartItem cartItem = new CartItem();
                cartItem = (from q in db.CartItems
                            where q.product_id == product.pro_id
                            select q).FirstOrDefault();

                if (cartItem == null)
                {
                    cartItem = new CartItem();
                    cartItem.product_id = Convert.ToInt32(product.pro_id);
                    cartItem.price = product.unit_price;
                    cartItem.quantity = 1;
                    db.CartItems.Add(cartItem);
                    db.SaveChanges();

                }

                else if (cartItem != null)
                {
                    cartItem.quantity++;
                    cartItem.price += product.unit_price;
                    db.SaveChanges();
                }

                return;
            }
        }
    }
}
