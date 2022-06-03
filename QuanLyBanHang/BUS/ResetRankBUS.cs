using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class ResetRankBUS
    {
        // reset mỗi tháng
        public void resetEachMonth()
        {
            DateTime datereset = new DateTime(DateTime.Today.Year, DateTime.Today.Month,1);
            if (DateTime.Now ==datereset)
            {
                resetRank();
            }
        }
        // reset rank
        public void resetRank()
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                foreach (var i in db.CustomerRanks)
                {
                    db.CustomerRanks.Remove(i);
                }
                db.SaveChanges();
            }
        }
    }
}
