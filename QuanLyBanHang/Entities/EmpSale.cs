using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Entities
{
    internal class EmpSale
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public EmpSale(int id, string name, int count, int total)
        {
            this.id = id;
            this.name = name;
            this.count = count;
            this.total = total;
        }

    }
}
