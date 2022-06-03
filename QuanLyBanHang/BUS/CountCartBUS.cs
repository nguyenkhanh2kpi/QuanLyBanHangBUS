using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class CountCartBUS
    {
        public int CountCart()
        {
            using(var db = new QuanLyBanHang1Entities())
            {
                int count = db.CartItems.Count();
                return count;
            }
        }
    }
}
