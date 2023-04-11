using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniGame.ViewModel
{
    public class NguoiDungViewModel
    {
        public int Id { get; set; }

        public string Ten { get; set; }

        public string Ngaysinh { get; set; }

        public string Tongdiem { get; set; }

        public string Matkhau { get; set; }

        public bool? Trangthai { get; set; }
    }
}