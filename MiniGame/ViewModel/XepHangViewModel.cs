using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniGame.ViewModel
{
    public class XepHangViewModel
    {
        public int Id { get; set; }

        public string Diem { get; set; }

        public int? IdNguoiDung { get; set; }

        public string IdGoiCauHoi { get; set; }

        public bool? Trangthai { get; set; }
        public string TenNguoiDung { get; set; }
    }
}