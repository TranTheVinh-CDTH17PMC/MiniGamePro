namespace MiniGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string Ngaysinh { get; set; }

        [StringLength(50)]
        public string Tongdiem { get; set; }

        [StringLength(50)]
        public string Matkhau { get; set; }

        public bool? Trangthai { get; set; }
    }
}
