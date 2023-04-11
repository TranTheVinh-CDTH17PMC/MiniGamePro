namespace MiniGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XepHang")]
    public partial class XepHang
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Diem { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public int? IdNguoiDung { get; set; }

        public string IdGoiCauHoi { get; set; }

        public bool? Trangthai { get; set; }
    }
}
