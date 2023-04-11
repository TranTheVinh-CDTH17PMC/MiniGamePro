using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniGame.ViewModel
{
    public class CauHoiViewModel
    {
        public int Id { get; set; }

        public string Mota { get; set; }
    
        public string CauA { get; set; }

        public string CauB { get; set; }

        public string CauC { get; set; }

        public string CauD { get; set; }

        public string DAn { get; set; }

        public string Hinhmota { get; set; }

        public string Id_Tengoi { get; set; }

        public int? Id_Goicauhoi { get; set; }

        public bool? Trangthai { get; set; }
        public int? IdNguoidung { get; set; }
    }
}