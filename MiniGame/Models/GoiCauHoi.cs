namespace MiniGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoiCauHoi")]
    public partial class GoiCauHoi
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Tengoi { get; set; }

        [StringLength(50)]
        public string IdTengoi { get; set; }

        public int? IdNguoidung { get; set; }

        public bool? Trangthai { get; set; }
    }
}
