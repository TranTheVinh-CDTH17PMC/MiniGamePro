using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniGame.ViewModel
{
    public class GoiCauHoiViewModel
    {
        public int Id { get; set; }

        public string Tengoi { get; set; }

        public string IdTengoi { get; set; }

        public int? IdNguoidung { get; set; }

        public bool? Trangthai { get; set; }
    }
}