using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Helper
{
    internal class RegexString
    {
        public static string NAME = @"^[a-zA-Z\s\W|_]+$";
        public static string EMAIL = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
    }
}
